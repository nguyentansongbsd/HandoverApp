using HandoverApp.Resources;
using System;
using Xamarin.Forms;

namespace HandoverApp.Controls
{
    public class MainSearchBar : SearchBar
    {
        public static readonly BindableProperty SearchBackgroundColorProperty = BindableProperty.Create(nameof(SearchBackgroundColor), typeof(Color), typeof(MainSearchBar), Color.White, BindingMode.TwoWay);
        public Color SearchBackgroundColor { get => (Color)GetValue(SearchBackgroundColorProperty); set => SetValue(SearchBackgroundColorProperty, value); }

        public MainSearchBar()
        {
            //if (Device.RuntimePlatform == Device.iOS)
            //{
            BackgroundColor = Color.FromHex("#f7f7f7");
            //}
            //this.BackgroundColor = Color.White;
            this.FontFamily = "Segoe";
            this.Placeholder = Language.tim_kiem;
        }
    }
}
