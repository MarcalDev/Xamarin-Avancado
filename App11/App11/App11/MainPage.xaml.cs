using App11.Traducao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App11
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Lang.AppLang.Culture = DependencyService.Get<ILocale>().GetCurrentCultureInfo();
            //Lang.AppLang.Culture = new System.Globalization.CultureInfo("pt-BR");
            LblMsg.Text = Lang.AppLang.MSG_01;
        }
    }
}
