using System.Runtime.ConstrainedExecution;
using System.Text.Json;
using User.Interface;
using User.Model;
using static System.Net.WebRequestMethods;

namespace User.Service
{
    public class BrasilApiService : IBrasilApiService
    {
        public HttpClient _httpClient;

        public BrasilApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EnderecoModel> GetEnderecoByCEP(string CEP)
        {
            using (var client = _httpClient)
            {
                var response = await _httpClient.GetAsync($"https://brasilapi.com.br/api/cep/v1/{CEP}");
                var contentResp = await response.Content.ReadAsStringAsync();
                EnderecoModel objResponse = JsonSerializer.Deserialize<EnderecoModel>(contentResp);

                return objResponse;
            }
        }
    }
}
