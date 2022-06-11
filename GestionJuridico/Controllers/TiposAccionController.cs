using System.Net;
using GestionJuridico.Data;
using GestionJuridico.Extensions;
using GestionJuridico.Models;
using GestionJuridico.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace GestionJuridico.Controllers;

public class TiposAccionController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<TiposAccionController> _logger;

    public TiposAccionController(AppDbContext context,
        ILogger<TiposAccionController> logger)
    {
        _context = context;
        _logger = logger;
    }
    public IActionResult Index()
    {
        var tiposAccion = _context.TiposAccion.ToList();
        return View(tiposAccion);
    }

    public IActionResult Details(int id)
    {
        var tipoAccion = _context.TiposAccion
            //.Include(p => p.Estados)
            .FirstOrDefault(p => p.Id == id);
        if (tipoAccion == null) return NotFound();
        return View(tipoAccion);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(TipoAccion tipoAccion)
    {
        if (ModelState.IsValid)
        {
            _context.TiposAccion.Add(tipoAccion);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosGuardadosExitosamente);
                return RedirectToAction("Details", new { id = tipoAccion.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
            return View(tipoAccion);

        }
        return View(tipoAccion);
    }

    public IActionResult Edit(int id)
    {
        var tipoAccion = _context.TiposAccion
            .FirstOrDefault(p => p.Id == id);
        if (tipoAccion is null) return NotFound();
        return View(tipoAccion);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, TipoAccion tipoAccion)
    {
        if (ModelState.IsValid)
        {
            _context.TiposAccion.Update(tipoAccion);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosActualizadosExitosamente);
                return RedirectToAction("Details", new { id = tipoAccion.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
            return View(tipoAccion);
        }
        return View(tipoAccion);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var tipoAccion = _context.TiposAccion.Find(id);
        if (tipoAccion is null) return NotFound();
        _context.TiposAccion.Remove(tipoAccion);
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
            _logger.LogError(e.Message);
            return false;
        }
    }
}