using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma20161.Models
{
    public class ItensDoPedido
    {
        [Key][Column(Order = 0)]
        public int ProdutoId { get; set; }

        [Key][Column(Order = 1)]
        public int PedidoId { get; set; }

        public int Quantidade { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}