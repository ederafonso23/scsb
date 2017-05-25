using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma20161.Models
{
    public class Endereco
    {
        [ForeignKey("Cliente")]
        public int EnderecoId { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string PontoReferencia { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}