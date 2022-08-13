using Sample.Core.Controls;
using Sample.iOS.Renderers;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BaseFrame), typeof(BaseFrameRenderer))]
namespace Sample.iOS.Renderers
{
    public class BaseFrameRenderer : FrameRenderer
    {
        public BaseFrameRenderer()
            => Layer.CornerRadius = 0;
        
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            var frame = (BaseFrame)Element;
            if (frame == null)
                return;

            if (frame.BorderWidth > 0)
            {
                Layer.BorderColor = frame.BorderColor.ToCGColor();
                Layer.BorderWidth = frame.BorderWidth;
            }

            if (frame.CornerRadius > 0)
                Layer.CornerRadius = frame.CornerRadius;
        }
        
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            if (!Element.HasShadow) 
                return;
            
            Layer.ShadowRadius = Element.CornerRadius + 2f;
            Layer.ShadowColor = UIColor.Gray.CGColor;
            Layer.ShadowOffset = new CGSize(2, 2);
            Layer.ShadowOpacity = .2f;
            Layer.ShadowPath = UIBezierPath.FromRect(Layer.Bounds).CGPath;
            Layer.MasksToBounds = false;
        }
    }
}