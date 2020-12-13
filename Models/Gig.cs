using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class Gig
    {
        public int Id { get; set; }

        [Required] public IdentityUser Artist { get; set; }

        public DateTime DateTime { get; set; }

        [Required] [StringLength(255)] public string Venue { get; set; }

        [Required] public Genre Genre { get; set; }
    }
}