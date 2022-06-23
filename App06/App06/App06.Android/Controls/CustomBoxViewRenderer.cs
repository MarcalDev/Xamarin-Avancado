using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App06.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace App06.Droid.Controls
{
    [Obsolete]
    public class CustomBoxViewRenderer : BoxRenderer
    {
        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

            CustomBoxView control = (CustomBoxView)Element;

            Paint p = new Paint();
            p.StrokeWidth = (float)control.Espessura

            canvas.DrawLine(100,0, 100, 100, p);
        }
    }
}