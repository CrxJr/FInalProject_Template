using FinalProject_Template.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinalProject_Template.Services.Network
{
    public class NetworkService : INetworkService
    {
        private HttpClient httpClient;

        public NetworkService()
        {
            httpClient = new HttpClient();
        }

        public async Task<TResult> GetAsync<TResult>(string url)
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if(response.StatusCode == HttpStatusCode.InternalServerError)
            {
                await Shell.Current.DisplayAlert("Error", "The Webservice is down. Please reload the Webservice and try again", "OK");
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }

            string serialized = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(serialized);

            return result;
        }
    }
}
