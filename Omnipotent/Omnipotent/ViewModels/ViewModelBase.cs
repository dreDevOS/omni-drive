using Omnipotent.Services.Interfaces;
using Omnipotent.Settings.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Omnipotent.ViewModels
{
   public abstract class ViewModelBase : BindableObject
    {

        protected readonly INavigationService _navigationService;
        protected readonly IRuntimeContext _runtimeContext;
        private IDriveServices driveServices;
        private IProfileService profileService;
        private IRuntimeContext runtimeContext;

        public ViewModelBase(INavigationService navigationServices)
        {
            _navigationService = navigationServices;
        }

        public ViewModelBase(INavigationService navigationServices, IRuntimeContext runtimeContext)
        {
            _navigationService = navigationServices;
            _runtimeContext = runtimeContext;

        }

        public ViewModelBase(INavigationService navigationServices, IDriveServices driveServices, IProfileService profileService, IRuntimeContext runtimeContext) : this(navigationServices)
        {
            this.driveServices = driveServices;
            this.profileService = profileService;
            this.runtimeContext = runtimeContext;
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
        public virtual void Initialize(object navigationData)
        {

        }
    }
}
