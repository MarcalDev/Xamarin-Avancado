using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App017
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            LblWelcome.FontFamily = Device.OnPlatform(
                null,
                "Montserrat",
                null
                );
        }
    }
}
