namespace SciaSquash.Model.DataContexts.SciaSquashMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "sciaSquash.MatchDay",
                c => new
                    {
                        MatchDayID = c.Int(nullable: false, identity: true),
                        MatchDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MatchDayID);
            
            CreateTable(
                "sciaSquash.Match",
                c => new
                    {
                        MatchID = c.Int(nullable: false, identity: true),
                        MatchDayID = c.Int(nullable: false),
                        FirstPlayerID = c.Int(nullable: false),
                        SecondPlayerID = c.Int(nullable: false),
                        ScorePlayerFirst = c.Int(nullable: false),
                        ScorePlayerSecond = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchID)
                .ForeignKey("sciaSquash.Player", t => t.FirstPlayerID, cascadeDelete: true)
                .ForeignKey("sciaSquash.MatchDay", t => t.MatchDayID, cascadeDelete: true)
                .ForeignKey("sciaSquash.Player", t => t.SecondPlayerID)
                .Index(t => t.MatchDayID)
                .Index(t => t.FirstPlayerID)
                .Index(t => t.SecondPlayerID);
            
            CreateTable(
                "sciaSquash.Player",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 256),
                        LastName = c.String(nullable: false, maxLength: 256),
                        NickName = c.String(nullable: false, maxLength: 10),
                        SpecialPower = c.String(nullable: false, maxLength: 256),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                    })
                .PrimaryKey(t => t.PlayerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("sciaSquash.Match", "SecondPlayerID", "sciaSquash.Player");
            DropForeignKey("sciaSquash.Match", "MatchDayID", "sciaSquash.MatchDay");
            DropForeignKey("sciaSquash.Match", "FirstPlayerID", "sciaSquash.Player");
            DropIndex("sciaSquash.Match", new[] { "SecondPlayerID" });
            DropIndex("sciaSquash.Match", new[] { "FirstPlayerID" });
            DropIndex("sciaSquash.Match", new[] { "MatchDayID" });
            DropTable("sciaSquash.Player");
            DropTable("sciaSquash.Match");
            DropTable("sciaSquash.MatchDay");
        }
    }
}
