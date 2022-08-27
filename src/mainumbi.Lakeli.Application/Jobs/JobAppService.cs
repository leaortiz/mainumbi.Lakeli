using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
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

        public async Task<JobDto> Create([FromBody] CreateJobInput input)
        {
            var job = await _jobManager
                                 .CreateAsync(GuidGenerator.Create(),
                                                GuidGenerator.Create(),
                                                input.Comment,
                                                input.ContactNumber,
                                                input.Adress);
            job = await _jobRepo.InsertAsync(job);
            return ObjectMapper.Map<Job, JobDto>(job);
        }

        public async Task Delete([FromQuery] Guid jobId)
        {
            var job = await _jobRepo.FindAsync(j => j.Id == jobId);
            await _jobRepo.DeleteAsync(job);
        }

        public async Task<List<JobDto>> GetJobs([FromQuery] JobState? state = null)
        {
            
            var jobs = await _jobManager.GetJobsAsync(state);
            return ObjectMapper.Map<List<Job>, List<JobDto>>(jobs);
        }

        public async Task<JobDto> GetJob([FromQuery] Guid jobId)
        {
            var job = await _jobRepo.FindAsync(j => j.Id == jobId);
            return ObjectMapper.Map<Job, JobDto>(job);
        }

        public async Task<JobDto> Update([FromBody] UpdateJobInput input)
        {
            var job = await _jobRepo.FindAsync(j => j.Id == input.JobId);
            if (job != null)
            {
                job = ObjectMapper.Map(input, job);
                await _jobRepo.UpdateAsync(job);
                return ObjectMapper.Map<Job, JobDto>(job); ;
            }

            throw new BusinessException(LakeliDomainErrorCodes.JobNotFound);
        }
    }
}
