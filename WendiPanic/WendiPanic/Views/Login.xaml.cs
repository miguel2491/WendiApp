using Plugin.Connectivity;
using System;
using System.Linq;
using WendiPanic.Models;
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

                var user = usuario.Text;
                var pass = password.Text;
                var token = user_exist[0].token;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error EX", "Error : " + ex.ToString(), "OK");
            }
            activityLogin.IsRunning = false;
            btnIniciarSesion.IsVisible = true;

            Application.Current.MainPage = new NavigationPage(new Menu());
        }
    }
}