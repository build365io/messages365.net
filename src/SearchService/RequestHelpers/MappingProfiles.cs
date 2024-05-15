using AutoMapper;
using Contracts;

namespace SearchService.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PostCreated, Item>();
        }
    }
}
