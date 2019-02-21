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
     public class LoginViewModel : ViewModelBase
    {

        public Command LoginCommand { get; }
        public Command CancelCommand { get; }

       
        private readonly IAuthenticationService _authenticateService;
        private readonly IProfileService _profileService;

        public LoginViewModel(INavigationService navigationService, IAuthenticationService authenticationService, IProfileService profileService) : this(navigationService, authenticationService, profileService, new RuntimeContext()) { }

        public LoginViewModel(INavigationService navigationService, IAuthenticationService authenticationService, IProfileService profileService, IRuntimeContext runtimeContext) : base(navigationService, runtimeContext)
        {
            _authenticateService = authenticationService;
            _profileService = profileService;

            LoginCommand = new Command(async () => await Login(), () => !IsBusy && !String.IsNullOrWhiteSpace(Username) && !String.IsNullOrWhiteSpace(Password));
            CancelCommand = new Command(async () => await CancelLogin());
        }

        private async Task CancelLogin()
        {
            try
            {
                IsBusy = true;

                await _navigationService.NavigateAsync<StartViewModel>();
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
                IsBusy = true;

                await _authenticateService.Login(Username, Password);
                _navigationService.SetRootPage(typeof(DrivesViewModel));

                    
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }

            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }


        private string _userName;
        public string Username
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
                LoginCommand.ChangeCanExecute();

            }
        }

        private string _password;
        public string Password
        { get { return _password; }

                set
            {
                _password = value;
                OnPropertyChanged();
                LoginCommand.ChangeCanExecute();
            } 
        }
    }
}
 