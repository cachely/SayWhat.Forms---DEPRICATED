using SayWhat.Forms.Messages;
using SayWhat.Forms.Utilities;
using Xamarin.Forms;

namespace SayWhat.Forms.Controls
{
    public class LocalizedEntry : Entry
    {
        public static readonly BindableProperty PlaceHolderResourceNameProperty =
           BindableProperty.Create(
                 nameof(PlaceHolderResourceName),
                 typeof(string),
                 typeof(LocalizedEntry),
                 null,
                 BindingMode.Default,
                 propertyChanged: PlaceHolderResourceNameChanged);

        public LocalizedEntry()
        {
            MessagingCenter.Subscribe<object>(new object(), CultureChangedMessage.Message, (o) => UpdateText(this));
        }

        public string PlaceHolderResourceName
        {
            get => GetValue(PlaceHolderResourceNameProperty) as string;
            set => SetValue(PlaceHolderResourceNameProperty, value);
        }

        public static void PlaceHolderResourceNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            LocalizedEntry entry = (LocalizedEntry)bindable;
            entry.PlaceHolderResourceName = (string)newValue;
            SetPlaceHolder(entry);
        }

        public static void SetPlaceHolder(LocalizedEntry entry)
        {
            entry.Placeholder = DynamicLocalizer.GetText(entry.PlaceHolderResourceName);
        }

        public void UpdateText(LocalizedEntry entry)
        {
            entry.Placeholder = DynamicLocalizer.GetText(entry.PlaceHolderResourceName);
        }

        public void Dispose()
        {
            MessagingCenter.Unsubscribe<object>(new object(), CultureChangedMessage.Message);
        }
    }
}
