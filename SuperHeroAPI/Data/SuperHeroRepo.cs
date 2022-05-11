using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroAPI.Data
{
    public class SuperHeroRepo : ISuperHeroRepo
    {
        private readonly DataContext _db;

        public SuperHeroRepo(DataContext db)
        {
            _db = db;
        }

        public async Task<List<SuperHero>> GetAllSuperHeroes()
        {
            return await _db.SuperHeros.ToListAsync();
        }

        public async Task<SuperHero> GetSuperHero(int id)
        {
            return await _db.SuperHeros.FindAsync(id);
        }

        public async Task<SuperHero> UpdateSuperHero(SuperHero request)
        {
            var hero = await _db.SuperHeros.FindAsync(request.Id);

            if (hero != null)
            {
                hero.SuperHeroName = request.SuperHeroName;
                hero.LegalFirstName = request.LegalFirstName;
                hero.LegalLastName = request.LegalLastName;
                hero.JurisdictionCity = request.JurisdictionCity;
                hero.JurisdictionState = request.JurisdictionState;

                await SaveChanges();

                return hero;
            }
            else
            {
                return hero;
            }
        }

        public async Task<List<SuperHero>> CreateSuperHero(SuperHero request)
        {
            await _db.SuperHeros.AddAsync(request);

            return await _db.SuperHeros.ToListAsync();
        }

        public async Task<List<SuperHero>> DeleteSuperHero(SuperHero hero)
        {
            _db.SuperHeros.Remove(hero);
            await SaveChanges();

            return await _db.SuperHeros.ToListAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return await _db.SaveChangesAsync() >= 0;
        }

    }
}
