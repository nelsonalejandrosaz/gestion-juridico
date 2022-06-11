using System.Security.Claims;
using Microsoft.Graph;

namespace GestionJuridico.Extensions;

public static class GraphClaimTypes
{
    public const string Id = "graph_id";
    public const string DisplayName = "graph_name";
    public const string Email = "graph_email";
    public const string Department = "graph_departament";
    public const string Photo = "graph_photo";
}

public static class GraphClaimsPrincipalExtensions
{
    public static string GetUserGraphDisplayName(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.FindFirstValue(GraphClaimTypes.DisplayName);
    }

    public static string GetUserGraphPhoto(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.FindFirstValue(GraphClaimTypes.Photo);
    }

    public static void AddUserGraphInfo(this ClaimsPrincipal claimsPrincipal, User user)
    {
        var identity = claimsPrincipal.Identity as ClaimsIdentity;

        identity?.AddClaim(
            new Claim(GraphClaimTypes.Id, user.Id));
        identity?.AddClaim(
            new Claim(GraphClaimTypes.DisplayName, user.DisplayName));
        identity?.AddClaim(
            new Claim(GraphClaimTypes.Email, user.Mail ?? "Sin email")); // user.UserPrincipalName
        identity?.AddClaim(
            new Claim(GraphClaimTypes.Department, user.Department ?? "Sin departamento"));
    }

    public static void AddUserGraphPhoto(this ClaimsPrincipal claimsPrincipal, Stream photoStream)
    {
        var identity = claimsPrincipal.Identity as ClaimsIdentity;

        if (photoStream is null)
        {
            // Add the default profile photo
            identity.AddClaim(
                new Claim(GraphClaimTypes.Photo, "/img/man.png"));
            return;
        }

        // Copy the photo stream to a memory stream
        // to get the bytes out of it
        var memoryStream = new MemoryStream();
        photoStream.CopyTo(memoryStream);
        var photoBytes = memoryStream.ToArray();

        // Generate a date URI for the photo
        var photoUrl = $"data:image/png;base64,{Convert.ToBase64String(photoBytes)}";

        identity.AddClaim(
            new Claim(GraphClaimTypes.Photo, photoUrl));
    }
}