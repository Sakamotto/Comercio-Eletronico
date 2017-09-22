namespace EchoHotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VersaoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acomodacaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Disponivel = c.Boolean(nullable: false),
                        Capacidade = c.Int(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Adicionals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tipo = c.Int(nullable: false),
                        Acomodacao_Id = c.Int(),
                        Hotel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Acomodacaos", t => t.Acomodacao_Id)
                .ForeignKey("dbo.Hotels", t => t.Hotel_Id)
                .Index(t => t.Acomodacao_Id)
                .Index(t => t.Hotel_Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Sobrenome = c.String(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Cpf = c.String(nullable: false, maxLength: 11),
                        Email = c.String(nullable: false),
                        EnderecoCliente_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enderecoes", t => t.EnderecoCliente_Id, cascadeDelete: true)
                .Index(t => t.EnderecoCliente_Id);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoCompra = c.String(),
                        TotalCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .Index(t => t.Cliente_Id);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CodigoLocacao = c.String(),
                        DataInicio = c.DateTime(nullable: false),
                        DataTermino = c.DateTime(nullable: false),
                        Ativa = c.Boolean(nullable: false),
                        Compra_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compras", t => t.Compra_Id)
                .Index(t => t.Compra_Id);
            
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cep = c.String(nullable: false),
                        Rua = c.String(),
                        Bairro = c.String(nullable: false),
                        Cidade = c.String(nullable: false),
                        Estado = c.String(nullable: false),
                        UF = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QtdAcomodacoes = c.Int(nullable: false),
                        QtdEstrelas = c.Int(nullable: false),
                        Descricao = c.String(),
                        EnderecoHotel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enderecoes", t => t.EnderecoHotel_Id, cascadeDelete: true)
                .Index(t => t.EnderecoHotel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hotels", "EnderecoHotel_Id", "dbo.Enderecoes");
            DropForeignKey("dbo.Adicionals", "Hotel_Id", "dbo.Hotels");
            DropForeignKey("dbo.Clientes", "EnderecoCliente_Id", "dbo.Enderecoes");
            DropForeignKey("dbo.Compras", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Reservas", "Compra_Id", "dbo.Compras");
            DropForeignKey("dbo.Adicionals", "Acomodacao_Id", "dbo.Acomodacaos");
            DropIndex("dbo.Hotels", new[] { "EnderecoHotel_Id" });
            DropIndex("dbo.Reservas", new[] { "Compra_Id" });
            DropIndex("dbo.Compras", new[] { "Cliente_Id" });
            DropIndex("dbo.Clientes", new[] { "EnderecoCliente_Id" });
            DropIndex("dbo.Adicionals", new[] { "Hotel_Id" });
            DropIndex("dbo.Adicionals", new[] { "Acomodacao_Id" });
            DropTable("dbo.Hotels");
            DropTable("dbo.Enderecoes");
            DropTable("dbo.Reservas");
            DropTable("dbo.Compras");
            DropTable("dbo.Clientes");
            DropTable("dbo.Adicionals");
            DropTable("dbo.Acomodacaos");
        }
    }
}
