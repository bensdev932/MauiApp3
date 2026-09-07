using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MauiApp3.ViewModel
{
   public partial class MainViewModel : ObservableObject
    {
        IConnectivity connectivity;
        public MainViewModel (IConnectivity connectivity){

            Items = new ObservableCollection<string>();
            this.connectivity = connectivity;

            }

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        private string text;

        [RelayCommand]
        private async Task Add()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;

         

            bool isDuplicate = Items.Any(item =>
                string.Equals(item.Trim(), Text, StringComparison.OrdinalIgnoreCase));

            if (isDuplicate)
            {
                await Shell.Current.DisplayAlertAsync(
                    "Duplicate Entry",
                    "This item already exists in the list!",
                    "OK");

                return;
            }

            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlertAsync(
                    "No Internet",
                    "Please connect!",
                    "OK");

                return;
            }

            Items.Add(Text);
            Text = string.Empty;
        }

        [RelayCommand]
        private async Task Delete(string s)
        {
            if (Items.Contains(s))
                Items.Remove(s);

        }

        [RelayCommand]

       private async  Task Tap (string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={(s)}");
        }
    }
}
