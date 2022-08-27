using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace mainumbi.Lakeli
{
    public class Customer : Entity<Guid>
    {
        public Guid UserId { get; set; }

        protected Customer()
        {

        }

        public Customer(Guid id)
        {
            Id = id;
            UserId = id;
        }

        internal Customer RateJob(Job job, Rating rating)
        {
            job.SetRating(rating);
            return this;
        }

        internal Customer CancelJob(Job job)
        {
            job.SetState(JobState.Canceled);
            job.SetLabourer(null);

            return this;
        }
    }
}
