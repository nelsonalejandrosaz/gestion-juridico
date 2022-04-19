using GestionJuridico.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionJuridico.Views.Shared.Components.Sidebar;

public class SidebarViewComponent : ViewComponent
{
    private readonly IMenuService _menuService;

    public SidebarViewComponent(IMenuService menuService)
    {
        _menuService = menuService;
    }

    public IViewComponentResult Invoke()
    {
        var menu = _menuService.LoadMenu();
        var controller = ViewContext.RouteData.Values["controller"]?.ToString();
        var accion = ViewContext.RouteData.Values["action"]?.ToString();

        foreach (var label in menu.LabelItems)
        {
            foreach (var menuItem in label.Items)
            {
                if (menuItem.TipoMenu == 2)
                {
                    foreach (var subMenuItem in menuItem.SubMenuItems)
                    {
                        if (subMenuItem.Controlador == controller && subMenuItem.Accion == accion)
                        {
                            menuItem.Activo = true;
                            subMenuItem.Activo = true;
                        }
                    }
                } else
                {
                    if (menuItem.Controlador == controller)
                    {
                        menuItem.Activo = true;
                    }
                }
            }
        }

        return View(menu);
    }
}