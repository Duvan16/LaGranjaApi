using AutoMapper;
using LaGranjaAPI.DTOs;
using LaGranjaAPI.Entities;
using LaGranjaAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaGranjaAPI.Controllers
{
    [Route("api/porcinos")]
    [ApiController]
    public class PorcinosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPorcinoRepository _porcinoRepository;

        public PorcinosController(IMapper mapper, IPorcinoRepository porcinoRepository)
        {
            this._mapper = mapper;
            this._porcinoRepository = porcinoRepository;
        }

        [HttpGet("todos")]
        [AllowAnonymous]
        public async Task<ActionResult<List<PorcinoDTO>>> Todos()
        {
            var Porcino = await _porcinoRepository.Get();
            return _mapper.Map<List<PorcinoDTO>>(Porcino);
        }


        [HttpGet]
        public async Task<ActionResult<List<PorcinoDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = await _porcinoRepository.Get();
            return _mapper.Map<List<PorcinoDTO>>(queryable);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<PorcinoDTO>> Get(int Id)
        {
            var Porcino = await _porcinoRepository.GetById(Id);

            if (Porcino == null)
            {
                return NotFound();
            }

            return _mapper.Map<PorcinoDTO>(Porcino);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PorcinoCreacionDTO PorcinoCreacionDTO)
        {
            var porcino = _mapper.Map<Porcino>(PorcinoCreacionDTO);
            await _porcinoRepository.Create(porcino);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int Id, [FromBody] PorcinoCreacionDTO PorcinoCreacionDTO)
        {
            var Porcino = await _porcinoRepository.GetById(Id);

            if (Porcino == null)
            {
                return NotFound();
            }

            Porcino = _mapper.Map(PorcinoCreacionDTO, Porcino);

            await _porcinoRepository.Update(Porcino);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Porcino = await _porcinoRepository.GetById(id);

            if (Porcino == null)
            {
                return NotFound();
            }

            await _porcinoRepository.Delete(Porcino);
            return NoContent();
        }
    }
}
