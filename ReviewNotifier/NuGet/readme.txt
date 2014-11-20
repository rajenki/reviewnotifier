ReviewNotifier 1.1.1 | Rajen Kishna
===============================================================================

ReviewNotifier is a helper class for Windows Phone and Windows apps to easily
ask users to rate and review your app after a number of launches.

Any questions/feedback/suggestion, let me know on Twitter:
@rajen_k

===============================================================================
Usage:
===============================================================================

1. In the launch event of your App.xaml.cs, insert the following three lines of
code.
-------------------------------------------------------------------------------
Windows Phone 8 / 8.1 (Silverlight)
-------------------------------------------------------------------------------
private async void Application_Launching(object sender, LaunchingEventArgs e)
{
    await ReviewNotification.InitializeAsync();

    // Rest of your Application_Launching method
    ...
-------------------------------------------------------------------------------
Windows 8 / Windows Phone 8.1 (Store/Universal)
-------------------------------------------------------------------------------
protected async override void OnLaunched(LaunchActivatedEventArgs args)
{
    await ReviewNotification.InitializeAsync();

    // Rest of your OnLaunched method
    ...
-------------------------------------------------------------------------------

2. In the Loaded event of your first page, use the following syntax. The count 
will specify how many launches are needed before the user is presented with a 
review notification reminder (default 5).
-------------------------------------------------------------------------------
Windows Phone 8 / 8.1 (Silverlight):
-------------------------------------------------------------------------------
ReviewNotification.TriggerAsync("MESSAGE", "TITLE");
ReviewNotification.TriggerAsync("MESSAGE", "TITLE", 5);
-------------------------------------------------------------------------------
Windows 8 / Windows Phone 8.1 (Store/Universal):
-------------------------------------------------------------------------------
ReviewNotification.TriggerAsync("MESSAGE", "TITLE");
ReviewNotification.TriggerAsync("MESSAGE", "TITLE", 5);
ReviewNotification.TriggerAsync("MESSAGE", "TITLE", "OK", "CANCEL");
ReviewNotification.TriggerAsync("MESSAGE", "TITLE", "OK", "CANCEL", 5);
-------------------------------------------------------------------------------