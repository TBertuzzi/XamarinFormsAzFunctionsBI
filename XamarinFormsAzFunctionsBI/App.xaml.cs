using System;
using System.Globalization;
using System.Threading;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsAzFunctionsBI
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public App()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");

            MainPage = ServiceProvider.GetService<MainPage>();
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=2fe4a08b-f9f9-44a8-b65a-0e95505a2957;" +
                  "ios=51d9329d-e269-4dd8-a001-99f20b6dda97",
                  typeof(Analytics), typeof(Crashes), typeof(Distribute));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
