using Omnipotent.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Omnipotent.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DrivesView : ContentPage

	{
        DrivesViewModel drivesViewModel;
		public DrivesView ()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);
            drivesViewModel = new DrivesViewModel(AppBootstrapper.NavigationService, AppBootstrapper.AuthenticationService, AppBootstrapper.DriveServices);
            BindingContext = drivesViewModel;

        }

        protected override async void OnAppearing()
        {
            await drivesViewModel.InitializeAsync(null);
        }
    }
}