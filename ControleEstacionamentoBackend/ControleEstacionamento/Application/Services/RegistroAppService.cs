using AutoMapper;
using ControleEstacionamento.Application.DTOs;
using ControleEstacionamento.Domain.Entidades;
using ControleEstacionamento.Domain.Interfaces.Repositories;
using ControleEstacionamento.Domain.Interfaces.Services;
using ControleEstacionamento.Infra.Data;

namespace ControleEstacionamento.Application.Services
{
    public class RegistroAppService : BaseAppService<Registro, RegistroDTO>, IBaseAppService<Registro, RegistroDTO>
    {
        private readonly ICarroRepository _carroRepository;

        public RegistroAppService(IUnitOfWork unitOfWork, IRepository<Registro> repository, IMapper mapper, ICarroRepository carroRepository) : base(unitOfWork, repository, mapper)
        {
            _carroRepository = carroRepository;
        }

        public override RegistroDTO Create(RegistroDTO dto)
        {
            var entidade = _mapper.Map<Registro>(dto);
            var carro = _carroRepository.GetPorPlaca(dto.PlacaCarro);

            if (carro == null)
                entidade.Carro = new Carro(dto.PlacaCarro);
            else
                entidade.CarroId = carro.Id;

            _repository.Create(entidade);
            _unitOfWork.Commit();

            return dto;
        }
    }
}
