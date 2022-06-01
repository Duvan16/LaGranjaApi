using AutoMapper;
using LaGranjaAPI.DTOs;
using LaGranjaAPI.Entities;
using LaGranjaAPI.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaGranjaAPI.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class ClientesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        [HttpGet("todos")]
        [AllowAnonymous]
        public async Task<ActionResult<List<ClienteDTO>>> Todos()
        {
            var Cliente = await _clienteRepository.Get();
            return _mapper.Map<List<ClienteDTO>>(Cliente);
        }


        [HttpGet]
        public async Task<ActionResult<List<ClienteDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = await _clienteRepository.Get();
            return _mapper.Map<List<ClienteDTO>>(queryable);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<ClienteDTO>> Get(int Id)
        {
            var Cliente = await _clienteRepository.GetById(Id);

            if (Cliente == null)
            {
                return NotFound();
            }

            return _mapper.Map<ClienteDTO>(Cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteCreacionDTO ClienteCreacionDTO)
        {
            var Cliente = _mapper.Map<Cliente>(ClienteCreacionDTO);
            await _clienteRepository.Create(Cliente);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int Id, [FromBody] ClienteCreacionDTO ClienteCreacionDTO)
        {
            var Cliente = await _clienteRepository.GetById(Id);

            if (Cliente == null)
            {
                return NotFound();
            }

            Cliente = _mapper.Map(ClienteCreacionDTO, Cliente);

            await _clienteRepository.Update(Cliente);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Cliente = await _clienteRepository.GetById(id);

            if (Cliente == null)
            {
                return NotFound();
            }

            await _clienteRepository.Delete(Cliente);
            return NoContent();
        }
    }
}
