using QualtricsPOC.Entities;
using QualtricsPOC.Interfaces;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace QualtricsPOC.Services

{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpService _httpService;
        private string datacentreId;
        public AuthenticationService(IHttpService httpService) {
            _httpService = httpService;
            datacentreId = "fra1";
        }
        public async Task GenerateAccessToken(string scope)
        {
            Authentication authentication = new Authentication(); 
            string uri = "https://" + datacentreId + ".qualtrics.com/oauth2/token?scope=" + scope;

           await _httpService.AuthPost(uri);

        }

    }
}
