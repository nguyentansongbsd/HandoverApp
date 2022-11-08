using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HandoverApp.Views;
using System.Globalization;
using HandoverApp.Settings;
using HandoverApp.Resources;

namespace HandoverApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            CultureInfo cultureInfo = new CultureInfo(UserLogged.Language);
            Language.Culture = cultureInfo;
            MainPage = new AppShell();
            Shell.Current.GoToAsync("//LoginPage");
            //MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
