using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using supermercadoMVC.context;
using supermercadoMVC.Models;

namespace supermercadoMVC.Controllers
{
    [Route("[controller]")]
    public class CarrinhoController : Controller
    {
        private readonly ILogger<CarrinhoController> _logger;
        private readonly AppDbContext _context;
        //classe carrinho
        private readonly Carrinho _carrinho;
        //construtor
        public CarrinhoController(ILogger<CarrinhoController> logger, AppDbContext context, Carrinho carrinho)
        {
            _logger = logger;
            _context = context;
            _carrinho = carrinho;
        }

        //route
        [Route("Index")]
        public IActionResult Index()
        {
            var itens = _carrinho.GetItensCarrinho();
            _carrinho.ItensCarrinho = itens;

            var carrinhoViewModel = new CarrinhoViewModel
            {
                Carrinho = _carrinho,
                CarrinhoTotal = _carrinho.GetCarrinhoTotal()
            };



            return View(carrinhoViewModel);
        }

        [Route("AdicionarAoCarrinho/{id}")]
        public async Task<IActionResult> AdicionarAoCarrinho(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _carrinho.AdicionarAoCarrinho(produto, 1);
            }
            return RedirectToAction("Index");
        }

        [Route("RemoverDoCarrinho/{id}")]
        public async Task<IActionResult> RemoverDoCarrinho(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _carrinho.RemoverDoCarrinho(produto);
            }
            return RedirectToAction("Index");
        }

        [Route("LimparCarrinho")]
        public IActionResult LimparCarrinho()
        {
            _carrinho.LimparCarrinho();
            return RedirectToAction("Index");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}