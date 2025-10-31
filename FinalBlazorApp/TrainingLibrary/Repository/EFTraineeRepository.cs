using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingLibrary.Models;

namespace TrainingLibrary.Repository
{
    public class EFTraineeRepository : ITraineeRepository
    {
        ZelisTrainingDBContext ctx;
        public EFTraineeRepository()
        {
            ctx = new ZelisTrainingDBContext();
        }
        public async Task AddTraineeAsync(Trainee trainee)
        {
            try
            {
                await ctx.Trainees.AddAsync(trainee);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TrainingException(ex.Message);
            }
        }
        //Employee
        public async Task InsertEmployeeAsync(Employee employee)
        {
            try
            {
                await ctx.Employees.AddAsync(employee);
                await ctx.SaveChangesAsync();
            }
            catch (TrainingException ex)
            {
                throw new TrainingException(ex.Message);
            }
        }
       

        public async Task UpdateTraineeAsync(int trainid, int eid, Trainee trainee)
        {
            try
            {
            Trainee trainee1 = await GetTraineeAsync(trainid, eid);
                trainee1.Status = trainee.Status;
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TrainingException(ex.Message);
            }
        }

        public async Task DeleteTraineeAsync(int trainid, int eid)
        {
            Trainee training = await GetTraineeAsync(trainid, eid);
            try
            {
                ctx.Trainees.Remove(training);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TrainingException(ex.Message);
            }

        }

        public async Task<List<Trainee>> GetAllTraineesAsync()
        {
            return await ctx.Trainees.ToListAsync();
        }


        public async Task<Trainee> GetTraineeAsync(int trainid, int eid)
        {
            try
            {
               Trainee trainee=await (from t in ctx.Trainees where t.TrainingId==trainid&& t.EmpId==eid select t).FirstAsync();
                return trainee;
            }
            catch (Exception ex)
            {
                throw new TrainingException("No trainee with given id");
            }
        }
        public async Task<List<Trainee>> GetTraineesByStatusAsync(string status)
        {
            
                List<Trainee> trainees = await (from c in ctx.Trainees where c.Status == status select c).ToListAsync();
            if (trainees.Count == 0)
                throw new TrainingException("No Trainee found based on Status");
            else
                return trainees;
        }
        public async Task<List<Trainee>> GetAllTraineesByEmployeeAsync(int eid)
        {
            
                List<Trainee> trainees = await (from c in ctx.Trainees where c.EmpId == eid select c).ToListAsync();
                if (trainees.Count == 0)
                    throw new TrainingException("No Employee found"); 
                else
                return trainees;
        }

        public async Task<List<Trainee>> GetAllTrainingByTraineeAsync(int trainid)
        {
                List<Trainee> trainees = await (from c in ctx.Trainees where c.TrainingId == trainid select c).ToListAsync();
                if (trainees.Count == 0)
                    throw new TrainingException("No Training found");
                else
                return trainees;
        }
    }
}
