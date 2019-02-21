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
	public partial class ProfileViews : ContentPage
	{
        ProfilViewModel _profilViewModel;



		public ProfileViews ()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);

            _profilViewModel = new ProfilViewModel(AppBootstrapper.NavigationService, AppBootstrapper.ProfileService);
            BindingContext = _profilViewModel;



		}

        protected override async void OnAppearing()
        {
            await _profilViewModel.InitializeAsync(null);
        }
	}
}