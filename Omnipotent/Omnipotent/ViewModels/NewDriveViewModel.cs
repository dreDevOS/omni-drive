using Omnipotent.Models;
using Omnipotent.Services.Interfaces;
using Omnipotent.Settings;
using Omnipotent.Settings.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Omnipotent.ViewModels
{
    public  class NewDriveViewModel : ViewModelBase 
    {

        private readonly IDriveServices _driveServices;
        private readonly IProfileService _profileService;
        

        public  Command BackCommand { get; }
        public Command NewDriveCommand { get; }

        private List<string> _carTypes;
        public List<string> CarTypes
        { get { return _carTypes; }


         set {
                _carTypes = value;
                OnPropertyChanged();
                NewDriveCommand.ChangeCanExecute();
            }

        }

        public NewDriveViewModel(INavigationService navigationService, IDriveServices driveServices, IProfileService profileService) : this(navigationService, driveServices, profileService, new RuntimeContext()) { }

        public NewDriveViewModel(INavigationService navigationServices, IDriveServices driveServices, IProfileService profileService, IRuntimeContext runtimeContext) : base(navigationServices, driveServices, profileService, runtimeContext)
        {



            _driveServices = driveServices;
            _profileService = profileService;


            BackCommand = new Command(async () => await Back(), () => !IsBusy);

            NewDriveCommand = new Command(async () => await NewDrive(), () => !IsBusy);


            CarTypes = new List<string> { "Honda_stream, Car, suv" };
            CarType = "Honda_Stream";
        }



        private async Task NewDrive()
        {
            try
            {
                IsBusy = true;
                var profile = await _profileService.GetProfile(_runtimeContext.UserId, _runtimeContext.Token);


                Drive newDrive = new Drive
                {
                    Address =
                    {
                    //    Address = Address,
                     //   X = Double.Parse(XAxis),
                      //  Y = Double.Parse(YAxis)
                    },

                    CarType = (Enums.CarTypes)Enum.Parse(typeof(Enums.CarTypes), this.CarType),
                };
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
        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged();
                NewDriveCommand.ChangeCanExecute();
            }
        }
        private string _yAxis;
        public string YAxis
        {
            get { return _yAxis; }

            set
            {
                _yAxis = value;
                OnPropertyChanged();
                NewDriveCommand.ChangeCanExecute();
            }
        }

        private string _xAxis;
        public string XAxis
        {
            get { return _xAxis; }

            set
            {
                _xAxis = value;
                OnPropertyChanged();
                NewDriveCommand.ChangeCanExecute();

            }
        }

        private async Task Back()
        {
            try
            {
                await _navigationService.NavigateAsync<DrivesViewModel>();


            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally { }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
                BackCommand.ChangeCanExecute();
                NewDriveCommand.ChangeCanExecute();
            }
        }


        private string _carType;
        public string CarType
        { get { return _carType; }
          set
            {
                _carType = value;
                OnPropertyChanged();
                NewDriveCommand.ChangeCanExecute();

            }
        }
    }


    }

