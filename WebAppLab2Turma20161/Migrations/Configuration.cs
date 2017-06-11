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

                    Nome = "Depilação",

                },

                new Categoria {

                    Nome = "Pele",

                },

                new Categoria {

                    Nome = "Unha",
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
                    Descricao = @"O shampoo é o primeiro item indispensável 
                                para potencializar os cuidados com os 
                                cabelos, pois além da função de limpar o 
                                couro cabeludo e os fios, podem conter 
                                ingredientes que nutrem e reconstroem 
                                a fibra capilar, preparando-a para 
                                receber os tratamentos à base de condicionadores 
                                e máscaras. Neste ponto os produtos 
                                da Loreal Profissional merecem especial 
                                destaque. ",

                },

                new Produto {
                    
                    Preco = 108.83M,
                    UltimaAtualizacao = DateTime.Now,
                    Categoria = categorias[0],
                    Nome = "Joico Smooth Cure Condicionador 300 ml",
                    Descricao = @"O condicionador é um produto que hidrata e 
                                devolve a maciez natural dos fios, 
                                criando uma camada protetora essencial 
                                para garantir nutrição e brilho aos 
                                cabelos. Rico em proteínas, sua ação é 
                                ampla e eficaz em relação ao 
                                fortalecimento da fibra capilar. ",

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
