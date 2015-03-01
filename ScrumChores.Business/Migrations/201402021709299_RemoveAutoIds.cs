namespace ScrumChores.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAutoIds : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserTypes", "UserTypeID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserTypes", "UserTypeID", c => c.Guid(nullable: false, identity: true));
        }
    }
}
