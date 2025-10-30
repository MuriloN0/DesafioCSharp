using AutoMapper;
using DesafioCSharp.Models;
using DesafioCSharp.DTO;

namespace DesafioCSharp.Mapping
{
    public class MappingProfile : Profile{
        public MappingProfile()
        {
            
            CreateMap<Cliente, ClienteResponseDto>();
            CreateMap<Endereco, EnderecoResponseDto>();
            CreateMap<Contato, ContatoResponseDto>();
        }
    }
}