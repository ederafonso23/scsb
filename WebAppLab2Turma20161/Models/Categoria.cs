using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma20161.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Categoria é obrigatório")]
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; } 
    }
}