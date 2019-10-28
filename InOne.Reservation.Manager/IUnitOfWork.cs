namespace InOne.Reservation.Manager
{
    public interface IUnitOfWork
    {
        IFurnitureManager FurnitureManager { get; }
        IBookingManager BookingManager { get; }
        IRoomManager RoomManager { get; }
        IUserManager UserManager { get; }
        void Commit();
        void RejectChanges();
        void Dispose();
    }
}
