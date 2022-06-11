using System.Net;
using GestionJuridico.Data;
using GestionJuridico.Extensions;
using GestionJuridico.Models;
using GestionJuridico.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace GestionJuridico.Controllers;

public class TiposActoController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<TiposActoController> _logger;

    public TiposActoController(AppDbContext context, 
        ILogger<TiposActoController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var tiposActo = _context.TiposActo.ToList();
        return View(tiposActo);
    }

    public IActionResult Details(int id)
    {
        var tipoActo = _context.TiposActo
            //.Include(p => p.Estados)
            .FirstOrDefault(p => p.Id == id);
        if (tipoActo == null) return NotFound();
        return View(tipoActo);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(TipoActo tipoActo)
    {
        if (ModelState.IsValid)
        {
            _context.TiposActo.Add(tipoActo);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosGuardadosExitosamente);
                return RedirectToAction("Details", new { id = tipoActo.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
            return View(tipoActo);

        }
        return View(tipoActo);
    }

    public IActionResult Edit(int id)
    {
        var tipoActo = _context.TiposActo
            .FirstOrDefault(p => p.Id == id);
        if (tipoActo is null) return NotFound();
        return View(tipoActo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, TipoActo tipoActo)
    {
        if (ModelState.IsValid)
        {
            _context.TiposActo.Update(tipoActo);
            if (SaveChanges())
            {
                TempData.MessageSuccess(AppMessages.DatosActualizadosExitosamente);
                return RedirectToAction("Details", new { id = tipoActo.Id });
            }
            TempData.MessageDanger(AppMessages.ErrorGuardarDatos);
        }
        return View(tipoActo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var tipoActo = _context.TiposActo.Find(id);
        if (tipoActo is null) return NotFound();
        _context.TiposActo.Remove(tipoActo);
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