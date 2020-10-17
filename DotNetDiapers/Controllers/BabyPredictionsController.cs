using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetDiapers.Data;
using DotNetDiapers.Models;

namespace DotNetDiapers.Controllers
{
    public class BabyPredictionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BabyPredictionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BabyPredictions
        public async Task<IActionResult> Index()
        {
            // order by nearest date
            var applicationDbContext = _context.BabyPredictions.Include(b => b.Guest).OrderBy(b=>b.Due_Date);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BabyPredictions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var babyPrediction = await _context.BabyPredictions
                .Include(b => b.Guest)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (babyPrediction == null)
            {
                return NotFound();
            }

            return View(babyPrediction);
        }

        // GET: BabyPredictions/Create
        public IActionResult Create()
        {
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "Username");
            
            return View();
        }

        // POST: BabyPredictions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Due_Date,Birth_Weight,Baby_Gender,Baby_Name,GuestId")] BabyPrediction babyPrediction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(babyPrediction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "Username", babyPrediction.GuestId);
            return View(babyPrediction);
        }

        // GET: BabyPredictions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var babyPrediction = await _context.BabyPredictions.FindAsync(id);
            if (babyPrediction == null)
            {
                return NotFound();
            }
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "Username", babyPrediction.GuestId);
            return View(babyPrediction);
        }

        // POST: BabyPredictions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Due_Date,Birth_Weight,Baby_Gender,Baby_Name,GuestId")] BabyPrediction babyPrediction)
        {
            if (id != babyPrediction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(babyPrediction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BabyPredictionExists(babyPrediction.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "Username", babyPrediction.GuestId);
            return View(babyPrediction);
        }

        // GET: BabyPredictions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var babyPrediction = await _context.BabyPredictions
                .Include(b => b.Guest)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (babyPrediction == null)
            {
                return NotFound();
            }

            return View(babyPrediction);
        }

        // POST: BabyPredictions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var babyPrediction = await _context.BabyPredictions.FindAsync(id);
            _context.BabyPredictions.Remove(babyPrediction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BabyPredictionExists(int id)
        {
            return _context.BabyPredictions.Any(e => e.Id == id);
        }
    }
}
