using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App018.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            LoginFacebookCommand = new DelegateCommand(LoginFacebook);
            Title = "Main Page";
        }

        public DelegateCommand LoginFacebookCommand { get; set; }

        public void LoginFacebook()
        {
            App.Current.MainPage = new Views.LoginFacebook();
        }

    }
}
