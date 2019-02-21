using Omnipotent.Services;
using Omnipotent.Services.Interfaces;
using Omnipotent.ViewModels;
using Omnipotent.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnipotent
{
   public class AppBootstrapper
    {


        public static INavigationService NavigationService => new NavigationService();
        public static IRequestService RequestService => new RequestService();
        public static IAuthenticationService AuthenticationService => new AuthenticationService(RequestService);
        public static IProfileService ProfileService => new ProfileService(RequestService, AuthenticationService);
        public static IDriveServices DriveServices => new DriveServices(RequestService, AuthenticationService);


        public void Initialize()
        {

            NavigationService.Register<StartView, StartViewModel>();
            NavigationService.Register<LoginView, LoginViewModel>();
            NavigationService.Register<RegisterView, RegisterViewModel>();
            NavigationService.Register<DrivesView, DrivesViewModel>();
            NavigationService.Register<DriveView, DriveViewModel>();
            NavigationService.Register<ProfileService, ProfilViewModel>();
            NavigationService.Register<CommentView, CommentViewModel>();
            NavigationService.Register<NewDriveView, NewDriveViewModel>();
            NavigationService.Register<EditDriveView, EditDriveViewModel>();


        }
    }

}
