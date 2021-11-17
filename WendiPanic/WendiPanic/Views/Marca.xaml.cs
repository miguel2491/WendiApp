
using Newtonsoft.Json;
using Plugin.Toast;
using System.Collections.Generic;
using System.Linq;
using WendiPanic.Models;
using WendiPanic.Services;
using WendiPanic.SQLiteDB;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WendiPanic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Marca : ContentPage
    {
        public Usuario user;
        private UserDB userdb;

        public Marca()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            //--------------------------------------------------
            userdb = new UserDB();
            var user_exist = userdb.GetMembers().ToList();
            var id_usr = user_exist[0].id_user;
            var ussr = user_exist[0].nombre;
            var roll = user_exist[0].rol;
            //--------------------------------------------------
            ApiRest apirest = new ApiRest();
            var response = await apirest.GetChalecas();
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var userResult = JsonConvert.DeserializeObject<List<Usuario>>(content);

                Gender.Items.Clear();
                if (roll == "Sindica")
                {
                    foreach (var item in userResult)
                    {
                        if (ussr != item.nombre)
                        {
                            Gender.Items.Add(item.nombre);
                        }
                    }
                }
                else {
                    foreach (var item in userResult)
                    {
                        if ("Wendi Cruz Hernandez" == item.nombre)
                        {
                            Gender.Items.Add(item.nombre);
                        }
                    }
                }
            }

        }

        private async void btnCall_Clicked(object sender, System.EventArgs e)
        {
            int selectedIndex = Gender.SelectedIndex;
            var chaleca = "";
            if (selectedIndex != -1)
            {
                chaleca = Gender.Items[selectedIndex];
            }
            var mensaje = Message.Text;
            //---------------------------------------------------------------------------
            ApiRest apirest = new ApiRest();
            var response = await apirest.SendLlamada("2",chaleca,mensaje);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Respuesta>(json);
                var succ = result.success;
                var failure = result.failure;
                //var Resultd = JsonConvert.DeserializeObject<List<Respuesta>>(json);
                if (succ == 1)
                {
                    CrossToastPopUp.Current.ShowToastSuccess("Aviso Enviado");
                }
                if(failure == 1) {
                    CrossToastPopUp.Current.ShowToastError("Vuelve a intentar no se ha notificado");
                }
            }
            //---------------------------------------------------------------------------
            Message.Text = "";
        }
    }
}