namespace GestionJuridico.Models;

public class AdministradoPersona
{
    public int AdministradoId { get; set; }
    public Administrado Administrado { get; set; }

    public int PersonaId { get; set; }
    public Persona Persona { get; set; }

    public int CargoPersonaRepresentanteId { get; set; }
    public CargoPersonaRepresentante CargoPersonaRepresentante { get; set; }
}