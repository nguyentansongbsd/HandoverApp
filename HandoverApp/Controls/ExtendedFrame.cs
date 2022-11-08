using System;
using Xamarin.Forms;

namespace HandoverApp.Controls
{
    public class ExtendedFrame : Frame
    {
        public ExtendedFrame()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                HasShadow = false;
                BorderColor = Color.LightGray;
            }
        }
    }
}
