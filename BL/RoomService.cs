using DL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RoomService
    {
       
        RoomData data = new RoomData();

        public OperationResult AddRoom(RoomDto room)
        {
            var result = ValidateRoom(room.RoomNumber, room.Capacity, room.Price);
            if (!result.Success)
                return result;
            if (data.RoomNumberExists(room.RoomNumber))
            {
                return OperationResult.Failed("شماره اتاق وارد شده تکراری می باشد");
            }
           
           return data.AddRoom(room);
            
        }
        public OperationResult RemoveRoom(int id)
        {
            if (data.HasReservation(id))
            {
                return OperationResult.Failed("این اتاق دارای رزرو است");
            }
            return data.RemoveRoom(id);
            
        }
        public OperationResult<RoomDto> GetRoomById(int id)
        {
            return data.GetRoomById(id);
        }
        public OperationResult Update(int id, string roomNumber, int capacity, decimal price)
        {
            OperationResult result = ValidateRoom(roomNumber, capacity, price);
            if (!result.Success)
                return result;
            if (data.IsRoomNumberExists(id, roomNumber))
            {
                return OperationResult.Failed("شماره اتاق وارد شده تکراری می باشد");
            }
            return data.Update(id, roomNumber, capacity, price);
        }
        public  OperationResult<List<RoomDto>> GetRooms()
        {
            return data.GetRooms();
        }
        public OperationResult ValidateRoom(string roomNumber, int capaCity, decimal price)
        {
            if (string.IsNullOrWhiteSpace(roomNumber))
            {
                return OperationResult.Failed("شماره اتاق الزامی است");
            }
            if (capaCity <= 0)
            {
                return OperationResult.Failed("ظرفیت نا مغتبر است");
            }
            if (price <= 0)
            {
                return OperationResult.Failed("مبلغ نا معتبر است");
            }
            return OperationResult.Ok();
        }
    }
}
