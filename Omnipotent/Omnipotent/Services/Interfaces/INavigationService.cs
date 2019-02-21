using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnipotent.Services.Interfaces
{
   public interface INavigationService
    {

        void Register<TView, TViewModel>();
        Task NavigateAsync<TViewModel>(bool animated = true);
        Task NavigateAsync<TViewMOdel>(object paramter, bool animate = true);
        void SetRootPage(Type viewModelType);
    }
}
