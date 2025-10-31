using FinalBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FinalBlazorApp.Pages.Employees
{
    [Authorize]
    public partial class Delete
    {
        [Parameter]
        public int eid { get; set; }
        public Employee employee { get; set; } = new Employee();
        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }
        HttpClient client;
        [Inject]
        public NavigationManager NavManager { get; set; }
        [Inject]
        public ISession Session { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = ClientFactory.CreateClient("EmpAPI");
            string token = await Session.GetTokenAsync();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            employee = await client.GetFromJsonAsync<Employee>(eid.ToString());
        }
        private async Task DeleteEmployee()
        {
            await client.DeleteAsync(eid.ToString());
            NavManager.NavigateTo("/employees");
        }
    }
}
