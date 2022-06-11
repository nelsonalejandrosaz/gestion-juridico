using System.Net;
using GestionJuridico.Data;
using GestionJuridico.Extensions;
using GestionJuridico.Models;
using GestionJuridico.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestionJuridico.Controllers;

public class EstadosController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<EstadosController> _logger;

    public EstadosController(AppDbContext context, 
        ILogger<EstadosController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var estados = _context.Estados
            .Include(e => e.Proceso)
            .ToList();
        return View(estados);
    }

    public IActionResult Details(int id)
    {
        var estado = _context.Estados
            .Include(e => e.Proceso)
            .FirstOrDefault(e => e.Id == id);
        if (estado == null) return NotFound();
        return View(estado);
    }

    public IActionResult Create()
    {
        LoadViewData();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Estado estado)
    {
        if (ModelState.IsValid)
        {
            _context.Estados.Add(estado);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosGuardadosExitosamente);
                return RedirectToAction("Details", new { id = estado.Id });
            }
            LoadViewData();
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
            return View(estado);
        }
        LoadViewData();
        return View(estado);
    }

    public IActionResult Edit(int id)
    {
        var estado = _context.Estados
            //.Include(e => e.Proceso)
            .FirstOrDefault(e => e.Id == id);
        if(estado is null) return NotFound();
        LoadViewData();
        return View(estado);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Estado estado)
    {
        if (ModelState.IsValid)
        {
            _context.Estados.Update(estado);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosActualizadosExitosamente);
                return RedirectToAction("Details", new { id = estado.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
            return View(estado);
        }
        LoadViewData();
        return View(estado);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var estado = _context.Estados.Find(id);
        if (estado is null) return NotFound();
        _context.Estados.Remove(estado);
        if (!SaveChanges()) return StatusCode((int) HttpStatusCode.InternalServerError);
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

    private void LoadViewData()
    {
        var procesos = _context.Procesos.ToList();
        ViewData["Procesos"] = new SelectList(procesos, "Id", "Nombre");
    }
}