using FFF_App.Services;
using FFF_App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FFF_App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<ScreeningDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
