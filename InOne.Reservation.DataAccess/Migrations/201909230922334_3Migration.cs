namespace InOne.Reservation.DataAccess
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3Migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "Time1", c => c.Time(precision: 7));
            AlterColumn("dbo.Bookings", "Time2", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "Time2", c => c.DateTime());
            AlterColumn("dbo.Bookings", "Time1", c => c.DateTime());
        }
    }
}
