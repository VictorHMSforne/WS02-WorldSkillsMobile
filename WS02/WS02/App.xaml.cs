using System;
using WS02.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WS02
{
    public partial class App : Application
    {
        public static String DbName; //adicionado
        public static String DbPath; //adicionado
        public App() //primeira vez que inicia o app
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PageHome()); // substituiu pelo PageHome
        }

        public App(string dbPath, string dbName) //segunda vez que inicia o app
        {
            InitializeComponent();
            App.DbName = dbName;
            App.DbPath = dbPath;
            MainPage = new NavigationPage(new PageHome());
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
