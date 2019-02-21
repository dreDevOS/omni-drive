using Omnipotent.Models;
using Omnipotent.Services.Interfaces;
using Omnipotent.Settings;
using Omnipotent.Settings.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Omnipotent.ViewModels
{
    public class DrivesViewModel : ViewModelBase
    {

        private readonly IDriveServices _driveService;
        private readonly IAuthenticationService _authenticateService;

        public Command CreateDriveCommand { get; }
        public Command LogOutCommand { get; }
        public Command ViewProfileCommand { get; }
        public Command<Guid> EditCommand { get; }
        public Command RefreshCommand { get; }

        private ObservableCollection<Drive> _driveList;
        public ObservableCollection<Drive> DriveList
        {
            get { return _driveList; }
            set
            {
                _driveList = value;
                OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await GetAllDrives();
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
                CreateDriveCommand.ChangeCanExecute();
                EditCommand.ChangeCanExecute();
                ViewProfileCommand.ChangeCanExecute();
            }
        }

        private async Task GetAllDrives()
        {
            try
            {
                IsBusy = true;

                var drives = await _driveService.GetAllDrives(_runtimeContext.UserId, _runtimeContext.Token);
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

        public DrivesViewModel(INavigationService navigationService, IAuthenticationService authenticationService, IDriveServices driveServices)
            : this(navigationService, authenticationService, driveServices, new RuntimeContext())
        { }

        public DrivesViewModel(INavigationService navigationService, IAuthenticationService authenticationService, IDriveServices driveServices, IRuntimeContext runtimeContext )
            : base (navigationService, runtimeContext)

        {
            DriveList = new ObservableCollection<Drive>();

            _driveService = driveServices;
            _authenticateService = authenticationService;


            CreateDriveCommand = new Command(async () => await CreateDrive(), () => !IsBusy);
            LogOutCommand = new Command(async () => await LogOut(), () => !IsBusy);
            RefreshCommand = new Command(async () => await Refresh(), () => !IsBusy);
            ViewProfileCommand = new Command(async () => await ViewProfile(), () => !IsBusy);
            EditCommand = new Command<Guid> (async (id) => await Edit(id), (id) => !IsBusy);  
            //search commands = new command(async() => await Search(), () => !IsBusy);
        }

        private async Task Edit(Guid id)
        {
            try
            {
                IsBusy = true;

                var selectedDrive = DriveList.Single(x => x.DriveId == id);


                if (selectedDrive.State == Enums.Status.Created)
                {
                    await _navigationService.NavigateAsync<DriveViewModel>(selectedDrive);
                }
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

        private async Task ViewProfile()
        {

            try
            {
                IsBusy = true;

                await _navigationService.NavigateAsync<ProfilViewModel>();
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");

            }
            finally
            {
                IsBusy = false;
            }
        }
        

        private async Task Refresh()
        {
            try
            {
                IsBusy = true;

                var result = await _driveService.GetAllDrives(_runtimeContext.UserId, _runtimeContext.Token);

                DriveList = new ObservableCollection<Drive>(result);

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

        private async Task LogOut()
        {
            try
            {
                IsBusy = true;
                await _authenticateService.Logout();
                _navigationService.SetRootPage(typeof(LoginViewModel));
                
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

        private async Task CreateDrive()
        {
            try
            {
                IsBusy = true;
                await _navigationService.NavigateAsync<DrivesViewModel>();
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
    }
}
