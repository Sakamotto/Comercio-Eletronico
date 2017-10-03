namespace EchoHotel.Data.Migrations
{
    using EchoHotel.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EchoHotel.Data.Context.EchoHotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EchoHotel.Data.Context.EchoHotelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Cliente.AddOrUpdate(
                new Cliente { Nome = "Cristian", Sobrenome = "Anterio", Ativo = true, Email = "csanterio@email.com",
                    Cpf = "12312312312", DataNascimento = new DateTime(1994, 7, 30), Id = 1,
                    Endereco = new Endereco { Bairro = "Cidade Continental", Cep = "29123324",
                        Cidade = "Serra", Estado = "Espírito Santo", Rua = "Rua teste", Id=1}
                });
        }
    }
}
