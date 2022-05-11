using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroAPI.Data
{
    public interface ISuperHeroRepo
    {
        Task<List<SuperHero>> GetAllSuperHeroes();
        Task<SuperHero> GetSuperHero(int Id);
        Task<List<SuperHero>> CreateSuperHero(SuperHero request);
        Task<SuperHero> UpdateSuperHero(SuperHero request);
        Task<List<SuperHero>> DeleteSuperHero(SuperHero request);
        Task<bool> SaveChanges();
    }
}
