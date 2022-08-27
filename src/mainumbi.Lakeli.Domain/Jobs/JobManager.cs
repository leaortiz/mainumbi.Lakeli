using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace mainumbi.Lakeli.HouseAdmins
{
    public class JobManager : DomainService, IJobManager
    {
        private readonly IRepository<Job> _jobRepo;

        public JobManager(IRepository<Job> jobRepo)
        {
            _jobRepo = jobRepo;
        }

        public async Task<List<Job>> GetJobsAsync(JobState? state = null)
        {
            var query = await _jobRepo.GetQueryableAsync();

            if(state != null)
                query = query.Where(x => x.State == state);

            return query.Where(j => j.State == JobState.Open).ToList();
        }

        public Task<Job> CreateAsync(Guid newId, Customer customer, string comment, string contactNumber, string adress)
        {
            Job job = new(newId, customer);
            job.SetComment(comment)
               .SetContactNumber(contactNumber) 
               .SetAdress(adress);

            return Task.FromResult(job);
        }
    }
}
