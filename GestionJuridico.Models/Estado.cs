using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GestionJuridico.Models.Utilities;

namespace GestionJuridico.Models;

public class Estado
{
    public int Id { get; set; }

    [Required(ErrorMessage = ModelErrorMessage.Requerido)]
    [MaxLength(10)]
    [DisplayName("Código")]
    public string Codigo { get; set; }

    [Required(ErrorMessage = ModelErrorMessage.Requerido)]
    [MaxLength(50)]
    public string Nombre { get; set; }

    [DisplayName("Días Plazo")]
    [DisplayFormat(NullDisplayText = "Sin plazo")]
    public int? DiasPlazo { get; set; }

    [Required(ErrorMessage = ModelErrorMessage.Requerido)]
    [DisplayName("Proceso")]
    public int ProcesoId { get; set; }
    public Proceso? Proceso { get; set; }

    //[Required(ErrorMessage = ModelErrorMessage.Requerido)]
    //public int TipoEstadoId { get; set; }
    //public TipoEstado? TipoEstado { get; set; }

    //public ICollection<Accion> AccionesEstadoActual { get; set; }

    //public ICollection<HistoricoEstados> HistoricoEstados { get; set; }

    //[DisplayName("Roles involucrados")]
    //public List<EstadosRoles> Roles { get; set; }
}