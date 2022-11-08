﻿using System;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using HandoverApp.Controls;
using HandoverApp.Droid.Renderers;

[assembly: ExportRenderer(typeof(MainEntry), typeof(MainEntryRenderer))]
namespace HandoverApp.Droid.Renderers
{
    public class MainEntryRenderer : EntryRenderer
    {
        public MainEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null && Control != null)
            {
                FormsEditText editText = Control;
                editText.SetBackgroundResource(Droid.Resource.Drawable.bg_main_entry);
                editText.SetPadding(20, 0, 15, 0);
            }
        }
    }
}
