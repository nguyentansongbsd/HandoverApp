using System;
using Foundation;
using UIKit;
using HandoverApp.IServices;
using HandoverApp.iOS.Services;

[assembly: Xamarin.Forms.Dependency(typeof(OpenAppSettings))]
namespace HandoverApp.iOS.Services
{
    public class OpenAppSettings : IOpenAppSettings
    {
        public void Open()
        {
            UIApplication.SharedApplication.OpenUrl(new NSUrl("app-settings:"));
        }
    }
}
