using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma20161.Models
{
    public class Carrinho
    {
        [Key]
        public int Id { get; set; }

        public string CarrinhoId { get; set; }

        public int ProdutoId { get; set; }
        public int TotalItens { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DataRegistro { get; set; }

        public virtual Produto Produto { get; set; }
    }
}