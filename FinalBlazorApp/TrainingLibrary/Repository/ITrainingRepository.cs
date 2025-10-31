using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingLibrary.Models;

namespace TrainingLibrary.Repository
{
    public interface ITrainingRepository
    {
        Task InsertTrainingAsync(Training training);
        Task UpdateTrainingAsync(int trainid, Training training);
        Task DeleteTrainingAsync(int trainid);
        Task<List<Training>> GetAllTrainingsAsync();
        Task<Training> GetTrainingAsync(int trainid);
        Task<List<Training>> GetAllTrainingsByTrainerAsync(int trid);
        Task<List<Training>> GetAllTechnologysInTrainingAsync(int techid);
        Task InsertTrainerAsync(Trainer trainer);
        Task InsertTechnologyAsync(Technology technology);
    }
}
