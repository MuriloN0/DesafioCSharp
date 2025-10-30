using DesafioCSharp.Data;
using Microsoft.AspNetCore.Mvc;
using DesafioCSharp.Models;
using DesafioCSharp.DTO;
using DesafioCSharp.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace DesafioCSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext; // Essa variavel vai acessar nosso banco de dados.
        private readonly IViaCepService _viaCepService;
        private readonly IMapper _mapper;

        public ClientesController(AppDbContext appDbContext, IViaCepService viaCepService, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _viaCepService = viaCepService;
            _mapper = mapper;
        }

        [HttpPost] 
        public async Task<IActionResult> AddCliente([FromBody] ClienteCreateDto clienteDto)
        {
            // CHAMAR O SERVIÇO QUE ACABAMOS DE CRIAR
            var cepInfo = await _viaCepService.ConsultarCepAsync(clienteDto.Endereco.Cep);
            
            // VERIFICAR SE O CEP FOI VÁLIDO
            if (cepInfo == null)
            {
                return BadRequest("CEP não encontrado ou inválido.");
            }

            // MAPEAR O DTO PARA AS ENTIDADES
            
            // Criar a entidade Endereco
            var novoEndereco = new Endereco{

                Logradouro = cepInfo.Logradouro,
                Cidade = cepInfo.Localidade,

                // Dados vindos do DTO (usuário)
                Cep = clienteDto.Endereco.Cep,
                Numero = clienteDto.Endereco.Numero,
                Complemento = clienteDto.Endereco.Complemento
            };

            // Criar a entidade Cliente
            var novoCliente = new Cliente
            {
                Nome = clienteDto.Nome,
                DataCadastro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Endereco = novoEndereco, // Associa o endereço
                Contatos = clienteDto.Contatos.Select(cDto => new Contato
                {
                    Tipo = cDto.Tipo,
                    Texto = cDto.Texto
                }).ToList() // Associa os contatos
            };

            _appDbContext.Clientes.Add(novoCliente);
            await _appDbContext.SaveChangesAsync();

            var clienteResponse = _mapper.Map<ClienteResponseDto>(novoCliente);

            return CreatedAtAction("GetClienteById", new { id = novoCliente.Id }, clienteResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _appDbContext.Clientes
                .Include(c => c.Endereco)
                .Include(c => c.Contatos)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            var clienteResponse = _mapper.Map<ClienteResponseDto>(cliente);

            return Ok(clienteResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            var clientes = await _appDbContext.Clientes
                .Include(c => c.Endereco)
                .Include(c => c.Contatos)
                .ToListAsync();

            var clientesResponse = _mapper.Map<List<ClienteResponseDto>>(clientes);

            return Ok(clientesResponse);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {

            var cliente = await _appDbContext.Clientes
                .Include(c => c.Endereco)
                .Include(c => c.Contatos)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            _appDbContext.Clientes.Remove(cliente);

            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}