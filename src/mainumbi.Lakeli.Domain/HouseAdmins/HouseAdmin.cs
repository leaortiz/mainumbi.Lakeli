using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace mainumbi.Lakeli
{
    public class HouseAdmin : AggregateRoot<Guid>
    {
        protected HouseAdmin()
        {

        }

        public HouseAdmin(Guid id)
        {
            Id = id;         
        }

        internal void AssignLaborer(Laborer laborer, Job job)
        {

            job.SetLabourer(laborer)
               .SetState(JobState.Assigned);
        }

        internal void FinishJob(Job job, Rating rating)
        {
            if (job.State != JobState.Assigned)
                throw new BusinessException(LakeliDomainErrorCodes.JobMustBeAssigned);

            rating.SetUserId(job.Laborer.Id);

            job.SetState(JobState.Finished)
               .Laborer.AddRating(rating);
        }

        internal List<Laborer> GetSignedInLabourers(Job job)
        {
            if (job == null) throw new ArgumentNullException(nameof(job));

            return job.Candidates.ToList();
        }

        internal void CancelJob(Job job)
        {
            job.SetState(JobState.Canceled);
            job.Laborer = null;
            job.Candidates = new();
        }
    }
}
