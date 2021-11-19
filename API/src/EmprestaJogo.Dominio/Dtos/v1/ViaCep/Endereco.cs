using System.Text.Json.Serialization;

namespace Cotacoes.Domain.Dtos.v1
{
    public class Endereco
    {
        [JsonPropertyName("cep")]
        public string Cep { get; set; }

        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }

        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }
        
        [JsonPropertyName("uf")]
        public string UF { get; set; }
    }
}
