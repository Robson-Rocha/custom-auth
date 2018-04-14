using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CustomAuthenticationHandler.Auth
{
    //Step 08 - Handler de AUtenticação Customizado
    public class MyCustomAuthHandler : AuthenticationHandler<MyCustomAuthOptions>
    {
        //Step 09 - Construtor invocando o base
        public MyCustomAuthHandler(IOptionsMonitor<MyCustomAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        //Step 10 - Método para autenticação de requisições
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    if (!Request.Query.ContainsKey("key"))
                        return AuthenticateResult.Fail("No key provided");

                    string userKey = Request.Query["key"];
                    User user = Users.RegisteredUsers.FirstOrDefault(u => u.Key == userKey);
                    if (user == null)
                        return AuthenticateResult.Fail($"No user with key {userKey} was found");

                    if (Scheme.Name == MyCustomAuthSchemes.UserScheme && !user.Profiles.Contains("User"))
                        return AuthenticateResult.Fail($"User does not belong to 'User' profile");

                    if (Scheme.Name == MyCustomAuthSchemes.AdminScheme && !user.Profiles.Contains("Admin"))
                        return AuthenticateResult.Fail($"User does not belong to 'Admin' profile");

                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Name, ClaimValueTypes.String, Options.ClaimsIssuer),
                        new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email, Options.ClaimsIssuer),
                    };

                    claims.AddRange(user.Profiles.Select(profile => new Claim(ClaimTypes.Role, profile, ClaimValueTypes.String, Options.ClaimsIssuer)));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, "MyCustomAuthToken");
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return AuthenticateResult.Success(ticket);
                }
                catch (Exception ex)
                {
                    return AuthenticateResult.Fail(ex);
                }
            });
        }

        //Step 13 - Processamento de Challenges - Quando a aplicação requer que o usuário se autentique
        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.Redirect(Options.LoginPage + "?returnUrl=" + UriHelper.GetEncodedUrl(Request));
            return Task.CompletedTask;
        }

        //Step 18 - Processamento de acessos não autorizados - quando o usuário está autenticado, mas não tem acesso
        protected override Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            Response.Redirect(Options.ForbiddenPage);
            return Task.CompletedTask;
        }
    }
}