namespace MechanicShopApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookAppointments",
                c => new
                    {
                        BookAppointmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Email = c.String(),
                        PhoneNo = c.String(),
                        ServiceId = c.Int(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.BookAppointmentId)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookAppointments", "ServiceId", "dbo.Services");
            DropIndex("dbo.BookAppointments", new[] { "ServiceId" });
            DropTable("dbo.Services");
            DropTable("dbo.BookAppointments");
        }
    }
}
