using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Xunit;

namespace mainumbi.Lakeli.Samples
{
    public class Job_Tests
    {
        Job _job { get; set; }
        Laborer _laborer { get; set; }

        [Fact]  
        public void Will_Create_A_New_Job()
        {
            Job job = new(Guid.NewGuid(), Guid.NewGuid());

            job.State.ShouldBe(JobState.Open);
        }

        [Fact]
        public void Will_Finish_Job()
        {
            JobWithLaborer();

            Rating rating = new(Guid.NewGuid(), Stars.Two, Stars.Five, Stars.Four, "Some Comment", _job);

            _job.RateJob(rating);

            rating.LaborerId.ShouldNotBe(Guid.Empty);
            _job.Rating.ShouldBe(rating);
        }

        [Fact]
        public void Will_Cancel_Job()
        {
            JobWithLaborer();
            _job.CancelJob();
            _job.State.ShouldBe(JobState.Canceled);
        }

        private void JobWithLaborer()
        {
            CreateJob();

            _laborer = new(Guid.NewGuid());
            _job.SetLabourer(_laborer);
        }

        private void CreateJob()
        {
            _job = new(Guid.NewGuid(), Guid.NewGuid());
        }
    }
}
