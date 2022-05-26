using SayWhat.Forms.Messages;
using SayWhat.Forms.Utilities;
using Xamarin.Forms;

namespace SayWhat.Forms.Controls
{
    public class LocalizedCarouselPage : ContentPage 
    {
        public static readonly BindableProperty TitleResourceNameProperty =
        BindableProperty.Create(
            nameof(TitleResourceName),
            typeof(string),
            typeof(LocalizedCarouselPage),
            null,
            BindingMode.Default,
            propertyChanged: TitleResourceNameChanged);

        public LocalizedCarouselPage() 
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
            var page = bindable as LocalizedCarouselPage;
            page.TitleResourceName = (string)newValue;
            SetPlaceHolder(page);
        }

        public static void SetPlaceHolder(LocalizedCarouselPage page)
        {
            page.Title = DynamicLocalizer.GetText(page.Title);
        }

        public void UpdateText(LocalizedCarouselPage page)
        {
            page.Title = DynamicLocalizer.GetText(page.Title);
        }

        public void Dispose()
        {
            MessagingCenter.Unsubscribe<object>(new object(), CultureChangedMessage.Message);
        }
    }
}
