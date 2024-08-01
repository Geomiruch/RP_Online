using AutoMapper;
using RP_Server.DTO;
using RP_Server.Models.Entities;

namespace RP_Server.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, CharacterDto>().ReverseMap();
            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Activity, ActivityDto>().ReverseMap();
        }
    }
}
