using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroAPI.DTOs
{
    public class SuperHeroReadDTO
    {
        public string SuperHeroName { get; set; }
        public string LegalName { get; set; }
        public string Jurisdiction { get; set; }
    }
}
