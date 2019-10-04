namespace InOne.Reservation.DataAccess
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "UserName");
        }
    }
}
