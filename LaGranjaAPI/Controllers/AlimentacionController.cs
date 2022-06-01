using AutoMapper;
using LaGranjaAPI.DTOs;
using LaGranjaAPI.Entities;
using LaGranjaAPI.Repositories;
using LaGranjaAPI.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaGranjaAPI.Controllers
{
    [Route("api/alimentacion")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class AlimentacionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAlimentacionRepository _alimentacionRepository;

        public AlimentacionController(IMapper mapper, IAlimentacionRepository alimentacionRepository)
        {
            this._mapper = mapper;
            this._alimentacionRepository = alimentacionRepository;
        }

        [HttpGet("todos")]
        [AllowAnonymous]
        public async Task<ActionResult<List<AlimentacionDTO>>> Todos()
        {
            var alimentacion = await _alimentacionRepository.Get();
            return _mapper.Map<List<AlimentacionDTO>>(alimentacion);
        }


        [HttpGet]
        public async Task<ActionResult<List<AlimentacionDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = await _alimentacionRepository.Get();
            //await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            //var alimentaciones = await queryable.OrderBy(x => x.Descripcion)
            //    .Paginar(paginacionDTO)
            //    .ToListAsync();
            return _mapper.Map<List<AlimentacionDTO>>(queryable);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<AlimentacionDTO>> Get(int Id)
        {
            var alimentacion = await _alimentacionRepository.GetById(Id);

            if (alimentacion == null)
            {
                return NotFound();
            }

            return _mapper.Map<AlimentacionDTO>(alimentacion);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AlimentacionCreacionDTO alimentacionCreacionDTO)
        {
            var alimentacion = _mapper.Map<Alimentacion>(alimentacionCreacionDTO);
            await _alimentacionRepository.Create(alimentacion);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int Id, [FromBody] AlimentacionCreacionDTO alimentacionCreacionDTO)
        {
            var alimentacion = await _alimentacionRepository.GetById(Id);

            if (alimentacion == null)
            {
                return NotFound();
            }

            alimentacion = _mapper.Map(alimentacionCreacionDTO, alimentacion);

            await _alimentacionRepository.Update(alimentacion);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var alimentacion = await _alimentacionRepository.GetById(id);

            if (alimentacion == null)
            {
                return NotFound();
            }

            await _alimentacionRepository.Delete(alimentacion);
            return NoContent();
        }
    }
}
