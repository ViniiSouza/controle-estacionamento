using AutoMapper;
using ControleEstacionamento.Application.DTOs;
using ControleEstacionamento.Domain.Entidades;

namespace ControleEstacionamento.Application.Mappers.Profiles
{
    public class RegistroProfile : Profile
    {
        public RegistroProfile()
        {
            CreateMap<Registro, RegistroDTO>()
                .ReverseMap();
        }
    }
}
