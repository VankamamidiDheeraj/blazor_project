using FinalBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Security.Cryptography;

namespace FinalBlazorApp.Pages.Trainings
{
    [Authorize]
    public partial class TraineeIndex
    {
        [Parameter]
        public int trainid { get; set; }
        public List<Trainee> trainees = new List<Trainee>();
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TraineeAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            trainees = await client.GetFromJsonAsync<List<Trainee>>($"Training/{trainid}");
        }
    }
}