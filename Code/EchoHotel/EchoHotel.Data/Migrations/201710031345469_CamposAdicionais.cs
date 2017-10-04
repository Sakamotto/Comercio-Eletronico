namespace EchoHotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CamposAdicionais : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hotel", "Nome", c => c.String(maxLength: 100));
            AddColumn("dbo.Hotel", "CNPJ", c => c.String(maxLength: 100));
            AddColumn("dbo.Endereco", "Numero", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Endereco", "Numero");
            DropColumn("dbo.Hotel", "CNPJ");
            DropColumn("dbo.Hotel", "Nome");
        }
    }
}
