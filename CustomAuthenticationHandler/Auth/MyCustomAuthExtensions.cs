using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomAuthenticationHandler.Auth
{
    //Step 04 - Classe com métodos de extensão para injeção dos esquemas de autenticação
    public static class MyCustomAuthExtensions
    {
        //Step 05 - Método de injeção
        public static AuthenticationBuilder AddMyCustomAuth(this AuthenticationBuilder builder, Action<MyCustomAuthOptions> configureOptions = null)
        {
            //Step 07 - Adição dos esquemas de autenticação
            return builder.AddScheme<MyCustomAuthOptions, MyCustomAuthHandler>(MyCustomAuthSchemes.UserScheme, configureOptions)
                          .AddScheme<MyCustomAuthOptions, MyCustomAuthHandler>(MyCustomAuthSchemes.AdminScheme, configureOptions);
        }
    }
}
