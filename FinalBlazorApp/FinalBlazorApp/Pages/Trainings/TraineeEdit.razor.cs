using FinalBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FinalBlazorApp.Pages.Trainings
{
    [Authorize]
    public partial class TraineeEdit
    {
        public List<Employee> EmployeeList { get; set; } = new();
        public Trainee trainee { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public ISession Session { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }
        [Parameter]
        public int trainid { get; set; }
        [Parameter]
        public int eid { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TraineeAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            trainee = await client.GetFromJsonAsync<Trainee>($"{trainid}/{eid}");
            EmployeeList = await client.GetFromJsonAsync<List<Employee>>("http://localhost:5184/api/Employee/");
        }
        protected async Task UpdateTrainee()
        {
            await client.PutAsJsonAsync<Trainee>($"{trainid}/{eid}", trainee);
            Navigation.NavigateTo($"traineeindex/{trainid}");
        }
    }
}
