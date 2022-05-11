using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<List<SuperHero>>> GetAll()
        {
            var heroes = await _repo.GetAllSuperHeroes();

            return Ok(_mapper.Map<List<SuperHeroReadDTO>>(heroes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await _repo.GetSuperHero(id);
            
            if (hero == null)
            {
                return BadRequest("Hero not found");
            }
            else
            {
                return Ok(_mapper.Map<SuperHeroReadDTO>(hero));
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> Update(SuperHero request)
        {
            var hero = await _repo.GetSuperHero(request.Id);

            if (hero != null)
            {
                var updatedHero = await _repo.UpdateSuperHero(request);

                return Ok(_mapper.Map<SuperHeroReadDTO>(updatedHero));
            }
            else
            {
                return BadRequest("Hero not found");
            }

        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> Create(SuperHero request)
        {
            var heroes = await _repo.CreateSuperHero(request);

            return Ok(_mapper.Map<List<SuperHeroReadDTO>>(heroes));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = await _repo.GetSuperHero(id);

            if (hero != null)
            {
                var heroes = await _repo.DeleteSuperHero(hero);
                return Ok(_mapper.Map<List<SuperHeroReadDTO>>(heroes));
            }
            {
                return BadRequest("Hero not found");
            }
        }


    }
}
