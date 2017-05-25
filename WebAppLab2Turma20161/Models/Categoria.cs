using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma20161.Models
{
    public class Categoria
    {
        public Categoria()
        {
            this.Produtos = new List<Produto>();
        }
        [Display(Name = "ID")]
        public int CategoriaID { get; set; }
        [Display(Name = "Categoria")]
        public String Descricao { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }


    }
}