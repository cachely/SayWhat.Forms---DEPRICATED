using SayWhat.Forms.Messages;
using SayWhat.Forms.Utilities;
using Xamarin.Forms;

namespace SayWhat.Forms.Controls
{
    public class LocalizedButton : Button
    {
        public static readonly BindableProperty TextResourceNameProperty =
           BindableProperty.Create(
                 nameof(TextResourceName),
                 typeof(string),
                 typeof(LocalizedButton),
                 null,
                 BindingMode.Default,
                 propertyChanged: TextResourceNameChanged);

        public LocalizedButton()
        {
            MessagingCenter.Subscribe<object>(new object(), CultureChangedMessage.Message, (o) => UpdateText(this));
        }

        public string TextResourceName
        {
            get => GetValue(TextResourceNameProperty) as string;
            set => SetValue(TextResourceNameProperty, value);
        }

        public static void TextResourceNameChanged(BindableObject bindable, object oldValue, object newValue)
        { 
            LocalizedButton button = (LocalizedButton) bindable;
            button.TextResourceName = (string)newValue;
            SetText(button);
        }

        public static void SetText(LocalizedButton button)
        {
            button.Text = DynamicLocalizer.GetText(button.TextResourceName);
        }

        public void UpdateText(LocalizedButton button)
        {
            button.Text = DynamicLocalizer.GetText(button.TextResourceName);
        }

        public void Dispose()
        {
            MessagingCenter.Unsubscribe<object>(new object(), CultureChangedMessage.Message);
        }
    }
}
