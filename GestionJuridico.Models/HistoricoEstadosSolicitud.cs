using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionJuridico.Models;

public class HistoricoEstadosSolicitud
{
    public int Id { get; set; }

    public Solicitud Solicitud { get; set; }
    public int SolicitudId { get; set; }

    public Accion Accion { get; set; }
    public int AccionId { get; set; }

    public Estado Estado { get; set; }
    public int EstadoId { get; set; }

    [Display(Name = "Fecha Inicio")]
    public DateTime FechaInicio { get; set; }

    [Display(Name = "Fecha Fin")]
    public DateTime? FechaFin { get; set; }

    [Column(TypeName = "date")]
    [Display(Name = "Fecha Vencimiento")]
    public DateTime? FechaVencimiento { get; set; }

    public string Comentario { get; set; }

    public bool Activo { get; set; }

    public string UsuarioCreador { get; set; }
}