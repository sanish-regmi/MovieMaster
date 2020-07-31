using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayer.Model
{
    public class Movie
    {
        public Movie()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int MovieId { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Rating { get; set; }
        public DateTime InsertedDate { get; set; }
        public virtual ICollection<MovieDetail> MovieDetails { get; set; }

    }
}
