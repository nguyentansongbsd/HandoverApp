﻿using System;
using Telerik.XamarinForms.Primitives;
using Xamarin.Forms;

namespace HandoverApp.Controls
{
    public class SearchBarFrame : RadBorder
    {
        public SearchBarFrame()
        {
            HeightRequest = 37;
            CornerRadius = 3;
            BorderColor = Color.LightGray;
            Padding = 0;
            Margin = new Thickness(5, 0);
            //HasShadow = false;
        }
    }
}
