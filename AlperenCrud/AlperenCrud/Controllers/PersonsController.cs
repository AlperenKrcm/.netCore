using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlperenCrud.Data;
using AlperenCrud.Models;

namespace AlperenCrud.Controllers
{
    public class PersonsController : Controller
    {
        private readonly AlpContext _context;

        public PersonsController(AlpContext context)
        {
            _context = context;
        }

        // GET: Persons
        public async Task<IActionResult> Index()
        {
              return _context.Kisiler != null ? 
                          View(await _context.Kisiler.ToListAsync()) :
                          Problem("Entity set 'AlpContext.Kisiler'  is null.");
        }

        // GET: Persons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kisiler == null)
            {
                return NotFound();
            }

            var persons = await _context.Kisiler
                .FirstOrDefaultAsync(m => m.personId == id);
            if (persons == null)
            {
                return NotFound();
            }

            return View(persons);
        }

        // GET: Persons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Persons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("personId,personName,personSurname,personAge,personGender,personIdentityId")] Persons persons)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persons);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persons);
        }

        // GET: Persons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kisiler == null)
            {
                return NotFound();
            }

            var persons = await _context.Kisiler.FindAsync(id);
            if (persons == null)
            {
                return NotFound();
            }
            return View(persons);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("personId,personName,personSurname,personAge,personGender,personIdentityId")] Persons persons)
        {
            if (id != persons.personId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persons);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonsExists(persons.personId))
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
            return View(persons);
        }

        // GET: Persons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kisiler == null)
            {
                return NotFound();
            }

            var persons = await _context.Kisiler
                .FirstOrDefaultAsync(m => m.personId == id);
            if (persons == null)
            {
                return NotFound();
            }

            return View(persons);
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kisiler == null)
            {
                return Problem("Entity set 'AlpContext.Kisiler'  is null.");
            }
            var persons = await _context.Kisiler.FindAsync(id);
            if (persons != null)
            {
                _context.Kisiler.Remove(persons);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonsExists(int id)
        {
          return (_context.Kisiler?.Any(e => e.personId == id)).GetValueOrDefault();
        }
    }
}
