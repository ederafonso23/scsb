using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using WebAppLab2Turma20161.Models;

namespace WebAppLab2Turma20161.DiagramaDeClasse
{
    public static class DiagramaDeClasse
    {
        public static void GerarDiagrama()
        {

            using (var ctx = new ContextoEF())
            {
                using (var writer = new XmlTextWriter(@"C:\Users\edera\Source\Repos\lojavirtual\WebAppLab2Turma20161\DiagramaDeClasse\Model.edmx", Encoding.Default))
                {
                    EdmxWriter.WriteEdmx(ctx, writer);
                }
            }
        }
    }
}