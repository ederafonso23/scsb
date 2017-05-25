using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma20161.Models
{
    public class Cliente
    {
        public Cliente()
        {
            this.Pedidos = new List<Pedido>();
        }
        [Display(Name = "ID")]
        public int ClienteID { get; set; }
        [Display(Name = "Nome do Cliente")]
        public String Nome { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        // public int Idade { get; set; }
        [Display(Name = "CPF")]
        public string CPF { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Display(Name = "CEP")]
        public string CEP { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Horario> Horarios { get; set; }
    }
    
}