using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadoIGL.Models;

namespace MercadoIGL.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly Contexto _context;

        public ProdutosController(Contexto context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Produtos.Include(p => p.cliente).Include(p => p.fornecedor).Include(p => p.funcionario).Include(p => p.tipo);
            return View(await contexto.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.cliente)
                .Include(p => p.fornecedor)
                .Include(p => p.funcionario)
                .Include(p => p.tipo)
                .FirstOrDefaultAsync(m => m.Id_Produto == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewData["CPF_Cliente"] = new SelectList(_context.Clientes, "CPF", "Endereco");
            ViewData["FornecedorCNPJ"] = new SelectList(_context.Fornecedores, "Id_CNPJ", "Razaosocial");
            ViewData["CPF_Funcionario"] = new SelectList(_context.Funcionarios, "CPF", "Nome_Completo");
            ViewData["Id_Tipo"] = new SelectList(_context.Tipos, "Id_Tipo", "TipoProduto");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Produto,Descricao,Valor,Estoque,FornecedorCNPJ,CPF_Cliente,CPF_Funcionario,Id_Tipo")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CPF_Cliente"] = new SelectList(_context.Clientes, "CPF", "Endereco", produto.CPF_Cliente);
            ViewData["FornecedorCNPJ"] = new SelectList(_context.Fornecedores, "Id_CNPJ", "Razaosocial", produto.FornecedorCNPJ);
            ViewData["CPF_Funcionario"] = new SelectList(_context.Funcionarios, "CPF", "Nome_Completo", produto.CPF_Funcionario);
            ViewData["Id_Tipo"] = new SelectList(_context.Tipos, "Id_Tipo", "TipoProduto", produto.Id_Tipo);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["CPF_Cliente"] = new SelectList(_context.Clientes, "CPF", "Endereco", produto.CPF_Cliente);
            ViewData["FornecedorCNPJ"] = new SelectList(_context.Fornecedores, "Id_CNPJ", "Razaosocial", produto.FornecedorCNPJ);
            ViewData["CPF_Funcionario"] = new SelectList(_context.Funcionarios, "CPF", "Nome_Completo", produto.CPF_Funcionario);
            ViewData["Id_Tipo"] = new SelectList(_context.Tipos, "Id_Tipo", "TipoProduto", produto.Id_Tipo);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Produto,Descricao,Valor,Estoque,FornecedorCNPJ,CPF_Cliente,CPF_Funcionario,Id_Tipo")] Produto produto)
        {
            if (id != produto.Id_Produto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id_Produto))
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
            ViewData["CPF_Cliente"] = new SelectList(_context.Clientes, "CPF", "Endereco", produto.CPF_Cliente);
            ViewData["FornecedorCNPJ"] = new SelectList(_context.Fornecedores, "Id_CNPJ", "Razaosocial", produto.FornecedorCNPJ);
            ViewData["CPF_Funcionario"] = new SelectList(_context.Funcionarios, "CPF", "Nome_Completo", produto.CPF_Funcionario);
            ViewData["Id_Tipo"] = new SelectList(_context.Tipos, "Id_Tipo", "TipoProduto", produto.Id_Tipo);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.cliente)
                .Include(p => p.fornecedor)
                .Include(p => p.funcionario)
                .Include(p => p.tipo)
                .FirstOrDefaultAsync(m => m.Id_Produto == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'Contexto.Produtos'  is null.");
            }
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
          return _context.Produtos.Any(e => e.Id_Produto == id);
        }
    }
}
