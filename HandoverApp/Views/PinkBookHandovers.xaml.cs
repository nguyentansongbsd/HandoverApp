using System;
using System.Collections.Generic;
using HandoverApp.Helpers;
using HandoverApp.Models;
using HandoverApp.Resources;
using HandoverApp.ViewModels;
using Xamarin.Forms;

namespace HandoverApp.Views
{
    public partial class PinkBookHandovers : ContentPage
    {
        public static bool? NeedRefresh { get; set; } = null;
        public PinkBooHandoversViewModel viewModel;
        public PinkBookHandovers()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new PinkBooHandoversViewModel();
            NeedRefresh = false;
            Init();
        }

        private async void Init()
        {
            await viewModel.LoadData();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (NeedRefresh.HasValue && NeedRefresh.Value == true)
            {
                LoadingHelper.Show();
                await viewModel.LoadOnRefreshCommandAsync();
                LoadingHelper.Hide();
            }
        }

        private async void SearchBar_SearchButtonPressed(System.Object sender, System.EventArgs e)
        {
            LoadingHelper.Show();
            await viewModel.LoadOnRefreshCommandAsync();
            LoadingHelper.Hide();
        }

        private void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(viewModel.Keyword))
            {
                SearchBar_SearchButtonPressed(null, EventArgs.Empty);
            }
        }

        private void BsdListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            LoadingHelper.Show();
            Guid id = ((PinkBookHandoversModel)e.Item).bsd_pinkbookhandoverid;
            PinkBookHandoverPage pinkBookHandover = new PinkBookHandoverPage(id);
            pinkBookHandover.OnCompleted = async (isSuccessed) =>
            {
                if (isSuccessed)
                {
                    await Navigation.PushAsync(pinkBookHandover);
                    LoadingHelper.Hide();
                }
                else
                {
                    LoadingHelper.Hide();
                    ToastMessageHelper.ShortMessage(Language.khong_tim_thay_thong_tin_vui_long_thu_lai);
                }
            };
        }
    }
}
