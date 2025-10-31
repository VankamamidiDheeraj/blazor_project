using FinalBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FinalBlazorApp.Pages.Trainings
{
    [Authorize]
    public partial class TraineeCreate
    {
        public List<Employee> EmployeeList { get; set; }

        public Trainee trainee { get; set; }
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public ISession Session { get; set; }
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Parameter]
        public int trainid { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("TraineeAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            trainee = new Trainee
            {
                TrainingId = trainid,
            };
            EmployeeList = await client.GetFromJsonAsync<List<Employee>>("http://localhost:5184/api/Employee/");
        }
        protected async Task CreateTrainee()
        {
            await client.PostAsJsonAsync<Trainee>("", trainee);
            NavManager.NavigateTo($"traineeindex/{trainid}");
        }
    }
}
