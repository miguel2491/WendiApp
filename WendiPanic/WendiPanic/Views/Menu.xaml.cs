
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace WendiPanic.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : Xamarin.Forms.TabbedPage
    {
        public Menu()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}