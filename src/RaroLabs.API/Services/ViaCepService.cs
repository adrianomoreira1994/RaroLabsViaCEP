using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RaroLabs.API.Interfaces;
using RaroLabs.API.Models;
using RaroLabs.Shared.Models;
using RaroLabs.Shared.Utils;
using System;
using System.Threading.Tasks;

namespace RaroLabs.API.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly IOptions<AppSettings> _options;

        public ViaCepService(IOptions<AppSettings> options) => _options = options;

        public async Task<ViaCep> GetViaCepData(int cep)
        {
            try
            {
                string endpoint = _options.Value.Endpoint.Replace("%CEP%", cep.ToString());

                var response = await RequestCore.Get(endpoint);
                var viaCep = JsonConvert.DeserializeObject<ViaCep>(response);

                return viaCep;
            }
            catch (Exception ex)
            {
                string error = ex.InnerException != null ? $"{ex.Message} - Inner Error : {ex.InnerException.Message}" : ex.Message;
                throw new Exception($"Ocorreu um erro ao consultar o CEP informado. Erro : {error}");
            }
        }
    }
}
