using MudBlazorExample.Models;

namespace MudBlazorExample.Services;

public interface IAppRoleService
{
    Task<IEnumerable<AppRoleVM>> GetRolesAsync();
}

public class AppRoleService : IAppRoleService
{
    private readonly IEnumerable<App> _apps;
    private readonly IEnumerable<AppRoleVM> _appRoles;
    
    private int GetRandomIndex()
    {
        var minIndex = 0;
        var maxIndex = _apps.Count() - 1;
        var random = new Random();
        return random.Next(minIndex, maxIndex);
    }

    public AppRoleService()
    {
        // Create example apps
        _apps = Enumerable.Range(1, 10)
            .Select(i =>
                new App(
                    $"{i}",
                    $"client-{i}",
                    $"Application {i}",
                    $"This is App Registration {i}"));
        // Create example app roles
        _appRoles = Enumerable.Range(1, 40)
            .Select(i =>
                new AppRoleVM(
                    $"{i}",
                    $"Role {i}",
                    $"This is App Role {i}",
                    $"role-{i}",
                    _apps.ElementAt(GetRandomIndex())));
    }
    
    public async Task<IEnumerable<AppRoleVM>> GetRolesAsync()
    {
        return _appRoles;
    }
}

public record AppRoleVM(string Id, string DisplayName, string Description, string Value, App App);

public record App(
    string Id,
    string ClientId,
    string DisplayName,
    string Description);