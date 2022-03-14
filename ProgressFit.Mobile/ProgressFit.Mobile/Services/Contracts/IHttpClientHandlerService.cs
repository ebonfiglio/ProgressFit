using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ProgressFit.Mobile.Services.Contracts
{
    public interface IHttpClientHandlerService
    {
        HttpClientHandler GetInsecureHandler();
    }
}
