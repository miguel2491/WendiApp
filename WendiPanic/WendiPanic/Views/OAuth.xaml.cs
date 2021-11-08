using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace WendiPanic.Views
{
    public partial class OAuth : ContentPage
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public OAuth()
        {
            InitializeComponent();
        }

        async void oAuthBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            UserName = userName.Text;
            Password = password.Text;

            if (string.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Password))
            {
                await DisplayAlert("Error","Password or Username necesary","ok");
            }
            else {
                HttpClient client = new HttpClient();
                var @params = new Dictionary<string, string>
                         {
                            { "username", UserName},
                            {"password" , Password },
                            {"token" , "" }
                         };

                
                var content = new FormUrlEncodedContent(@params);
                try
                {
                    var resp = await client.PostAsync("https://wenpanic.000webhostapp.com/api/usuario", content);
                    if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                    }
                    else
                    {
                        var ex = resp.RequestMessage;
                        await DisplayAlert("Error", $"{ex}", "ok");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"{ex}", "ok");
                }
                
            }
        }
    }
}
