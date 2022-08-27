using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace mainumbi.Lakeli
{
    public class Job : AggregateRoot<Guid>
    {
        [Required]
        public JobState State { get; protected set; }
        [MaxLength(500)]
        public string Comment { get; protected set; }
        [MaxLength(20)]
        public string ContactNumber { get; protected set; }
        [MaxLength(100)]
        public string Adress { get; protected set; }
        public Laborer Laborer { get; protected set; }
        public Guid UserId { get; protected set; }
        public Rating Rating { get; protected set; }

        internal void SetRating(Rating rating)
        {
            Rating = rating;
        }
        internal Job SetContactNumber(string contactNumber)
        {
            ContactNumber = contactNumber;
            return this;
        }

        internal Job SetAdress(string adress)
        {
            Adress = adress;
            return this;
        }

        internal Job SetComment(string comment)
        {
            Comment = comment;
            return this;
        }

        protected Job()
        {

        }
        public Job(Guid id, Guid userId)
        {
            Id = id;
            State = JobState.Open;
            UserId = userId;
        }

        public Job SetState(JobState newState)
        {
            State = newState;
            return this;
        }

        public Job ClearLabourer()
        {
            Laborer = null;

            return this;
        }
        public Job SetLabourer(Laborer laborer)
        {
            Laborer = laborer ?? throw new ArgumentNullException(nameof(laborer));

            return this;
        }

        internal Job RateJob(Rating rating)
        {
            SetRating(rating);
            return this;
        }

        internal Job CancelJob()
        {
            SetState(JobState.Canceled);
            SetLabourer(null);

            return this;
        }

    }
}
