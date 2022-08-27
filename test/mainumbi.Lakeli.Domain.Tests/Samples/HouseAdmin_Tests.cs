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
    public class HouseAdmin_Tests
    {
        Customer _admin { get; set; }
        Job _job { get; set; }
        Laborer _laborer { get; set; }

        [Fact]  
        public void House_Admin_Can_Post_New_Cleaning_Job()
        {
            Customer admin = new(Guid.NewGuid());

            Job job = new(Guid.NewGuid(), admin);

            job.State.ShouldBe(JobState.Open);
            job.HouseAdminId.ShouldBe(admin.Id);
        }

        [Fact]
        public void House_Admin_Can_Finish_Job()
        {
            JobWithLaborer();

            Rating rating = new(Guid.NewGuid(), Stars.Two, Stars.Five, Stars.Four, "Some Comment", _job);

            _admin.RateJob(_job, rating);

            rating.LaborerId.ShouldNotBe(Guid.Empty);
            _job.Rating.ShouldBe(rating);
        }

        [Fact]
        public void House_Admin_Will_Cancel_Job()
        {
            AdminWithJob();

            _admin.CancelJob(_job);

            _job.State.ShouldBe(JobState.Canceled);
        }

        private void JobWithLaborer()
        {
            AdminWithJob();

            _laborer = new(Guid.NewGuid());
            _job.SetLabourer(_laborer);
        }

        private void AdminWithJob()
        {
            _admin = new(Guid.NewGuid());

            _job = new(Guid.NewGuid(), _admin);
        }
    }
}
