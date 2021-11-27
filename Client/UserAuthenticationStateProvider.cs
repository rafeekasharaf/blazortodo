using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ToDo.Shared;
using System.Net.Http.Json;

namespace ToDo.Client
{
    public class UserAuthenticationStateProvider: AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
       // private readonly ILocalStorageService _localStorage;

        public UserAuthenticationStateProvider(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync() {
            Users currentUser = await _httpClient.GetFromJsonAsync<Users>("users/getcurrentuser");

            if (currentUser != null && currentUser.Email != null)
            { 
                 //create a claims
                var claimEmailAddress = new Claim(ClaimTypes.Name, currentUser.Email);
                var claimNameIdentifier = new Claim(ClaimTypes.NameIdentifier, Convert.ToString(currentUser.Email));
                //create claimsIdentity
                var claimsIdentity = new ClaimsIdentity(new[] { claimEmailAddress, claimNameIdentifier }, "serverAuth");
                //create claimsPrincipal
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                return new AuthenticationState(claimsPrincipal);
            }
            else
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            
        }
    }
}