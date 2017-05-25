using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma20161.Models
{
    public class Produto
    {
        [Display(Name = "ID")]
        public int ProdutoID { get; set; }
        [Display(Name = "Categoria")]
        public int CategoriaID { get; set; }
        [Display(Name = "Produto")]
        public String Descricao { get; set; }
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }

    }
}