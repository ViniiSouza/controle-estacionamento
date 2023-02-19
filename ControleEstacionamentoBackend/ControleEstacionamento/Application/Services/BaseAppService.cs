﻿using AutoMapper;
using ControleEstacionamento.Domain.Entidades;
using ControleEstacionamento.Domain.Interfaces.Repositories;
using ControleEstacionamento.Domain.Interfaces.Services;
using ControleEstacionamento.Infra.Data;

namespace ControleEstacionamento.Application.Services
{
    public class BaseAppService<TEntity, TDto> : IBaseAppService<TEntity, TDto> where TEntity : EntidadeBase where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseAppService(IUnitOfWork unitOfWork, IRepository<TEntity> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public List<TDto> GetAll()
        {
            var entities = _repository.GetAll().ToList();
            return _mapper.Map<List<TDto>>(entities);
        }

        public TDto GetById(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                throw new NullReferenceException("Entidade não encontrada");
            }
            return _mapper.Map<TDto>(entity);
        }

        public TDto Create(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _repository.Create(entity);
            _unitOfWork.Commit();
            // trabalhar os dados?
            return dto;
        }

        public TDto Update(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _repository.Update(entity);
            _unitOfWork.Commit();
            // trabalhar os dados?
            return dto;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _unitOfWork.Commit();
        }
    }
}
