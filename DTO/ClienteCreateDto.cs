

namespace DesafioCSharp.DTO
{
    public class ClienteCreateDto
    {
        public string Nome { get; set; }
        public EnderecoCreateDto Endereco { get; set; }
        public List<ContatoCreateDto> Contatos { get; set; }
    }
}