using APINomina.Util;
using DatosNomina.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioNomina.Servicios;

namespace API_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _personaService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _personaService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PersonaDTO persona)
        {

            int iduser = ClaimsUser.GetIdUser(HttpContext);
            await _personaService.AddAsync(persona, iduser);
            return CreatedAtAction(nameof(GetById), new { id = persona.IdPersona }, persona);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PersonaDTO persona)
        {
            if (id != persona.IdPersona)
            {
                return BadRequest();
            }


            int iduser = ClaimsUser.GetIdUser(HttpContext);
            await _personaService.UpdateAsync(persona, iduser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _personaService.DeleteAsync(id);
            return NoContent();
        }


        [HttpPost("GetPersonas")]
        public async Task<ActionResult<PaginacionResponse<PersonaDTO>>> GetPersonas(PaginacionRequestDTO request)
        {
            var result = await _personaService.GetPersonas(request);
            return Ok(result);
        }
    }
}
