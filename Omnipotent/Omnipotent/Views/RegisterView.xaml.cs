using Omnipotent.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Omnipotent.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterView : ContentPage
	{
		public RegisterView ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new RegisterViewModel(AppBootstrapper.NavigationService, AppBootstrapper.ProfileService);
		}
	}
}