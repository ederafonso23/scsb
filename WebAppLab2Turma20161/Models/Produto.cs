using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma20161.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Nome do produto é obrigatório")]
        public string Nome { get; set; }
        public Decimal Preco { get;set; }
        public string Descricao { get; set; }

        [Display(Name = "Atualizado em")]
        [Column(TypeName = "datetime2")]
        public DateTime UltimaAtualizacao { get; set; }

        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<ItensDoPedido> ProdutoEncomendado { get; set; } 

    }
}