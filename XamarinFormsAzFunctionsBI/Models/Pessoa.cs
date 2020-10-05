using System;
using MvvmHelpers;
using XamarinFormsAzFunctionsBI.Validations;
using XamarinFormsAzFunctionsBI.Validations.Rules;

namespace XamarinFormsAzFunctionsBI.Models
{
    public class Pessoa : ObservableObject
    {
        private ValidatableObject<string> _email;
        public ValidatableObject<string> Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private ValidatableObject<string> _dataNascimento;
        public ValidatableObject<string> DataNascimento
        {
            get => _dataNascimento;
            set => SetProperty(ref _dataNascimento, value);
        }

        private ValidatableObject<string> _estado;
        public ValidatableObject<string> Estado
        {
            get => _estado;
            set => SetProperty(ref _estado, value);
        }

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

        public Pessoa(bool validar)
        {
            Init();

            if (validar)
            {
                InitValidate();
            }
        }

        public bool Validate()
        {
            var email = _email.Validate();
            var dataNascimento = _dataNascimento.Validate();
            var estado = _estado.Validate();
            var formacao = _formacao.Validate();
            var areaAtuacao = _areaAtuacao.Validate();
            var faixaSalarial = _faixaSalarial.Validate();


            return email
                && dataNascimento
                && estado
                && formacao
                && areaAtuacao
                && faixaSalarial;
        }

        private void Init()
        {
            _email = new ValidatableObject<string>();
            _dataNascimento = new ValidatableObject<string>();
            _estado = new ValidatableObject<string>();
            _formacao = new ValidatableObject<string>();
            _areaAtuacao = new ValidatableObject<string>();
            _faixaSalarial = new ValidatableObject<string>();
            _possuiCertificacao = new ValidatableObject<bool>();
        }

        private void InitValidate()
        {
            _email.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "E-mail é obrigatório."
            });
            _email.Validations.Add(new EmailRule<string>
            {
                ValidationMessage = "E-mail invalido."
            });

            _estado.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "O Estado é obrigatório."
            });

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

            _dataNascimento.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A Data de Nascimento é obrigatória."
            });

        }
    }
}
