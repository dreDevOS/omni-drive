using Omnipotent.Services.Interfaces;
using Omnipotent.Settings;
using Omnipotent.Settings.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Omnipotent.ViewModels
{
     public class StartViewModel : ViewModelBase
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        public StartViewModel(INavigationService navigationService) : this(navigationService, new RuntimeContext())
        {

        }

        public StartViewModel(INavigationService navigationServices, IRuntimeContext runtimeContext) : base(navigationServices, runtimeContext)
        {
            LoginCommand = new Command(async () => await Login());

            RegisterCommand = new Command(async () => await RegisterNewUser());


        }

        private  async Task RegisterNewUser()
        {
            try
            {
                await _navigationService.NavigateAsync<RegisterViewModel>();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally { }
           
        }

        private async Task Login()
        {
            try
            {
                _navigationService.SetRootPage(typeof(LoginViewModel));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {

            }
        }
    }
}
