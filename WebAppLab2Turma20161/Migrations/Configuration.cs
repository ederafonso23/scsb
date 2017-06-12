namespace WebAppLab2Turma20161.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<ContextoEF>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        private void PopularDados(ContextoEF context)
        {
            var categorias = new List<Categoria>()
            {
                new Categoria {

                    Nome = "Cabelo",


                },

                new Categoria {

                    Nome = "Maquiagem",

                },

                new Categoria {

                    Nome = "Depila��o",

                },

                new Categoria {

                    Nome = "Pele",

                }


            };

            context.Categorias.AddRange(categorias);

            var produtos = new List<Produto>()
            {
                new Produto {

                    Preco = 107.12M,
                    UltimaAtualizacao = DateTime.Now,
                    Categoria = categorias[0],
                    Nome = "Ghair Detox Kit Duo Grande",
                    Descricao = @"O shampoo � o primeiro item indispens�vel 
                                para potencializar os cuidados com os 
                                cabelos, pois al�m da fun��o de limpar o 
                                couro cabeludo e os fios, podem conter 
                                ingredientes que nutrem e reconstroem 
                                a fibra capilar, preparando-a para 
                                receber os tratamentos � base de condicionadores 
                                e m�scaras. Neste ponto os produtos 
                                da Loreal Profissional merecem especial 
                                destaque.�",

                },

                new Produto {
                    
                    Preco = 108.83M,
                    UltimaAtualizacao = DateTime.Now,
                    Categoria = categorias[0],
                    Nome = "Joico Smooth Cure Condicionador 300 ml",
                    Descricao = @"O condicionador � um produto que hidrata e 
                                devolve a maciez natural dos fios, 
                                criando uma camada protetora essencial 
                                para garantir nutri��o e brilho aos 
                                cabelos. Rico em prote�nas, sua a��o � 
                                ampla e eficaz em rela��o ao 
                                fortalecimento da fibra capilar.�",

                },

                new Produto {

                    Preco = 259.00M,
                    UltimaAtualizacao = DateTime.Now,
                    Categoria = categorias[1],
                    Nome = "MAKE B. PALETTE DE MAQUIAGEM THE FAVORITES",
                    Descricao = @"MAKE B. PALETTE DE MAQUIAGEM THE FAVORITES",

                },

                new Produto {

                    Preco = 62M,
                    UltimaAtualizacao = DateTime.Now,
                    Categoria = categorias[1],
                    Nome = "Kit bareMinerals Get Started Light (5 produtos)",
                    Descricao = @"Kit bareMinerals Get Started Light (5 produtos)",

                },

                new Produto {

                    Preco = 6.33M,
                    UltimaAtualizacao = DateTime.Now,
                    Categoria = categorias[2],
                    Nome = "Depil Bella Cera Depilat�ria Roll-On Camomila com Cal�ndula 100g",
                    Descricao = @"Depil Bella Cera Depilat�ria Roll-On Camomila com Cal�ndula 100g",

                },

                new Produto {

                    Preco = 66.99M,
                    UltimaAtualizacao = DateTime.Now,
                    Categoria = categorias[2],
                    Nome = "Kit Para Depila��o Sistema Roll-On Cera Quente Bivolt - Depil Bella",
                    Descricao = @"Kit Para Depila��o Sistema Roll-On Cera Quente Bivolt - Depil Bella",

                },

                new Produto {

                    Preco = 62.32M,
                    UltimaAtualizacao = DateTime.Now,
                    Categoria = categorias[3],
                    Nome = "ACTIVE KIT ANTISSINAIS AVAN�ADOS 45+",
                    Descricao = @"ACTIVE KIT ANTISSINAIS AVAN�ADOS 45+",

                },

                new Produto {

                    Preco = 135.20M,
                    UltimaAtualizacao = DateTime.Now,
                    Categoria = categorias[3],
                    Nome = "Clinique Sistema 3 Passos - Peles Mistas Kit",
                    Descricao = @"Clinique Sistema 3 Passos - Peles Mistas Kit",

                },


            };

            context.Produtos.AddRange(produtos);

        }

        protected override void Seed(ContextoEF context)
        {

            if (context.Categorias.Count() == 0)
            {
                try
                {
                    PopularDados(context);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    // TODO: fazer log de erro
                    ex.ToString();
                }
            }

        }
    }
}
