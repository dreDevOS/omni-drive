using Omnipotent.Models;
using Omnipotent.Services.Interfaces;
using Omnipotent.Settings;
using Omnipotent.Settings.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnipotent.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRequestService _requestService;
        private readonly IRuntimeContext _runtimeContext;

        public AuthenticationService(IRequestService requestService)
            : this(requestService, new RuntimeContext())
        { }

        public AuthenticationService(IRequestService requestService, IRuntimeContext runtimeContext)
        {
            _requestService = requestService;
            _runtimeContext = runtimeContext;
        }
        public async Task<bool> Login(string userName, string password)
        {
            UriBuilder builder = new UriBuilder(_runtimeContext.BaseEndpoint)
            {
                Path = "api/Login/SignIn"
            };

            LoginClass login = new LoginClass
            {
                Password = password,
                Username = userName
            };

            var message = await _requestService.PostAsync<LoginClass, LoginDto>(builder.Uri, login);

            _runtimeContext.Token = message.AccessToken.ToString();
            _runtimeContext.UserId = message.User.Id;

            return await Task.FromResult(true);
        }

        public Task<bool> Logout()
        {
            _runtimeContext.RemoveToken();
            _runtimeContext.RemoveUserId();
            return Task.FromResult(true);
        }
    }
}
