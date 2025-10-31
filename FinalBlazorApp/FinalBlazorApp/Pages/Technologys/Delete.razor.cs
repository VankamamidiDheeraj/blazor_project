using FinalBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FinalBlazorApp.Pages.Technologys
{
    [Authorize]
    public partial class Delete
    {
        [Parameter]
        public int tid { get; set; }
        public Technology technology { get; set; } = new Technology();
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TechAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            technology = await client.GetFromJsonAsync<Technology>(tid.ToString());
        }
        private async Task DeleteTechnology()
        {
            await client.DeleteAsync(tid.ToString());
            NavManager.NavigateTo("/technologys");
        }
    }
}

