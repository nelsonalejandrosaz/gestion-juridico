using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GestionJuridico.Models.Utilities;

namespace GestionJuridico.Models;

public class Solicitud
{
    public int Id { get; set; }

    public string Codigo { get; set; } = $"{DateTime.Now.Year}-XXXX";

    [DataType(DataType.Date)]
    [Required(ErrorMessage = ModelErrorMessage.Requerido)]
    public DateTime FechaIngreso { get; set; } = DateTime.Now;

    public DateTime? FechaFinalizado { get; set; }

    [Required(ErrorMessage = ModelErrorMessage.Requerido)]
    public int UnidadSolicitanteId { get; set; }
    public UnidadInstitucion? UnidadSolicitante { get; set; }

    [Required(ErrorMessage = ModelErrorMessage.Requerido)]
    public string PersonaSolicitante { get; set; }

    [Required(ErrorMessage = ModelErrorMessage.Requerido)]
    public string Descripcion { get; set; }

    [DataType(DataType.Url)]
    public string? ArchivoVinculado { get; set; }

    public int? TipoEmisorId { get; set; }
    [DisplayFormat(NullDisplayText = "S/A")]
    public TipoEmisor? TipoEmisor { get; set; }

    public int? TipoActoId { get; set; }
    public TipoActo? TipoActo { get; set; }

    [DataType(DataType.Url)]
    public string? DocumentoTrabajo { get; set; }

    public int EstadoId { get; set; } = 1;
    public Estado? EstadoActual { get; set; }

    public string? EmpleadoAsignadoId { get; set; }
    public string? EmpleadoAsignadoNombre { get; set; }

    public int? CasoId { get; set; }
    public Caso? Caso { get; set; }

    public List<HistoricoEstadosSolicitud>? HistoricoEstados { get; set; }
}