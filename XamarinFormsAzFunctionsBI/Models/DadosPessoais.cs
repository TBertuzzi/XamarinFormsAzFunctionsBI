using System;
using MvvmHelpers;
using XamarinFormsAzFunctionsBI.Validations;
using XamarinFormsAzFunctionsBI.Validations.Rules;

namespace XamarinFormsAzFunctionsBI.Models
{
    public class DadosPessoais : ObservableObject
    {
        private ValidatableObject<string> _nome;
        public ValidatableObject<string> Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

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

        public DadosPessoais(bool validar)
        {
            Init();

            if (validar)
            {
                InitValidate();
            }
        }

        public bool Validate()
        {
            var nome = _nome.Validate();
            var email = _email.Validate();
            var dataNascimento = _dataNascimento.Validate();
            var estado = _estado.Validate();


            return nome &&
                email
                && dataNascimento
                && estado;
        }

        private void Init()
        {
            _nome = new ValidatableObject<string>();
            _email = new ValidatableObject<string>();
            _dataNascimento = new ValidatableObject<string>();
            _estado = new ValidatableObject<string>();
        }

        private void InitValidate()
        {
            _nome.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "O Nome é obrigatório."
            });

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

            _dataNascimento.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A Data de Nascimento é obrigatória."
            });

        }
    }
}
