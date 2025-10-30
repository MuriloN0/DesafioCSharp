
namespace DesafioCSharp.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Texto { get; set; }

        public int ClienteId { get; set; } //Chave estrangeira para CLiente
        public Cliente Cliente { get; set; }
    }
}