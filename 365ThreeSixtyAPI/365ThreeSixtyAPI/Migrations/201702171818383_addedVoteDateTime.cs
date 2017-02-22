namespace _365ThreeSixtyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedVoteDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.votes", "voteSubmittedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.votes", "voteSubmittedAt");
        }
    }
}
