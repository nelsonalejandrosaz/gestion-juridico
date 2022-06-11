using System.Net;
using GestionJuridico.Data;
using GestionJuridico.Extensions;
using GestionJuridico.Models;
using GestionJuridico.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace GestionJuridico.Controllers;

public class CargosPersonaRepresentante : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<TiposActoController> _logger;

    public CargosPersonaRepresentante(AppDbContext context,
        ILogger<TiposActoController> logger)
    {
        _context = context;
        _logger = logger;
    }
    public IActionResult Index()
    {
        var cargosPersonasRepresentante = _context.CargosPersonaRepresentante.ToList();
        return View(cargosPersonasRepresentante);
    }

    public IActionResult Details(int id)
    {
        var cargoPersonaRepresentante = _context.CargosPersonaRepresentante
            //.Include(p => p.Estados)
            .FirstOrDefault(p => p.Id == id);
        if (cargoPersonaRepresentante == null) return NotFound();
        return View(cargoPersonaRepresentante);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CargoPersonaRepresentante cargoPersonaRepresentante)
    {
        if (ModelState.IsValid)
        {
            _context.CargosPersonaRepresentante.Add(cargoPersonaRepresentante);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosGuardadosExitosamente);
                return RedirectToAction("Details", new { id = cargoPersonaRepresentante.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
            return View(cargoPersonaRepresentante);

        }
        return View(cargoPersonaRepresentante);
    }

    public IActionResult Edit(int id)
    {
        var cargoPersonaRepresentante = _context.CargosPersonaRepresentante
            .FirstOrDefault(p => p.Id == id);
        if (cargoPersonaRepresentante is null) return NotFound();
        return View(cargoPersonaRepresentante);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, CargoPersonaRepresentante cargoPersonaRepresentante)
    {
        if (ModelState.IsValid)
        {
            _context.CargosPersonaRepresentante.Update(cargoPersonaRepresentante);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosActualizadosExitosamente);
                return RedirectToAction("Details", new { id = cargoPersonaRepresentante.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
            return View(cargoPersonaRepresentante);
        }
        return View(cargoPersonaRepresentante);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var cargoPersonaRepresentante = _context.CargosPersonaRepresentante.Find(id);
        if (cargoPersonaRepresentante is null) return NotFound();
        _context.CargosPersonaRepresentante.Remove(cargoPersonaRepresentante);
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