using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Demo.Helper;

namespace WebAPI_Demo.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Entities.Author, Models.AuthorDto>()
                .ForMember(
                   des => des.Name,
                   opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
                   )
                .ForMember(
                des => des.Age,
                opt => opt.MapFrom(src => $"{src.DateOfBirth.GetCurrentAge()}")
                );

            CreateMap<Models.CreateAuthorDto, Entities.Author>();
            CreateMap<Models.UpdateAuthorDto, Entities.Author>();
        }
    }
}
