namespace InOne.Reservation.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4Migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "BirthYear", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "BirthYear", c => c.DateTime());
        }
    }
}
