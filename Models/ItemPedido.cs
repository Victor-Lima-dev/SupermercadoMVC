using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace supermercadoMVC.Models
{
    public class ItemPedido
    {
        public int ItemPedidoId { get; set; }
        public int Quantidade { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public Pedido Pedido { get; set; }
        public decimal Preco { get; set; }

    }
}