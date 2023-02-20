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
                .ForMember(dest => dest.PlacaCarro, opt => opt.MapFrom(src => src.Carro.Placa))
                .ForMember(dest => dest.Duracao, opt => opt.MapFrom(src => (src.HorarioSaida - src.HorarioEntrada).ToString()))
                .ForMember(dest => dest.TempoCobrado, opt => opt.MapFrom(src => GetTempoCobrado(src.ValorHora, src.ValorTotal)))
                .ForMember(dest => dest.ValorHora, opt => opt.MapFrom(src => src.ValorHora.ToString("0.00")))
                .ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(src => src.ValorTotal.HasValue ? src.ValorTotal.Value.ToString("0.00") : ""))
                .ReverseMap()
                .ForPath(dest => dest.Carro.Placa, opt => opt.MapFrom(src => src.PlacaCarro.Replace("-", "").ToUpper()));
        }

        public static string GetTempoCobrado(decimal valorHora, decimal? valorTotal)
        {
            if (!valorTotal.HasValue)
                return "";
            return (valorTotal / valorHora).ToString();
        }
    }
}
