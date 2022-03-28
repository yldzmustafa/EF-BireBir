namespace BirebirEntityForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Adres = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OgrenciTs", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.OgrenciTs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ad = c.String(),
                        Soyad = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adresses", "ID", "dbo.OgrenciTs");
            DropIndex("dbo.Adresses", new[] { "ID" });
            DropTable("dbo.OgrenciTs");
            DropTable("dbo.Adresses");
        }
    }
}
