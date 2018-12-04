using System;
using Autofac;
using CockroachRaces.Providers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace CockroachRaces
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }



        public void ConfigureAuth(IAppBuilder app, IContainer container)
        {



            var PublicClientId = "self";

            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                // устанавливает URL, по которому клиент будет получать токен
                TokenEndpointPath = new PathString("/token"),
                // указывает на вышеопределенный провайдер авторизации
                Provider = new ApplicationOAuthProvider(PublicClientId, container),
                AuthorizeEndpointPath = new PathString("/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };




            // включает в приложении функциональность токенов
            app.UseOAuthBearerTokens(OAuthOptions);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            //app.UseCookieAuthentication(new CookieAuthenticationOptions {
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            //    LoginPath = new PathString("/User/Login"),
            // });


            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);


            //app.UseWebApi(container.Resolve<HttpConfiguration>());
            //app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            //app.CreatePerOwinContext<CrazyDogsContext>(CrazyDogsContext.Create);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions() {
            //    ClientId = "20664109382-988qsd809ept3i5m34hu8ueh457io4tf.apps.googleusercontent.com",
            //    ClientSecret = "R2_ks3TTNkcj-Rw2F-Prynkw"
            //});

        }
    }
}