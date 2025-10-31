using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainerLibrary.Models;

namespace TrainerLibrary.Repository
{
    public interface ITrainerRepository
    {
        Task InsertTrainerAsync(Trainer trainer);
        Task UpdateTrainerAsync(int trid, Trainer trainer);
        Task DeleteTrainerAsync(int trid);
        Task<List<Trainer>> GetAllTrainersAsync();
        Task<Trainer> GetTrainerAsync(int trid);
        Task<List<Trainer>> GetTrainerByTypeAsync(string type);
    }
}
