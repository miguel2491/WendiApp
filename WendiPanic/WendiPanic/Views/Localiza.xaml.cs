using Plugin.Geolocator;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace WendiPanic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Localiza : ContentPage
    {
        public Localiza()
        {
            InitializeComponent();
            /*Mapx.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(37, -122), Distance.FromMiles(1)));
            */
            _ = CurrentLocation();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Run(async () => await CurrentLocation());
        }

        public async Task CurrentLocation()
        {
            var pos = await CrossGeolocator.Current.GetPositionAsync();
            var lat = pos.Latitude;
            var lon = pos.Longitude;
            Mapx.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(lat, lon), Distance.FromMiles(-1)));
            Mapx.IsVisible = true;
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(lon, lat),
                Label = "Mi ubicacion",
                Address = "  usted se encuentra aqui",

            };
            Mapx.Pins.Add(pin);
        }
        //*************************************************************************************************
    }
}