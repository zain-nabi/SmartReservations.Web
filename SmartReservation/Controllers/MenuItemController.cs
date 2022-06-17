using Microsoft.AspNetCore.Mvc;
using SmartReservation.Interface;
using SmartReservation.Model;
using SmartReservation.Utils;
using System;
using System.Threading.Tasks;

namespace SmartReservation.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly IMenuItem _menuItem;

        public MenuItemController(IMenuItem menuItem)
        {
            _menuItem = menuItem;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuItem model)
        {
            var menuItem = new MenuItem()
            {
                Name = model.Name,
                Price = model.Price,
                CreatedOn = DateTime.Now,
                CreatedByUserID = User.GetUserId()
            };

            var result = await _menuItem.CreateAsync(menuItem);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int MenuItemID)
        {
            var MenuItemViewModel = new SmartReservation.Models.MenuItemViewModel();
            MenuItemViewModel.MenuItem = await _menuItem.FindByIdAsync(MenuItemID);
            MenuItemViewModel.MenuItemID = MenuItemID; 
            return View(MenuItemViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SmartReservation.Models.MenuItemViewModel model)
        {
            var menuItem = new MenuItem()
            {
                MenuItemID = model.MenuItemID,
                Name = model.MenuItem.Name,
                Price = model.MenuItem.Price,
                CreatedOn = DateTime.Now,
                CreatedByUserID = User.GetUserId()
            };

            var result = await _menuItem.CheckIfMenuItemExist(model.MenuItem.Name);
            var MenuDetails = await _menuItem.FindByIdAsync(model.MenuItemID);
            if (MenuDetails.Name == model.MenuItem.Name)
            {

                if (MenuDetails.Name != model.MenuItem.Name)
                {
                    if (MenuDetails.Name == model.MenuItem.Name)
                    {
                        model.ItemExist = "";
                    }
                    if (MenuDetails.Name != model.MenuItem.Name)
                    {
                        model.MenuItemExist = "Menu Item Exist";
                    }
                    if (result.Name == "False")
                    {
                        await _menuItem.UpdateAsync(menuItem);
                        return RedirectToAction("Restaurants", "Restaurant");
                    }
                    else
                    {
                        model.MenuItemExist = "Menu Item Exist";
                        model.ItemExist = "True";
                        return View(model);
                    }
                }
                await _menuItem.UpdateAsync(menuItem);
                return RedirectToAction("Restaurants", "Restaurant");
            }


            if (MenuDetails.Name == model.MenuItem.Name)
            {
                model.ItemExist = "";
            }
            if (MenuDetails.Name != model.MenuItem.Name)
            {
                model.MenuItemExist = "Menu Item Exist";
            }
            if (result.Name == "False")
            {
                await _menuItem.UpdateAsync(menuItem);
                return RedirectToAction("Restaurants", "Restaurant");
            }
            else
            {

                model.MenuItemExist = "Menu Item Exist";
                model.ItemExist = "True";
                return View(model);
            }
        }
    }
}
