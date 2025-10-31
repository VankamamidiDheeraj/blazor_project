using FinalBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FinalBlazorApp.Pages.Trainings
{
    [Authorize]
    public partial class ByEmployee
    {
        [Parameter]
        public int eid { get; set; }
        [Parameter]
        public int trainid { get; set; }
        List<Trainee> trainees;
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TraineeAPI");
            await GetAllTrainees();
        }
        private async Task GetAllTrainees()
        {
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            trainees = await client.GetFromJsonAsync<List<Trainee>>($"Employee/{eid}");
        }
    }
}


