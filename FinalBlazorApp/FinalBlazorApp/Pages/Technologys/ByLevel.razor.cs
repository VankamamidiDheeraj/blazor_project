using FinalBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FinalBlazorApp.Pages.Technologys
{
    [Authorize]
    public partial class ByLevel
    {
        [Parameter]
        public string level { get; set; }
        List<Technology> technologies;
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TechAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            await GetAllTechnologiesByLevel();
        }
        private async Task GetAllTechnologiesByLevel()
        {
            technologies = await client.GetFromJsonAsync<List<Technology>>($"level/{level}");
        }
    }
}
   
