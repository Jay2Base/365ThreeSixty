namespace _365ThreeSixtyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addaccountId : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.accounts", newName: "userAccounts");
            DropColumn("dbo.employees", "accountId");
            DropColumn("dbo.keywordDictionaries", "accountId");
            DropColumn("dbo.missions", "accountId");
            DropColumn("dbo.votes", "accountId");
            AddColumn("dbo.employees", "UserAccountId", c => c.String());
            AddColumn("dbo.keywordDictionaries", "UserAccountId", c => c.String());
            AddColumn("dbo.missions", "UserAccountId", c => c.String());
            AddColumn("dbo.votes", "userAccountId", c => c.String());

        }
        
        public override void Down()
        {
            AddColumn("dbo.votes", "accountId", c => c.String());
            AddColumn("dbo.missions", "accountId", c => c.String());
            AddColumn("dbo.keywordDictionaries", "accountId", c => c.String());
            AddColumn("dbo.employees", "accountId", c => c.String());
            DropColumn("dbo.votes", "userAccountId");
            DropColumn("dbo.missions", "UserAccountId");
            DropColumn("dbo.keywordDictionaries", "UserAccountId");
            DropColumn("dbo.employees", "UserAccountId");
            RenameTable(name: "dbo.userAccounts", newName: "accounts");
        }
    }
}
