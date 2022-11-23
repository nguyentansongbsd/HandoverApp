using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using HandoverApp.Controls;
using Java.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HandoverApp.Droid.Renderers
{
    public class JSBridge : Java.Lang.Object
    {
        readonly WeakReference<CustomWebViewRenderer> customWebViewRenderer;

        public JSBridge(CustomWebViewRenderer customRenderer)
        {
            customWebViewRenderer = new WeakReference<CustomWebViewRenderer>(customRenderer);
        }

        [JavascriptInterface]
        [Export("invokeAction")]
        public void InvokeAction(string data)
        {
            CustomWebViewRenderer customRenderer;

            if (customWebViewRenderer != null && customWebViewRenderer.TryGetTarget(out customRenderer))
            {
                ((CustomWebView)customRenderer.Element).InvokeAction(data);
                ((CustomWebView)customRenderer.Element).actionData?.Invoke(data);
            }
        }
    }
}