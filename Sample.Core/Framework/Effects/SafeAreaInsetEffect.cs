using Xamarin.Forms;

namespace Sample.Core.Framework.Effects
{
     public class SafeAreaInsetEffect : RoutingEffect
     {
          public static readonly BindableProperty InsetTypeProperty = BindableProperty.CreateAttached(
               propertyName: "InsetType",
               returnType: typeof(InsetType),
               declaringType: typeof(SafeAreaInsetEffect),
               defaultValue: InsetType.None);

          public static InsetType GetInsetType(BindableObject view) => (InsetType)view.GetValue(InsetTypeProperty);
          public static void SetInsetType(BindableObject view, InsetType value) => view.SetValue(InsetTypeProperty, value);
          
          public SafeAreaInsetEffect() : base($"{nameof(Sample)}.{nameof(SafeAreaInsetEffect)}") { }
     }

     public enum InsetType
     {
          None = 0,
          Top,
          Bottom,
          TopAndBottom
     }
}