using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomAuthenticationHandler.Auth
{
    //Step 04 - Classe com m�todos de extens�o para inje��o dos esquemas de autentica��o
    public static class MyCustomAuthExtensions
    {
        //Step 05 - M�todo de inje��o
        public static AuthenticationBuilder AddMyCustomAuth(this AuthenticationBuilder builder, Action<MyCustomAuthOptions> configureOptions = null)
        {
            //Step 07 - Adi��o dos esquemas de autentica��o
            return builder.AddScheme<MyCustomAuthOptions, MyCustomAuthHandler>(MyCustomAuthSchemes.UserScheme, configureOptions)
                          .AddScheme<MyCustomAuthOptions, MyCustomAuthHandler>(MyCustomAuthSchemes.AdminScheme, configureOptions);
        }
    }
}
