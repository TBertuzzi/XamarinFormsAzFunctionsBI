using System;
namespace XamarinFormsAzFunctionsBI.Models
{
    public class Pessoa
    {
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Estado { get; set; }

        public string Formacao { get; set; }
        public string AreaAtuacao { get; set; }
        public bool PossuiCertificacao { get; set; }
        public string FaixaSalarial { get; set; }
    }
}
