using DesafioCSharp.DTO;
using System.Text.Json;

namespace DesafioCSharp.Services
{
    public class ViaCepService : IViaCepService
    {
        // Este é o "WebClient" ou "RestTemplate" do .NET.
        // Ele será injetado automaticamente (Passo 3)
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ViaCepResponse?> ConsultarCepAsync(string cep)
        {

            var response = await _httpClient.GetAsync($"{cep}/json/");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                
                // Se o conteúdo for vazio ou erro, retorna nulo
                if (string.IsNullOrEmpty(content)) return null;

                // Converte o JSON (string) para o nosso DTO (ViaCepResponse)
                var cepResponse = JsonSerializer.Deserialize<ViaCepResponse>(content);

                // Se o ViaCEP retornar { "erro": true }, significa CEP não encontrado
                if (cepResponse == null || cepResponse.Erro)
                {
                    return null;
                }

                return cepResponse;
            }

            // Se a chamada falhou (ex: 404, 500)
            return null;
        }
    }
}