using System;
using System.Collections.Generic;
using System.Linq;
using FFImageLoading.Forms.Platform;
using Foundation;
using HandoverApp.IServices;
using UIKit;
using Xamarin.Forms;

namespace HandoverApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init();

            Stormlion.PhotoBrowser.iOS.Platform.Init();
            CachedImageRenderer.Init();
            ZXing.Net.Mobile.Forms.iOS.Platform.Init();
            DependencyService.Get<ILoadingService>().Initilize();

            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
    }
}
