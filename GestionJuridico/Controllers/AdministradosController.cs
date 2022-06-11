using GestionJuridico.Data;
using GestionJuridico.Extensions;
using GestionJuridico.Models;
using GestionJuridico.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GestionJuridico.Controllers;

public class AdministradosController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<AdministradosController> _logger;

    public AdministradosController(AppDbContext context,
        ILogger<AdministradosController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var entidadesSolicitantes = _context.Administrados
            .Include(es => es.TipoEntidad)
            .Include(es => es.TipoDocumento)
            .ToList();
        return View(entidadesSolicitantes);
    }

    public IActionResult Details(int id)
    {
        var entidadSolicitante = _context.Administrados
            .Include(es => es.TipoEntidad)
            .Include(es => es.TipoDocumento)
            .Include(es => es.AdministradoPersonas)
            //.Include(es => es.CargoPersonaRepresentante)
            .FirstOrDefault(es => es.Id == id);
        if (entidadSolicitante is null) return NotFound();
        var personas = _context.Personas.ToList();
        var cargosPersonas = _context.CargosPersonaRepresentante.ToList();
        ViewData["Personas"] = new SelectList(personas, "Id", "Nombre");
        ViewData["CargosPersonas"] = new SelectList(cargosPersonas, "Id", "Nombre");
        return View(entidadSolicitante);
    }

    public IActionResult Create()
    {
        LoadViewData();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Administrado administrado)
    {
        if(ModelState.IsValid)
        {
            _context.Administrados.Add(administrado);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosGuardadosExitosamente);
                return RedirectToAction("Details", new { id = administrado.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
        }
        LoadViewData();
        return View(administrado);
    }

    public IActionResult Edit(int id)
    {
        var entidadSolicitante = _context.Administrados
            .FirstOrDefault(es => es.Id == id);
        if (entidadSolicitante is null) return NotFound();
        LoadViewData();
        return View(entidadSolicitante);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Administrado administrado)
    {
        if (ModelState.IsValid)
        {
            _context.Administrados.Update(administrado);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosActualizadosExitosamente);
                return RedirectToAction("Details", new { id = administrado.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
        }
        LoadViewData();
        return View();
    }

    private void LoadViewData()
    {
        var tiposEntidad = _context.TiposEntidad.ToList();
        var tiposDocumento = _context.TiposDocumento.ToList();
        var cargosPersonaRepresentante = _context.CargosPersonaRepresentante.ToList();
        ViewData["TiposEntidad"] = new SelectList(tiposEntidad, "Id", "Nombre");
        ViewData["TiposDocumento"] = new SelectList(tiposDocumento, "Id", "Nombre");
        ViewData["CargosPersonaRepresentante"] = new SelectList(cargosPersonaRepresentante, "Id", "Nombre");
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