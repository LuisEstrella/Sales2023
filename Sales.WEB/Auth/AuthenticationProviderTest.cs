using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Sales.WEB.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //await Task.Delay(3000);
            var anonimous = new ClaimsIdentity();
            var EstrellaUser = new ClaimsIdentity(new List<Claim>
        {
            new Claim("FirstName", "Luis"),
            new Claim("LastName", "Estrella"),
            new Claim(ClaimTypes.Name, "luisestre@yopmail.com"),
            new Claim(ClaimTypes.Role, "User")

        },
        authenticationType: "test");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(EstrellaUser)));

        }
    }
}
