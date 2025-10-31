using FinalBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FinalBlazorApp.Pages.Trainers
{
    [Authorize]
    public partial class Index
    {
        List<Trainer> trainers;
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public ISession Session { get; set; }

        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TrainerAPI");
            await GetAllTrainers();
        }
        private async Task GetAllTrainers()
        {
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            trainers = await client.GetFromJsonAsync<List<Trainer>>("");
        }
    }
}
