using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppLab2Turma20161.Models;

namespace WebAppLab2Turma20161.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Carrinho> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}