using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mainumbi.Lakeli.Jobs
{
    public interface IJobAppService
    {
        Task<JobDto> Create(CreateJobInput input);
        Task<List<JobDto>> GetJobs(JobState? state = null);
        Task<JobDto> GetJob(Guid jobId);
        Task Delete(Guid jobId);
        Task<JobDto> Update(UpdateJobInput input);
    }
}
