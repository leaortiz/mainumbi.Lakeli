using AutoMapper;
using mainumbi.Lakeli.Jobs;

namespace mainumbi.Lakeli;

public class LakeliApplicationAutoMapperProfile : Profile
{
    public LakeliApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Job, JobDto>();
        CreateMap<UpdateJobInput, Job>();
    }
}
