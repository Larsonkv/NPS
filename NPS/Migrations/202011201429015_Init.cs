namespace NPS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Setors",
                c => new
                    {
                        SetorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.SetorId);
            
            CreateTable(
                "dbo.Votoes",
                c => new
                    {
                        VotoId = c.Int(nullable: false, identity: true),
                        Vl_voto = c.Int(nullable: false),
                        Nr_telefone = c.String(unicode: false),
                        Justificativa_voto = c.String(unicode: false),
                        SetorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VotoId)
                .ForeignKey("dbo.Setors", t => t.SetorId, cascadeDelete: true)
                .Index(t => t.SetorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votoes", "SetorId", "dbo.Setors");
            DropIndex("dbo.Votoes", new[] { "SetorId" });
            DropTable("dbo.Votoes");
            DropTable("dbo.Setors");
        }
    }
}
