using Omnipotent;
using Omnipotent.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Omnipotent
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var boot = new AppBootstrapper();
            boot.Initialize();
            

            MainPage = new StartView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
