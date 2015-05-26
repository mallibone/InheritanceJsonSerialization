using System.Reflection;
using InheritanceJsonSerialization.Client.Models;
using InheritanceJsonSerialization.Client.ViewModels;
using Xamarin.Forms;

namespace InheritanceJsonSerialization.Client.Views
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();

            _viewModel = App.Locator.Main;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.Init();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = (ParentClass) e.SelectedItem;
            string title = selectedItem.Descirption;
            string description = selectedItem.Descirption;
            if (selectedItem is ChildClass)
            {
                description = description + " Secret: " + ((ChildClass) selectedItem).ChildSecret;
            }
            DisplayAlert(title, description, "OK");
        }
    }
}
