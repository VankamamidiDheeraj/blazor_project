using FinalBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Security.Cryptography;

namespace FinalBlazorApp.Pages.Trainings
{
    [Authorize]
    public partial class TraineeDetails
    {
    [Parameter]
    public int trainid { get; set; }
    [Parameter]
    public int eid { get; set; }
    public Trainee trainee { get; set; }
    [Inject]
    public IHttpClientFactory ClientFactory { get; set; }
    HttpClient client;
    [Inject]
    public ISession Session { get; set; }
    [Inject]
    public NavigationManager Navigation { get; set; }

    protected override async Task OnInitializedAsync()
    {
        client = ClientFactory.CreateClient("TraineeAPI");
        string token = await Session.GetTokenAsync();
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        trainee = await client.GetFromJsonAsync<Trainee>($"{trainid}/{eid}");
    }
}
}
