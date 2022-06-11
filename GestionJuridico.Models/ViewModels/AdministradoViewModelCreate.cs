using System.ComponentModel.DataAnnotations;

namespace GestionJuridico.Models.ViewModels;

public class AdministradoViewModelCreate
{
    public int Id { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [MaxLength(100)]
    public string Nombre { get; set; }

    [Required]
    [MaxLength(25)]
    public string NumeroDocumento { get; set; }

    [Required]
    public int TipoDocumentoId { get; set; }
    public TipoDocumento? TipoDocumento { get; set; }

    [Required]
    [MaxLength(280)]
    public string Direccion { get; set; }

    [Required]
    [MaxLength(50)]
    public string Telefono { get; set; }


    [MaxLength(100)]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    public int? PersonaId { get; set; }

    [Required]
    [MaxLength(10)]
    public string? Dui { get; set; }

    [Required]
    [MaxLength(100)]
    public string NombrePersonaRepresentante { get; set; }

    [Required]
    [MaxLength(50)]
    public string TelefonoPersonaRepresentante { get; set; }

    [Required]
    public int? CargoPersonaRepresentanteId { get; set; }
    public CargoPersonaRepresentante? CargoPersonaRepresentante { get; set; }

    [Required]
    public int TipoEntidadId { get; set; }
    public TipoEntidad? TipoEntidad { get; set; }

}