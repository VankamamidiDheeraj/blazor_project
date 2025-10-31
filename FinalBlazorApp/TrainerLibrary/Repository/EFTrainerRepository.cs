using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainerLibrary.Models;

namespace TrainerLibrary.Repository
{
    public class EFTrainerRepository:ITrainerRepository
    {
        ZelisTrainerDBContext ctx = new ZelisTrainerDBContext();
        public async Task InsertTrainerAsync(Trainer trainer)
        {
            try
            {
                ctx.Trainers.AddAsync(trainer);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TrainerException(ex.Message);
            }
        }

        public async Task UpdateTrainerAsync(int trid, Trainer trainer)
        {
            Trainer trainer2up = await GetTrainerAsync(trid);
            try
            {
                trainer2up.TrainerName = trainer.TrainerName;
                trainer2up.Type = trainer.Type;
                trainer2up.Email = trainer.Email;
                trainer2up.Phone = trainer.Phone;
                await ctx.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new TrainerException(ex.Message);
            }
        }
        public async Task DeleteTrainerAsync(int trid)
        {
            Trainer trainer2del = await GetTrainerAsync(trid);
            try
            {
                ctx.Trainers.Remove(trainer2del);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TrainerException(ex.Message);
            }
        }

        public async Task<List<Trainer>> GetAllTrainersAsync()
        {
            return await ctx.Trainers.ToListAsync();

        }

        public async Task<Trainer> GetTrainerAsync(int trid)
        {
            try
            {
                Trainer trainer = await (from t in ctx.Trainers where t.TrainerId == trid select t).FirstAsync();
                return trainer;

            }
            catch (Exception ex)
            {
                throw new TrainerException("Trainer Not Found!");
            }

        }

        public async Task<List<Trainer>> GetTrainerByTypeAsync(string type)
        {
            try
            {
                List<Trainer> trainer = await (from t in ctx.Trainers where t.Type == type select t).ToListAsync();
                if (trainer == null)
                {
                    throw new TrainerException("No Trainer found based on Status");

                }
                return trainer;
            }
            catch (Exception ex)
            {
                throw new TrainerException("Trainer Not Found!");

            }
        }
    }
}
