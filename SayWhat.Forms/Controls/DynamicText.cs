using SayWhat.Forms.Messages;
using SayWhat.Forms.Utilities;
using System;
using Xamarin.Forms;

namespace SayWhat.Forms.Controls
{
    public class DynamicLabel : Label, IDisposable
    {
        public static readonly BindableProperty ResourceNameProperty =
          BindableProperty.Create(nameof(ResourceName),
              typeof(string),
              null,
              string.Empty,
              BindingMode.Default);

        public DynamicLabel()
        {
            MessagingCenter.Subscribe<object>(new object(), CultureChangedMessage.Message, (o) => RefreshText());
        }

        public string ResourceName
        {
            get => GetValue(ResourceNameProperty) as string;
            set
            {
                SetValue(ResourceNameProperty, value);
                Text = DynamicLocalizer.GetText(value);
            }
        }
        public void RefreshText()
        {
            Text = DynamicLocalizer.GetText(ResourceName);
        }

        public void Dispose()
        {
            MessagingCenter.Unsubscribe<object>(new object(), CultureChangedMessage.Message);
        }
    }
}
