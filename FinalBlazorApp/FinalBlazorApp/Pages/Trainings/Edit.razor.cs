using FinalBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FinalBlazorApp.Pages.Trainings
{
    [Authorize]
    public partial class Edit
    {
        public List<Technology> TechnologyList { get; set; } = new();
        public List<Trainer> TrainerList { get; set; } = new();
        [Parameter]
        public int trainid { get; set; }
        public Training training { get; set; } = new Training();
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TrainingAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            training = await client.GetFromJsonAsync<Training>(trainid.ToString());
            TechnologyList = await client.GetFromJsonAsync<List<Technology>>("http://localhost:5200/api/Technology/");
            TrainerList = await client.GetFromJsonAsync<List<Trainer>>("http://localhost:5210/api/Trainer/");
        }
        private async Task UpdateTraining()
        {
            await client.PutAsJsonAsync(trainid.ToString(), training);
            NavManager.NavigateTo("/trainings");
        }
    }
}