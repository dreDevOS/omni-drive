using Omnipotent.Models;
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
     public  class EditDriveViewModel : ViewModelBase
    {

        private readonly IDriveServices _driveServices;

        public Command BackCommand { get; }

        public Command NewDriveCommand { get; }

        public Command QuitDriveCommand { get; }


        public EditDriveViewModel(INavigationService navigationService, IDriveServices driveServices) : this(navigationService, driveServices, new RuntimeContext()) { }
        public EditDriveViewModel(INavigationService navigationService, IDriveServices driveServices, IRuntimeContext runtimeContext) : base(navigationService, runtimeContext)
        {
            _driveServices = driveServices;


            BackCommand = new Command(async () => await Back(), () => !IsBusy);
            NewDriveCommand = new Command(async () => await EditDrive(), () => !IsBusy);
            QuitDriveCommand = new Command(async () => await QuitDrive(), () => !IsBusy);



            CarTypes = new List<string> { "Honda_Stream, Car, SUV" };
            CarType = "HOnda_Stream";

        }

        private List<string> _carTypes;
        public List<string> CarTypes
        {
            get { return _carTypes; }
            set
            {
                _carTypes = value;
            }
        }

        private async Task QuitDrive()
        {
            try
            {
                IsBusy = true;
                Drive newDrive = new Drive
                {
                    Address =
                    {


                    },
                    DriveId  = _selectedDrive.DriveId,
                    CarType = (Enums.CarTypes)Enum.Parse(typeof(Enums.CarTypes), this.CarType)
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

        private string _carType;
        public string CarType
        {
            get { return _carType; }

            set
            {
                _carType = value;
                OnPropertyChanged();
                
            }
        }

        private Guid _driveId;
        private Drive _selectedDrive;

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

        private string _xAxis;
        public  string XAxis
        {
            get { return _xAxis; }

            set
            {
                _xAxis = value;
                OnPropertyChanged();
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

        public override void Initialize(object navigationData)
        {
            try
            {
                IsBusy = true;


                var drive = navigationData as Drive;


                _selectedDrive = drive;

                //  Address = drive.Address.Address;
                //  XAxis = drive.Address.X.ToString();
                // YAxis = drive.Y.ToString();
                   CarType = drive.CarType.ToString();

                _driveId = drive.DriveId;
            }
            catch (Exception ex)
            {
                 Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        private async Task EditDrive()
        {
           try
            {
                IsBusy = true;

                Drive newDrive = new Drive
                {
                    Address =
                    {
                       // Address = Address,
                      //  X = Double.Parse(XAxis),
                      //  Y = Double.Parse(YAxis)
 
                    },
                    DriveId = _selectedDrive.DriveId,
                    CarType = (Enums.CarTypes)Enum.Parse(typeof(Enums.CarTypes), this.CarType)
                };
                await _driveServices.QuitDrive(_runtimeContext.Token, newDrive);

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

            }
        }
    }
}
