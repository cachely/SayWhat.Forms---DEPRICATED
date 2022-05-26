using SayWhat.Forms.Messages;
using SayWhat.Forms.Utilities;
using Xamarin.Forms;

namespace SayWhat.Forms.Controls
{
    public class LocalizedContentPage : ContentPage 
    {
        public static readonly BindableProperty TitleResourceNameProperty =
        BindableProperty.Create(
            nameof(TitleResourceName),
            typeof(string),
            typeof(LocalizedContentPage),
            null,
            BindingMode.Default,
            propertyChanged: TitleResourceNameChanged);

        public LocalizedContentPage() 
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
            var page = bindable as LocalizedContentPage;
            page.TitleResourceName = (string)newValue;
            SetPlaceHolder(page);
        }

        public static void SetPlaceHolder(LocalizedContentPage page)
        {
            page.Title = DynamicLocalizer.GetText(page.TitleResourceName);
        }

        public void UpdateText(LocalizedContentPage page)
        {
            page.Title = DynamicLocalizer.GetText(page.TitleResourceName);
        }

        public void Dispose()
        {
            MessagingCenter.Unsubscribe<object>(new object(), CultureChangedMessage.Message);
        }
    }
}
