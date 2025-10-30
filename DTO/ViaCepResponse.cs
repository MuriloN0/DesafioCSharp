using System.Text.Json.Serialization; // <-- Adicione este 'using' se estiver faltando

namespace DesafioCSharp.DTO{

    // Esta é a única declaração de classe que deve existir no arquivo
    public class ViaCepResponse{

        public bool Error { get; internal set; }
        
        [JsonPropertyName("cep")]
        public string? Cep { get; set; }

        [JsonPropertyName("logradouro")]
        public string? Logradouro { get; set; }

        [JsonPropertyName("complemento")]
        public string? Complemento { get; set; }

        [JsonPropertyName("bairro")]
        public string? Bairro { get; set; }

        // "localidade" no ViaCEP é o que usaremos como "Cidade"
        [JsonPropertyName("localidade")]
        public string? Localidade { get; set; }

        [JsonPropertyName("uf")]
        public string? Uf { get; set; }
        
        // O ViaCEP retorna "erro: true" se o CEP não for encontrado
        [JsonPropertyName("erro")]
        public bool Erro { get; set; }
    }
}