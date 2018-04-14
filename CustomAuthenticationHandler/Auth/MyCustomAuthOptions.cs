using Microsoft.AspNetCore.Authentication;

namespace CustomAuthenticationHandler.Auth
{
    //Step 06
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