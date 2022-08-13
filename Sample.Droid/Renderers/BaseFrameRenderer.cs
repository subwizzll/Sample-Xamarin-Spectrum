using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Sample.Core.Controls;
using System.ComponentModel;
using Android.Graphics;
using Sample.Droid.Renderers;

[assembly: ExportRenderer(typeof(BaseFrame), typeof(BaseFrameRenderer))]
namespace Sample.Droid.Renderers
{
    public class BaseFrameRenderer : Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer
    { 
        public BaseFrameRenderer(Context context) : base(context)
            => SetWillNotDraw(false);

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            var frame = Element as BaseFrame;
            using var paint = new Paint { AntiAlias = true };
            using var path = new Path();
            using var direction = Path.Direction.Cw;
            using var style = Paint.Style.Stroke;
            using var rect = new RectF(0, 0, canvas.Width, canvas.Height);
            var radius = Forms.Context.ToPixels(frame?.CornerRadius ?? 0); //Default Corner Radius = 0
            
            path.AddRoundRect(rect, radius, radius, direction);
            
            paint.StrokeWidth = frame.BorderWidth * 4f;
            
            paint.Color = frame.BorderColor.ToAndroid();
            paint.SetStyle(style);
            canvas.DrawPath(path, paint);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == BaseFrame.BorderWidthProperty.PropertyName 
                || e.PropertyName ==  BaseFrame.BorderColorProperty.PropertyName
                || e.PropertyName ==  BaseFrame.CornerRadiusProperty.PropertyName)
                Invalidate(); // Force a call to OnDraw
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {   
            base.OnElementChanged(e);
            if (!(e.NewElement is BaseFrame { HasShadow: true } element)) 
                return;

            Elevation = element.CornerRadius + 2f;
            TranslationZ = 0.0f;
            SetZ(Elevation);
        }
    }
}