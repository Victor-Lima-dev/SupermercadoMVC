using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using supermercadoMVC.context;

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
        [Route("ListarTodosProdutos")]
   
        //assincrono
        public async Task<IActionResult> ListarTodosProdutos()
        {
            //criar uma lista de produtos
            var listaDeProdutos = await _context.Produtos.ToListAsync();
          
            //retornar a view com a lista de produtos
            return View(listaDeProdutos);
        }
    
    }
}