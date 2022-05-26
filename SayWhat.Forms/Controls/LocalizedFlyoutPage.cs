using SayWhat.Forms.Messages;
using SayWhat.Forms.Utilities;
using Xamarin.Forms;

namespace SayWhat.Forms.Controls
{
    public class LocalizedFlyoutPage : FlyoutPage 
    {
        public static readonly BindableProperty TitleResourceNameProperty =
        BindableProperty.Create(
            nameof(TitleResourceName),
            typeof(string),
            typeof(LocalizedFlyoutPage),
            null,
            BindingMode.Default,
            propertyChanged: TitleResourceNameChanged);

        public LocalizedFlyoutPage() 
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
            var page = bindable as LocalizedFlyoutPage;
            page.TitleResourceName = (string)newValue;
            SetPlaceHolder(page);
        }

        public static void SetPlaceHolder(LocalizedFlyoutPage page)
        {
            page.Title = DynamicLocalizer.GetText(page.TitleResourceName);
        }

        public void UpdateText(LocalizedFlyoutPage page)
        {
            page.Title = DynamicLocalizer.GetText(page.TitleResourceName);
        }

        public void Dispose()
        {
            MessagingCenter.Unsubscribe<object>(new object(), CultureChangedMessage.Message);
        }
    }
}
