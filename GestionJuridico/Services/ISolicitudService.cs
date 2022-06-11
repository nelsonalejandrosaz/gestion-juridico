using GestionJuridico.Models.ViewModels;

namespace GestionJuridico.Services;

public interface ISolicitudService
{
    /// <summary>
    /// Ingresa el estado nuevo
    /// </summary>
    /// <param name="accionEstadoViewModel">La accion</param>
    /// <param name="nombreUsuario">El usuario</param>
    /// <returns></returns>
    public bool IngresarEstado(AccionEstadoViewModel accionEstadoViewModel, string nombreUsuario);

    /// <summary>
    /// Genera el codigo 
    /// </summary>
    /// <returns></returns>
    public string GenerarCodigo();
}