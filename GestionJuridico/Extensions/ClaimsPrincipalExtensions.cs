using System.Security.Claims;

namespace GestionJuridico.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string GetRoleValue(this ClaimsPrincipal user)
    {
        var role = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        return role;
    }
}