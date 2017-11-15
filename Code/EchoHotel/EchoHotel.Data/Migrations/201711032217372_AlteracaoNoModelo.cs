namespace EchoHotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoNoModelo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Acomodacao", "UrlImg", c => c.String(maxLength: 100));
            AddColumn("dbo.Hotel", "UrlImg", c => c.String(maxLength: 100));
            AddColumn("dbo.Cliente", "Senha", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "Senha");
            DropColumn("dbo.Hotel", "UrlImg");
            DropColumn("dbo.Acomodacao", "UrlImg");
        }
    }
}
