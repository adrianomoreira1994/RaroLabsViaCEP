using Microsoft.AspNetCore.Mvc;
using RaroLabs.API.Interfaces;
using RaroLabs.Shared.Validations;
using System.Threading.Tasks;

namespace RaroLabs.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViaCepController : ApiController
    {
        private IViaCepService _service;

        public ViaCepController(IViaCepService service) => _service = service;

        [HttpGet]
        [Route("{cep}")]
        public async Task<IActionResult> Get(int cep)
        {
            if (!ValidaCep.IsValid(cep))
            {
                AddError($"CEP: {cep} inválido.");
                return CustomResponse();
            }

            var response = await _service.GetViaCepData(cep);

            return CustomResponse(response);
        }
    }
}
