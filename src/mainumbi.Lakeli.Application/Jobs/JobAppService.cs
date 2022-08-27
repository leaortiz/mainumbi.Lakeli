using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace mainumbi.Lakeli.Jobs
{
    public class JobAppService : LakeliAppService, IJobAppService
    {
        private readonly IRepository<Job> _jobRepo;
        private readonly IJobManager _jobManager;

        public JobAppService(IRepository<Job> jobRepo, IJobManager jobManager)
        {
            _jobRepo = jobRepo;
            _jobManager = jobManager;
        }

        public async Task<JobDto> Create([FromBody]CreateJobInput input)
        {
           Customer customer = new(GuidGenerator.Create());
           var job = await _jobManager
                                .CreateAsync(GuidGenerator.Create(),
                                               customer, 
                                               input.Comment, 
                                               input.ContactNumber, 
                                               input.Adress);
            job = await _jobRepo.InsertAsync(job);
            return ObjectMapper.Map<Job, JobDto>(job);
        }

        public Task Delete(Guid jobId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JobDto>> GetJobs([FromQuery]JobState? state = null)
        {
            var jobs = await _jobManager.GetJobsAsync(state);
            return ObjectMapper.Map<List<Job>, List<JobDto>>(jobs);
        }

        public Task<JobDto> GetJob(Guid jobId)
        {
            throw new NotImplementedException();
        }

        public Task<JobDto> Update(UpdateJobInput input)
        {
            throw new NotImplementedException();
        }
    }
}
