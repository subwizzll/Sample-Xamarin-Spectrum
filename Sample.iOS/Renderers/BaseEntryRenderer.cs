using System;
using Sample.Core.Controls;
using Sample.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(BaseEntryRenderer), new[] { typeof(BaseVisual) })]
namespace Sample.iOS.Renderers
{
    public class BaseEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null || Control == null) 
                return;
            Control.BorderStyle = UITextBorderStyle.None;
            Control.Layer.CornerRadius = 4f;
        }
    }
}