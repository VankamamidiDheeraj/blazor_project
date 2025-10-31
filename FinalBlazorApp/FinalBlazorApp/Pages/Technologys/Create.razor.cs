using FinalBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace FinalBlazorApp.Pages.Technologys
{
    [Authorize]
    public partial class Create
    {
        public Technology technology { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public ISession Session { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
         string token { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TechAPI");
            token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            technology = new Technology();
        }
        private async Task SaveTechnology()
        {
            await client.PostAsJsonAsync<Technology>($"{token}", technology);
            NavManager.NavigateTo("/technologys");
        }
    }
}