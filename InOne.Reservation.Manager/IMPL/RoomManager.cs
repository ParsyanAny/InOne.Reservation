using InOne.Reservation.DataAccess;
using InOne.Reservation.DTOModels;
using InOne.Reservation.Models;
using System.Linq;

namespace InOne.Reservation.Manager.IMPL
{
    public class RoomManager : BaseManager<Room, RoomDTO>, IRoomManager
    {
        public RoomManager(ApplicationContext context) : base(context) { }

        public void AddRoom(RoomModel roomModel)
        {
            Room room = new Room()
            {
                Id = 0,
                IsEmpty = roomModel.IsEmpty,
                Number = roomModel.Number,
                Price = roomModel.Price,
                ParentRoomId = roomModel.ParentRoomId,
                RoomFurnitures = roomModel.Furnitures.Select(p => new RoomFurniture
                {
                    Count = p.FurnitureCount,
                    FurnitureId = p.FurnitureId
                }).ToList(),
            };
            _context.Rooms.Add(room);
            _context.SaveChanges();
            Room currentRoom = _context.Rooms.Where(p => p.Number == roomModel.Number).First();
            roomModel.Id = currentRoom.Id;
        }
        public void ChangeRoom(RoomModel model)
        {
            var result = _context.Rooms.Find(model.Id);
            if (result != null)
            {
                result.Number = model.Number;
                result.Price = model.Price;
                result.IsEmpty = model.IsEmpty;
                result.ParentRoomId = model.ParentRoomId;
                result.RoomFurnitures = model.Furnitures.Select(p => new RoomFurniture
                {
                    Count = p.FurnitureCount,
                    FurnitureId = p.FurnitureId
                }).ToList();
            }
        }
        public void DeleteAllRooms()
        => _context.Rooms.RemoveRange(_context.Rooms.AsQueryable());
        public Room GetByNumber(int number)
            => _context.Rooms.Where(p => p.Number == number).FirstOrDefault();
        public double GetCost(int roomID)
        {
            Room currentRoom = _context.Rooms.Find(roomID);
            var furs = _context.RoomFurnitures.Where(p => p.RoomId == roomID).ToArray();
            double roomCost = currentRoom.Price;
            double furRomCost = (from fur in _context.Furnitures
                                  join romFur in _context.RoomFurnitures on fur.FurnitureId equals romFur.FurnitureId
                                  where romFur.RoomId == roomID
                                  select fur.Price * romFur.Count).Sum();

            return roomCost + furRomCost;
        }
        public RoomModel[] GetRooms()
        {
            RoomModel[] roomModels = _context.Rooms.Select(p => new RoomModel
            {
                Id = p.Id,
                Number = p.Number,
                IsEmpty = p.IsEmpty,
                Price = p.Price,
                ParentRoomId = p.ParentRoomId,
                Furnitures = p.RoomFurnitures.Select(f => new FurnitureInfo
                {
                    FurnitureCount = f.Count,
                    FurnitureId = f.FurnitureId
                }).ToList(),
            }).ToArray();

            return roomModels;
        }

        public override RoomDTO ModelToDto(Room room)
            => new RoomDTO
            {
                Id = room.Id,
                Price = room.Price,
                IsEmpty = room.IsEmpty,
                Number = room.Number,
                ParentRoomId = room.ParentRoomId,
            };
        public override Room DtoToModel(RoomDTO roomDto)
            => new Room
            {
                Id = roomDto.Id,
                IsEmpty = roomDto.IsEmpty,
                Number = roomDto.Number,
                Price = roomDto.Price,
                ParentRoomId = roomDto.ParentRoomId
            };
    }
}