﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Bartender_Application.Data;
using MVC_Bartender_Application.Models;

namespace MVC_Bartender_Application.Controllers
{
    public class CocktailsController : Controller
    {
        private readonly ApplicationDbContex _context;

        public CocktailsController(ApplicationDbContex context)
        {
            _context = context;
        }

        // GET: Cocktails
        public async Task<IActionResult> Index()
        {
              return _context.Cocktails != null ? 
                          View(await _context.Cocktails.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContex.Cocktails'  is null.");
        }

        // GET: Cocktails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cocktails == null)
            {
                return NotFound();
            }

            var cocktail = await _context.Cocktails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cocktail == null)
            {
                return NotFound();
            }

            return View(cocktail);
        }

        // GET: Cocktails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cocktails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Discription,DisplayOrder,CreatedDateTime")] Cocktail cocktail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cocktail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cocktail);
        }

        // GET: Cocktails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cocktails == null)
            {
                return NotFound();
            }

            var cocktail = await _context.Cocktails.FindAsync(id);
            if (cocktail == null)
            {
                return NotFound();
            }
            return View(cocktail);
        }

        // POST: Cocktails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Discription,DisplayOrder,CreatedDateTime")] Cocktail cocktail)
        {
            if (id != cocktail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cocktail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CocktailExists(cocktail.Id))
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
            return View(cocktail);
        }

        // GET: Cocktails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cocktails == null)
            {
                return NotFound();
            }

            var cocktail = await _context.Cocktails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cocktail == null)
            {
                return NotFound();
            }

            return View(cocktail);
        }

        // POST: Cocktails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cocktails == null)
            {
                return Problem("Entity set 'ApplicationDbContex.Cocktails'  is null.");
            }
            var cocktail = await _context.Cocktails.FindAsync(id);
            if (cocktail != null)
            {
                _context.Cocktails.Remove(cocktail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CocktailExists(int id)
        {
          return (_context.Cocktails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}