namespace DamMonWebConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pomiar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CzasProcesora = c.Single(nullable: false),
                        SredniaDlugoscKolejkiDyski = c.Single(nullable: false),
                        DostepnaPamiec = c.Single(nullable: false),
                        DataCzasProbki = c.DateTime(nullable: false),
                        NazwaSerwera = c.String(),
                        SerwerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Serwer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Serwer");
            DropTable("dbo.Pomiar");
        }
    }
}
