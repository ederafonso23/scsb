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
        [Display(Name = "Id do Produto")]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Nome do produto é obrigatório")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Valor")]
        public Decimal Preco { get;set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Atualizado em")]
        [Column(TypeName = "datetime2")]
        public DateTime UltimaAtualizacao { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<ItensDoPedido> ProdutoEncomendado { get; set; } 

    }
}