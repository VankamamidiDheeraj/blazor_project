using FinalBlazorApp.Models;
using Microsoft.AspNetCore.Components;

namespace FinalBlazorApp.Pages
{
    public partial class Home
    {
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("AuthAPI");
            string userName = "ramesh@zelis.com";
            string role = "Admin";
            string secretKey = "im naruto greater than any other hokage in history of shinobi";
            string token = await client.GetStringAsync($"{userName}/{role}/{secretKey}");
            await Session.SetTokenAsync(token);
        }
    }
}