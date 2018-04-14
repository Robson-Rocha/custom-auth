using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomAuthenticationHandler.Auth
{
    //Step 04
    public static class MyCustomAuthExtensions
    {
        //Step 05
        public static AuthenticationBuilder AddMyCustomAuth(this AuthenticationBuilder builder, Action<MyCustomAuthOptions> configureOptions = null)
        {
            //Step 07
            return builder.AddScheme<MyCustomAuthOptions, MyCustomAuthHandler>(MyCustomAuthSchemes.UserScheme, configureOptions)
                          .AddScheme<MyCustomAuthOptions, MyCustomAuthHandler>(MyCustomAuthSchemes.AdminScheme, configureOptions);
        }
    }
}
