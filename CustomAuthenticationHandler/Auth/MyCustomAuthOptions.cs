using Microsoft.AspNetCore.Authentication;

namespace CustomAuthenticationHandler.Auth
{
    //Step 06 - Op��es de configura��o para o handler de autentica��o customizado
    public class MyCustomAuthOptions : AuthenticationSchemeOptions
    {
        public string ForbiddenPage { get; set; }
        public string LoginPage { get; set; }

        public override void Validate()
        {
            base.Validate();
        }
    }
}