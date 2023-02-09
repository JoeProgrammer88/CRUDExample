using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDExample.Data;
using CRUDExample.Models;

namespace CRUDExample.Controllers
{
    public class PhonesController : Controller
    {
        private readonly CRUDExampleContext _context;

        public PhonesController(CRUDExampleContext context)
        {
            _context = context;
        }

        // GET: Phones
        public async Task<IActionResult> Index()
        {
            // Get all phones from the database using the DB context
            List<Phone> allPhones = await _context.Phone.ToListAsync();

            // Pass the list of phones to the view
            return View(allPhones);
        }

        // GET: Phones/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Phone == null)
            {
                return NotFound();
            }

            var phone = await _context.Phone
                .FirstOrDefaultAsync(m => m.SerialNumber == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // GET: Phones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Phones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SerialNumber,Model,Type,Price,Size,Color")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phone);
        }

        // GET: Phones/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Phone == null)
            {
                return NotFound();
            }

            var phone = await _context.Phone.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }
            return View(phone);
        }

        // POST: Phones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SerialNumber,Model,Type,Price,Size,Color")] Phone phone)
        {
            if (id != phone.SerialNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneExists(phone.SerialNumber))
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
            return View(phone);
        }

        // GET: Phones/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Phone == null)
            {
                return NotFound();
            }

            var phone = await _context.Phone
                .FirstOrDefaultAsync(m => m.SerialNumber == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // POST: Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Phone == null)
            {
                return Problem("Entity set 'CRUDExampleContext.Phone'  is null.");
            }
            var phone = await _context.Phone.FindAsync(id);
            if (phone != null)
            {
                _context.Phone.Remove(phone);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneExists(string id)
        {
          return _context.Phone.Any(e => e.SerialNumber == id);
        }
    }
}
