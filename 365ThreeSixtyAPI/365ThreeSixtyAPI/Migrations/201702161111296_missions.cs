namespace _365ThreeSixtyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class missions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.exclusions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        exclusion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.keywordDictionaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        keyword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.missions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        missionStatement = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.missions");
            DropTable("dbo.keywordDictionaries");
            DropTable("dbo.exclusions");
        }
    }
}
