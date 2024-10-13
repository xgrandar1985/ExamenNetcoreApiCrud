using Examen.Core.Application.Dto;
using Examen.Core.Application.Interfaces;
using Examen.Core.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChoferController: Controller
    {

        private readonly IChoferRepository _choferRepository;

        public ChoferController(IChoferRepository choferRepository) { 
            _choferRepository = choferRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Chofer>> getAllChoferes() {
            return await _choferRepository.GetAllChoferes();
        }

        [HttpGet("con-taxis")]
        public async Task<IEnumerable<Chofer>> getChoferesConTaxis() {
            return await _choferRepository.GetAllChoferesConTaxis();
        }

        [HttpGet("con-taxis-con-accesorios")]
        public async Task<IEnumerable<ChoferDTO>> getChoferesConTaxisConAccesorios()
        {
            return await _choferRepository.GetChoferesTaxisAccesorios();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chofer>> GetChoferById(int id) { 
            var chofer = await _choferRepository.GetChoferById(id);

            if (chofer == null)
            {
                return NotFound();
            }

            return Ok(chofer);
        }

        [HttpPost]
        public async Task<ActionResult<Chofer>> saveChofer([FromBody] Chofer chofer) {
            var choferNew = await _choferRepository.CreateChofer(chofer);
            return CreatedAtAction(nameof(GetChoferById), new { id = choferNew.Id }, choferNew); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChofer(int id, [FromBody] Chofer chofer)
        {
            if (id != chofer.Id)
            {
                return BadRequest();
            }

            await _choferRepository.UpdateChofer(chofer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChofer(int id)
        {
            await _choferRepository.DeleteChofer(id);
            return NoContent();
        }
    }
}
