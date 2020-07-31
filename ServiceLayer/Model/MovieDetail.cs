using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayer.Model
{
    public class MovieDetail
    {
        public MovieDetail()
        {
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int MovieDetailId { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public DateTime InsertedDate { get; set; }
        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }

    }
}
