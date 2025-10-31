using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingLibrary.Models;

namespace TrainingLibrary.Repository
{
    public class EFTrainingRepository:ITrainingRepository
    {
        ZelisTrainingDBContext ctx;
        public EFTrainingRepository() 
        {
            ctx = new ZelisTrainingDBContext(); 
        }
        public async Task InsertTrainingAsync(Training training)
        {
            try
            {
                await ctx.Trainings.AddAsync(training);
                await ctx.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new TrainingException(ex.Message);
            }
        }
        //Trainer
        public async Task InsertTrainerAsync(Trainer trainer)
        {
            try
            {
                await ctx.Trainers.AddAsync(trainer);
                await ctx.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new TrainingException(ex.Message);
            }

        }
        //Technology
        public async Task InsertTechnologyAsync(Technology technology)
        {
            try
            {
                await ctx.Technologies.AddAsync(technology);
                await ctx.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new TrainingException(ex.Message);
            }
        }

        public async Task UpdateTrainingAsync(int trainid, Training training)
        {
            try
            {
            Training training2up = await GetTrainingAsync(trainid);
                training2up.TrainerId = training.TrainerId;
                training2up.TechnologyId = training.TechnologyId;
                training2up.StartDate = training.StartDate;
                training2up.EndDate = training.EndDate;
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TrainingException(ex.Message);
            }
        }
        public async Task DeleteTrainingAsync(int trainid)
        {
            try
            {
            Training training2del = await GetTrainingAsync(trainid);
                ctx.Trainings.Remove(training2del);
                await ctx.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new TrainingException(ex.Message);

            }

        }

        public async Task<List<Training>> GetAllTrainingsAsync()
        {
            return await ctx.Trainings.ToListAsync();
        }
        public async Task<Training> GetTrainingAsync(int trainid)
        {
            try
            {
                Training training = await (from t in ctx.Trainings where t.TrainingId == trainid select t).FirstAsync();
                return training;
            }
            catch (Exception ex)
            {
                throw new TrainingException("Training not Found!");
            }
        }

        public async Task<List<Training>> GetAllTechnologysInTrainingAsync(int techid)
        {
            
                List<Training> trainings = await (from c in ctx.Trainings where c.TechnologyId == techid select c).ToListAsync();
                if (trainings.Count == 0)
                    throw new TrainingException("No technology found ");
                else
                    return trainings;
        }
        public async Task<List<Training>> GetAllTrainingsByTrainerAsync(int trid)
        {
            List<Training> trainings = await (from c in ctx.Trainings where c.TrainerId == trid select c).ToListAsync();
            if (trainings.Count == 0)
                throw new TrainingException("No trainer found ");
            else
                return trainings;
        }
    }
}
   
