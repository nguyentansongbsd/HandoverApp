using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandoverApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapFloorPlan : ContentView
    {
        public Action<string> Action;
        public MapFloorPlan()
        {
            InitializeComponent();
            webView.actionData = async (data) =>
            {
                Action?.Invoke(data);
            };
        }
    }
}