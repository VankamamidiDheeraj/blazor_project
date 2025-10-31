using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyLibrary.Models;

namespace TechnologyLibrary.Repository
{
    public interface ITechnologyRepository
    {
        Task InsertTechnologyAsync(Technology technology);
        Task UpdateTechnologyAsync(int techid, Technology technology);
        Task DeleteTechnologyAsync(int techid);
        Task<List<Technology>> GetAllTechnologysAsync();
        Task<Technology> GetTechnologyAsync(int techid);
        Task<List<Technology>> GetTechnologyByLevelAsync(string level);
    }
}
