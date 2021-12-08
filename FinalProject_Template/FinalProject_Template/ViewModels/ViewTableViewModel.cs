using FinalProject_Template.Models;
using FinalProject_Template.Services.Network;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace FinalProject_Template.ViewModels
{
    public class ViewTableViewModel : ViewModelBase
    {
        private INetworkService networkService;

        public ObservableRangeCollection<Temperature> Items { get; set; }
        public AsyncCommand GoBackCommand { get; }
        public ViewTableViewModel(INetworkService networkService)
        {
            this.networkService = networkService;

            Title = "View Table";

            Items = new ObservableRangeCollection<Temperature>();
            GetTableListing();
            GoBackCommand = new AsyncCommand(GoBack);
        }

        private async void GetTableListing()
        {
            var result = await networkService.GetAsync<ListOfTemperatures>(ApiConstant.GetAllTemperatureUrl());

            if (result == null)
                return;

            Items = new ObservableRangeCollection<Temperature>(result.All);
            OnPropertyChanged("Items");
        }

        private async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
