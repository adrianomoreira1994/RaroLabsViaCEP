using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RaroLabs.Shared.Utils
{
    public static class RequestCore
    {
        public static async Task<string> Get(string endPoint)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(endPoint))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content.ReadAsStringAsync().Result;
                            return result;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.InnerException != null ? $"{ex.Message} - {ex.InnerException.Message}" : ex.Message;
                throw new Exception($"Request is not successfuly. Error : {error}");
            }
        }
    }
}
