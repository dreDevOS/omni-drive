using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omnipotent.Models;
using Omnipotent.Services.Interfaces;
using Omnipotent.Settings;
using Omnipotent.Settings.Interfaces;
using Xamarin.Forms;


namespace Omnipotent.ViewModels
{
    public class ProfilViewModel : ViewModelBase


    {
        public Command ChangeCommand { get; }
        public Command BackCommand { get; }


        private readonly IProfileService _profileService;

        public ProfilViewModel(INavigationService navigationServices, IProfileService profileService) : this(navigationServices, profileService, new RuntimeContext())
        {
        }

        public ProfilViewModel(INavigationService navigationServices, IProfileService profileService, IRuntimeContext runtimeContext) : base(navigationServices, runtimeContext)
        {
            _profileService = profileService;
            ChangeCommand = new Command(async () => await UpdateProfile(), () => !IsBusy && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(UserName));
            BackCommand = new Command(async () => await Back());
            Genders = new List<string> { "Male", "Female" };
        }

        private async Task Back()
        {
            try
            {
                await _navigationService.NavigateAsync<DrivesViewModel>();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {

            }
        }

        private async Task UpdateProfile()
        {
            try
            {
                IsBusy = true;

                Enums.Genders chosenGender = (Enums.Genders)Enum.Parse(typeof(Enums.Genders), _gender);


                Customer newCustomer = new Customer
                {
                    Email = _email,
                    Id = _runtimeContext.UserId,
                    IsBanned = false,
                    Jmbg = _jmbg,
                    Name = _name,
                    Password = _password,
                    Phone = _phone,
                    Surname = _surname,
                    Username = _userName,
                    Gender = chosenGender,
                    Role = Enums.Roles.Customer


                };

                await _profileService.UpdateProfile(_runtimeContext.UserId, newCustomer, _runtimeContext.Token);
                await _navigationService.NavigateAsync<DrivesViewModel>();

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

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
                ChangeCommand.ChangeCanExecute();
            }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
                ChangeCommand.ChangeCanExecute();
            }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged();
                ChangeCommand.ChangeCanExecute();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
                ChangeCommand.ChangeCanExecute();
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
                ChangeCommand.ChangeCanExecute();
            }
        }
        

        private string _jmbg;
        public string Jmbg
        {
            get { return _jmbg; }
            set
            {
                _jmbg = value;
                OnPropertyChanged();
                ChangeCommand.ChangeCanExecute();


            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
               
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await GetMyProfile();
        }


        private List<string> _genders;
        public List<string> Genders
        {
            get { return _genders; }
            set
            {
                _genders = value;
            }
        }

        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnPropertyChanged();
               
            }
        }

        private async Task GetMyProfile()
        {
            try
            {
                IsBusy = true;

                var profile = await _profileService.GetProfile(_runtimeContext.UserId, _runtimeContext.Token);

                UserName = profile.Username;
                Password = profile.Password;
                Jmbg = profile.Jmbg;
                Name = profile.Name;
                Surname = profile.Surname;
                Email = profile.Email;
                Gender = profile.Gender.ToString();
                Phone = profile.Phone;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
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
                ChangeCommand.ChangeCanExecute();
            }
        }




    }
}
