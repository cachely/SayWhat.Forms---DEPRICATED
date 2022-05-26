using SayWhat.Forms.Messages;
using SayWhat.Forms.Utilities;
using System;
using Xamarin.Forms;

namespace SayWhat.Forms.Controls
{
    public class DynamicLabel : Label, IDisposable
    {
        public static readonly BindableProperty ResourceTextNameProperty =
            BindableProperty.Create(
                  nameof(ResourceTextName),
                  typeof(string),
                  typeof(DynamicLabel),
                  null,
                  BindingMode.Default,
                  propertyChanged: ResourceTextNameChanged);

        public DynamicLabel()
        {
            MessagingCenter.Subscribe<object>(new object(), CultureChangedMessage.Message, (o) => UpdateText(this));
        }

        public string ResourceTextName
        {
            get => GetValue(ResourceTextNameProperty) as string;
            set => SetValue(ResourceTextNameProperty, value);
        }

        public static void ResourceTextNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DynamicLabel label = (DynamicLabel)bindable;
            label.ResourceTextName = (string) newValue;
            SetText(label);
        }

        public static void SetText(DynamicLabel label)
        {
            label.Text = DynamicLocalizer.GetText(label.ResourceTextName);
        }

        public void UpdateText(DynamicLabel label)
        {
            label.Text = DynamicLocalizer.GetText(label.ResourceTextName);
        }

        public void Dispose()
        {
            MessagingCenter.Unsubscribe<object>(new object(), CultureChangedMessage.Message);
        }
    }
}
