using Microsoft.AspNetCore.Mvc;
using RaroLabs.API.Interfaces;
using RaroLabs.Shared.Validations;
using System.Threading.Tasks;

namespace RaroLabs.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViaCepController : ControllerBase
    {
        private IViaCepService _service;

        public ViaCepController(IViaCepService service) => _service = service;

        [HttpGet]
        [Route("{cep}")]
        public async Task<IActionResult> Get(int cep)
        {
            try
            {
                if (!ValidaCep.IsValid(cep))
                {
                    return StatusCode(400, new
                    {
                        value = cep,
                        message = "Informe um CEP valido"
                    });
                }

                var response = await _service.GetViaCepData(cep);

                return StatusCode(200, new
                {
                    data = response
                });
            }
            catch (System.Exception exception)
            {
                return StatusCode(500, new
                {
                    error = exception.Message
                });
            }
        }
    }
}
