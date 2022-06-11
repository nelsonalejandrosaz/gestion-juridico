using GestionJuridico.Data;
using GestionJuridico.Extensions;
using GestionJuridico.Models;
using GestionJuridico.Models.ViewModels;
using GestionJuridico.Services;
using GestionJuridico.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using Microsoft.Identity.Web;

namespace GestionJuridico.Controllers;

[Authorize]
public class SolicitudesController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<SolicitudesController> _logger;
    private readonly ISolicitudService _solicitudService;
    private readonly GraphServiceClient _graphServiceClient;

    public SolicitudesController(AppDbContext context, 
        ILogger<SolicitudesController> logger, 
        ISolicitudService solicitudService, 
        GraphServiceClient graphServiceClient)
    {
        _context = context;
        _logger = logger;
        _solicitudService = solicitudService;
        _graphServiceClient = graphServiceClient;
    }

    [Authorize(Policy = Policies.SolicitudVerListaName)]
    public IActionResult Index()
    {
        var solicitudes = _context
            .Solicitudes
            .Select(s => new Solicitud()
            {
                Id = s.Id,
                Codigo = s.Codigo,
                UnidadSolicitante = new UnidadInstitucion()
                {
                    Nombre = s.UnidadSolicitante.Nombre
                },
                PersonaSolicitante = s.PersonaSolicitante,
                FechaIngreso = s.FechaIngreso,
                FechaFinalizado = s.FechaFinalizado,
                EstadoActual = new Estado()
                {
                    Nombre = s.EstadoActual.Nombre
                },
                EmpleadoAsignadoNombre = s.EmpleadoAsignadoNombre
            })
            .ToList();
        return View(solicitudes);
    }

    [AuthorizeForScopes]
    public async Task<IActionResult> Details(int id)
    {
        // Url de retorno
        var returnUrl = Request.GetTypedHeaders().Referer;
        var solicitud = _context.Solicitudes
            .Include(s => s.HistoricoEstados)
            .ThenInclude(he => he.Accion)
            .Include(s => s.HistoricoEstados)
            .ThenInclude(he => he.Estado)
            .Include(s => s.UnidadSolicitante)
            .Include(s => s.TipoEmisor)
            .Include(s => s.TipoActo)
            .Include(s => s.Caso)
            .FirstOrDefault(s => s.Id == id);
        if (solicitud == null) return NotFound();
        var listaEmpleados = await _graphServiceClient.GetUserList();
        var acciones = _context.Acciones
            .Include(a => a.TipoAccion)
            .Where(a => a.EstadoActualId == solicitud.EstadoId).ToList();
        var casos = _context.Casos
            .Select(c => new
            {
                c.Id,
                c.Codigo,
                c.FechaCierre,
            })
            .Where(c => !c.FechaCierre.HasValue)
            .ToList();
        ViewData["Acciones"] = acciones;
        ViewData["Empleados"] = new SelectList(listaEmpleados, "Id", "DisplayName");
        ViewData["Casos"] = new SelectList(casos, "Id", "Codigo");
        ViewData["UrlRetorno"] = Request.GetTypedHeaders().Referer;
        return View(solicitud);
    }

    public IActionResult Create()
    {
        var solicitud = new Solicitud();
        LoadViewData();
        return View(solicitud);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Solicitud solicitud)
    {
        if (ModelState.IsValid)
        {
            // Generar codigo para solicitud
            solicitud.Codigo = _solicitudService.GenerarCodigo();
            //
            _context.Solicitudes.Add(solicitud);
            if (SaveChanges())
            {
                // Agregar estado inicial
                var proceso = _context.Procesos.FirstOrDefault(s => s.Codigo == "S");
                if (proceso is null || !proceso.AccionInicialId.HasValue)
                {
                    _context.Solicitudes.Remove(solicitud);
                    SaveChanges();
                    TempData.MessageDanger(AppMessages.ProcesoNoConfigurado);
                    return View(solicitud);
                }
                var accionInicialId = _context.Procesos.First(s => s.Codigo == "S").AccionInicialId.Value;
                var accionEstadoViewModel = new AccionEstadoViewModel()
                {
                    SolicitudId = solicitud.Id,
                    AccionId = accionInicialId,
                    Comentario = "Solicitud ingresada correctamente"
                };
                var result = _solicitudService.IngresarEstado(accionEstadoViewModel, User.GetUserGraphDisplayName());
                if (result)
                {
                    TempData.MessageSuccess(AppMessages.DatosGuardadosExitosamente);
                    return RedirectToAction("Details", new { id = solicitud.Id });
                }
            }
            LoadViewData();
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
            return View(solicitud);
        }
        LoadViewData();
        return View(solicitud);
    }

    public IActionResult Edit(int id)
    {
        var solicitud = _context.Solicitudes
            .FirstOrDefault(s => s.Id == id);
        if (solicitud == null) return NotFound();
        LoadViewData();
        //return Ok(solicitud);
        return View(solicitud);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Solicitud solicitud)
    {
        //return Ok(solicitud);
        if (ModelState.IsValid)
        {
            _context.Solicitudes.Update(solicitud);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosActualizadosExitosamente);
                return RedirectToAction("Details", new { id = solicitud.Id });
            }
            LoadViewData();
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
            return View(solicitud);
        }
        LoadViewData();
        return View(solicitud);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CambiarEstadoNormal(AccionEstadoViewModel accionEstadoViewModel)
    {
        // url de retorno
        //var returnUrl = Request.GetTypedHeaders().Referer;
        // Servicio 
        var result = _solicitudService.IngresarEstado(accionEstadoViewModel, User.GetUserGraphDisplayName());
        if (result)
        {
            TempData.MessageSuccess(AppMessages.SolicitudActualizada);
            return RedirectToAction("Details", new { id = accionEstadoViewModel.SolicitudId });
        }
        TempData.MessageSuccess(AppMessages.ErrorGuardarDatos);
        return RedirectToAction("Details", new { id = accionEstadoViewModel.SolicitudId });
        //

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CambiarEstadoAsignar(AccionEstadoViewModel accionEstadoViewModel)
    {
        var result = _solicitudService.IngresarEstado(accionEstadoViewModel, User.GetUserGraphDisplayName());
        if (result)
        {
            TempData.MessageSuccess(AppMessages.SolicitudActualizada);
            return RedirectToAction("Details", new { id = accionEstadoViewModel.SolicitudId });
        }
        TempData.MessageSuccess(AppMessages.ErrorGuardarDatos);
        return RedirectToAction("Details", new { id = accionEstadoViewModel.SolicitudId });
        //

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AsignarCaso(SolicitudCasoViewModel solicitudCasoViewModel)
    {
        var solicitud = _context.Solicitudes
            .FirstOrDefault(s => s.Id == solicitudCasoViewModel.SolicitudId);
        if (solicitud == null) return NotFound();
        solicitud.CasoId = solicitudCasoViewModel.CasoId;
        if (SaveChanges())
        {
            TempData.MessageSuccess(AppMessages.SolicitudActualizada);
            return RedirectToAction("Details", new { id = solicitudCasoViewModel.SolicitudId });
        }
        TempData.MessageSuccess(AppMessages.ErrorGuardarDatos);
        return RedirectToAction("Details", new { id = solicitudCasoViewModel.SolicitudId });
    }

    private bool SaveChanges()
    {
        try
        {
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _logger.LogError(e.InnerException.Message);
            return false;
        }
    }

    private void LoadViewData()
    {
        var casos = _context.Casos
            .Select(c => new
            {
                c.Id,
                c.Codigo,
                c.FechaCierre,
            })
            .Where(c => !c.FechaCierre.HasValue)
            .ToList();
        var unidades = _context.UnidadesInstitucion.ToList();
        var tiposActo = _context.TiposActo.ToList();
        var tiposEmisor = _context.TiposEmisor.ToList();
        ViewData["Unidades"] = new SelectList(unidades, "Id", "Nombre");
        ViewData["TiposActo"] = new SelectList(tiposActo, "Id", "Nombre");
        ViewData["TiposEmisor"] = new SelectList(tiposEmisor, "Id", "Nombre");
        ViewData["Casos"] = new SelectList(casos, "Id", "Codigo");
    }
}