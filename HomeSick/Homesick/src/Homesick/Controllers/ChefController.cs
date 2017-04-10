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
    public class ChefController : Controller
    {
        private readonly ApplicationDbContext _context;
        private int pageSize = 9;
        public ChefController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Chef
        public async Task<IActionResult> Index(string searchText, int page = 1, string sortOrder = "score", string sortTag = "")
        {
            IQueryable<Chef> chefs = _context.Chefs.Include(f => f.Foods);

            if (!String.IsNullOrEmpty(searchText))
            {
                chefs = chefs.Where(s => s.ChefDisplayName.ToLower().Contains(searchText.ToLower())||
                s.ChefName.ToLower().Contains(searchText.ToLower()));
            }

            IEnumerable<Chef> chefList = await chefs.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            ListViewModel listViewModel = new ListViewModel
            {
                Chefs = chefList,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = await chefs.CountAsync()
                }
            };

            return View(listViewModel);
        }

        // GET: Chef/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chef = await _context.Chefs
                .Include(f=>f.Foods)
                .SingleOrDefaultAsync(m => m.ChefId == id);
            if (chef == null)
            {
                return NotFound();
            }

            return View(chef);
        }

        // GET: Chef/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chef/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChefId,ChefAddress,ChefCareer,ChefDisplayName,ChefInfo,ChefName,ChefPhone")] Chef chef)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chef);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(chef);
        }

        // GET: Chef/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chef = await _context.Chefs.SingleOrDefaultAsync(m => m.ChefId == id);
            if (chef == null)
            {
                return NotFound();
            }
            return View(chef);
        }

        // POST: Chef/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChefId,ChefAddress,ChefCareer,ChefDisplayName,ChefInfo,ChefName,ChefPhone")] Chef chef)
        {
            if (id != chef.ChefId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chef);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChefExists(chef.ChefId))
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
            return View(chef);
        }

        // GET: Chef/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chef = await _context.Chefs.SingleOrDefaultAsync(m => m.ChefId == id);
            if (chef == null)
            {
                return NotFound();
            }

            return View(chef);
        }

        // POST: Chef/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chef = await _context.Chefs.SingleOrDefaultAsync(m => m.ChefId == id);
            _context.Chefs.Remove(chef);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ChefExists(int id)
        {
            return _context.Chefs.Any(e => e.ChefId == id);
        }
    }
}
