using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppLab2Turma20161.Models
{
    [Bind(Exclude = "PedidoId")]
    public class Pedido
    {
        [ScaffoldColumn(false)]
        [Display(Name = "Id do Pedido")]
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DisplayName("Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "{0} obritatório")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DisplayName("CEP")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DisplayName("País")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DisplayName("E-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "E-mail inválido.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
     
        [ScaffoldColumn(false)]
        [Column(TypeName = "datetime2")]
        [Display(Name = "Data do Pedido")]
        public DateTime DataRegistro { get; set; }

        public int? ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }

        [Display(Name = "Data do Envio")]
        public DateTime? DataEnvio { get; set; }

        [Display(Name = "Data da Entrega")]
        public DateTime? DataEntrega { get; set; }

        [ScaffoldColumn(false)]
        public Decimal Total { get; set; }

        [ScaffoldColumn(false)]
        public string NomeUsuarioCliente { get; set; }

    }
}