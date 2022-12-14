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
    public class TransacoesController : Controller
    {
        private readonly Contexto _context;

        public TransacoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Transacoes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.transacoes.Include(t => t.Produto).Include(t => t.cliente);
            return View(await contexto.ToListAsync());
        }

        // GET: Transacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.transacoes == null)
            {
                return NotFound();
            }

            var transacao = await _context.transacoes
                .Include(t => t.Produto)
                .Include(t => t.cliente)
                .FirstOrDefaultAsync(m => m.id == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // GET: Transacoes/Create
        public IActionResult Create()
        {
            ViewData["produtoId"] = new SelectList(_context.produtos, "id", "nomeProduto");
            ViewData["clienteId"] = new SelectList(_context.clientes, "id", "nome");
            return View();
        }

        // POST: Transacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,tipoProduto,quantidade,data,valor,produtoId,clienteId")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["produtoId"] = new SelectList(_context.produtos, "id", "nomeProduto", transacao.produtoId);
            ViewData["clienteId"] = new SelectList(_context.clientes, "id", "nome", transacao.clienteId);
            return View(transacao);
        }

        // GET: Transacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.transacoes == null)
            {
                return NotFound();
            }

            var transacao = await _context.transacoes.FindAsync(id);
            if (transacao == null)
            {
                return NotFound();
            }
            ViewData["produtoId"] = new SelectList(_context.produtos, "id", "nomeProduto", transacao.produtoId);
            ViewData["clienteId"] = new SelectList(_context.clientes, "id", "nome", transacao.clienteId);
            return View(transacao);
        }

        // POST: Transacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,tipoProduto,quantidade,data,valor,produtoId,clienteId")] Transacao transacao)
        {
            if (id != transacao.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransacaoExists(transacao.id))
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
            ViewData["produtoId"] = new SelectList(_context.produtos, "id", "nomeProduto", transacao.produtoId);
            ViewData["clienteId"] = new SelectList(_context.clientes, "id", "nome", transacao.clienteId);
            return View(transacao);
        }

        // GET: Transacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.transacoes == null)
            {
                return NotFound();
            }

            var transacao = await _context.transacoes
                .Include(t => t.Produto)
                .Include(t => t.cliente)
                .FirstOrDefaultAsync(m => m.id == id);
            if (transacao == null)
            {
                return NotFound();
            }

            return View(transacao);
        }

        // POST: Transacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.transacoes == null)
            {
                return Problem("Entity set 'Contexto.transacoes'  is null.");
            }
            var transacao = await _context.transacoes.FindAsync(id);
            if (transacao != null)
            {
                _context.transacoes.Remove(transacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransacaoExists(int id)
        {
          return _context.transacoes.Any(e => e.id == id);
        }
    }
}
