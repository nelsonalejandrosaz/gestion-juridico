using System.ComponentModel.DataAnnotations;

namespace GestionJuridico.Models.ViewModels;

public class PersonaCargoViewModel
{
    [Required]
    public int AdministradoId { get; set; }

    [Required]
    public int PersonaId { get; set; }

    [Required]
    public int CargoId { get; set; }
}