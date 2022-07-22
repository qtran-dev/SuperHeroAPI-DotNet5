using AutoMapper;
using SuperHeroAPI.DTOs;
using SuperHeroAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroAPI.Profiles
{
    public class SuperHeroProfiles : Profile
    {
        public SuperHeroProfiles()
        {
            //Source -> Target
            CreateMap<SuperHero, SuperHeroReadDTO>()
                .ForMember(target => target.LegalName, option => option.MapFrom(source => $"{source.LegalFirstName} {source.LegalLastName}"))
                .ForMember(target => target.Jurisdiction, option => option.MapFrom(source => $"{source.JurisdictionCity}, {source.JurisdictionState}"));

            CreateMap<SuperHero, SuperHeroDTO>();
        }
    }
}
