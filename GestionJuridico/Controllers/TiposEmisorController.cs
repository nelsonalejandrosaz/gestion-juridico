using System.Net;
using GestionJuridico.Data;
using GestionJuridico.Extensions;
using GestionJuridico.Models;
using GestionJuridico.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace GestionJuridico.Controllers;

public class TiposEmisorController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<TiposEmisorController> _logger;

    public TiposEmisorController(AppDbContext context, 
        ILogger<TiposEmisorController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var tiposEmisor = _context.TiposEmisor.ToList();
        return View(tiposEmisor);
    }

    public IActionResult Details(int id)
    {
        var tipoEmisor = _context.TiposEmisor
            //.Include(p => p.Estados)
            .FirstOrDefault(p => p.Id == id);
        if (tipoEmisor == null) return NotFound();
        return View(tipoEmisor);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(TipoEmisor tipoEmisor)
    {
        if (ModelState.IsValid)
        {
            _context.TiposEmisor.Add(tipoEmisor);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosGuardadosExitosamente);
                return RedirectToAction("Details", new { id = tipoEmisor.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
            return View(tipoEmisor);

        }
        return View(tipoEmisor);
    }

    public IActionResult Edit(int id)
    {
        var tipoEmisor = _context.TiposEmisor
            .FirstOrDefault(p => p.Id == id);
        if (tipoEmisor is null) return NotFound();
        return View(tipoEmisor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, TipoEmisor tipoEmisor)
    {
        if (ModelState.IsValid)
        {
            _context.TiposEmisor.Update(tipoEmisor);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosActualizadosExitosamente);
                return RedirectToAction("Details", new { id = tipoEmisor.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
            return View(tipoEmisor);
        }
        return View(tipoEmisor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var tipoEmisor = _context.TiposEmisor.Find(id);
        if (tipoEmisor is null) return NotFound();
        _context.TiposEmisor.Remove(tipoEmisor);
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