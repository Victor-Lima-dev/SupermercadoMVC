using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace supermercadoMVC.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public decimal PedidoTotal { get; set; }
        public int PedidoTotalItens { get; set; }

        public List<ItemPedido> PedidoItens { get; set; }
    }
}