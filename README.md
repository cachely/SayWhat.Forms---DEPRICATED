# SayWhat.Forms
Dynamic localization framework for Xamarin.Forms. Using wrapper classes for controls and pages, applications are able to update localized text to the UI regardless of chosen
design patterns or UI implementation (c# or xaml). 

### Example 

Recommended to initialize in the app.xaml.cs or app.cs file.
//Initialization
var resourceManager = new ResourceManager("SayWhat.Forms.Demo.Resources.AppResources", Assembly.GetAssembly(typeof(MainPage)));
Utilities.SayWhat.Settings.Initialize(resourceManager, CurrentCulture);

//Usage in xaml
<?xml version="1.0" encoding="utf-8" ?>
<sw:LocalizedContentPage
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:sw="clr-namespace:SayWhat.Forms.Controls;assembly=SayWhat.Forms"
    x:Class="SayWhat.Forms.Demo.MainPage"
    TitleResourceName="TranslatedTitle">
    <StackLayout 
        HorizontalOptions="Center"
        VerticalOptions="Center">
        <sw:LocalizedLabel 
            TextResourceName="HelloWorld" 
            FontSize="18"/>
        <sw:LocalizedEntry
            PlaceHolderResourceName="PlaceholderText" />
        <sw:LocalizedButton 
            TextResourceName="UpdateLanguage" 
            Clicked="Button_Clicked" />
    </StackLayout>
</sw:LocalizedContentPage>

# SayWhat.Forms.Demo
This includes examples for intializing the framework and usage in xaml which is easily translatable into c# implementation.



