namespace _365ThreeSixtyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVoteId : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.votes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        reviewerRef = c.Int(nullable: false),
                        recipientRef = c.Int(nullable: false),
                        rawScore = c.Int(nullable: false),
                        weightedScore = c.Double(nullable: false),
                        comment = c.String(),
                        commentFactor = c.Double(nullable: false),
                        commentScore = c.Double(nullable: false),
                        tierFactor = c.Double(nullable: false),
                        tierScore = c.Double(nullable: false),
                        reviewerFactor = c.Double(nullable: false),
                        reviewerScore = c.Double(nullable: false),
                        recipientFactor = c.Double(nullable: false),
                        recipientScore = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.votes");
        }
    }
}
