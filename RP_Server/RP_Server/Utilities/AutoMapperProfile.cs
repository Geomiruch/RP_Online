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
        }
    }
}
