using MudBlazorExample.Models;

namespace MudBlazorExample.Services;

public interface IAppService
{
    Task<List<AppVM>> GetAppsAsync();
}

public class AppService : IAppService
{
    private IEnumerable<AppRole> CreateRandomRolesForApp(string id) => Enumerable.Range(1, 3)
        .Select(i => 
            new AppRole(
                $"{id}-{i}",
                $"App Role {i}",
                $"This is App Role {i} to App {id}",
                $"appRole{i}"));
    
    // Create a list of 10 example appVMs
    private List<AppVM> _apps;

    public AppService()
    {
        _apps = Enumerable.Range(1, 10)
            .Select(i => 
                new AppVM(
                    $"{i}",
                    $"client-{i}",
                    $"Application {i}",
                    $"This is App Registration {i}",
                    CreateRandomRolesForApp($"{i}")))
            .ToList();
    }

    public async Task<List<AppVM>> GetAppsAsync()
    {
        return _apps;
    }
}