using System;
using Xamarin.Forms;

namespace HandoverApp.Controls
{
    public class EntryNoneBorderControl :Entry
    {
        public EntryNoneBorderControl()
        {
            TextColor = Color.Black;
            this.FontSize = 15;
            this.PlaceholderColor = Color.Gray;
        }
    }
}
