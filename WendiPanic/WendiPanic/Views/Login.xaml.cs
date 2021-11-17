using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using WendiPanic.Models;
using WendiPanic.Services;
using WendiPanic.SQLiteDB;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WendiPanic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Usuario user;
        private UserDB userdb;
        public Login()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Error", "Por favor activa tus datos o conectate a una red", "ok");
                btnIniciarSesion.IsVisible = false;
            }
            else
            {
                btnIniciarSesion.IsVisible = true;
            }
        }

        private async void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            //App.Current.MainPage = new Menu();
            try
            {
                btnIniciarSesion.IsVisible = false;
                activityLogin.IsRunning = true;

                userdb = new UserDB();
                var user_exist = userdb.GetMembers().ToList();

                var user = username.Text;
                var pass = password.Text;
                var token = user_exist[0].token;
                ApiRest apirest = new ApiRest();
                //------------------------
                var response = await apirest.GetLogin(user, pass, token);
                if (response.IsSuccessStatusCode)
                {
                    HttpContent resp_content = response.Content;
                    var json2 = resp_content.ReadAsStringAsync();
                    var userResult = JsonConvert.DeserializeObject<List<Usuario>>(await json2);
                    var rol = userResult[0].rol;
                    CrossToastPopUp.Current.ShowToastSuccess("Bienvenida");

                    var idUser = userResult[0].id;
                    var nombre = userResult[0].nombre;
                    var username = userResult[0].username;
                    var password = userResult[0].password;
                    var token_id = userResult[0].token;
                    var status = 1;

                    userdb.UpdateMember(1, idUser, nombre, username, password, rol, status);

                    Application.Current.MainPage = new NavigationPage(new Menu());
                }
                else
                {
                    CrossToastPopUp.Current.ShowToastError("Ocurrio un problema");
                }
                //--------------------

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error EX", "Error : " + ex.ToString(), "OK");
            }
            activityLogin.IsRunning = false;
            btnIniciarSesion.IsVisible = true;


        }
    }
}