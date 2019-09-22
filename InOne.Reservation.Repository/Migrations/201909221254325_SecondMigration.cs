namespace InOne.Reservation.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "BirthYear", c => c.DateTime());
            DropColumn("dbo.Users", "BirthayYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "BirthayYear", c => c.DateTime());
            DropColumn("dbo.Users", "BirthYear");
        }
    }
}
