using RaroLabs.API.Models;
using System.Threading.Tasks;

namespace RaroLabs.API.Interfaces
{
    public interface IViaCepService
    {
        Task<ViaCep> GetViaCepData(int cep);
    }
}
