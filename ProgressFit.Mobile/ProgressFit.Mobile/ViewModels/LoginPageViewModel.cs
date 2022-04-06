using IdentityModel.OidcClient;
using ProgressFit.Mobile.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using System.Net.Http;
using IdentityModel.OidcClient.Browser;
using System.Net.Http.Headers;
using System.ComponentModel;
using IdentityModel.Client;

namespace ProgressFit.Mobile.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged// : ViewModelBase
    {
        OidcClient _client;
        LoginResult _result;

        Lazy<HttpClient> _apiClient = new Lazy<HttpClient>(() => new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler()));

        public LoginPageViewModel()//INavigationService navigationService) : base(navigationService)
        {
            var browser = DependencyService.Get<IBrowser>();

            var options = new OidcClientOptions
            {
                Authority = "https://10.0.2.2:5001",
                ClientId = "xamarin",
                Scope = "openid profile offline_access progressfit-api",
                RedirectUri = "xamarinformsclients://callback",
                Browser = browser,
                BackchannelHandler = DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler()
            };

            _client = new OidcClient(options);
            _apiClient.Value.BaseAddress = new Uri("https://10.0.2.2:5001");
        }

        public ICommand LoginCommand => new Command(OnLogin);

        public ICommand RegisterCommand => new Command(OnRegister);

        public event PropertyChangedEventHandler PropertyChanged;

        private async void OnLogin()
        {
            _result = await _client.LoginAsync(new LoginRequest());

            if (_result.IsError)
            {
                //OutputText.Text = _result.Error;
                return;
            }

            var sb = new StringBuilder(128);
            foreach (var claim in _result.User.Claims)
            {
                sb.AppendFormat("{0}: {1}\n", claim.Type, claim.Value);
            }

            sb.AppendFormat("\n{0}: {1}\n", "refresh token", _result?.RefreshToken ?? "none");
            sb.AppendFormat("\n{0}: {1}\n", "access token", _result.AccessToken);

            //OutputText.Text = sb.ToString();

            _apiClient.Value.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _result?.AccessToken ?? "");
        }

        private async void OnRegister()
        {
            //var result = await _apiClient.Value.GetAsync("account/register");
            var disco = await _apiClient.Value.GetDiscoveryDocumentAsync();
            var tokenResponse = await _apiClient.Value.RequestAuthorizationCodeTokenAsync(new AuthorizationCodeTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "xamarin",
                ClientCredentialStyle = ClientCredentialStyle.AuthorizationHeader
            });

            //if (result.IsSuccessStatusCode)
            //{
            //    //OutputText.Text = JsonDocument.Parse(await result.Content.ReadAsStringAsync()).RootElement.GetRawText();
            //}
            //else
            //{
            //    //OutputText.Text = result.ReasonPhrase;
            //}
        }
    }
}
