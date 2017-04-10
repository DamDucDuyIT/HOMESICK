using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Homesick.Data;
using Homesick.Models;
using HomeSick.Models.ViewModels;
using Homesick.Models.ViewModels;

namespace Homesick.Controllers
{
    public class FoodController : Controller
    {
        private readonly ApplicationDbContext _context;
        private int pageSize = 9;
        public FoodController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Food
        public async Task<IActionResult> Index(string searchText, int page = 1, string sortOrder = "score", string sortTag = "")
        {
            IQueryable<Food> foods = _context.Foods.Include(c=>c.Chef);

            if (!String.IsNullOrEmpty(searchText))
            {
                foods = foods.Where(s => s.FoodName.ToLower().Contains(searchText.ToLower()) ||
                s.FoodInfo.ToLower().Contains(searchText.ToLower()));
            }

            IEnumerable<Food> foodList = await foods.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            ListViewModel listViewModel = new ListViewModel
            {
                Foods = foodList,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = await foods.CountAsync()
                }
            };

            return View(listViewModel);
        }

        // GET: Food/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.Foods.SingleOrDefaultAsync(m => m.FoodId == id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // GET: Food/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Food/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodId,FoodAvatar,FoodInfo,FoodName,FoodPrice,FoodUnit")] Food food)
        {
            if (ModelState.IsValid)
            {
                _context.Add(food);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(food);
        }

        // GET: Food/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.Foods.SingleOrDefaultAsync(m => m.FoodId == id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }

        // POST: Food/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodId,FoodAvatar,FoodInfo,FoodName,FoodPrice,FoodUnit")] Food food)
        {
            if (id != food.FoodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(food);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodExists(food.FoodId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(food);
        }

        // GET: Food/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.Foods.SingleOrDefaultAsync(m => m.FoodId == id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // POST: Food/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var food = await _context.Foods.SingleOrDefaultAsync(m => m.FoodId == id);
            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FoodExists(int id)
        {
            return _context.Foods.Any(e => e.FoodId == id);
        }
    }
}
