using AutoMapper;
using LaGranjaAPI.Entities;
using LaGranjaAPI.DTOs;
using LaGranjaAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaGranjaAPI.Controllers
{
    [Route("api/razas")]
    [ApiController]
    public class RazasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRazaRepository _razaRepository;

        public RazasController(IMapper mapper, IRazaRepository razaRepository)
        {
            _mapper = mapper;
            _razaRepository = razaRepository;
        }

        [HttpGet("todos")]
        [AllowAnonymous]
        public async Task<ActionResult<List<RazaDTO>>> Todos()
        {
            var Raza = await _razaRepository.Get();
            return _mapper.Map<List<RazaDTO>>(Raza);
        }


        [HttpGet]
        public async Task<ActionResult<List<RazaDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = await _razaRepository.Get();
            return _mapper.Map<List<RazaDTO>>(queryable);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<RazaDTO>> Get(int Id)
        {
            var Raza = await _razaRepository.GetById(Id);

            if (Raza == null)
            {
                return NotFound();
            }

            return _mapper.Map<RazaDTO>(Raza);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RazaCreacionDTO RazaCreacionDTO)
        {
            var Raza = _mapper.Map<Raza>(RazaCreacionDTO);
            await _razaRepository.Create(Raza);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int Id, [FromBody] RazaCreacionDTO RazaCreacionDTO)
        {
            var Raza = await _razaRepository.GetById(Id);

            if (Raza == null)
            {
                return NotFound();
            }

            Raza = _mapper.Map(RazaCreacionDTO, Raza);

            await _razaRepository.Update(Raza);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Raza = await _razaRepository.GetById(id);

            if (Raza == null)
            {
                return NotFound();
            }

            await _razaRepository.Delete(Raza);
            return NoContent();
        }


    }
}
