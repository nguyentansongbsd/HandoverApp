using System;
using System.Threading.Tasks;
using HandoverApp.iOS.Services;
using HandoverApp.IServices;
using HandoverApp.Views;

[assembly:Xamarin.Forms.Dependency(typeof(PdfService))]
namespace HandoverApp.iOS.Services
{
    public class PdfService : IPdfService
    {
        public async Task View(string Url, string Name)
        {
            await AppShell.Current.Navigation.PushAsync(new ViewPDFFilePage(Url) { Title = Name });
        }
    }
}
