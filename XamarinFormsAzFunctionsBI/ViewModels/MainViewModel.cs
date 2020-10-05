using System;
using Microsoft.Extensions.Logging;
using XamarinFormsAzFunctionsBI.ViewModels.Interfaces;

namespace XamarinFormsAzFunctionsBI.ViewModels
{
    public class MainViewModel : ViewModelBase ,IMainViewModel
    {
        private string _hello;
        public string Hello
        {
            get => _hello;
            set => SetProperty(ref _hello, value);
        }

        private int _step;
        public int Step
        {
            get { return _step; }
            set
            {
                if (this.SetProperty(ref _step, value))
                {
                   // HabilitarPainel(_step);
                }
            }
        }

        public MainViewModel(ILogger<MainViewModel> logger)
        {
           // var httpClient = httpClientFactory.CreateClient();
            logger.LogCritical("Always be logging!");
            Hello = "Hello from IoC";
        }

    }
}
