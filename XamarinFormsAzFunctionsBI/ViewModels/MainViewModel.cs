using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Extensions.Logging;
using Xamarin.Forms;
using XamarinFormsAzFunctionsBI.Models;
using XamarinFormsAzFunctionsBI.ViewModels.Interfaces;

namespace XamarinFormsAzFunctionsBI.ViewModels
{
    public class MainViewModel : ViewModelBase ,IMainViewModel
    {
        private int _step;
        public int Step
        {
            get { return _step; }
            set
            {
                if (this.SetProperty(ref _step, value))
                {
                    HabilitarPainel(_step);
                }
            }
        }

        private bool _dadosPessoais;
        public bool DadosPessoais
        {
            get { return _dadosPessoais; }
            set { SetProperty(ref _dadosPessoais, value); }
        }

        private bool _dadosProfissionais;
        public bool DadosProfissionais
        {
            get { return _dadosProfissionais; }
            set { SetProperty(ref _dadosProfissionais, value); }
        }

        private DadosPessoais _pessoa;
        public DadosPessoais Pessoa
        {
            get { return _pessoa; }
            set { SetProperty(ref _pessoa, value); }
        }

        private DadosProfissionais _profissional;
        public DadosProfissionais Profissional
        {
            get { return _profissional; }
            set { SetProperty(ref _profissional, value); }
        }

        private ICommand proximoCommand;
        public ICommand ProximoCommand => proximoCommand ?? (proximoCommand = new Command(async () => await ProximoCommandExecute()));

        private ICommand cadastrarCommand;
        public ICommand CadastrarCommand => cadastrarCommand ?? (cadastrarCommand = new Command(async () => await CadastrarCommandExecute()));

        public MainViewModel(ILogger<MainViewModel> logger)
        {
            DadosPessoais = true;
            // var httpClient = httpClientFactory.CreateClient();
            logger.LogCritical("Acessando o Aplicativo");
            Pessoa = new DadosPessoais(true);
            Profissional = new DadosProfissionais(true);

            Step = 1;
        }

        private async Task ProximoCommandExecute()
        {
            if (!ValidateNavigation(Step))
                return;

            if (Step < 2)
            {
                Step++;
            }
        }

        private async Task CadastrarCommandExecute()
        {
            if (!ValidateNavigation(Step))
                return;
        }

        private bool ValidateNavigation(int step)
        {

            switch (step)
            {
                case 1: return Pessoa.Validate();
                case 2: return Profissional.Validate(); 
                default: return true;
            }
        }

        private void HabilitarPainel(int step)
        {
            switch (step)
            {
                case 1:
                    DadosPessoais = true;
                    DadosProfissionais = false;
                    break;
                case 2:
                    DadosPessoais = false;
                    DadosProfissionais = true;
                    break;
                default:
                    DadosPessoais = false;
                    DadosProfissionais = false;
                    break;
            }
        }

       

    }
}
