using Foundation;
using HandoverApp.iOS.Services;
using HandoverApp.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using WebKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClearCookies))]
namespace HandoverApp.iOS.Services
{
    public class ClearCookies : IClearCookies
    {
        public void ClearAllCookies()
        {
            NSHttpCookieStorage.SharedStorage.RemoveCookiesSinceDate(NSDate.DistantPast);

            WKWebsiteDataStore.DefaultDataStore.FetchDataRecordsOfTypes(WKWebsiteDataStore.AllWebsiteDataTypes, (NSArray records) => {

                for (nuint i = 0; i < records.Count; i++)
                {
                    var record = records.GetItem<WKWebsiteDataRecord>(i);
                    WKWebsiteDataRecord[] recordArray = new WKWebsiteDataRecord[record.DataTypes.Count];
                    WKWebsiteDataStore.DefaultDataStore.RemoveDataOfTypes(record.DataTypes, NSDate.DistantPast, () => { });
                }

            });
        }
    }
}