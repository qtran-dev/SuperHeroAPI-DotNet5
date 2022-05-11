using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroAPI
{
    public class SuperHero
    {
        public int Id { get; set; }

        [Required]
        public string SuperHeroName { get; set; }

        [Required]
        public string LegalFirstName { get; set; }

        [Required]
        public string LegalLastName { get; set; }

        [Required]
        public string JurisdictionCity { get; set; }

        [Required]
        public string JurisdictionState { get; set; }

    }
}
