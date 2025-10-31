using FinalBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace FinalBlazorApp.Pages.Trainings
{
    [Authorize]
    public partial class Create
    {
        public List<Technology> TechnologyList { get; set; } = new();
        public List<Trainer> TrainerList { get; set; } = new();
        public Training training { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public ISession Session { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TrainingAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            training = new Training
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(1)
            };
            TechnologyList = await client.GetFromJsonAsync<List<Technology>>("http://localhost:5200/api/Technology/");
            TrainerList = await client.GetFromJsonAsync<List<Trainer>>("http://localhost:5210/api/Trainer/");
        }
        private async Task SaveTraining()
        {
            await client.PostAsJsonAsync<Training>("", training);
            NavManager.NavigateTo("/trainings");
        }
    }
}