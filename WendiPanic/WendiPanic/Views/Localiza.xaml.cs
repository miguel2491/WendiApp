using Plugin.Geolocator;
using System.Threading.Tasks;
using Xamarin.Forms;
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

        public async Task CurrentLocation()
        {
            var pos = await CrossGeolocator.Current.GetPositionAsync();
            var lat = pos.Latitude;
            var lon = pos.Longitude;

        }
        //*************************************************************************************************
    }
}