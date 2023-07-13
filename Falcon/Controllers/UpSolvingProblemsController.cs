using Falcon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Falcon.Controllers
{
    public class UpSolvingProblemsController : Controller
    {
        private readonly AppDbContext _context;
        public UpSolvingProblemsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? filter)
        {
            var problems = _context.Problems.OrderByDescending(x => x.CreatedAt).AsQueryable();

            if(filter != null)
            {
                if(filter == "codeforces" || filter == "leetcode")
                {
                    problems = problems.Where(x => x.ProblemURL.Contains(filter) && x.IsSolved != true && x.IsDelayed != true);
                }
                else if(filter == "favourite")
                {
                    problems = problems.Where(x => x.IsFavourite == true);
                }
                else if(filter == "delay")
                {
					problems = problems.Where(x => x.IsDelayed == true);
                }
			}
            else
            {
                problems = problems.Where(x => x.IsDelayed != true && x.IsSolved != true);
            }

			var filteredProblems = await problems.ToListAsync();

			return View(filteredProblems);
        }

        [HttpGet]
		public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> Create(UpSolveProblem problem)
        {
            if(ModelState.IsValid)
            {
                problem.CreatedAt = DateTime.Now;
                var addedProblem = await _context.Problems.AddAsync(problem);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Solve(int id, string? method)
        {
            var problem = await _context.Problems.FindAsync(id);
            if(problem != null) 
            {
                if (method != null)
                {
                    if(method == "favourite")
                    {
                        problem.IsFavourite = false;
                    }
                    else if(method == "delay")
                    {
                        problem.IsDelayed = false;
                    }
                }
                else
                {
                    problem.IsSolved = true;
                }
                _context.Problems.Update(problem);
                await _context.SaveChangesAsync();
            }
			return RedirectToAction("Index", "UpSolvingProblems", new { filter = method });
        }


		public async Task<IActionResult> Favourite(int id)
        {
			var problem = await _context.Problems.FindAsync(id);
			if (problem != null)
			{
				problem.IsFavourite = true;
				_context.Problems.Update(problem);
				await _context.SaveChangesAsync();
			}

			return RedirectToAction(nameof(Index));
		}


		public async Task<IActionResult> Delay(int id)
        {
			var problem = await _context.Problems.FindAsync(id);
			if (problem != null)
			{
				problem.IsDelayed = true;
				_context.Problems.Update(problem);
				await _context.SaveChangesAsync();
			}

			return RedirectToAction(nameof(Index));
		}

	}
}
