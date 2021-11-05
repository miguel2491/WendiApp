using WendiPanic.Services;
using WendiPanic.Splash;
using Xamarin.Forms;

namespace WendiPanic
{
    public partial class App : Application //, IOnRingAlarm (implementa OnRingAlarmExec, tner un handler)
    {

        public App()
        {
            InitializeComponent();
            //  handler(IOnRingAlarm) = this; 
            //subcribe here onRingalarm
            //msn.suscribe<dedonde,objetoquerecibo>("onRingAlaarm",OnRingAlarmExec());
            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new SplashScreen());
        }

        public void OnRingAlarmExec()
        {

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            //subscribee sound event

        }

        protected override void OnResume()
        {
        }
    }
}
