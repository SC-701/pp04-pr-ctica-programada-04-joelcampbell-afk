using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehiculoController : ControllerBase, IVehiculoController
    {
        private IVehiculoFlujo _vehiculoFlujo;
        private ILogger<VehiculoController> _logger;

        public VehiculoController(IVehiculoFlujo vehiculoFlujo, ILogger<VehiculoController> logger)
        {
            _vehiculoFlujo = vehiculoFlujo;
            _logger = logger;
        }
        [HttpPost]
        [Authorize(Roles = "2")]
        public async Task<IActionResult> Agregar(VehiculoRequest vehiculo)
        {
            var resultado= await _vehiculoFlujo.Agregar(vehiculo);
            return CreatedAtAction(nameof(Obtener), new {Id=resultado}, null);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "2")]
        public async Task<IActionResult> Editar([FromRoute]Guid id, [FromBody]VehiculoRequest vehiculo)
        {
            if (!await VerificarVehiculoExiste(id))
                return NotFound($"El vehiculo con Id {id} no existe");
            var resultado = await _vehiculoFlujo.Editar(id, vehiculo);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "2")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            if (!await VerificarVehiculoExiste(id))
                return NotFound($"El vehiculo con Id {id} no existe");
            var resultado= await _vehiculoFlujo.Eliminar(id);
            return NoContent();
        }
        [HttpGet]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> Obtener()
        {
            var resultado=  await _vehiculoFlujo.Obtener();
            if (!resultado.Any())
            {
                return NoContent();
            }
            return Ok(resultado);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> Obtener([FromRoute]Guid id)
        {
            var resultado= await _vehiculoFlujo.Obtener(id);
            return Ok(resultado);
        }

        private async Task<bool> VerificarVehiculoExiste(Guid id)
        {
            var resultadoValidacion = false;
            var resultadoVehiculoExiste = await _vehiculoFlujo.Obtener(id);
            if (resultadoVehiculoExiste != null)
                resultadoValidacion = true;
            return resultadoValidacion;
        }
    }
}
