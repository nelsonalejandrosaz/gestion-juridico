using System.ComponentModel.DataAnnotations;

namespace GestionJuridico.Models;

public class Caso
{
    public int Id { get; set; }

    [Required]
    public string Codigo { get; set; } = $"SIGET-{DateTime.Now.Year}-XXXX";

    [Required]
    [DataType(DataType.Date)]
    public DateTime FechaApertura { get; set; } = DateTime.Now;

    [DataType(DataType.Date)]
    public DateTime? FechaCierre { get; set; }

    [Required]
    public string Descripcion { get; set; }

    [Required]
    public int EntidadSolicitanteId { get; set; }
    public Administrado? EntidadSolicitante { get; set; }

    public int EstadoId { get; set; } = 1;
    public Estado? EstadoActual { get; set; }

    public string? EmpleadoAsignadoId { get; set; }
    public string? EmpleadoAsignadoNombre { get; set; }

    public ICollection<Solicitud>? Solicitudes { get; set; }

    public List<HistoricoEstadosCaso>? HistoricoEstados { get; set; }

}