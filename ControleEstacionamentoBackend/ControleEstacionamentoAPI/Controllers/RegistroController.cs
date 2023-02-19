using ControleEstacionamento.Application.DTOs;
using ControleEstacionamento.Domain.Entidades;
using ControleEstacionamento.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstacionamentoAPI.Controllers
{
    [ApiController]
    [Route("registro")]
    public class RegistroController : ControllerBase
    {
        private readonly IRegistroAppService _registroAppService;

        public RegistroController(IRegistroAppService registroAppService) 
        {
            _registroAppService = registroAppService;
        }

        [HttpGet]
        public List<RegistroDTO> GetAll()
        {
            return _registroAppService.GetAll();
        }

        [HttpGet("{id}")]
        public RegistroDTO GetById([FromRoute] int id)
        {
            return _registroAppService.GetById(id);
        }

        [HttpPost]
        public RegistroDTO Create([FromBody] RegistroDTO registroDTO)
        {
            return _registroAppService.Create(registroDTO);
        }

        [HttpPut]
        public RegistroDTO Update([FromBody] RegistroDTO registroDTO)
        {
            return _registroAppService.Update(registroDTO);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _registroAppService.Delete(id);
        }
    }
}
