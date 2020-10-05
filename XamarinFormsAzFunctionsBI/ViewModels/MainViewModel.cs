using System;
using Microsoft.Extensions.Logging;
using XamarinFormsAzFunctionsBI.ViewModels.Interfaces;

namespace XamarinFormsAzFunctionsBI.ViewModels
{
    public class MainViewModel : IMainViewModel
    {
        public MainViewModel(ILogger<MainViewModel> logger)
        {
           // var httpClient = httpClientFactory.CreateClient();
            logger.LogCritical("Always be logging!");
            Hello = "Hello from IoC";
        }

        public string Hello { get; set; }
    }
}
