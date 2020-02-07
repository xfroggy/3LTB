using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3LTB.Data;
using _3LTB.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _3LTB.Controllers
{
    public class TradeBoardController : Controller
    {
        private _3LTBContext context;

        public TradeBoardController(_3LTBContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            @ViewBag.Title = "Trade Board";
            IList<Post> posts = context.Posts.ToList();
            
            return View(posts);
        }
    }
}
