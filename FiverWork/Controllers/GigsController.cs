using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FiverWork.Data;
using FiverWork.Models;

namespace FiverWork.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gigs
        public async Task<IActionResult> Index()
        {
            //var gig = _context.Gigs.FirstOrDefault();

            //return View(gig);
            return _context.Gigs != null ?
                        View(await _context.Gigs.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Gigs'  is null.");
        }

        // GET: Gigs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gigs == null)
            {
                return NotFound();
            }

            var gig = await _context.Gigs
                .FirstOrDefaultAsync(m => m.GigId == id);
            if (gig == null)
            {
                return NotFound();
            }

            return View(gig);
        }

        // GET: Gigs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gigs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GigId,GigTitle,SellerName,SellerImage,GigImage1,GigImage2,GigImage3,GigImage4,GigImage5,GigRating,GigRatingCount,GigPrice")] Gig gig)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gig);
        }

        // GET: Gigs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gigs == null)
            {
                return NotFound();
            }

            var gig = await _context.Gigs.FindAsync(id);
            if (gig == null)
            {
                return NotFound();
            }
            return View(gig);
        }

        // POST: Gigs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GigId,GigTitle,SellerName,SellerImage,GigImage1,GigImage2,GigImage3,GigImage4,GigImage5,GigRating,GigRatingCount,GigPrice")] Gig gig)
        {
            if (id != gig.GigId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gig);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GigExists(gig.GigId))
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
            return View(gig);
        }

        // GET: Gigs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gigs == null)
            {
                return NotFound();
            }

            var gig = await _context.Gigs
                .FirstOrDefaultAsync(m => m.GigId == id);
            if (gig == null)
            {
                return NotFound();
            }

            return View(gig);
        }

        // POST: Gigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gigs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Gigs'  is null.");
            }
            var gig = await _context.Gigs.FindAsync(id);
            if (gig != null)
            {
                _context.Gigs.Remove(gig);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GigExists(int id)
        {
          return (_context.Gigs?.Any(e => e.GigId == id)).GetValueOrDefault();
        }
    }
}
