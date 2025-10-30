
using DesafioCSharp.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioCSharp.Data
{
    public class AppDbContext : DbContext //
    {
        public AppDbContext(DbContextOptions options) : base(options) { } //Método construtor do nosso DBContext.
        
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Contato> Contatos { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }
    }
}