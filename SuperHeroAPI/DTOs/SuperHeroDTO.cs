using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroAPI.DTOs
{
    public class SuperHeroDTO
    {
        public int Id { get; set; }

        public string SuperHeroName { get; set; }

        public string LegalFirstName { get; set; }

        public string LegalLastName { get; set; }

        public string JurisdictionCity { get; set; }

        public string JurisdictionState { get; set; }
    }
}
