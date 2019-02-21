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
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
          //  image.Source = ImageSource.FromResource("TaxiApp.Images.taxi1.jpg");

           // BindingContext = new LoginViewModel(AppBootstrapper.NavigationService, AppBootstrapper.AuthenticationService, AppBootstrapper.ProfileService);
        }
    }
}