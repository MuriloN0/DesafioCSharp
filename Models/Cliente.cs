
namespace DesafioCSharp.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataCadastro { get; set; }

        //Relação de composição com as classes endereco e contato.

        //Endereco é 1 para 1.
        public Endereco Endereco { get; set; }

        //Contato é 1 para muitos.
        public List<Contato> Contatos { get; set; }
    

    }
}