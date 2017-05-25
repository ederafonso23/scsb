using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma20161.Models.ViewModels
{
    public class ProdutoCategoriaViewModel
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int CodigoCategoria { get; set; }
        public string DescricaoCategoria { get; set; }
    }
}