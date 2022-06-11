using System.Net;
using GestionJuridico.Data;
using GestionJuridico.Extensions;
using GestionJuridico.Models;
using GestionJuridico.Utilities;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestionJuridico.Controllers;

public class ProcesosController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<ProcesosController> _logger;

    public ProcesosController(AppDbContext context, 
        ILogger<ProcesosController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var procesos = _context.Procesos.ToList();
        return View(procesos);
    }

    public IActionResult Details(int id)
    {
        var proceso = _context.Procesos
            //.Include(p => p.Estados)
            .FirstOrDefault(p => p.Id == id);
        if (proceso == null) return NotFound();
        return View(proceso);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Proceso proceso)
    {
        if (ModelState.IsValid)
        {
            _context.Procesos.Add(proceso);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosGuardadosExitosamente);
                return RedirectToAction("Details", new { id = proceso.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
            return View(proceso);

        }
        return View(proceso);
    }

    public IActionResult Edit(int id)
    {
        var proceso = _context.Procesos
            .FirstOrDefault(p => p.Id == id);
        if(proceso is null) return NotFound();
        LoadViewData();
        return View(proceso);
    }

    private void LoadViewData()
    {
        var acciones = _context.Acciones
            .Select(a => new
            {
                a.Id,
                Nombre = $"{a.Codigo} - {a.Nombre}"
            })
            .ToList();
        ViewData["Acciones"] = new SelectList(acciones, "Id", "Nombre");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Proceso proceso)
    {
        if(ModelState.IsValid)
        {
            _context.Procesos.Update(proceso);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosActualizadosExitosamente);
                return RedirectToAction("Details", new { id = proceso.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
            return View(proceso);
        }
        return View(proceso);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var proceso = _context.Procesos.Find(id);
        if(proceso is null) return NotFound();
        _context.Procesos.Remove(proceso);
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