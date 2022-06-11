namespace GestionJuridico.Models;

public class ConjuntoItemMenu
{
    public string Nombre { get; set; }
    public string Icono { get; set; } = "fa-circle";
    public bool Activo { get; set; } = false;
    public List<ItemMenu>? Items { get; set; } = new List<ItemMenu>();
}