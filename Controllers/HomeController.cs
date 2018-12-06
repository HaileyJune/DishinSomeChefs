using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using DishinSomeChefs.Models;
using System.Linq;

namespace DishinSomeChefs.Controllers
{
    public class HomeController : Controller
    {
        private RecipeContext dbContext;
        public HomeController(RecipeContext context)
    {
        dbContext = context;
    }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Chef> AllChefsAndDishes = dbContext.Chef
                    .Include(c => c.Dishes)
                    .ToList();
            return View(AllChefsAndDishes);
        }
        // GET: /Dishes/
        [HttpGet]
        [Route("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishesAndChefs = dbContext.Dish
                    .Include(d => d.Chef)
                    .ToList();
            return View(AllDishesAndChefs);
        }
        // GET: /New Dishes/
        [HttpGet]
        [Route("dishes/new")]
        public IActionResult NewDish()
        {
            List<Chef> AllChefs = dbContext.Chef.ToList();
            ViewBag.Chefs = AllChefs;
            // return View(AllChefs);
            return View();
        }
        [HttpGet]
        [Route("new")]
        public IActionResult NewChef()
        {
            // List<Chef> AllChefs = dbContext.Chef.ToList();
            // return View(AllChefs);
            return View();
        }

        [HttpPost("CreateChef")]
        public IActionResult CreateChef(Chef userImput)
        {
            if(ModelState.IsValid)
            {
                // do somethng!  maybe insert into db?  then we will redirect
                dbContext.Add(userImput);
                // OR _context.Users.Add(NewPerson);
                dbContext.SaveChanges();
                return Redirect("/");
            }
            else
            {
                // Oh no!  We need to return a ViewResponse to preserve the ModelState, and the errors it now contains!
                return View("NewChef", userImput);
            }
        }
        [HttpPost("CreateDish")]

        public IActionResult CreateDish(Dish userImput)
        {
            if(ModelState.IsValid)
            {
                // do somethng!  maybe insert into db?  then we will redirect
                dbContext.Add(userImput);
                // OR _context.Users.Add(NewPerson);
                dbContext.SaveChanges();
                return Redirect("/dishes");
            }
            else
            {
                // Oh no!  We need to return a ViewResponse to preserve the ModelState, and the errors it now contains!
                return View("NewDish", userImput);
            }
        }
    }
}
