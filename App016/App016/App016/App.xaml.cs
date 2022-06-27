using App016.ViewModels;
using App016.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace App016
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            App016.Database.Massa.CriarMassaDados();

            await NavigationService.NavigateAsync("NavigationPage/ListaProfissionais");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ListaProfissionais, ListaProfissionaisViewModel>();
            containerRegistry.RegisterForNavigation<DetalheProfissional, DetalheProfissionalViewModel>();
        }
    }
}
