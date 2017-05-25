using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma20161.Models
{
    public class Horario
    {
        [Display(Name = "ID")]
        public int HorarioID { get; set; }
        [Display(Name = "Cliente")]
        public int? ClienteID { get; set; }
        [Display(Name = "Serviço")]
        public string Descricao { get; set; }
        [Display(Name = "Data do Atendimento")]
        public DateTime DataAtendimento { get; set; }
        [Display(Name = "Horário do Atendimento")]
        public string HorarioAtendimento { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}