using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace XamarinFormsAzFunctionsBI.Models
{
    public class Response<T> : Response
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }
    }

    public class Response
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("errors")]
        public List<string> Errors { get; set; }

        public string ObterErros()
        {
            string erros = string.Empty;

            for (int i = 0; i < Errors?.Count; i++)
            {
                erros = erros + "," + Errors[i];
            }

            if (string.IsNullOrEmpty(erros))
                return erros.Trim().Substring(1);
            else
                return erros;
        }
    }
}
