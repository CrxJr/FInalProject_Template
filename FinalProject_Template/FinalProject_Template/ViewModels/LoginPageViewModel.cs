using FinalProject_Template.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace FinalProject_Template.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private string pin;

        public string Pin
        {
            get => pin; 
            set => SetProperty(ref pin, value); 
        }

        public AsyncCommand LoginCommand { get; }

        public LoginPageViewModel()
        {
            LoginCommand = new AsyncCommand(Login);
        }

        private async Task Login()
        {
            if (string.IsNullOrEmpty(Pin))
            {
                await Shell.Current.DisplayAlert("Missing Pin", "Please insert your pin before continuing", "OK");
                return;
            }   
            else if (Pin.Length != 4){
                await Shell.Current.DisplayAlert("Pin Too Short", "Make sure the Pin is 4 digits long", "OK");
                return;
            }
            else if (!Pin.Equals("3452"))
            {
                await Shell.Current.DisplayAlert("Invalid Pin", "The Pin you entered is invalid", "OK");
                return;
            }

            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}
