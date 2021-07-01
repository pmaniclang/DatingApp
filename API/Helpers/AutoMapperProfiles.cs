using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        //AutoMapper allows to map one object to another
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, 
                           opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x=> x.IsMain).Url)) //this will map to PhotoUrl from Users.Photos.IsMain
                .ForMember(dest => dest.Age, 
                           opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()))   ;       
            CreateMap<Photo, PhotoDto>();
        }
    }
}