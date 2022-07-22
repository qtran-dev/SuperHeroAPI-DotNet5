using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.DTOs;
using SuperHeroAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroRepo _repo;
        public IMapper _mapper { get; }


        public SuperHeroController(ISuperHeroRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHeroReadDTO>>> GetAll()
        { 
            var heroes = await _repo.GetAllSuperHeroes(); 

            return _mapper.Map<List<SuperHeroReadDTO>>(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHeroReadDTO>> Get(int id)
        {
            var hero = await _repo.GetSuperHero(id);
            
            if (hero == null)
            {
                return NotFound("Hero Not Found");
            }
            else
            {
                var rtn = _mapper.Map<SuperHeroReadDTO>(hero);
                return rtn;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHeroDTO>> GetPrivileged(int id)
        {
            var hero = await _repo.GetSuperHero(id);

            if (hero == null)
            {
                return NotFound("Hero Not Found");
            }
            else
            {
                return _mapper.Map<SuperHeroDTO>(hero);
            }
        }

        [HttpPut]
        public async Task<ActionResult<SuperHeroReadDTO>> Update(SuperHero request)
        {
            var hero = await _repo.GetSuperHero(request.Id);

            if (hero != null)
            {
                var updatedHero = await _repo.UpdateSuperHero(request);

                return _mapper.Map<SuperHeroReadDTO>(updatedHero);
            }
            else
            {
                return BadRequest("Hero not found");
            }

        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHeroReadDTO>>> Create(SuperHero request)
        {
            var heroes = await _repo.CreateSuperHero(request);

            return _mapper.Map<List<SuperHeroReadDTO>>(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHeroReadDTO>>> Delete(int id)
        {
            var hero = await _repo.GetSuperHero(id);

            if (hero != null)
            {
                var heroes = await _repo.DeleteSuperHero(hero);
                return _mapper.Map<List<SuperHeroReadDTO>>(heroes);
            }
            {
                return BadRequest("Hero not found");
            }
        }


    }
}
