using GestionJuridico.Models;

namespace GestionJuridico.Services;

public class MenuService : IMenuService
{
    public Menu LoadMenu()
    {
        var menu = new Menu()
        {
            LabelItems = new List<LabelItem>()
            {
                new LabelItem()
                {
                    Nombre = "Inicio", Items = new List<MenuItem>()
                    {
                        new MenuItem() { Nombre = "Home", Icono = "fa-home", Accion = "Index", Controlador = "Home" },
                    }
                },
                new LabelItem()
                {
                    Nombre = "Correspondencia", Items = new List<MenuItem>()
                    {
                        new MenuItem()
                        {
                            Nombre = "Correspondencia", Icono = "fa-envelope-open", TipoMenu = 2, SubMenuItems = new List<MenuItem>()
                            {
                                new MenuItem() { Nombre = "Lista", Controlador = "Correspondencia", Accion = "Index" },
                                new MenuItem() { Nombre = "Ingresar correspondencia", Controlador = "Correspondencia", Accion = "Create" },
                            }
                        },
                    }
                },
                new LabelItem()
                {
                    Nombre = "Personas", Items = new List<MenuItem>()
                    {
                        new MenuItem() { 
                            Nombre = "Personas", Icono = "fa-users", TipoMenu = 2, SubMenuItems = new List<MenuItem>()
                            {
                                new MenuItem(){ Nombre = "Lista", Controlador = "Persona", Accion = "Index"},
                                new MenuItem(){ Nombre = "Nueva persona", Controlador = "Persona", Accion = "Create"},
                            }

                        },
                    }
                },
                new LabelItem()
                {
                    Nombre = "Catálogos", Items = new List<MenuItem>()
                    {
                        new MenuItem() {
                            Nombre = "Remitentes", Icono = "fa-address-card", TipoMenu = 2, SubMenuItems = new List<MenuItem>()
                            {
                                new MenuItem(){ Nombre = "Lista", Controlador = "Remitentes", Accion = "Index"},
                                new MenuItem(){ Nombre = "Nueva persona", Controlador = "Remitentes", Accion = "Create"},
                            }
                        },
                        new MenuItem(){ Nombre = "Empleados", Controlador = "DatosEmpleados", Accion = "Index"},
                        new MenuItem(){ Nombre = "Roles", Controlador = "Roles", Accion = "Index"},
                        new MenuItem(){ Nombre = "Acciones", Controlador = "Acciones", Accion = "Index"},
                        new MenuItem(){ Nombre = "Estados", Controlador = "Estados", Accion = "Index"},
                        new MenuItem(){ Nombre = "Procesos", Controlador = "Proceso", Accion = "Index"},
                        new MenuItem(){ Nombre = "Anexos", Controlador = "Anexos", Accion = "Index"},
                        new MenuItem(){ Nombre = "Requerimientos", Controlador = "Requerimiento", Accion = "Index"},
                        new MenuItem(){ Nombre = "Tipo Acción", Controlador = "TipoAccion", Accion = "Index"},
                        new MenuItem(){ Nombre = "Tipo Archivo", Controlador = "TipoArchivo", Accion = "Index"},
                        new MenuItem(){ Nombre = "Tipo Documento", Controlador = "TipoDocumentoRemitente", Accion = "Index"},
                        new MenuItem(){ Nombre = "Tipo Entidad", Controlador = "TipoEntidad", Accion = "Index"},
                        new MenuItem(){ Nombre = "Tipo Estado", Controlador = "TipoEstado", Accion = "Index"},
                        new MenuItem(){ Nombre = "Tipo Remitente", Controlador = "TipoRemitente", Accion = "Index"},
                        new MenuItem(){ Nombre = "Empleados Requerimiento", Controlador = "EmpleadosRequerimiento", Accion = "Create"},
                    }
                }
            }
        };
        return menu;
    }
}