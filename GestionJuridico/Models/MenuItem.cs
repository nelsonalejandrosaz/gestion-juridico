namespace GestionJuridico.Models;

public class MenuItem
{
    public string Nombre { get; set; }
    public string Icono { get; set; } = "fa-circle";
    public string? Controlador { get; set; }
    public string? Accion { get; set; }
    public bool Activo { get; set; } = false;
    public int TipoMenu { get; set; } = 1; // 1: Menu -- 2: SubMenu 
    public List<MenuItem>? SubMenuItems { get; set; }
}