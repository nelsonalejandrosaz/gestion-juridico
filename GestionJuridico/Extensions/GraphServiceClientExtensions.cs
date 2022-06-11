using Microsoft.Graph;

namespace GestionJuridico.Extensions;

public static class GraphServiceClientExtensions
{
    public static async Task<List<User>> GetUserList(this GraphServiceClient graphServiceClient)
    {
        var requestUsers = await graphServiceClient.Users.Request().Select(u => new
        {
            u.Id,
            u.DisplayName,
            u.Mail
        }).Top(999).GetAsync();
        var users = requestUsers.ToList();
        return users;
    }

    public static string GetUserDisplayName(this GraphServiceClient graphServiceClient, string userId)
    {
        var displayName = graphServiceClient.Users[userId].Request().GetAsync().Result.DisplayName;
        return displayName;
    }
}