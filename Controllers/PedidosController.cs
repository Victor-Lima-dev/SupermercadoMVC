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
    public class PedidosController : Controller
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly AppDbContext _context;
        private readonly Carrinho _carrinho;

        public PedidosController(ILogger<PedidosController> logger, AppDbContext context, Carrinho carrinho)
        {
            _logger = logger;
            _context = context;
            _carrinho = carrinho;
        }
        [HttpGet("Checkout")]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            int quantidadeItens = 0;
            decimal valorTotal = 0;
            
            var itens = _carrinho.GetItensCarrinho();
            _carrinho.ItensCarrinho = itens;

            if (_carrinho.ItensCarrinho.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio, adicione um produto!");
            }

            foreach (var item in itens)
            {
                quantidadeItens += item.Quantidade;
                valorTotal += item.Produto.Preco * item.Quantidade;
            }

            pedido.PedidoTotal = valorTotal;
            pedido.PedidoTotalItens = quantidadeItens;
            

            if (ModelState.IsValid)
            {
                _context.Pedidos.Add(pedido);
                _context.SaveChanges();

                //itempedido
                int pedidoId = pedido.PedidoId;
                foreach (var item in itens)
                {
                    var itemPedido = new ItemPedido()
                    {
                        PedidoId = pedidoId,
                        ProdutoId = item.Produto.ProdutoId,
                        Quantidade = item.Quantidade,
                        Preco = item.Produto.Preco
                    };
                    _context.ItensPedido.Add(itemPedido);
                }

                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido!";
                ViewBag.TotalPedido = _carrinho.GetCarrinhoTotal();

                _carrinho.LimparCarrinho();


                _context.SaveChanges();
                return RedirectToAction("CheckoutCompleto");
            }
            return View(pedido);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}