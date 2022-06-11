using System.ComponentModel.DataAnnotations;

namespace GestionJuridico.Models;

public class TipoEstado
{
    public int Id { get; set; }

    [Required]
    [MaxLength(10)]
    public string Codigo { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; }
}