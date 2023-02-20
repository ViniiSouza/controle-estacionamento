using AutoMapper;
using ControleEstacionamento.Application.DTOs;
using ControleEstacionamento.Domain.Entidades;
using ControleEstacionamento.Domain.Interfaces.Repositories;
using ControleEstacionamento.Domain.Interfaces.Services;
using ControleEstacionamento.Infra.Data;

namespace ControleEstacionamento.Application.Services
{
    public class RegistroAppService : BaseAppService<Registro, RegistroDTO>, IRegistroAppService
    {
        private readonly ICarroRepository _carroRepository;
        private readonly IVigenciaPrecoRepository _vigenciaPreco;

        // Valor usado quando não há uma vigência na data informada
        const decimal ValorHoraPadrao = 2;

        public RegistroAppService(IUnitOfWork unitOfWork, IRegistroRepository repository, IMapper mapper, ICarroRepository carroRepository, IVigenciaPrecoRepository vigenciaPreco) : base(unitOfWork, repository, mapper)
        {
            _carroRepository = carroRepository;
            _vigenciaPreco = vigenciaPreco;
        }

        public override List<RegistroDTO> GetAll()
        {
            var entidades = _repository.GetAll().ToList();
            var dtos = _mapper.Map<List<RegistroDTO>>(entidades);
            return dtos;
        }

        public override RegistroDTO Create(RegistroDTO dto)
        {
            var entidade = _mapper.Map<Registro>(dto);
            var carro = _carroRepository.GetPorPlaca(entidade.Carro.Placa);
            var vigencia = _vigenciaPreco.GetPorData(entidade.HorarioEntrada);

            entidade.ValorHora = vigencia != null ? vigencia.ValorHora : ValorHoraPadrao;

            if (carro == null)
                entidade.Carro = new Carro(entidade.Carro.Placa);
            else
                entidade.CarroId = carro.Id;

            _repository.Create(entidade);
            _unitOfWork.Commit();

            return dto;
        }

        public override RegistroDTO Update(RegistroDTO dto)
        {
            var entidadeMapeada = _mapper.Map<Registro>(dto);
            var entidade = (_repository as IRegistroRepository).GetPorPlacaCarroSemHoraSaida(entidadeMapeada.Carro.Placa);
            entidade.HorarioSaida = entidadeMapeada.HorarioSaida;
            entidade.CalcularValorTotal();
            _repository.Update(entidade);
            _unitOfWork.Commit();
            return dto;
        }
    }
}
