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
        HouseAdmin _admin { get; set; }
        Job _job { get; set; }
        Laborer _laborer { get; set; }

        [Fact]  
        public void House_Admin_Can_Post_New_Cleaning_Gob()
        {
            HouseAdmin admin = new(Guid.NewGuid());

            Job job = new(Guid.NewGuid(), admin);

            job.State.ShouldBe(JobState.Open);
            job.HouseAdmin.ShouldBe(admin);
        }

        [Fact]
        public void House_Admin_Can_Select_Laborer()
        {
            AdminWithJob();

            Laborer laborer = new(Guid.NewGuid());
            _admin.AssignLaborer(laborer, _job);
           
            _job.Laborer.ShouldBe(laborer);
            _job.State.ShouldBe(JobState.Assigned);
        }

        [Fact]
        public void House_Admin_Can_Finish_Job()
        {
            JobWithLaborer();

            Rating rating = new(Stars.Two, Stars.Five, Stars.Four, "Some Comment");
            _job.SetState(JobState.Assigned);


            _admin.FinishJob(_job, rating);

            _job.State.ShouldBe(JobState.Finished);
            rating.UserId.ShouldNotBe(Guid.Empty);
        }

        [Fact]
        public void House_Admin_Will_Get_Signees()
        {
            AdminWithJob();
            _laborer = new(Guid.NewGuid());
            _job.Apply(_laborer); 
            _job.Apply(new(Guid.NewGuid()));

            var ex = Assert.Throws<BusinessException>(() => _job.Apply(_laborer));

            ex.Code.ShouldBe(LakeliDomainErrorCodes.OneApplyPerJob);
            _job.Candidates.Count.ShouldBe(2);
            _admin.GetSignedInLabourers(_job).Count.ShouldBe(2);
        }

        [Fact]
        public void House_Admin_Will_Cancel_Job()
        {
            AdminWithJob();
            _laborer = new(Guid.NewGuid());
            _job.Apply(_laborer);
            _job.Apply(new(Guid.NewGuid()));

            _admin.CancelJob(_job);

            _job.Candidates.Count.ShouldBe(0);
            _job.State.ShouldBe(JobState.Canceled);
        }

        private void JobWithLaborer()
        {
            AdminWithJob();

            _laborer = new(Guid.NewGuid());
            _admin.AssignLaborer(_laborer, _job);
        }

        private void AdminWithJob()
        {
            _admin = new(Guid.NewGuid());

            _job = new(Guid.NewGuid(), _admin);
        }
    }
}
