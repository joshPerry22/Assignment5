using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Assignment5.Models;
using Assignment5.Infrastructure;

namespace Assignment5.Pages
{
    public class ShopModel : PageModel
    {
        private IBookRepository repository;
        //Constructor
        public ShopModel (IBookRepository repo)
        {
            repository = repo;
        }
        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //Methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long BookId, string returnUrl)
        {
            Project project = repository.Projects.FirstOrDefault(p => p.BookId == BookId);

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(project, 1);

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove (long bookId, string returnUrl)
        {
            //Project project = repository.Projects.FirstOrDefault(p => p.BookId == BookId);
            Cart.RemoveLine(Cart.Lines.First(cl =>
            cl.Project.BookId == bookId).Project);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
