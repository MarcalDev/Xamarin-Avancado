using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Mapas01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var mapa = new Map(MapSpan.FromCenterAndRadius(new Position(-15.8190881,-48.0478394), Distance.FromKilometers(1)));
            
            MapContainer.Children.Add(mapa);

        }
    }
}
