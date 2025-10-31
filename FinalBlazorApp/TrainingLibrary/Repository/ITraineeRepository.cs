using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingLibrary.Models;

namespace TrainingLibrary.Repository
{
    public interface ITraineeRepository
    {
        Task AddTraineeAsync(Trainee trainee);
        Task UpdateTraineeAsync(int trainid, int eid, Trainee trainee);
        Task DeleteTraineeAsync(int trainid, int eid);
        Task<Trainee> GetTraineeAsync(int trainid, int eid);
        Task<List<Trainee>> GetAllTraineesAsync();
        Task<List<Trainee>> GetTraineesByStatusAsync(string status);
        Task<List<Trainee>> GetAllTrainingByTraineeAsync(int trainid);
        Task<List<Trainee>> GetAllTraineesByEmployeeAsync(int eid);
        Task InsertEmployeeAsync(Employee employee);
        
        
    }
}
