using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class estabelecimentoController : Controller
    {
        private readonly EstabelecimentoContext _context;

        public estabelecimentoController(EstabelecimentoContext context)
        {
            _context = context;
        }

        // GET: estabelecimento
        public async Task<IActionResult> Index()
        {
            return View(await _context.estabelecimentos.ToListAsync());
        }

        // GET: estabelecimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estabelecimento = await _context.estabelecimentos
                .FirstOrDefaultAsync(m => m.estabelecimentoId == id);
            if (estabelecimento == null)
            {
                return NotFound();
            }

            return View(estabelecimento);
        }

        // GET: estabelecimento/Create
        public IActionResult CriaOuEdita( int id = 0 )
        {
            if(id==0)
            return View(new estabelecimento());
            else
                return View(_context.estabelecimentos.Find(id));
        }

        // POST: estabelecimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriaOuEDita([Bind("estabelecimentoId,razaoSocial,nome,cnpj,email,endereco,cidade,estado,telefone,dataCadastro,categoria,status,agencia,conta")] estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                if(estabelecimento.estabelecimentoId == 0)
                _context.Add(estabelecimento);
                else
                    _context.Update(estabelecimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estabelecimento);
        }

        // GET: estabelecimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estabelecimento = await _context.estabelecimentos.FindAsync(id);
            if (estabelecimento == null)
            {
                return NotFound();
            }
            return View(estabelecimento);
        }

        // POST: estabelecimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("estabelecimentoId,razaoSocial,nome,cnpj,email,endereco,cidade,estado,telefone,dataCadastro,categoria,status,agencia,conta")] estabelecimento estabelecimento)
        {
            if (id != estabelecimento.estabelecimentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estabelecimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!estabelecimentoExists(estabelecimento.estabelecimentoId))
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
            return View(estabelecimento);
        }

        // GET: estabelecimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var estabelecimento = await  _context.estabelecimentos.FindAsync(id);
            _context.estabelecimentos.Remove(estabelecimento);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: estabelecimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estabelecimento = await _context.estabelecimentos.FindAsync(id);
            _context.estabelecimentos.Remove(estabelecimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool estabelecimentoExists(int id)
        {
            return _context.estabelecimentos.Any(e => e.estabelecimentoId == id);
        }
    }
}
