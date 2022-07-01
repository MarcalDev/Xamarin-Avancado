using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Newtonsoft.Json;
using Xamarin.Auth;

using App018.Droid;
using App018.Views;


[assembly:ExportRenderer(typeof(LoginFacebook), typeof(LoginFacebookRenderer))]
namespace App018.Droid
{
    public class LoginFacebookRenderer : PageRenderer
    {
        [Obsolete]
        public LoginFacebookRenderer()
        {
            //Usando o OAuth(Xamarin.Auth)
            // 2 autenticações - 1 para o usuário e um para o cliente
            var oauth = new OAuth2Authenticator(
                clientId: "#idDoCliente",
                scope:"email",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("https://m.facebook.com/connect/login_success.html")
                );

            // Ao completar o OAuth
            oauth.Completed += async (sender, args) =>
            {
                if (args.IsAuthenticated)
                {
                    //Acesso aos dados - Token de Acesso
                    var token = args.Account.Properties["access_token"].ToString();

                    
                    var requisicao = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me?fields=name,email"),
                        null, args.Account);

                    var resposta = await requisicao.GetResponseAsync();

                    dynamic obj = JsonConvert.DeserializeObject( resposta.GetResponseText());

                    var Nome = obj.name.ToString();

                    var Email = obj.email.ToString();

                    App.NavegarParaInicial(Nome, Email);

                }
                else
                {
                    App.NavegarParaInicial("Login rejeitado");
                }
            };



            //API do Android - Xamarin.Android;
            var activity = this.Context as Activity;

            activity.StartActivity(oauth.GetUI(activity));
        }

    }
}