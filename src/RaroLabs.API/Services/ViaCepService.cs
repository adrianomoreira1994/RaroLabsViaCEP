using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RaroLabs.API.Interfaces;
using RaroLabs.API.Models;
using RaroLabs.Shared.Models;
using RaroLabs.Shared.Utils;
using System.Threading.Tasks;

namespace RaroLabs.API.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly IOptions<AppSettings> _options;

        public ViaCepService(IOptions<AppSettings> options) => _options = options;

        public async Task<ViaCep> GetViaCepData(int cep)
        {
            string endpoint = _options.Value.Endpoint.Replace("%CEP%", cep.ToString());

            var response = await RequestCore.Get(endpoint);
            var viaCep = JsonConvert.DeserializeObject<ViaCep>(response);

            return viaCep;
        }
    }
}
