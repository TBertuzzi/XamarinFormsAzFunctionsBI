using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Extensions.Logging;
using Xamarin.Forms;
using XamarinFormsAzFunctionsBI.Models;
using XamarinFormsAzFunctionsBI.Services;
using XamarinFormsAzFunctionsBI.ViewModels.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using XamarinFormsAzFunctionsBI.Services.DTO;
using Acr.UserDialogs;

namespace XamarinFormsAzFunctionsBI.ViewModels
{
    public class MainViewModel : ViewModelBase ,IMainViewModel
    {
        private IDadosCadastraisService _aprovacaoService;

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

        private ICommand voltarCommand;
        public ICommand VoltarCommand => voltarCommand ?? (voltarCommand = new Command(async () => await VoltarCommandExecute()));

      

        public MainViewModel(ILogger<MainViewModel> logger)
        {
            DadosPessoais = true;
            _aprovacaoService = App.ServiceProvider.GetService<IDadosCadastraisService>();
            logger.LogCritical("Acessando o Aplicativo");
            Pessoa = new DadosPessoais(true);
            Profissional = new DadosProfissionais(true);

            Step = 1;
        }

        private async Task VoltarCommandExecute()
        {
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
            try
            {
                if (!ValidateNavigation(Step))
                    return;

                using (var dialog = UserDialogs.Instance.Loading("Cadastrando", null, null, true, MaskType.Black))
                {
                    var cadastro = new CadastroDto
                    {
                        AreaAtuacao = Profissional.AreaAtuacao.Value,
                        CodEstado = Pessoa.Estado.Value,
                        DataNascimento = Convert.ToDateTime(Pessoa.DataNascimento.Value).ToString("yyyy-MM-dd"),
                        Email = Pessoa.Email.Value,
                        FlCertificacao = Profissional.PossuiCertificacao.Value,
                        Formacao = Profissional.Formacao.Value,
                        Nome = Pessoa.Nome.Value,
                        Salario = Convert.ToDouble(Profissional.FaixaSalarial.Value)

                    };


                    var retorno = await _aprovacaoService.Cadastrar(cadastro);


                    if (retorno.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        if (retorno.Value.Sucesso)
                        {
                            await Application.Current.MainPage.DisplayAlert("Sucesso", "Cadastro Incluido com Sucesso", "OK");
                            Step = 1;
                            Pessoa = new DadosPessoais(true);
                            Profissional = new DadosProfissionais(true);
                        }
                        else
                        {
                            string inconsistencias = string.Empty;

                            for (int i = 0; i < retorno.Value.Inconsistencias.Length; i++)
                            {
                                inconsistencias = inconsistencias + "," + retorno.Value.Inconsistencias[i];
                            }

                            await Application.Current.MainPage.DisplayAlert("Atenção", $"{inconsistencias}", "OK");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Erro", $"Ocorreu um erro ao cadastrar{retorno.Error}", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", $"Ocorreu um erro ao cadastrar{ex.Message}", "OK");
            }

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
