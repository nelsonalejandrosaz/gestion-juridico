using System.ComponentModel.DataAnnotations;
using GestionJuridico.Models.Utilities;

namespace GestionJuridico.Models;

public class Proceso
{
    public int Id { get; set; }

    [Required(ErrorMessage = ModelErrorMessage.Requerido)]
    [MaxLength(1)]
    public string Codigo { get; set; }

    [Required(ErrorMessage = ModelErrorMessage.Requerido)]
    [MaxLength(50)]
    public string Nombre { get; set; }

    [Required(ErrorMessage = ModelErrorMessage.Requerido)]
    [MaxLength(140)]
    public string Descripcion { get; set; }

    public int? AccionInicialId { get; set; }

    //public ICollection<Estado> Estados { get; set; }
}