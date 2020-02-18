using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3LTB.Data;
using _3LTB.Helpers;
using _3LTB.Models;
using _3LTB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _3LTB.Controllers
{
    public class TradeBoardController : Controller
    {
        private readonly _3LTBContext context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TradeBoardController(UserManager<ApplicationUser> userManager, _3LTBContext dbContext)
        {
            context = dbContext;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            @ViewBag.Title = "Trade Board";
            IList<Post> posts = context.Posts.ToList();

            return View(posts);
        }

        [Authorize]
        public IActionResult CreatePost()
        {
            CreatePostViewModel createPostViewModel = new CreatePostViewModel();

            //TODO: These fields are populated automatically. Simulate for now.
            createPostViewModel.DepartureCity = "Miami";
            createPostViewModel.ArrivalCity = "New York";
            //createPostViewModel.Report = "Some info";

            ViewBag.Title = "Create Post";

            return View(createPostViewModel);
        }

        [HttpPost]
        public IActionResult CreatePost(CreatePostViewModel createPostViewModel)
        {
            if (ModelState.IsValid)
            {
                //Retrieve id of logged in user and use to retrieve employee id
                string userid = _userManager.GetUserId(User);
                string empId = context.Users.Where(x => x.Id == userid).Select(x => x.EmployeeID).Single();

                Post newPost = new Post
                {
                    Trade = createPostViewModel.Trade,
                    Title = createPostViewModel.Title,
                    Flight = createPostViewModel.Flight,
                    FlightDate = createPostViewModel.FlightDate,
                    Position = createPostViewModel.Position,
                    Report = "Some info",
                    Lang = createPostViewModel.Lang,
                    RedFlag = createPostViewModel.RedFlag,
                    DepartureCity = createPostViewModel.DepartureCity,
                    ArrivalCity = createPostViewModel.ArrivalCity,
                    UserID = empId,
                };

                context.Posts.Add(newPost);
                context.SaveChanges();

                return Redirect("/TradeBoard");
            }

            // If this point is reached, something is wrong
            return View(createPostViewModel);
        }
    }
}
