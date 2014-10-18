# ReviewNotifier

ReviewNotifier is a helper class for Windows Phone and Windows apps to easily ask users to rate and review your app after a number of launches.

## How to use

* Download or clone the source code from the GitHub repository or use the [NuGet package] (http://www.nuget.org/packages/ReviewNotifier/)

### Windows Phone Silverlight

* In Windows Phone Silverlight projects, use the following syntax]
  * In the launch event of your App.xaml.cs, insert the following three lines of code.
```csharp
private async void Application_Launching(object sender, LaunchingEventArgs e)
{
    await ReviewNotification.InitializeAsync();

    // Rest of your Application_Launching method
    ...
```

  * In the Loaded event of your first page, use the following syntax. The count will specify how many launches are needed before the user is presented with a review notification reminder (default 5).
```csharp
ReviewNotification.TriggerAsync("MESSAGE", "TITLE");
ReviewNotification.TriggerAsync("MESSAGE", "TITLE", 5);
```

### Windows Store (Windows 8.1, Windows Phone 8.1, Universal)
* In Windows Store projects, use the following syntax
  * In the launch event of your App.xaml.cs, insert the following three lines of code.
```csharp
protected async override void OnLaunched(LaunchActivatedEventArgs args)
{
    await ReviewNotification.InitializeAsync();

    // Rest of your OnLaunched method
    ...
```

  * In the Loaded event of your first page, use the following syntax. The count will specify how many launches are needed before the user is presented with a review notification reminder (default 5).
```csharp
ReviewNotification.TriggerAsync("MESSAGE", "TITLE");
ReviewNotification.TriggerAsync("MESSAGE", "TITLE", 5);
ReviewNotification.TriggerAsync("MESSAGE", "TITLE", "OK", "CANCEL");
ReviewNotification.TriggerAsync("MESSAGE", "TITLE", "OK", "CANCEL", 5);
```

## Credits

This library has been written by [Rajen Kishna] (https://twitter.com/rajen_k) with input from [Dave Smits] (https://twitter.com/davesmits).
This library has been created as a side-project to assist the community and is provided "as is" with no warranty whatsoever and has no relations to our employers (Microsoft and Sparked).