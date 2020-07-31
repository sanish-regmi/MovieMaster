using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceLayer.Model
{
    public class ActorType
    {
        public ActorType()
        {
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ActorTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
    }
}
