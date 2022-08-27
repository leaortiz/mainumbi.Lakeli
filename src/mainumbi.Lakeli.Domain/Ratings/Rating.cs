using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace mainumbi.Lakeli
{
    public class Rating : Entity<Guid>
    {
        public Stars Speed { get; internal set; }
        public Stars Cleaning { get; internal set; }
        public Stars Puntuality { get; internal set; }
        public Guid LaborerId { get; internal set; }
        public Guid JobId { get; internal set; }
        public Guid HouseAdminId { get; internal set; }

        [MaxLength(500)]
        public string Comment { get; set; }

        protected Rating()
        {
        }

        public Rating(Guid id, Stars speed, Stars cleaning, Stars puntuality, string comment, Job job)
        {
            Id = id;
            Speed = speed;
            Cleaning = cleaning;
            Puntuality = puntuality;
            Comment = comment ?? throw new ArgumentNullException(nameof(comment));
            LaborerId = job.Laborer.Id;
            JobId = job.Id;
            HouseAdminId = job.UserId;
        }
    }
}
