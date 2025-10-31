using FinalBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FinalBlazorApp.Pages.Trainers
{
    [Authorize]
    public partial class Delete
    {
        [Parameter]
        public int trid { get; set; }
        public Trainer trainer { get; set; } = new Trainer();
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TrainerAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            trainer = await client.GetFromJsonAsync<Trainer>(trid.ToString());
        }
        private async Task DeleteTrainer()
        {
            await client.DeleteAsync(trid.ToString());
            NavManager.NavigateTo("/trainers");
        }
    }
}
