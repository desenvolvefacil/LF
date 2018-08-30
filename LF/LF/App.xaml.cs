using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LF.Views;
using System.Globalization;
using LF.Models;
using LF.WS;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LF
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            // Define o Idioma para Português do Brasil
            var userSelectedCulture = new CultureInfo("pt-BR");
            System.Threading.Thread.CurrentThread.CurrentCulture = userSelectedCulture;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
