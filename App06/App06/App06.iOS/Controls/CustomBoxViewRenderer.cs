using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using App06.Controls;
using CoreGraphics;
using System.ComponentModel;

[assembly:ExportRenderer(typeof(CustomBoxView), typeof(App06.iOS.Controls.CustomBoxViewRenderer))]
namespace App06.iOS.Controls
{
    public class CustomBoxViewRenderer : BoxRenderer
    {
        public override void Draw(CGRect rect)
        {
            CustomBoxView control = (CustomBoxView)Element;

            using (var context = UIGraphics.GetCurrentContext())
            {
                context.SetStrokeColor(new CGColor(0, 0, 0));
                context.SetLineWidth((float) control.Espessura);

                var rectPath = new CGRect(0, 0, 200, 200);


                context.AddRect(rectPath);
                context.DrawPath(CGPathDrawingMode.Stroke);
            }
            //base.Draw(rect);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == CustomBoxView.EspessuraProperty.PropertyName)
            {
                SetNeedsDisplay();
            }

            //base.OnElementPropertyChanged(sender, e);
        }
    }
}