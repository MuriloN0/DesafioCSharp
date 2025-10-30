using DesafioCSharp.DTO;

namespace DesafioCSharp.Services
{
    public interface IViaCepService
    {
        // Ele tem um método que recebe um CEP e retorna
        // (de forma assíncrona) a resposta do ViaCEP
        Task<ViaCepResponse?> ConsultarCepAsync(string cep);
    }
}