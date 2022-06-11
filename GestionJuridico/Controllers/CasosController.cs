using GestionJuridico.Data;
using GestionJuridico.Extensions;
using GestionJuridico.Models;
using GestionJuridico.Models.ViewModels;
using GestionJuridico.Services;
using GestionJuridico.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using Microsoft.Identity.Web;

namespace GestionJuridico.Controllers;

public class CasosController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<CasosController> _logger;
    private readonly ICasoService _casoService;
    private readonly GraphServiceClient _graphServiceClient;

    public CasosController(AppDbContext context,
        ILogger<CasosController> logger,
        ICasoService casoService,
        GraphServiceClient graphServiceClient)
    {
        _context = context;
        _logger = logger;
        _casoService = casoService;
        _graphServiceClient = graphServiceClient;
    }

    public IActionResult Index()
    {
        var casos = _context.Casos
            .Include(c => c.EntidadSolicitante)
            .ToList();
        return View(casos);
    }

    [AuthorizeForScopes]
    public async Task<IActionResult> Details(int id)
    {
        var caso = _context.Casos
            .Include(c => c.HistoricoEstados)
            .ThenInclude(he => he.Accion)
            .Include(c => c.HistoricoEstados)
            .ThenInclude(he => he.Estado)
            .Include(c => c.EntidadSolicitante)
            .Include(c => c.Solicitudes)
            .ThenInclude(s => s.EstadoActual)
            .FirstOrDefault(c => c.Id == id);
        if (caso is null) return NotFound();
        //return Ok(caso);
        var listaEmpleados = await _graphServiceClient.GetUserList();
        var acciones = _context.Acciones
            .Include(a => a.TipoAccion)
            .Where(a => a.EstadoActualId == caso.EstadoId).ToList();
        ViewData["Acciones"] = acciones;
        ViewData["Empleados"] = new SelectList(listaEmpleados, "Id", "DisplayName");
        return View(caso);
    }

    public IActionResult Create()
    {
        var caso = new Caso();
        LoadViewData();
        return View(caso);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CambiarEstadoNormal(AccionEstadoViewModel accionEstadoViewModel)
    {
        // url de retorno
        //var returnUrl = Request.GetTypedHeaders().Referer;
        // Servicio 
        var result = _casoService.IngresarEstado(accionEstadoViewModel, User.GetUserGraphDisplayName());
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
    public IActionResult Create(Caso caso)
    {
        if (ModelState.IsValid)
        {
            // Generar codigo para el caso
            caso.Codigo = _casoService.GenerarCodigo();
            _context.Casos.Add(caso);
            if (SaveChanges())
            {
                // Agregar estado inicial 
                var proceso = _context.Procesos.FirstOrDefault(p => p.Codigo == "C");
                if (proceso is null || !proceso.AccionInicialId.HasValue)
                {
                    _context.Casos.Remove(caso);
                    SaveChanges();
                    TempData.MessageDanger(AppMessages.ProcesoNoConfigurado);
                    return View(caso);
                }

                var accionInicialId = proceso.AccionInicialId;
                var accionEstadoViewModel = new AccionEstadoViewModel()
                {
                    SolicitudId = caso.Id,
                    AccionId = accionInicialId.Value,
                    Comentario = "Solicitud ingresada correctamente"
                };
                var result = _casoService.IngresarEstado(accionEstadoViewModel, User.GetUserGraphDisplayName());
                if (result)
                {
                    TempData.MessageSuccess(AppMessages.DatosGuardadosExitosamente);
                    return RedirectToAction("Details", new { id = caso.Id });
                }
            }

            LoadViewData();
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
            return View(caso);
        }

        return View();
    }

    private void LoadViewData()
    {
        var entidadesSolicitente = _context.Administrados
            .Select(es => new
            {
                es.Id,
                Nombre = $"{es.NumeroDocumento} | {es.Nombre}"
            })
            .ToList();
        ViewData["EntidadesSolicitante"] = new SelectList(entidadesSolicitente, "Id", "Nombre");
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
}