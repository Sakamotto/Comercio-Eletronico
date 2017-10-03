namespace EchoHotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VersaoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acomodacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservaId = c.Int(nullable: false),
                        HotelId = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Disponivel = c.Boolean(nullable: false),
                        Capacidade = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotel", t => t.HotelId, cascadeDelete: true)
                .ForeignKey("dbo.Reserva", t => t.ReservaId, cascadeDelete: true)
                .Index(t => t.ReservaId)
                .Index(t => t.HotelId);
            
            CreateTable(
                "dbo.Adicional",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hotel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QtdAcomodacoes = c.Int(nullable: false),
                        QtdEstrelas = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 500),
                        Endereco_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endereco", t => t.Endereco_Id)
                .Index(t => t.Endereco_Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cep = c.String(nullable: false, maxLength: 100),
                        Rua = c.String(maxLength: 100),
                        Bairro = c.String(nullable: false, maxLength: 100),
                        Cidade = c.String(nullable: false, maxLength: 100),
                        Estado = c.String(nullable: false, maxLength: 100),
                        UF = c.String(maxLength: 2),
                        Cliente_Id = c.Int(),
                        Hotel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Id)
                .ForeignKey("dbo.Hotel", t => t.Hotel_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Hotel_Id);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Sobrenome = c.String(nullable: false, maxLength: 100),
                        DataNascimento = c.DateTime(nullable: false),
                        Cpf = c.String(nullable: false, maxLength: 11),
                        Email = c.String(nullable: false, maxLength: 100),
                        Ativo = c.Boolean(nullable: false),
                        Endereco_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endereco", t => t.Endereco_Id)
                .Index(t => t.Endereco_Id);
            
            CreateTable(
                "dbo.Compra",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoCompra = c.String(nullable: false, maxLength: 100),
                        TotalCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Reserva",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompraId = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CodigoLocacao = c.String(maxLength: 100),
                        DataInicio = c.DateTime(nullable: false),
                        DataTermino = c.DateTime(nullable: false),
                        Ativa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compra", t => t.CompraId, cascadeDelete: true)
                .Index(t => t.CompraId);
            
            CreateTable(
                "dbo.AdicionalAcomodacao",
                c => new
                    {
                        Adicional_Id = c.Int(nullable: false),
                        Acomodacao_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Adicional_Id, t.Acomodacao_Id })
                .ForeignKey("dbo.Adicional", t => t.Adicional_Id)
                .ForeignKey("dbo.Acomodacao", t => t.Acomodacao_Id)
                .Index(t => t.Adicional_Id)
                .Index(t => t.Acomodacao_Id);
            
            CreateTable(
                "dbo.HotelAdicional",
                c => new
                    {
                        Hotel_Id = c.Int(nullable: false),
                        Adicional_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Hotel_Id, t.Adicional_Id })
                .ForeignKey("dbo.Hotel", t => t.Hotel_Id)
                .ForeignKey("dbo.Adicional", t => t.Adicional_Id)
                .Index(t => t.Hotel_Id)
                .Index(t => t.Adicional_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hotel", "Endereco_Id", "dbo.Endereco");
            DropForeignKey("dbo.Endereco", "Hotel_Id", "dbo.Hotel");
            DropForeignKey("dbo.Endereco", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.Cliente", "Endereco_Id", "dbo.Endereco");
            DropForeignKey("dbo.Reserva", "CompraId", "dbo.Compra");
            DropForeignKey("dbo.Acomodacao", "ReservaId", "dbo.Reserva");
            DropForeignKey("dbo.Compra", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.HotelAdicional", "Adicional_Id", "dbo.Adicional");
            DropForeignKey("dbo.HotelAdicional", "Hotel_Id", "dbo.Hotel");
            DropForeignKey("dbo.Acomodacao", "HotelId", "dbo.Hotel");
            DropForeignKey("dbo.AdicionalAcomodacao", "Acomodacao_Id", "dbo.Acomodacao");
            DropForeignKey("dbo.AdicionalAcomodacao", "Adicional_Id", "dbo.Adicional");
            DropIndex("dbo.HotelAdicional", new[] { "Adicional_Id" });
            DropIndex("dbo.HotelAdicional", new[] { "Hotel_Id" });
            DropIndex("dbo.AdicionalAcomodacao", new[] { "Acomodacao_Id" });
            DropIndex("dbo.AdicionalAcomodacao", new[] { "Adicional_Id" });
            DropIndex("dbo.Reserva", new[] { "CompraId" });
            DropIndex("dbo.Compra", new[] { "ClienteId" });
            DropIndex("dbo.Cliente", new[] { "Endereco_Id" });
            DropIndex("dbo.Endereco", new[] { "Hotel_Id" });
            DropIndex("dbo.Endereco", new[] { "Cliente_Id" });
            DropIndex("dbo.Hotel", new[] { "Endereco_Id" });
            DropIndex("dbo.Acomodacao", new[] { "HotelId" });
            DropIndex("dbo.Acomodacao", new[] { "ReservaId" });
            DropTable("dbo.HotelAdicional");
            DropTable("dbo.AdicionalAcomodacao");
            DropTable("dbo.Reserva");
            DropTable("dbo.Compra");
            DropTable("dbo.Cliente");
            DropTable("dbo.Endereco");
            DropTable("dbo.Hotel");
            DropTable("dbo.Adicional");
            DropTable("dbo.Acomodacao");
        }
    }
}
