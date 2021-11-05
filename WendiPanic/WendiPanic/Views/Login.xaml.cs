using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WendiPanic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            //App.Current.MainPage = new Menu();
            Application.Current.MainPage = new NavigationPage(new Menu());
        }
    }
}