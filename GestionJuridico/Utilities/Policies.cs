namespace GestionJuridico.Utilities;

public static class Policies
{
    public const string SolicitudVerListaName = "SOLICITUDVERLISTA";
    public const string SolicitudVerListaAsignadosName = "SOLICITUDVERLISTAASIGNADOS";
    public const string SolicutudCrudName = "SOLICITUDCRUD";
    public const string CatalogosAdministracionName = "CATALOGOSADMINISTRACION";

    public static List<string> SolicitudVerLista()
    {
        var policy = new List<string>()
        {
            RolesTypes.Administrador, RolesTypes.JefeJuridico, 
            RolesTypes.AsistenteAdministrativo
        };
        return policy;
    }

    public static List<string> SolicitudVerListaAsignados()
    {
        var policy = new List<string>()
        {
            RolesTypes.Administrador, 
            RolesTypes.ColaboradorJuridico
        };
        return policy;
    }

    public static List<string> SolicitudCrud()
    {
        var policy = new List<string>()
        {
            RolesTypes.Administrador, RolesTypes.JefeJuridico,
            RolesTypes.AsistenteAdministrativo, RolesTypes.ColaboradorJuridico
        };
        return policy;
    }

    public static List<string> CatalogosAdministracion()
    {
        var policy = new List<string>()
        {
            RolesTypes.Administrador
        };
        return policy;
    }
}