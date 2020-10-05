using System;
using MvvmHelpers;
using XamarinFormsAzFunctionsBI.Validations;

namespace XamarinFormsAzFunctionsBI.Models
{
    public class DadosProfissionais : ObservableObject
    {
        private ValidatableObject<string> _formacao;
        public ValidatableObject<string> Formacao
        {
            get => _formacao;
            set => SetProperty(ref _formacao, value);
        }

        private ValidatableObject<string> _areaAtuacao;
        public ValidatableObject<string> AreaAtuacao
        {
            get => _areaAtuacao;
            set => SetProperty(ref _areaAtuacao, value);
        }

        private ValidatableObject<string> _faixaSalarial;
        public ValidatableObject<string> FaixaSalarial
        {
            get => _faixaSalarial;
            set => SetProperty(ref _faixaSalarial, value);
        }

        private ValidatableObject<bool> _possuiCertificacao;
        public ValidatableObject<bool> PossuiCertificacao
        {
            get => _possuiCertificacao;
            set => SetProperty(ref _possuiCertificacao, value);
        }



        public DadosProfissionais(bool validar)
        {
            Init();

            if (validar)
            {
                InitValidate();
            }
        }

        public bool Validate()
        {
            var formacao = _formacao.Validate();
            var areaAtuacao = _areaAtuacao.Validate();
            var faixaSalarial = _faixaSalarial.Validate();


            return  formacao
                && areaAtuacao
                && faixaSalarial;
        }

        private void Init()
        {
            _formacao = new ValidatableObject<string>();
            _areaAtuacao = new ValidatableObject<string>();
            _faixaSalarial = new ValidatableObject<string>();
            _possuiCertificacao = new ValidatableObject<bool>();
        }

        private void InitValidate()
        {

            _formacao.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A Formação é obrigatória."
            });

            _areaAtuacao.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A Area de Atuação é obrigatória."
            });

            _faixaSalarial.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A faixa salarial é obrigatória."
            });
        }
    }
}
