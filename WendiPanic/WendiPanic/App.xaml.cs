using System;
using WendiPanic.Services;
using WendiPanic.Splash;
using WendiPanic.Views;
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
            MainPage = new NavigationPage(new OAuth());
        }

        public void OnRingAlarmExec()
        {

        }

        protected override void OnStart()
        {
            Console.WriteLine("Comienzo");
        }

        protected override void OnSleep()
        {
            //subscribee sound event
            Console.WriteLine("Dormido");

        }

        protected override void OnResume()
        {
            Console.WriteLine("Continuando");
        }
    }
}
