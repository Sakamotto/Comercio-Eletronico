namespace EchoHotel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullReservaIdEmAcomodacao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Acomodacao", "ReservaId", "dbo.Reserva");
            DropIndex("dbo.Acomodacao", new[] { "ReservaId" });
            AlterColumn("dbo.Acomodacao", "ReservaId", c => c.Int());
            CreateIndex("dbo.Acomodacao", "ReservaId");
            AddForeignKey("dbo.Acomodacao", "ReservaId", "dbo.Reserva", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Acomodacao", "ReservaId", "dbo.Reserva");
            DropIndex("dbo.Acomodacao", new[] { "ReservaId" });
            AlterColumn("dbo.Acomodacao", "ReservaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Acomodacao", "ReservaId");
            AddForeignKey("dbo.Acomodacao", "ReservaId", "dbo.Reserva", "Id", cascadeDelete: true);
        }
    }
}
