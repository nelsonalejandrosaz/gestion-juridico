using GestionJuridico.Models;
using GestionJuridico.Utilities;

namespace GestionJuridico.Services;

public class MenuService : IMenuService
{
    public Menu LoadMenu()
    {
        var menu = new Menu()
        {
            Items = new List<CategoriaMenu>()
            {
                new CategoriaMenu()
                {
                    Nombre = "Inicio", Items = new List<ItemMenu>()
                    {
                        new ItemMenu() { Nombre = "Home", Icono = "fa-home", Accion = "Index", Controlador = "Home", Roles = new List<string>() },
                    }
                },
                new CategoriaMenu()
                {
                    Nombre = "Correspondencia", ConjuntoItems = new List<ConjuntoItemMenu>()
                    {
                        new ConjuntoItemMenu()
                        {
                            Nombre = "Correspondencia", Icono = "fa-envelope-open", Items = new List<ItemMenu>()
                            {
                                new ItemMenu() { Nombre = "Lista", Controlador = "Correspondencia", Accion = "Index", Roles = new List<string>() },
                                new ItemMenu() { Nombre = "Ingresar correspondencia", Controlador = "Correspondencia", Accion = "Create", Roles = new List<string>() },
                            }
                        },
                    }
                },
                new CategoriaMenu()
                {
                    Nombre = "Gestiones", ConjuntoItems = new List<ConjuntoItemMenu>()
                    {
                        new ConjuntoItemMenu()
                        {
                            Nombre = "Solicitudes", Icono = "fa-clipboard", Items = new List<ItemMenu>()
                            {
                                new ItemMenu() { Nombre = "Lista", Controlador = "Solicitudes", Accion = "Index", Roles = Policies.SolicitudVerLista()},
                                new ItemMenu() { Nombre = "Ingresar solicitud", Controlador = "Solicitudes", Accion = "Create", Roles = Policies.SolicitudCrud()},
                            }
                        },
                        new ConjuntoItemMenu()
                        {
                            Nombre = "Casos", Icono = "fa-clipboard", Items = new List<ItemMenu>()
                            {
                                new ItemMenu() { Nombre = "Lista", Controlador = "Casos", Accion = "Index", Roles = Policies.SolicitudVerLista()},
                                new ItemMenu() { Nombre = "Ingresar caso", Controlador = "Casos", Accion = "Create", Roles = Policies.SolicitudCrud()},
                            }
                        },
                    }
                },
                new CategoriaMenu()
                {
                    Nombre = "Administrados", ConjuntoItems = new List<ConjuntoItemMenu>()
                    {
                        new ConjuntoItemMenu() { 
                            Nombre = "Personas", Icono = "fa-users", Items = new List<ItemMenu>()
                            {
                                new ItemMenu(){ Nombre = "Lista", Controlador = "Personas", Accion = "Index", Roles = new List<string>()},
                                new ItemMenu(){ Nombre = "Nueva persona", Controlador = "Personas", Accion = "Create", Roles = new List<string>()},
                            }
                        },
                        new ConjuntoItemMenu() {
                            Nombre = "Administrados", Icono = "fa-address-book", Items = new List<ItemMenu>()
                            {
                                new ItemMenu(){ Nombre = "Lista", Controlador = "Administrados", Accion = "Index", Roles = new List<string>()},
                                new ItemMenu(){ Nombre = "Nuevo administrado", Controlador = "Administrados", Accion = "Create", Roles = new List<string>()},
                            }
                        },
                        new ConjuntoItemMenu() {
                            Nombre = "Remitentes", Icono = "fa-address-book", Items = new List<ItemMenu>()
                            {
                                new ItemMenu(){ Nombre = "Lista", Controlador = "Remitentes", Accion = "Index", Roles = new List<string>(){"ADMINISTRADOR"}},
                                new ItemMenu(){ Nombre = "Nueva persona", Controlador = "Remitentes", Accion = "Create", Roles = new List<string>()},
                            }
                        },
                    }
                },
                new CategoriaMenu()
                {
                    Nombre = "Catálogos", 
                    ConjuntoItems = new List<ConjuntoItemMenu>()
                    {
                        new ConjuntoItemMenu() {
                            Nombre = "Catálogos procesos", Icono = "fa-project-diagram", Items = new List<ItemMenu>()
                            {
                                new ItemMenu(){ Nombre = "Test", Controlador = "Tests", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                                new ItemMenu(){ Nombre = "Procesos", Controlador = "Procesos", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                                new ItemMenu(){ Nombre = "Estados", Controlador = "Estados", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                                new ItemMenu(){ Nombre = "Acciones", Controlador = "Acciones", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                            }
                        },
                        new ConjuntoItemMenu() {
                            Nombre = "Catálogos generales", Icono = "fa-sitemap", Items = new List<ItemMenu>()
                            {
                                new ItemMenu(){ Nombre = "Empleados", Controlador = "DatosEmpleados", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                                new ItemMenu(){ Nombre = "Unidades Institución", Controlador = "UnidadesInstitucion", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                                new ItemMenu(){ Nombre = "Roles", Controlador = "Roles", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                                new ItemMenu(){ Nombre = "Anexos", Controlador = "Anexos", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                                new ItemMenu(){ Nombre = "Requerimientos", Controlador = "Requerimiento", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                                new ItemMenu(){ Nombre = "Tipo Acción", Controlador = "TiposAccion", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                                new ItemMenu(){ Nombre = "Tipo Archivo", Controlador = "TipoArchivo", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                                new ItemMenu(){ Nombre = "Tipo Documento", Controlador = "TipoDocumentoRemitente", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                                new ItemMenu(){ Nombre = "Tipo Entidad", Controlador = "TipoEntidad", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                                new ItemMenu(){ Nombre = "Tipo Estado", Controlador = "TipoEstado", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                                new ItemMenu(){ Nombre = "Tipo Remitente", Controlador = "TipoRemitente", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                                new ItemMenu(){ Nombre = "Tipo Emisor", Controlador = "TiposEmisor", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                                new ItemMenu(){ Nombre = "Tipo Acto", Controlador = "TiposActo", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                                new ItemMenu(){ Nombre = "Cargos Persona Representante", Controlador = "CargosPersonaRepresentante", Accion = "Index", Roles = Policies.CatalogosAdministracion()},
                                new ItemMenu(){ Nombre = "Empleados Requerimiento", Controlador = "EmpleadosRequerimiento", Accion = "Create", Roles = Policies.CatalogosAdministracion()},
                            }
                        }
                    }
                }
            }
        };
        return menu;
    }
}