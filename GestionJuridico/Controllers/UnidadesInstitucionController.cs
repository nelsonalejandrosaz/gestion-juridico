using System.Net;
using GestionJuridico.Data;
using GestionJuridico.Extensions;
using GestionJuridico.Models;
using GestionJuridico.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace GestionJuridico.Controllers;

public class UnidadesInstitucionController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<UnidadesInstitucionController> _logger;

    public UnidadesInstitucionController(AppDbContext context, 
        ILogger<UnidadesInstitucionController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var unidadesIntitucion = _context.UnidadesInstitucion.ToList();
        return View(unidadesIntitucion);
    }

    public IActionResult Details(int id)
    {
        var unidadIntitucion = _context.UnidadesInstitucion
            //.Include(p => p.Estados)
            .FirstOrDefault(p => p.Id == id);
        if (unidadIntitucion == null) return NotFound();
        return View(unidadIntitucion);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(UnidadInstitucion unidadIntitucion)
    {
        if (ModelState.IsValid)
        {
            _context.UnidadesInstitucion.Add(unidadIntitucion);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosGuardadosExitosamente);
                return RedirectToAction("Details", new { id = unidadIntitucion.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
            return View(unidadIntitucion);

        }
        return View(unidadIntitucion);
    }

    public IActionResult Edit(int id)
    {
        var unidadIntitucion = _context.UnidadesInstitucion
            .FirstOrDefault(p => p.Id == id);
        if (unidadIntitucion is null) return NotFound();
        return View(unidadIntitucion);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, UnidadInstitucion unidadIntitucion)
    {
        if (ModelState.IsValid)
        {
            _context.UnidadesInstitucion.Update(unidadIntitucion);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosActualizadosExitosamente);
                return RedirectToAction("Details", new { id = unidadIntitucion.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
            return View(unidadIntitucion);
        }
        return View(unidadIntitucion);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var unidadIntitucion = _context.UnidadesInstitucion.Find(id);
        if (unidadIntitucion is null) return NotFound();
        _context.UnidadesInstitucion.Remove(unidadIntitucion);
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