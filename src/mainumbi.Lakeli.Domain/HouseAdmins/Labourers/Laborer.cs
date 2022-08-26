using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace mainumbi.Lakeli
{
    public class Laborer : Entity<Guid>
    {
        public List<Rating> Ratings { get; set; }
        protected Laborer()
        {

        }

        public Laborer(Guid id)
        {
            Id = id;
            Ratings = new();
        }

        internal void AddRating(Rating rating)
        {
            Ratings.Add(rating);
        }
    }
}
