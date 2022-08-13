using System.Linq;
using Xamarin.Forms;

namespace Sample.Core.Framework.Behaviors
{

    public class NumericValidationBehavior : Behavior<Entry> {

        protected override void OnAttachedTo(Entry entry) {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry) {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.NewTextValue))
                return;
            var entry = sender as Entry;
            
            var isValid = args.NewTextValue.ToCharArray().All(char.IsDigit);

            entry.Text = isValid 
                ? args.NewTextValue 
                : args.NewTextValue.Remove(args.NewTextValue.Length - 1);
        }
    }
}