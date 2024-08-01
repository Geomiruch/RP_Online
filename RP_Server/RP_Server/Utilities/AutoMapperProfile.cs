using AutoMapper;
using RP_Server.DTO;
using RP_Server.Models.Entities;
using RP_Server.Requests.CreateRequsts;

namespace RP_Server.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CharacterCreateRequeest, Character>();
            CreateMap<HumanoidCharacterCreateRequest, HumanoidCharacter>();
            CreateMap<PlayerCharacterCreateRequest, PlayerCharacter>();
            CreateMap<GroupCreateRequest, Group>();
            CreateMap<LocationCreateRequest, Location>();
            CreateMap<ActivityCreateRequest, Activity>();

            CreateMap<Character, CharacterDto>()
                .ForMember(dest => dest.CharacterType, opt => opt.MapFrom(src => src.GetType().Name))
                .ReverseMap();
            CreateMap<Character, HumanoidCharacterDto>()
                .ForMember(dest => dest.CharacterType, opt => opt.MapFrom(src => src.GetType().Name))
                .ReverseMap();
            CreateMap<Character, PlayerCharacterDto>()
                .ForMember(dest => dest.CharacterType, opt => opt.MapFrom(src => src.GetType().Name))
                .ReverseMap();

            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Activity, ActivityDto>().ReverseMap();
        }
    }
}
