namespace MudBlazorExample.Models;

public record AppRole(string Id, string DisplayName, string Description, string Value);

public record AppVM(
    string Id,
    string ClientId,
    string DisplayName,
    string Description,
    IEnumerable<AppRole>? AppRoles);

