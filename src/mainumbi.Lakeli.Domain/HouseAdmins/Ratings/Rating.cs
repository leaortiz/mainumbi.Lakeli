using System;
using System.Collections.Generic;
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
        public Guid UserId { get; internal set; }
        
        public string Comment { get; set; }

        protected Rating()
        {
        }

        public Rating(Stars speed, Stars cleaning, Stars Puntuality, string comment)
        {
            Speed = speed;
            Cleaning = cleaning;
            Comment = comment ?? throw new ArgumentNullException(nameof(comment));
        }

        internal Rating SetUserId(Guid userId)
        {
            UserId = userId;
            return this;
        }
    }
}
