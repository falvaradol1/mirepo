using Microsoft.AspNetCore.Mvc;
using Api17420.Models;
using System.Text.RegularExpressions;

namespace Api17420.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Message17420Controller : ControllerBase
    {
        [HttpPost]
        public ActionResult<FrequencyResponse12345> Analizar([FromBody] TextRequest12345 request)
        {
            if (string.IsNullOrWhiteSpace(request?.Texto))
                return BadRequest(new { error = "El campo 'texto' es requerido y no puede estar vacío." });

            var response = new FrequencyResponse12345();

            // separar palabras
            var palabras = Regex.Matches(request.Texto.ToLowerInvariant(), @"\b\w+\b");

            foreach (var palabra in palabras)
            {
                var p = palabra.ToString();
                if (response.Frecuencia.ContainsKey(p))
                    response.Frecuencia[p]++;
                else
                    response.Frecuencia[p] = 1;
            }

            return Ok(response);
        }
    }
}
