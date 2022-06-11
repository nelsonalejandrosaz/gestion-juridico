namespace GestionJuridico.Models;

public class CategoriaMenu
{
    public string Nombre { get; set; }

    public List<ItemMenu> Items { get; set; } = new List<ItemMenu>();
    public List<ConjuntoItemMenu> ConjuntoItems { get; set; } = new List<ConjuntoItemMenu>();
}