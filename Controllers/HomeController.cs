using Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment5.Models.ViewModels;

namespace Assignment5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookRepository _repository;

        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository; //assigning value to private repository
        }

        public IActionResult Index(string category, int pageNum = 1)
        {

            return View(

                new ProjectListViewModel
                {
                    Projects = _repository.Projects
                    .Where(p => category == null || p.Category == category)
                         .OrderBy(p => p.BookId)
                         .Skip((pageNum - 1) * PageSize)
                            .Take(PageSize)
                        ,

                    PagingInfo = new PagingInfo //count of passed in repository
                    {
                        CurrentPage = pageNum,
                        ItemsPerPage = PageSize,
                        TotalNumItems = category == null ? _repository.Projects.Count() : 
                        _repository.Projects.Where(x => x.Category == category).Count()
                    },
                    Type = category
                });
    
               
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
