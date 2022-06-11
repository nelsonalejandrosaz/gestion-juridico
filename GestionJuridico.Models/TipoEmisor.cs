using System.ComponentModel.DataAnnotations;

namespace GestionJuridico.Models;

public class TipoEmisor
{
    public int Id { get; set; }

    [Required]
    [MaxLength(2)]
    public string Codigo { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; }
}