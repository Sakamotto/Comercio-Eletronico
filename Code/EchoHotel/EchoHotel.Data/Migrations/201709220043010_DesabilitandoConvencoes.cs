namespace EchoHotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DesabilitandoConvencoes : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Acomodacaos", newName: "Acomodacao");
            RenameTable(name: "dbo.Adicionals", newName: "Adicional");
            RenameTable(name: "dbo.Clientes", newName: "Cliente");
            RenameTable(name: "dbo.Compras", newName: "Compra");
            RenameTable(name: "dbo.Reservas", newName: "Reserva");
            RenameTable(name: "dbo.Enderecoes", newName: "Endereco");
            RenameTable(name: "dbo.Hotels", newName: "Hotel");
            AlterColumn("dbo.Acomodacao", "Descricao", c => c.String(maxLength: 500));
            AlterColumn("dbo.Adicional", "Nome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Cliente", "Nome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Cliente", "Sobrenome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Cliente", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Compra", "CodigoCompra", c => c.String(maxLength: 100));
            AlterColumn("dbo.Reserva", "CodigoLocacao", c => c.String(maxLength: 100));
            AlterColumn("dbo.Endereco", "Cep", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Endereco", "Rua", c => c.String(maxLength: 100));
            AlterColumn("dbo.Endereco", "Bairro", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Endereco", "Cidade", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Endereco", "Estado", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Hotel", "Descricao", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hotel", "Descricao", c => c.String());
            AlterColumn("dbo.Endereco", "Estado", c => c.String(nullable: false));
            AlterColumn("dbo.Endereco", "Cidade", c => c.String(nullable: false));
            AlterColumn("dbo.Endereco", "Bairro", c => c.String(nullable: false));
            AlterColumn("dbo.Endereco", "Rua", c => c.String());
            AlterColumn("dbo.Endereco", "Cep", c => c.String(nullable: false));
            AlterColumn("dbo.Reserva", "CodigoLocacao", c => c.String());
            AlterColumn("dbo.Compra", "CodigoCompra", c => c.String());
            AlterColumn("dbo.Cliente", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Cliente", "Sobrenome", c => c.String(nullable: false));
            AlterColumn("dbo.Cliente", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Adicional", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Acomodacao", "Descricao", c => c.String());
            RenameTable(name: "dbo.Hotel", newName: "Hotels");
            RenameTable(name: "dbo.Endereco", newName: "Enderecoes");
            RenameTable(name: "dbo.Reserva", newName: "Reservas");
            RenameTable(name: "dbo.Compra", newName: "Compras");
            RenameTable(name: "dbo.Cliente", newName: "Clientes");
            RenameTable(name: "dbo.Adicional", newName: "Adicionals");
            RenameTable(name: "dbo.Acomodacao", newName: "Acomodacaos");
        }
    }
}
