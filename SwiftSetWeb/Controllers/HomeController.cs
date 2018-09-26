using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiftSetWeb.Models;

namespace SwiftSetWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly SwiftSetContext _context;

        public HomeController(SwiftSetContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ExercisesController.Clear();
            ViewBag.NumExercises = _context.Exercises.Count();
            ExerciseGroupViewModel vm = new ExerciseGroupViewModel();
            vm.SortingGroups = _context.SortingGroups
                .Include(sg => sg.Categories)
                .Include(sg => sg.NewOptions)
                .ThenInclude(sg => sg.SortingCategory);
            vm.Exercises = _context.Exercises;

            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
