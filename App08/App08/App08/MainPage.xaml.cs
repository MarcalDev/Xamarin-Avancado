using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App08
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public MainPage()
        {
            InitializeComponent();
            PanGestureRecognizer pan = new PanGestureRecognizer();
            pan.PanUpdated += PanGestureRecognizer_Pan;

            MyLabel.GestureRecognizers.Add(pan);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            count++;
            //   DisplayAlert("Tapped", "Label tocada/clicada" + count, "OK");
            //MyBox.TranslateTo(200, 350, 1000, Easing.BounceOut);
            //MyBox.ScaleTo(2, 1000);
            //MyBox.FadeTo(0.5, 1000);
            //MyBox.RotateTo(45, 1000, Easing.SpringOut);

            var anim = new Animation(v => MyBox.WidthRequest = v, 10, 300);
            var anim2 = new Animation(v => MyBox.BackgroundColor = Color.FromHsla(v, 2, 0.2), start: 0, end: 1);
            anim.Commit(this, "animação", 2, 1000);
            anim2.Commit(this, "animação 2", 16, 4000, Easing.Linear);
        }
        
        private void PanGestureRecognizer_Pan(object sender, PanUpdatedEventArgs e)
        {
            if(e.StatusType == GestureStatus.Running)
            {
                Rectangle rect = new Rectangle(e.TotalX, e.TotalY, 200, 25);

                AbsoluteLayout.SetLayoutBounds(MyLabel, rect);
                AbsoluteLayout.SetLayoutFlags(MyLabel, AbsoluteLayoutFlags.None);

            }
        }
    }
}
