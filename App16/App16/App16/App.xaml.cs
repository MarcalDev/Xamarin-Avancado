using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using App16.Views;
using Prism.Ioc;
using Prism;

namespace App16
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/LoginPage");

            App.Current.MainPage = new NavigationPage(new LoginPage());
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Container.RegisterTypeForNavigation<NavigationPage>();
            //Container.RegisterTypeForNavigation<LoginPage>();
        }
    }
}
