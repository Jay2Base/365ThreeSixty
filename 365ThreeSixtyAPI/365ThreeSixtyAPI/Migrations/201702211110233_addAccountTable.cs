namespace _365ThreeSixtyAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAccountTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.accounts",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        accountName = c.String(),
                        accountEmail = c.String(),
                        accountContactName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.accounts");
        }
    }
}
