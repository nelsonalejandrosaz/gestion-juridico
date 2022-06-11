using System.Net;
using GestionJuridico.Data;
using GestionJuridico.Extensions;
using GestionJuridico.Models;
using GestionJuridico.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace GestionJuridico.Controllers;

public class PersonasController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<PersonasController> _logger;

    public PersonasController(AppDbContext context,
        ILogger<PersonasController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET
    public IActionResult Index()
    {
        var personas = _context.Personas.ToList();
        return View(personas);
    }

    public IActionResult Details(int id)
    {
        var persona = _context.Personas
            .FirstOrDefault(p => p.Id == id);
        if (persona == null) return NotFound();
        return View(persona);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Create(Persona persona)
    {
        if (ModelState.IsValid)
        {
            _context.Personas.Add(persona);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosGuardadosExitosamente);
                return RedirectToAction("Details", new { id = persona.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
        }
        return View(persona);
    }

    public IActionResult Edit(int id)
    {
        var persona = _context.Personas
            .FirstOrDefault(p => p.Id == id);
        if(persona == null) return NotFound();
        return View(persona);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Persona persona)
    {
        if (ModelState.IsValid)
        {
            _context.Personas.Update(persona);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosActualizadosExitosamente);
                return RedirectToAction("Details", new { id = persona.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
        }
        return View(persona);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var persona = _context.Personas.Find(id);
        if(persona is null) return NotFound();
        _context.Personas.Remove(persona);
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