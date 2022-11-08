using System;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using HandoverApp.Controls;
using HandoverApp.Droid.Renderers;

[assembly: ExportRenderer(typeof(LookUpEntry), typeof(LookUpEntryRenderer))]
namespace HandoverApp.Droid.Renderers
{
    public class LookUpEntryRenderer : EntryRenderer
    {
        private LookUpEntry _lookUpEntry;
        public LookUpEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                _lookUpEntry = e.NewElement as LookUpEntry;
            }
            if (Control != null)
            {
                FormsEditText editText = Control;
                editText.SetBackgroundResource(Resource.Drawable.bg_main_entry);
                editText.SetPadding(20, 0, 60, 0);
                //editText.SetFocusable(views.ViewFocusability.NotFocusable);
                editText.FocusableInTouchMode = false;
                editText.SetCursorVisible(false);
                //editText.Touch += EditText_Touch;
            }
        }
    }
}
