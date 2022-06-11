using Microsoft.AspNetCore.Authorization;

namespace GestionJuridico.Utilities;

public static class StartupConfigurations
{
    public static void ConfigurePoliciesOptions(AuthorizationOptions options)
    {
        // Directivas de Solicitudes
        options.AddPolicy(Policies.SolicitudVerListaName, 
            policy => policy.RequireRole(Policies.SolicitudVerLista()));
        options.AddPolicy(Policies.SolicitudVerListaAsignadosName,
    policy => policy.RequireRole(Policies.SolicitudVerListaAsignados()));
        options.AddPolicy(Policies.SolicutudCrudName,
    policy => policy.RequireRole(Policies.SolicitudCrud()));
        // Directivas de Administracion general
        options.AddPolicy(Policies.CatalogosAdministracionName,
    policy => policy.RequireRole(Policies.CatalogosAdministracion()));

    }
}