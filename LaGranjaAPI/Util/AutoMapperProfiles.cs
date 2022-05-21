using AutoMapper;
using LaGranjaAPI.DTOs;
using LaGranjaAPI.Entities;
using Microsoft.AspNetCore.Identity;

namespace LaGranjaAPI.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Alimentacion, AlimentacionDTO>().ReverseMap();
            CreateMap<AlimentacionCreacionDTO, Alimentacion>().ReverseMap();
            //CreateMap<IdentityUser, UsuarioDTO>();
        }
    }
}
