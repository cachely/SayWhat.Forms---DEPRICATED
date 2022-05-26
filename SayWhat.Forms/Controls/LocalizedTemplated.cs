using SayWhat.Forms.Messages;
using SayWhat.Forms.Utilities;
using Xamarin.Forms;

namespace SayWhat.Forms.Controls
{
    public class LocalizedTemplatedPage : ContentPage 
    {
        public static readonly BindableProperty TitleResourceNameProperty =
        BindableProperty.Create(
            nameof(TitleResourceName),
            typeof(string),
            typeof(LocalizedTemplatedPage),
            null,
            BindingMode.Default,
            propertyChanged: TitleResourceNameChanged);

        public LocalizedTemplatedPage() 
        {
            MessagingCenter.Subscribe<object>(new object(), CultureChangedMessage.Message, (o) => UpdateText(this));
        }

        public string TitleResourceName
        {
            get => GetValue(TitleResourceNameProperty) as string;
            set => SetValue(TitleResourceNameProperty, value);
        }

        public static void TitleResourceNameChanged(BindableObject bindable, object oldValue, object newValue)
        { 
            var page = bindable as LocalizedTemplatedPage;
            page.TitleResourceName = (string)newValue;
            SetPlaceHolder(page);
        }

        public static void SetPlaceHolder(LocalizedTemplatedPage page)
        {
            page.Title = DynamicLocalizer.GetText(page.Title);
        }

        public void UpdateText(LocalizedTemplatedPage page)
        {
            page.Title = DynamicLocalizer.GetText(page.Title);
        }

        public void Dispose()
        {
            MessagingCenter.Unsubscribe<object>(new object(), CultureChangedMessage.Message);
        }
    }
}
