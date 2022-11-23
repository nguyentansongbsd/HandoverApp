using HandoverApp.Controls;
using HandoverApp.Helpers;
using HandoverApp.IServices;
using HandoverApp.Models;
using HandoverApp.Resources;
using HandoverApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandoverApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FloorPlanPage : ContentPage
    {
        FloorPlanPageViewModel viewModel;
        public FloorPlanPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new FloorPlanPageViewModel();
            Init();
        }
        public void Init()
        {
            webView.actionData = (data) =>
            {
                viewModel.UnitID = data;
            };
            Unit_Popup.Close += Unit_Popup_Close;
        }

        private void Unit_Popup_Close(object sender, EventArgs e)
        {
            webView.IsEnabled = true;
        }

        private async void ShowMoreDanhSachDatCho_Clicked(object sender, EventArgs e)
        {
            LoadingHelper.Show();
            viewModel.PageDanhSachDatCho++;
            await viewModel.LoadQueues(viewModel.Unit.productid.ToString());
            LoadingHelper.Hide();
        }

        private void UnitInfor_Clicked(object sender, EventArgs e)
        {
            LoadingHelper.Show();
            UnitInfo unitInfo = new UnitInfo(viewModel.Unit.productid);
            unitInfo.OnCompleted = async (IsSuccess) => {
                if (IsSuccess)
                {
                    await Navigation.PushAsync(unitInfo);
                    LoadingHelper.Hide();
                }
                else
                {
                    LoadingHelper.Hide();
                    ToastMessageHelper.ShortMessage(Language.khong_tim_thay_san_pham);
                }
            };
        }
        private async Task LoadUnit()
        {
            LoadingHelper.Show();
            viewModel.PageDanhSachDatCho = 1;
            viewModel.QueueList.Clear();
            await Task.WhenAll(
                viewModel.LoadQueues(viewModel.UnitID),
                viewModel.LoadUnitById(viewModel.UnitID)
                );
            if (!string.IsNullOrWhiteSpace(viewModel.Unit.bsd_viewphulong))
            {
                viewModel.UnitView = ViewData.GetViewByIds(viewModel.Unit.bsd_viewphulong);
            }
            else
            {
                viewModel.UnitView = null;
            }
            if (viewModel.Unit?.productid != Guid.Empty)
                Unit_Popup.ShowCenterPopup();
            LoadingHelper.Hide();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            webView.IsEnabled = false;
            await LoadUnit();
        }
    }
}