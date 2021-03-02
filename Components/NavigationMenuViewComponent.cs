using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment5.Models;

namespace Assignment5.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookRepository repository;

        public NavigationMenuViewComponent(IBookRepository r)
        {
            repository = r; //pass in repository and pass into the IBookRepository variable
        }

        public IViewComponentResult Invoke() //drop partial view into a view
        {
            ViewBag.SelectedType = RouteData?.Values["category"];

            return View(repository.Projects //select info out of repository
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
