using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCSharp.DTO
{
    public class ClienteResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataCadastro { get; set; }
        public EnderecoResponseDto Endereco { get; set; }
        public List<ContatoResponseDto> Contatos { get; set; }
    }
}