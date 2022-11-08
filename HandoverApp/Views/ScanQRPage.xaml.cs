using System;
using System.Collections.Generic;
using HandoverApp.Helpers;
using HandoverApp.Models;
using HandoverApp.Resources;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace HandoverApp.Views
{
    public partial class ScanQRPage : ContentPage
    {
        public event EventHandler OnCompleted;
        public ScanQRPage()
        {
            InitializeComponent();
        }

        private void StartScaning_Clicked(object sender, EventArgs e)
        {
            Camera.IsScanning = true;
        }

        private void zxing_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    LoadingHelper.Show();
                    Camera.IsScanning = false;
                    await Navigation.PopAsync(false);
                    MessagingCenter.Send<ScanQRPage, string>(this, "CallBack", result.ToString());
                }
                catch (Exception ex)
                {

                }
            });
        }
    }
}
