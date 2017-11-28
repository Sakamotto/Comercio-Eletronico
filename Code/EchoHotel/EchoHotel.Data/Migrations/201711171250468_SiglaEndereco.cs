namespace EchoHotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SiglaEndereco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Endereco", "Sigla", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Endereco", "Sigla");
        }
    }
}
