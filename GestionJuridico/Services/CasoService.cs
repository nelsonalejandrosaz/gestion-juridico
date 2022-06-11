using GestionJuridico.Data;
using GestionJuridico.Extensions;
using GestionJuridico.Models;
using GestionJuridico.Models.ViewModels;
using Microsoft.Graph;

namespace GestionJuridico.Services;

public class CasoService : ICasoService
{
    private readonly AppDbContext _context;
    private readonly ILogger<SolicitudService> _logger;
    private readonly GraphServiceClient _graphServiceClient;

    public CasoService(AppDbContext context,
        ILogger<SolicitudService> logger,
        GraphServiceClient graphServiceClient)
    {
        _context = context;
        _logger = logger;
        _graphServiceClient = graphServiceClient;
    }
    public string GenerarCodigo()
    {
        var totalCasos = _context.Solicitudes.Count();
        totalCasos++;
        var anio = DateTime.Now.Year.ToString();
        var codigo = $"SIGET-{anio}-{totalCasos:D4}";
        return codigo;
    }

    public bool IngresarEstado(AccionEstadoViewModel accionEstadoViewModel, string nombreUsuario)
    {
        // caso
        var caso = _context.Casos
            .First(s => s.Id == accionEstadoViewModel.SolicitudId);
        // accion
        var accion = _context.Acciones
            .First(a => a.Id == accionEstadoViewModel.AccionId);
        // estado
        var estadoSiguiente = _context.Estados
            .First(e => e.Id == accion.EstadoSiguienteId);
        //
        var historicoEstadoActual = _context.HistoricoEstadosCaso
            .FirstOrDefault(he => he.CasoId == accionEstadoViewModel.SolicitudId && he.Activo);
        if (historicoEstadoActual is not null)
        {
            historicoEstadoActual.Activo = false;
            historicoEstadoActual.FechaFin = DateTime.Now;
        }
        // Se inserta el nuevo estado
        var historicoEstadoSiguiente = new HistoricoEstadosCaso()
        {
            CasoId = caso.Id,
            EstadoId = estadoSiguiente.Id,
            AccionId = accion.Id,
            FechaInicio = DateTime.Now,
            Activo = true,
            Comentario = accionEstadoViewModel.Comentario,
            UsuarioCreador = nombreUsuario
        };
        // Si el estado tiene plazo de vencimiento se agrega la fecha de vencimiento al estado
        if (estadoSiguiente.DiasPlazo.HasValue)
        {
            historicoEstadoSiguiente.FechaVencimiento = DateTime.Now.AddDays(estadoSiguiente.DiasPlazo.Value);
        }
        caso.EstadoId = estadoSiguiente.Id;
        _context.HistoricoEstadosCaso.Add(historicoEstadoSiguiente);
        if (accionEstadoViewModel.UserId is not null)
        {
            caso.EmpleadoAsignadoId = accionEstadoViewModel.UserId;
            caso.EmpleadoAsignadoNombre = _graphServiceClient.GetUserDisplayName(accionEstadoViewModel.UserId);
        }
        try
        {
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _logger.LogError($"No se pudo guardar el nuevo estado, consulte SolicitudService. Error: {e.InnerException?.Message}");
            return false;
        }
        // TODO Envio de notificaciones por correo
        return true;
    }

}