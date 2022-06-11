using System.ComponentModel.DataAnnotations;

namespace GestionJuridico.Models;

public class TipoEntidad
{
    public int Id { get; set; }

    [Required]
    [MaxLength(5)]
    public string Codigo { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; }

}