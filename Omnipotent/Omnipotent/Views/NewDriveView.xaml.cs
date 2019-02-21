﻿using Omnipotent.ViewModels;
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
	public partial class NewDriveView : ContentPage
	{

        NewDriveViewModel _newDriveViewModel;
		public NewDriveView ()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);

            _newDriveViewModel = new NewDriveViewModel(AppBootstrapper.NavigationService, AppBootstrapper.DriveServices, AppBootstrapper.ProfileService);
            BindingContext = _newDriveViewModel;
		}
	}
}