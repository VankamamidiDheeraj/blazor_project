using FinalBlazorApp.Authentication;
using FinalBlazorApp.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


namespace FinalBlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<HttpClient>();
            builder.Services.AddSingleton<ISession, Session>();
            builder.Services.AddScoped<BrowserStorageService>();
            builder.Services.AddScoped<CustomAuthStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthStateProvider>());
            builder.Services.AddHttpClient("UserAPI", client =>
            {
                client.BaseAddress = new Uri(@"http://localhost:5085/api/User/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            builder.Services.AddHttpClient("AuthAPI", client =>
            {
                client.BaseAddress = new Uri(@"http://localhost:5085/api/Auth/");
                client.DefaultRequestHeaders.Add("Accept", "application/text");
            });
            builder.Services.AddHttpClient("EmpAPI", client =>
            {
                client.BaseAddress = new Uri(@"http://localhost:5184/api/Employee/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            builder.Services.AddHttpClient("TechAPI", client =>
            {
                client.BaseAddress = new Uri(@"http://localhost:5200/api/Technology/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            builder.Services.AddHttpClient("TrainerAPI", client =>
            {
                client.BaseAddress = new Uri(@"http://localhost:5210/api/Trainer/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            builder.Services.AddHttpClient("TrainingAPI", client =>
            {
                client.BaseAddress = new Uri(@"http://localhost:5170/api/Training/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            builder.Services.AddHttpClient("TraineeAPI", client =>
            {
                client.BaseAddress = new Uri(@"http://localhost:5170/api/Trainee/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            await builder.Build().RunAsync();
        }
    }
}
