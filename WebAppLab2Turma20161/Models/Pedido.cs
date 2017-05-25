using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma20161.Models
{
    public class Pedido
    {
        [Display(Name = "ID")]
        public int PedidoID { get; set; }
        public int? ClienteID { get; set; }
        [Display(Name = "Data do Pedido")]
        public DateTime DataPedido { get; set; }
        [Display(Name = "Data do Envio")]
        public DateTime? DataEnvio { get; set; }
        [Display(Name = "Data da Entrega")]
        public DateTime? DataEntrega { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}