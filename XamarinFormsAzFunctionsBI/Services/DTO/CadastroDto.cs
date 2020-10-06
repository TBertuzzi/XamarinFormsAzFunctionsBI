using System;
using Newtonsoft.Json;

namespace XamarinFormsAzFunctionsBI.Services.DTO
{
    public partial class CadastroDto
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("CodEstado")]
        public string CodEstado { get; set; }

        [JsonProperty("Salario")]
        public double Salario { get; set; }

        [JsonProperty("DataNascimento")]
        public DateTimeOffset DataNascimento { get; set; }

        [JsonProperty("FlCertificacao")]
        public bool FlCertificacao { get; set; }

        [JsonProperty("Formacao")]
        public string Formacao { get; set; }

        [JsonProperty("AreaAtuacao")]
        public string AreaAtuacao { get; set; }
    }
}
