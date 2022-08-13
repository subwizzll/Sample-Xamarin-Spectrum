using Android.Content;
using Android.Graphics.Drawables;
using Sample.Core.Controls;
using Sample.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(BaseEntryRenderer), new[] { typeof(BaseVisual) })]
namespace Sample.Droid.Renderers
{
    public class BaseEntryRenderer : EntryRenderer
    {
        public BaseEntryRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
                return;
            
            Control.SetPadding(0, 0, 0, 0);
            Control.Background = DrawBackground();
        }

        Drawable DrawBackground()
        {
            var background = new GradientDrawable();
            SetBackgroundColor(ref background , Element.BackgroundColor);
            SetCornerRadius(ref background , 4);
            return background;
        }

        void SetBackgroundColor(ref GradientDrawable background, Color backgroundColor)
        {
            Control.Background = null;
            Element.BackgroundColor = Color.Transparent;
            backgroundColor = backgroundColor != Color.Default ? backgroundColor : Color.Transparent;
            background.SetColor(backgroundColor.ToAndroid());
        }

        void SetCornerRadius(ref GradientDrawable background, float borderRadius)
        {
            var radius = Forms.Context.ToPixels(borderRadius);
            if (radius > 0)
                background.SetCornerRadius(radius);
        }
    }
}