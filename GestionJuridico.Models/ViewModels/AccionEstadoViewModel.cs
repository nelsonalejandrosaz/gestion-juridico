namespace GestionJuridico.Models.ViewModels;

public class AccionEstadoViewModel
{
    public int AccionId { get; set; }

    public int SolicitudId { get; set; }

    public string Comentario { get; set; }

    public string? UserId { get; set; }
}