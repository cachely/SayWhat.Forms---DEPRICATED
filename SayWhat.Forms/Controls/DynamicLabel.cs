using SayWhat.Forms.Messages;
using SayWhat.Forms.Utilities;
using System;
using Xamarin.Forms;

namespace SayWhat.Forms.Controls
{
    public class DynamicLabel : Label, IDisposable
    {
        public static readonly BindableProperty TextResourceNameProperty =
            BindableProperty.Create(
                  nameof(TextResourceName),
                  typeof(string),
                  typeof(DynamicLabel),
                  null,
                  BindingMode.Default,
                  propertyChanged: TextResourceNameChanged);

        public DynamicLabel()
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
            DynamicLabel label = (DynamicLabel)bindable;
            label.TextResourceName = (string) newValue;
            SetText(label);
        }

        public static void SetText(DynamicLabel label)
        {
            label.Text = DynamicLocalizer.GetText(label.TextResourceName);
        }

        public void UpdateText(DynamicLabel label)
        {
            label.Text = DynamicLocalizer.GetText(label.TextResourceName);
        }

        public void Dispose()
        {
            MessagingCenter.Unsubscribe<object>(new object(), CultureChangedMessage.Message);
        }
    }
}
