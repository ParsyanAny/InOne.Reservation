namespace InOne.Reservation.DataAccess
{
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingFurnitures",
                c => new
                    {
                        BookingId = c.Int(nullable: false),
                        FurnitureId = c.Int(nullable: false),
                        Count = c.Int(),
                    })
                .PrimaryKey(t => new { t.BookingId, t.FurnitureId })
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: true)
                .ForeignKey("dbo.Furnitures", t => t.FurnitureId, cascadeDelete: true)
                .Index(t => t.BookingId)
                .Index(t => t.FurnitureId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        Time1 = c.DateTime(),
                        Time2 = c.DateTime(),
                        RoomId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        IsEmpty = c.Boolean(nullable: false),
                        Price = c.Double(nullable: false),
                        ParentRoomId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.ParentRoomId)
                .Index(t => t.ParentRoomId);
            
            CreateTable(
                "dbo.RoomFurnitures",
                c => new
                    {
                        FurnitureId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FurnitureId, t.RoomId })
                .ForeignKey("dbo.Furnitures", t => t.FurnitureId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.FurnitureId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Furnitures",
                c => new
                    {
                        FurnitureId = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 50),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FurnitureId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 70),
                        BirthayYear = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserBookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.BookingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingFurnitures", "FurnitureId", "dbo.Furnitures");
            DropForeignKey("dbo.BookingFurnitures", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserBookings", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserBookings", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomFurnitures", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomFurnitures", "FurnitureId", "dbo.Furnitures");
            DropForeignKey("dbo.Rooms", "ParentRoomId", "dbo.Rooms");
            DropIndex("dbo.UserBookings", new[] { "BookingId" });
            DropIndex("dbo.UserBookings", new[] { "UserId" });
            DropIndex("dbo.RoomFurnitures", new[] { "RoomId" });
            DropIndex("dbo.RoomFurnitures", new[] { "FurnitureId" });
            DropIndex("dbo.Rooms", new[] { "ParentRoomId" });
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropIndex("dbo.Bookings", new[] { "RoomId" });
            DropIndex("dbo.BookingFurnitures", new[] { "FurnitureId" });
            DropIndex("dbo.BookingFurnitures", new[] { "BookingId" });
            DropTable("dbo.UserBookings");
            DropTable("dbo.Users");
            DropTable("dbo.Furnitures");
            DropTable("dbo.RoomFurnitures");
            DropTable("dbo.Rooms");
            DropTable("dbo.Bookings");
            DropTable("dbo.BookingFurnitures");
        }
    }
}
