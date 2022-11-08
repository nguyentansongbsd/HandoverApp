using System;
using System.Threading.Tasks;
using Android.Content;
using HandoverApp.Droid.Services;
using HandoverApp.IServices;

[assembly: Xamarin.Forms.Dependency(typeof(PdfService))]
namespace HandoverApp.Droid.Services
{
    public class PdfService : IPdfService
    {
        public async Task View(string url, string name)
        {
            Intent intent = new Intent(Intent.ActionView);
            intent.SetDataAndType(Android.Net.Uri.Parse(url), "application/pdf");
            intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);
            intent.SetAction(Intent.ActionView);
            try
            {
                Xamarin.Essentials.Platform.CurrentActivity.StartActivity(intent);
            }
            catch (Exception ex)
            {
                await AppShell.Current.Navigation.PushAsync(new HandoverApp.Views.ViewPDFFilePage(url) { Title = name });
            }
        }
    }
}