using System.Net;
using GestionJuridico.Data;
using GestionJuridico.Extensions;
using GestionJuridico.Models;
using GestionJuridico.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestionJuridico.Controllers;

public class AccionesController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<AccionesController> _logger;

    public AccionesController(AppDbContext context,
        ILogger<AccionesController> logger)
    {
        _context = context;
        _logger = logger;
    }
    public IActionResult Index()
    {
        var acciones = _context.Acciones
            .Include(a => a.EstadoActual)
            .ThenInclude(e => e.Proceso)
            .Include(a => a.EstadoSiguiente)
            .ToList();
        return View(acciones);
    }

    public IActionResult Details(int id)
    {
        var accion = _context.Acciones
            .Include(a => a.EstadoActual)
            .Include(a => a.EstadoSiguiente)
            .FirstOrDefault(a => a.Id == id);
        if (accion is null) return NotFound();
        return View(accion);
    }

    public IActionResult Create()
    {
        LoadViewData(null);
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Accion accion)
    {
        if (ModelState.IsValid)
        {
            _context.Acciones.Add(accion);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosGuardadosExitosamente);
                return RedirectToAction("Details", new { id = accion.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
        }
        LoadViewData(null);
        return View(accion);
    }

    public IActionResult Edit(int id)
    {
        var accion = _context.Acciones
            .Include(e => e.EstadoActual)
            .FirstOrDefault(e => e.Id == id);
        if (accion is null) return NotFound();
        LoadViewData(accion);
        return View(accion);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Accion accion)
    {
        if (ModelState.IsValid)
        {
            _context.Acciones.Update(accion);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosActualizadosExitosamente);
                return RedirectToAction("Details", new { id = accion.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
        }
        LoadViewData(accion);
        return View(accion);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var accion = _context.Acciones.Find(id);
        if (accion is null) return NotFound();
        _context.Acciones.Remove(accion);
        if (!SaveChanges()) return StatusCode((int)HttpStatusCode.InternalServerError);
        TempData.MessageSuccess(AppMessages.DatosEliminadosExitosamente);
        return Ok();
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

    private void LoadViewData(Accion? accion)
    {
        var procesos = _context.Procesos.ToList();
        var tiposAccion = _context.TiposAccion.ToList();
        if (accion is not null)
        {
            var estados = _context.Estados
                .Where(e => e.ProcesoId == accion.EstadoActual.ProcesoId)
                .ToList();
            ViewData["Estados"] = new SelectList(estados, "Id", "Nombre");
        }
        ViewData["Procesos"] = new SelectList(procesos, "Id", "Nombre");
        ViewData["TiposAccion"] = new SelectList(tiposAccion, "Id", "Nombre");
    }

}