using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma20161.Models.Configurations
{
    public class ConfiguracaoCliente : EntityTypeConfiguration<Cliente>
    {
            public ConfiguracaoCliente()
            {
               

            this.Property(n => n.Nome)
                .IsRequired().HasMaxLength(500);

            /* One-To-Zero-Or-One 
            this.HasOptional(end => end.Endereco)
                .WithRequired(cli => cli.Cliente)
                .WillCascadeOnDelete(true); */

             this.HasMany(ped => ped.Pedidos)
                .WithOptional(cli => cli.Cliente)
                .HasForeignKey(cli => cli.ClienteID)
                .WillCascadeOnDelete(true);

            this.HasMany(hor => hor.Horarios)
                    .WithOptional(cli => cli.Cliente)
                    .HasForeignKey(cli => cli.ClienteID)
                    .WillCascadeOnDelete(true);
            }
        }
    }
