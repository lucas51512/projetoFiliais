using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using criptowebbcc.Models;

namespace criptowebbcc.Controllers
{
    public class FiliaisController : Controller
    {
        private readonly Contexto _context;

        public FiliaisController(Contexto context)
        {
            _context = context;
        }

        // GET: Filiais
        public async Task<IActionResult> Index()
        {
              return View(await _context.filiais.ToListAsync());
        }

        // GET: Filiais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.filiais == null)
            {
                return NotFound();
            }

            var filial = await _context.filiais
                .FirstOrDefaultAsync(m => m.id == id);
            if (filial == null)
            {
                return NotFound();
            }

            return View(filial);
        }

        // GET: Filiais/Create
        public IActionResult Create()
        {
            var estado = Enum.GetValues(typeof(Estado)).Cast<Estado>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                });
            ViewBag.bagEstado = estado;

            return View();
        }

        // POST: Filiais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nomeFilial,cidadeFilial,estadoFilial")] Filial filial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filial);
        }

        // GET: Filiais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.filiais == null)
            {
                return NotFound();
            }

            var filial = await _context.filiais.FindAsync(id);
            if (filial == null)
            {
                return NotFound();
            }
            return View(filial);
        }

        // POST: Filiais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nomeFilial,cidadeFilial,estadoFilial")] Filial filial)
        {
            if (id != filial.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilialExists(filial.id))
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
            return View(filial);
        }

        // GET: Filiais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.filiais == null)
            {
                return NotFound();
            }

            var filial = await _context.filiais
                .FirstOrDefaultAsync(m => m.id == id);
            if (filial == null)
            {
                return NotFound();
            }

            return View(filial);
        }

        // POST: Filiais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.filiais == null)
            {
                return Problem("Entity set 'Contexto.filiais'  is null.");
            }
            var filial = await _context.filiais.FindAsync(id);
            if (filial != null)
            {
                _context.filiais.Remove(filial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilialExists(int id)
        {
          return _context.filiais.Any(e => e.id == id);
        }
    }
}
