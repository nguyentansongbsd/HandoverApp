using Android.Webkit;
using HandoverApp.IServices;
using Xamarin.Forms;
using HandoverApp.Droid.Services;

[assembly: Dependency(typeof(ClearCookies))]
namespace HandoverApp.Droid.Services
{
    public class ClearCookies : IClearCookies
    {
        public void ClearAllCookies()
        {
            var cookieManager = CookieManager.Instance;
            cookieManager.RemoveAllCookie();
        }
    }
}