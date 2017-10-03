namespace EchoHotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrecaoChaveEndereco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Endereco", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.Endereco", "Hotel_Id", "dbo.Hotel");
            DropIndex("dbo.Endereco", new[] { "Cliente_Id" });
            DropIndex("dbo.Endereco", new[] { "Hotel_Id" });
            RenameColumn(table: "dbo.Hotel", name: "Endereco_Id", newName: "EnderecoId");
            RenameColumn(table: "dbo.Cliente", name: "Endereco_Id", newName: "EnderecoId");
            RenameIndex(table: "dbo.Hotel", name: "IX_Endereco_Id", newName: "IX_EnderecoId");
            RenameIndex(table: "dbo.Cliente", name: "IX_Endereco_Id", newName: "IX_EnderecoId");
            DropColumn("dbo.Endereco", "Cliente_Id");
            DropColumn("dbo.Endereco", "Hotel_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Endereco", "Hotel_Id", c => c.Int());
            AddColumn("dbo.Endereco", "Cliente_Id", c => c.Int());
            RenameIndex(table: "dbo.Cliente", name: "IX_EnderecoId", newName: "IX_Endereco_Id");
            RenameIndex(table: "dbo.Hotel", name: "IX_EnderecoId", newName: "IX_Endereco_Id");
            RenameColumn(table: "dbo.Cliente", name: "EnderecoId", newName: "Endereco_Id");
            RenameColumn(table: "dbo.Hotel", name: "EnderecoId", newName: "Endereco_Id");
            CreateIndex("dbo.Endereco", "Hotel_Id");
            CreateIndex("dbo.Endereco", "Cliente_Id");
            AddForeignKey("dbo.Endereco", "Hotel_Id", "dbo.Hotel", "Id");
            AddForeignKey("dbo.Endereco", "Cliente_Id", "dbo.Cliente", "Id");
        }
    }
}
