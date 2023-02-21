using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using supermercadoMVC.context;

namespace supermercadoMVC.Models
{
    public class Carrinho
    {
        private AppDbContext _context { get; set; }
        public Carrinho(AppDbContext _context)
        {
            this._context = _context;
        }

        public string CarrinhoId { get; set; }
        public List<ItemCarrinho> ItensCarrinho { get; set; }



        public static Carrinho GetCarrinho(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            session.SetString("CarrinhoId", carrinhoId);

            return new Carrinho(context) { CarrinhoId = carrinhoId };
        }

        public void AdicionarAoCarrinho(Produto produto, int quantidade)
        {
            var itemCarrinho = _context.ItensCarrinho.SingleOrDefault(
                i => i.Produto.ProdutoId == produto.ProdutoId && i.CarrinhoId == CarrinhoId);

            if (itemCarrinho == null)
            {
                itemCarrinho = new ItemCarrinho
                {
                    CarrinhoId = CarrinhoId,
                    Produto = produto,
                    Quantidade = quantidade
                };

                _context.ItensCarrinho.Add(itemCarrinho);
            }
            else
            {
                itemCarrinho.Quantidade++;
            }
            _context.SaveChanges();
        }

        public int RemoverDoCarrinho(Produto produto)
        {
            var itemCarrinho = _context.ItensCarrinho.SingleOrDefault(
                i => i.Produto.ProdutoId == produto.ProdutoId && i.CarrinhoId == CarrinhoId);

            var quantidadeLocal = 0;

            if (itemCarrinho != null)
            {
                if (itemCarrinho.Quantidade > 1)
                {
                    itemCarrinho.Quantidade--;
                    quantidadeLocal = itemCarrinho.Quantidade;
                }
                else
                {
                    _context.ItensCarrinho.Remove(itemCarrinho);
                }
            }
            _context.SaveChanges();

            return quantidadeLocal;
        }

        public List<ItemCarrinho> GetItensCarrinho()
        {
            return ItensCarrinho ?? (ItensCarrinho = _context.ItensCarrinho.Where(c => c.CarrinhoId == CarrinhoId)
                .Include(s => s.Produto)
                .ToList());
        }

        public void LimparCarrinho()
        {
            var itensCarrinho = _context.ItensCarrinho.Where(c => c.CarrinhoId == CarrinhoId);

            _context.ItensCarrinho.RemoveRange(itensCarrinho);

            _context.SaveChanges();
        }

        public decimal GetCarrinhoTotal()
        {
            var total = _context.ItensCarrinho.Where(c => c.CarrinhoId == CarrinhoId)
                .Select(c => c.Produto.Preco * c.Quantidade).Sum();
            return total;
        }

    }
}