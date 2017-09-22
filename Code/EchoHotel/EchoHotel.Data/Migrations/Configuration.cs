namespace EchoHotel.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.EchoHotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.EchoHotelContext context)
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
                new Domain.Entities.Cliente { Nome = "Cristian", Sobrenome="Anterio", Cpf="12312312312", Email="csanterio@gmail.com", DataNascimento= new DateTime(1994, 7, 30),
                Endereco = new Domain.Entities.Endereco
                {
                    Cep ="1212112", Bairro="Cidade Continental", Cidade="Serra", Estado="Espírito Santo", UF="ES"}
                }
                
                );


        }
    }
}
