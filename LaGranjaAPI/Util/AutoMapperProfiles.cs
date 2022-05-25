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

            CreateMap<Raza, RazaDTO>().ReverseMap();
            CreateMap<RazaCreacionDTO, Raza>().ReverseMap();

            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<ClienteCreacionDTO, Cliente>().ReverseMap();
            //CreateMap<IdentityUser, UsuarioDTO>();
        }
    }
}
