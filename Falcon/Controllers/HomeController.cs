using Falcon.Models;
using Falcon.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Falcon.Controllers
{
    public class HomeController : Controller
    {
        public readonly AppDbContext _context;
        private readonly ILeetCodeContests _leetCodeContests;
        private readonly ICodeforcesContests _codeforcesContests;
        public HomeController(ILeetCodeContests leetCodeContests, AppDbContext context, ICodeforcesContests codeforcesContests)
        {
            _leetCodeContests = leetCodeContests;
            _context = context;
            _codeforcesContests = codeforcesContests;
        }

        public async Task<IActionResult> Index()
        {
            var leetCodeContests = await _leetCodeContests.GetUpComing();
            if (leetCodeContests != null)
            {
                ViewBag.Current = "LeetCode Contest";
				ViewBag.URL = leetCodeContests.URL;
				ViewBag.Name = leetCodeContests.Name;
				ViewBag.StartTime = leetCodeContests.StartTime.AddHours(3);
				return View();
            }

            var problems = await _context.Problems.Where(x => x.IsSolved != true && x.IsDelayed != true).ToListAsync();
            if (problems.Count > 1)
            {
                ViewBag.Current = "Problem to UpSolve";
                return View();
            }
            else
            {
                var codeforcesContests = await _codeforcesContests.GetUpComing();
                if (codeforcesContests != null)
                {
                    ViewBag.Current = "Codeforces Contest";
                    ViewBag.URL = codeforcesContests.URL;
                    ViewBag.Name = codeforcesContests.Name;
                    ViewBag.StartTime = codeforcesContests.StartTime.AddHours(3);
                    return View();
                }
                else
                {
                    ViewBag.Current = "LeetCode Problem";
                    return View();
                }
            }
        }
    }
}