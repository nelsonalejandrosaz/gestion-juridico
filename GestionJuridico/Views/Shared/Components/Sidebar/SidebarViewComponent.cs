using GestionJuridico.Extensions;
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

        var rol = UserClaimsPrincipal.GetRoleValue();

        foreach (var categoriaMenu in menu.Items.ToList())
        {
            foreach (var conjuntoItemMenu in categoriaMenu.ConjuntoItems.ToList())
            {
                foreach (var itemMenu in conjuntoItemMenu.Items.ToList())   
                {
                    if (itemMenu.Roles.Count != 0 && !itemMenu.Roles.Contains(rol))
                    {
                        conjuntoItemMenu.Items.Remove(itemMenu);
                    }
                    if (itemMenu.Controlador == controller && itemMenu.Accion == accion)
                    {
                        conjuntoItemMenu.Activo = true;
                        itemMenu.Activo = true;
                    }
                }
                if (conjuntoItemMenu.Items.Count == 0)
                {
                    categoriaMenu.ConjuntoItems.Remove(conjuntoItemMenu);
                }
            }

            foreach (var itemMenu in categoriaMenu.Items.ToList())
            {
                if(itemMenu.Roles.Count != 0 && !itemMenu.Roles.Contains(rol))
                {
                    categoriaMenu.Items.Remove(itemMenu);
                }
                if (itemMenu.Controlador == controller)
                {
                    itemMenu.Activo = true;
                }
            }

            if (categoriaMenu.ConjuntoItems.Count == 0 && categoriaMenu.Items.Count == 0)
            {
                menu.Items.Remove(categoriaMenu);
            }
        }


        //foreach (var label in menu.Items.ToList())
        //{
        //    foreach (var menuItem in label.Items.ToList())
        //    {
        //        if (menuItem.TipoMenu == 2)
        //        {
        //            foreach (var subMenuItem in menuItem.SubMenuItems.ToList())
        //            {
        //                if (!subMenuItem.Roles.Contains(rol))
        //                {
        //                    menuItem.SubMenuItems.Remove(subMenuItem);
        //                }
        //                if (subMenuItem.Controlador == controller && subMenuItem.Accion == accion)
        //                {
        //                    menuItem.Activo = true;
        //                    subMenuItem.Activo = true;
        //                }
        //            }
        //            if(menuItem.SubMenuItems.Count == 0)
        //            {
        //                label.Items.Remove(menuItem);
        //            }
        //        } else
        //        {
        //            if(!menuItem.Roles.Contains(rol))
        //            {
        //                label.Items.Remove(menuItem);
        //            }
        //            if (menuItem.Controlador == controller)
        //            {
        //                menuItem.Activo = true;
        //            }
        //        }
        //    }

        //    if (label.Items.Count == 0)
        //    {
        //        menu.Items.Remove(label);
        //    }
        //}

        return View(menu);
    }
}