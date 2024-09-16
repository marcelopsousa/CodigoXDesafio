using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace CodigoX4.Controllers
{
    [Route("[controller]")]
    public class CalculoController : Controller
    {
        private readonly ILogger<CalculoController> _logger;

        public CalculoController(ILogger<CalculoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("sum")]
        public async Task<ActionResult<double>> soma(string parametro1, string parametro2)
        {
            try
            {
                if(double.TryParse(parametro1, out var valor1) && double.TryParse(parametro2, out var valor2))
                {
                    return Ok(new { result = valor1 + valor2 });
                } else
                {
                    return BadRequest("Valores dos parâmetros devem ser numéricos");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
