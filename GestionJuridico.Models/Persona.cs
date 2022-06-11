using System.ComponentModel.DataAnnotations;

namespace GestionJuridico.Models;

public class Persona
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; }

    [Required]
    [MaxLength(10)]
    public string Dui { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public ICollection<AdministradoPersona>? Administrados { get; set; }
}