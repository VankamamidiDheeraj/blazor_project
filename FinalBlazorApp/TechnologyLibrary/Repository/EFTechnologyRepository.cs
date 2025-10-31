using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyLibrary.Models;

namespace TechnologyLibrary.Repository
{
    public class EFTechnologyRepository:ITechnologyRepository
    {
        ZelisTechnologyDBContext ctx = new ZelisTechnologyDBContext();
        public async Task InsertTechnologyAsync(Technology technology)
        {
            try
            {
                ctx.Technologies.AddAsync(technology);
                await ctx.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new TechnologyException(ex.Message);
            }
        }

        public async Task UpdateTechnologyAsync(int techid, Technology technology)
        {
            Technology technology2up = await GetTechnologyAsync(techid);
            try
            {
                technology2up.TechnologyName = technology.TechnologyName;
                technology2up.Level = technology.Level;
                technology2up.Duration = technology.Duration;
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TechnologyException(ex.Message);
            }
        }
        public async Task DeleteTechnologyAsync(int techid)
        {
            Technology technology2del = await GetTechnologyAsync(techid);
            try
            {
                ctx.Technologies.Remove(technology2del);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TechnologyException(ex.Message);
            }

        }

        public async Task<List<Technology>> GetAllTechnologysAsync()
        {
            return await ctx.Technologies.ToListAsync();
        }

        public async Task<Technology> GetTechnologyAsync(int techid)
        {
            try
            {
                Technology technology = await (from t in ctx.Technologies
                                               where t.TechnologyId == techid
                                               select t).FirstAsync();
                return technology;


            }
            catch (Exception ex)
            {
                throw new TechnologyException("Technology not Found!");
            }
        }

        public async Task<List<Technology>> GetTechnologyByLevelAsync(string level)
        {
            try
            {
                List<Technology> technology = await (from t in ctx.Technologies where t.Level == level select t).ToListAsync();
                if (technology == null)
                {
                    throw new TechnologyException("No Technology found based on Status");
                }
                return technology;
            }
            catch (Exception ex)
            {
                throw new TechnologyException("Technology not Found!");
            }
        }

    }
}
