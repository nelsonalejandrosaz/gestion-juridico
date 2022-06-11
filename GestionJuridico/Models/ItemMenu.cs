namespace GestionJuridico.Models;

public class ItemMenu
{
    public string Nombre { get; set; }
    public string Icono { get; set; } = "fa-circle";
    public string? Controlador { get; set; }
    public string? Accion { get; set; }
    public bool Activo { get; set; } = false;
    public List<string> Roles { get; set; }
}