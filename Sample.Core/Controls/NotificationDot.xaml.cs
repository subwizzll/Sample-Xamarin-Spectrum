using System.ComponentModel;
using Xamarin.Forms;

namespace Sample.Core.Controls
{
    public partial class NotificationDot : Frame
    {
        public NotificationDot() => InitializeComponent();

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(NotificationDot),
            defaultValue: string.Empty,
            propertyChanged: (b, o, n) =>
            {
                var notificationDot = b as NotificationDot;
                var label = notificationDot.Label;
                var text = n as string;
                var appliedWidth = text.Length switch
                {
                    3 => 26d,
                    _ => 18d
                };
                
                notificationDot.WidthRequest = appliedWidth;
                label.Text = text;
            });
    }
}