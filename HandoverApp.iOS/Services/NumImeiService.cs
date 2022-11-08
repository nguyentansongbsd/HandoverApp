using System;
using System.Threading.Tasks;
using HandoverApp.iOS.Services;
using HandoverApp.IServices;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(NumImeiService))]
namespace HandoverApp.iOS.Services
{
    public class NumImeiService :INumImeiService
    {
        public async Task<string> GetImei()
        {
            return UIDevice.CurrentDevice.IdentifierForVendor.AsString();
        }
    }
}
