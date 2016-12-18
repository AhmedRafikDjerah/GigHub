using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Artist { get; set; }

        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(100)]
        public string Venue { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public byte GenreId { get; set; }


    }
}