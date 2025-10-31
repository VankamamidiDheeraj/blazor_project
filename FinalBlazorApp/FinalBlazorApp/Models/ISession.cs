namespace FinalBlazorApp.Models
{
    public interface ISession
    {
        Task SetTokenAsync(string token);
        Task<string> GetTokenAsync();
    }
}
