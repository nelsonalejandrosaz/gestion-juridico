using System.ComponentModel.DataAnnotations;

namespace GestionJuridico.Models.ViewModels;

public class SolicitudCasoViewModel
{
    [Required]
    public int SolicitudId { get; set; }

    [Required]
    public int CasoId { get; set; }

}