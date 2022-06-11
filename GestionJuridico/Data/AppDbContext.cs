using GestionJuridico.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionJuridico.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Accion> Acciones { get; set; }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<Proceso> Procesos { get; set; }
    public DbSet<TipoAccion> TiposAccion { get; set; }
    public DbSet<TipoEstado> TiposEstado { get; set; }
    public DbSet<Solicitud> Solicitudes { get; set; }
    public DbSet<HistoricoEstadosSolicitud> HistoricoEstadosSolicitud { get; set; }

    public DbSet<TipoEmisor> TiposEmisor { get; set; }
    public DbSet<UnidadInstitucion> UnidadesInstitucion { get; set; }
    public DbSet<TipoActo> TiposActo { get; set; }

    public DbSet<Administrado> Administrados { get; set; }
    public DbSet<TipoDocumento> TiposDocumento { get; set; }
    public DbSet<TipoEntidad> TiposEntidad { get; set; }
    public DbSet<Caso> Casos { get; set; }
    public DbSet<HistoricoEstadosCaso> HistoricoEstadosCaso { get; set; }
    public DbSet<CargoPersonaRepresentante> CargosPersonaRepresentante { get; set; }

    public DbSet<Persona> Personas { get; set; }

    public DbSet<AdministradoPersona> AdministradoPersona { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Cambio de comportamiento de eliminación de modelos relacionados 
        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
        foreach (var fk in cascadeFKs)
        {
            fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
        // Tabla: Acciones 
        modelBuilder.Entity<Accion>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<Accion>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        // Tabla: Estados
        modelBuilder.Entity<Estado>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<Estado>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        // Tabla: Procesos
        modelBuilder.Entity<Proceso>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<Proceso>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        // Tabla: TiposAccion
        modelBuilder.Entity<TipoAccion>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<TipoAccion>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        // Tabla: TiposEstados
        modelBuilder.Entity<TipoEstado>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<TipoEstado>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        // Tabla: Solicitudes
        modelBuilder.Entity<Solicitud>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<Solicitud>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        // Tabla: HistoricoEstadosSolicitud
        modelBuilder.Entity<HistoricoEstadosSolicitud>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<HistoricoEstadosSolicitud>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        // Tabla: TiposEmisor
        modelBuilder.Entity<TipoEmisor>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<TipoEmisor>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        // Tabla: UnidadesInstitucion
        modelBuilder.Entity<UnidadInstitucion>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<UnidadInstitucion>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        // Tabla: TiposActo
        modelBuilder.Entity<TipoActo>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<TipoActo>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        // Tabla: EntidadesSolicitante
        modelBuilder.Entity<Administrado>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<Administrado>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        // Tabla: TiposDocumento
        modelBuilder.Entity<TipoDocumento>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<TipoDocumento>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        // Tabla: TiposEntidad
        modelBuilder.Entity<TipoEntidad>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<TipoEntidad>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        // Tabla: Casos
        modelBuilder.Entity<Caso>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<Caso>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        // Tabla: HistoricoEstadosCaso
        modelBuilder.Entity<HistoricoEstadosCaso>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<HistoricoEstadosCaso>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        // Tabla: CargosPersonaRepresentante
        modelBuilder.Entity<CargoPersonaRepresentante>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<CargoPersonaRepresentante>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        // Tabla: CargosPersonaRepresentante
        modelBuilder.Entity<Persona>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<Persona>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        // Tabla: AdministradoPersona
        modelBuilder.Entity<AdministradoPersona>()
            .HasKey(ap => new { ap.AdministradoId, ap.PersonaId });
        modelBuilder.Entity<AdministradoPersona>()
            .HasOne(ap => ap.Administrado)
            .WithMany(a => a.AdministradoPersonas)
            .HasForeignKey(ap => ap.AdministradoId);
        modelBuilder.Entity<AdministradoPersona>()
            .HasOne(ap => ap.Persona)
            .WithMany(p => p.Administrados)
            .HasForeignKey(ap => ap.PersonaId);
        modelBuilder.Entity<AdministradoPersona>().Property<bool>("isDeleted").HasDefaultValue(false);
        modelBuilder.Entity<AdministradoPersona>().HasQueryFilter(x => EF.Property<bool>(x, "isDeleted") == false);
        //
        base.OnModelCreating(modelBuilder);

    }
}