# SayWhat.Forms
Dynamic localization framework for Xamarin.Forms. Using wrapper classes for controls and pages, applications are able to update localized text to the UI regardless of chosen
design patterns or UI implementation (c# or xaml). 

### Example 
Full example is shown here:
https://github.com/cachely/SayWhat.Forms/tree/main/SayWhat.Forms.Demo

It is recommended to initialize in the app.xaml.cs or app.cs file as it is done here:
https://github.com/cachely/SayWhat.Forms/blob/main/SayWhat.Forms.Demo/SayWhat.Forms.Demo/App.xaml.cs

//Initialization<br>
var resourceManager = new ResourceManager("SayWhat.Forms.Demo.Resources.AppResources", Assembly.GetAssembly(typeof(MainPage)));
Utilities.SayWhat.Settings.Initialize(resourceManager, CurrentCulture);

Usage in xaml See: https://github.com/cachely/SayWhat.Forms/blob/7d90b920c7e2644547f8f9292405e0e14db9c15b/SayWhat.Forms.Demo/SayWhat.Forms.Demo/MainPage.xaml
