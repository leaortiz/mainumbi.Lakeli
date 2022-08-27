using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace mainumbi.Lakeli
{
    public class Laborer : Entity<Guid>
    {
        [MaxLength(20)]
        public string FirstName { get; internal set; }
        [MaxLength(20)]
        public string LastName { get; internal set; }
        [MaxLength(50)]
        public string PhoneNumber { get; internal set; }
        public List<Rating> Ratings { get; internal set; }
        protected Laborer()
        {

        }

        public Laborer(Guid id)
        {
            Id = id;
            Ratings = new();
        }

    }
}
