using FinalBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FinalBlazorApp.Pages.Trainers
{
    [Authorize]
    public partial class ByType : ComponentBase
    {
        [Parameter]
        public string Type { get; set; }
        List<Trainer> trainers;
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TrainerAPI");
            await GetAllTrainees();
        }
        private async Task GetAllTrainees()
        {
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            trainers = await client.GetFromJsonAsync<List<Trainer>>($"type/{Type}");
        }
    }
}

