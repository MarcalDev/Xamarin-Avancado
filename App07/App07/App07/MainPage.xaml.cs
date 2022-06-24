using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App07
{
    public partial class MainPage : ContentPage
    {
        [Obsolete]
        public MainPage()
        {
            InitializeComponent();

            if(Device.Idiom == TargetIdiom.Tablet)
            {
                Container.BackgroundColor = Color.Aqua;
            }


            if (Device.OS == TargetPlatform.iOS)
            {
                Container.Margin = new Thickness(0, 10, 0, 0);
            }

            Thickness Margin = null;


            Device.OnPlatform(iOS: () =>
            {
                Margin = new Thickness(0, 10, 0, 0);
            },
            Android: ()=>
            {
                Margin = new Thickness(0, 10, 0, 0);
            } ,
            WinPhone: () =>
            {
                Margin = new Thickness(0, 10, 0, 0);
            }
            );

            Container.Margin = Margin;
        }
    }
}
