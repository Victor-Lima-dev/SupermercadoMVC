using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using supermercadoMVC.context;
using supermercadoMVC.Models;

namespace supermercadoMVC.Controllers
{
    [Route("[controller]")]
    public class ProdutosController : Controller
    {
        private readonly ILogger<ProdutosController> _logger;
        private readonly AppDbContext _context;

        public ProdutosController(ILogger<ProdutosController> logger , AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //route
        [Route("ListarTodosProdutos/{categoria?}")]
          
        //assincrono
        public async Task<IActionResult> ListarTodosProdutos(string categoria)
        {
            IEnumerable<Produto> listaDeProdutos;
            string CategoriaEscolhida = string.Empty;
            if (string.IsNullOrEmpty(categoria))
            {
                listaDeProdutos = await _context.Produtos.OrderBy(p => p.Nome).ToListAsync();
                CategoriaEscolhida = "Todos os produtos";
            }
            else
            {
                listaDeProdutos = await _context.Produtos.Where(p => p.Categoria.Equals(categoria)).OrderBy(p => p.Nome).ToListAsync();
                CategoriaEscolhida = categoria;
            }
            ViewBag.CategoriaEscolhida = CategoriaEscolhida;

            return View(listaDeProdutos);
        }

        
    
    }
}