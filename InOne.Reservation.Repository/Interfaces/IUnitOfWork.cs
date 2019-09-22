namespace InOne.Reservation.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IFurnitureRepository FurnitureRepository { get; }
        IBookingRepository BookingRepository { get; }
        IRoomRepository RoomRepository { get; }
        IUserRepository UserRepository { get; }
        void Commit();
        void RejectChanges();
        void Dispose();
    }
}
