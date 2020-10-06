using System;
using Newtonsoft.Json;

namespace XamarinFormsAzFunctionsBI.Services.DTO
{
    public partial class RetornoDto
    {
        [JsonProperty("acao")]
        public string Acao { get; set; }

        [JsonProperty("sucesso")]
        public bool Sucesso { get; set; }

        [JsonProperty("inconsistencias")]
        public string[] Inconsistencias { get; set; }
    }
}
