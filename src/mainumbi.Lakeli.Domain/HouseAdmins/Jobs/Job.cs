using System;
using System.Collections.Generic;
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
        public JobState State { get; internal set; }
        public Laborer Laborer { get; internal set; }
        public List<Laborer> Candidates { get; internal set; }
        public HouseAdmin HouseAdmin { get; internal set; }
        protected Job()
        {

        }
        public Job(Guid id, HouseAdmin houseAdmin)
        {
            Id = id;
            State = JobState.Open;
            Candidates = new();
            HouseAdmin = houseAdmin;
        }

        public Job SetState(JobState newState)
        {
            State = newState;
            return this;
        }

        public Job SetLabourer(Laborer laborer)
        {
            Laborer = laborer ?? throw new ArgumentNullException(nameof(laborer));

            return this;
        }

        internal void Apply(Laborer laborer)
        {
            if (Candidates.Any(c => c.Id == laborer.Id))
                throw new BusinessException(LakeliDomainErrorCodes.OneApplyPerJob);
            Candidates.Add(laborer);
        }
    }
}
