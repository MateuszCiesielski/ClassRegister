namespace DziennikElektroniczny.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DaneUczniów",
                c => new
                    {
                        u_id = c.Int(nullable: false, identity: true),
                        Imię = c.String(),
                        DataUrodzenia = c.DateTime(nullable: false),
                        AdresZamieszkania = c.String(),
                        Zdjęcie = c.Binary(),
                        k_id = c.Int(nullable: false),
                        DataRozpoczęciaNauki = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.u_id)
                .ForeignKey("dbo.Klasies", t => t.k_id, cascadeDelete: true)
                .Index(t => t.k_id);
            
            CreateTable(
                "dbo.Frekwencjas",
                c => new
                    {
                        f_id = c.Int(nullable: false, identity: true),
                        DataZajęć = c.DateTime(nullable: false),
                        u_id = c.Int(nullable: false),
                        Obecność = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.f_id)
                .ForeignKey("dbo.DaneUczniów", t => t.u_id, cascadeDelete: true)
                .Index(t => t.u_id);
            
            CreateTable(
                "dbo.Klasies",
                c => new
                    {
                        k_id = c.Int(nullable: false, identity: true),
                        SymbolKlasy = c.String(),
                        Wychowawca = c.String(),
                        Profil = c.String(),
                    })
                .PrimaryKey(t => t.k_id);
            
            CreateTable(
                "dbo.OcenyCząstkowe",
                c => new
                    {
                        oc_id = c.Int(nullable: false, identity: true),
                        DataOceny = c.DateTime(nullable: false),
                        u_id = c.Int(nullable: false),
                        Ocena = c.Int(nullable: false),
                        RodzajOceny = c.String(),
                    })
                .PrimaryKey(t => t.oc_id)
                .ForeignKey("dbo.DaneUczniów", t => t.u_id, cascadeDelete: true)
                .Index(t => t.u_id);
            
            CreateTable(
                "dbo.StatystykaKońcowa",
                c => new
                    {
                        s_id = c.Int(nullable: false, identity: true),
                        u_id = c.Int(nullable: false),
                        Średnia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Frekwencja = c.Int(nullable: false),
                        OcenaKońcowa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.s_id)
                .ForeignKey("dbo.DaneUczniów", t => t.u_id, cascadeDelete: true)
                .Index(t => t.u_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StatystykaKońcowa", "u_id", "dbo.DaneUczniów");
            DropForeignKey("dbo.OcenyCząstkowe", "u_id", "dbo.DaneUczniów");
            DropForeignKey("dbo.DaneUczniów", "k_id", "dbo.Klasies");
            DropForeignKey("dbo.Frekwencjas", "u_id", "dbo.DaneUczniów");
            DropIndex("dbo.StatystykaKońcowa", new[] { "u_id" });
            DropIndex("dbo.OcenyCząstkowe", new[] { "u_id" });
            DropIndex("dbo.Frekwencjas", new[] { "u_id" });
            DropIndex("dbo.DaneUczniów", new[] { "k_id" });
            DropTable("dbo.StatystykaKońcowa");
            DropTable("dbo.OcenyCząstkowe");
            DropTable("dbo.Klasies");
            DropTable("dbo.Frekwencjas");
            DropTable("dbo.DaneUczniów");
        }
    }
}
