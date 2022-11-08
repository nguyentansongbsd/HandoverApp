using HandoverApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandoverApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserCRMInfoPage : ContentPage
    {
        public UserCRMInfoPageViewModel viewModel;
        public Action<bool> OnCompleted;
        public UserCRMInfoPage()
        {
            InitializeComponent();
            Init();
        }
        private async void Init()
        {
            this.BindingContext = viewModel = new UserCRMInfoPageViewModel();
            await viewModel.LoadUserCRM();
            if (viewModel.UserCRM != null)
            {
                OnCompleted?.Invoke(true);
            }
            else
            {
                OnCompleted?.Invoke(false);
            }
        }
    }
}