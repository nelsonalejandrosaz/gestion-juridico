using GestionJuridico.Models.ViewModels;

namespace GestionJuridico.Services;

public interface ICasoService
{
    public string GenerarCodigo();
    public bool IngresarEstado(AccionEstadoViewModel accionEstadoViewModel, string nombreUsuario);
}