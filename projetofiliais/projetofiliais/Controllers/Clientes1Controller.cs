using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projetofiliais.Models;

namespace projetofiliais.Controllers
{
    public class Clientes1Controller : Controller
    {
        private readonly Contexto _context;

        public Clientes1Controller(Contexto context)
        {
            _context = context;
        }

        // GET: Clientes1
        public async Task<IActionResult> Index()
        {
              return View(await _context.clientes.ToListAsync());
        }

        // GET: Clientes1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.clientes
                .FirstOrDefaultAsync(m => m.id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes1/Create
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

        // POST: Clientes1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,cidade,estado,idade")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            var estado = Enum.GetValues(typeof(Estado)).Cast<Estado>()
            .Select(e => new SelectListItem
            {
               Value = e.ToString(),
               Text = e.ToString()
            });
            ViewBag.bagEstado = estado;

            return View(cliente);
        }

        // POST: Clientes1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,cidade,estado,idade")] Cliente cliente)
        {
            if (id != cliente.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.id))
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
            return View(cliente);
        }

        // GET: Clientes1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.clientes
                .FirstOrDefaultAsync(m => m.id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.clientes == null)
            {
                return Problem("Entity set 'Contexto.clientes'  is null.");
            }
            var cliente = await _context.clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.clientes.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return _context.clientes.Any(e => e.id == id);
        }
    }
}
