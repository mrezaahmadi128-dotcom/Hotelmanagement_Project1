using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelmanagement
{
    public class RoomManager
    {
        private static List<Room> _rooms = new List<Room>();
        public List<Room> GetRooms()
        {
            return _rooms;
        }
        public  Result AddRoom(Room room)
        {
            Result result=Room.Validation(room.RoomNumber,room.Capacity,room.Price);
            if(!result.Success)
                return result;
            if(ExistRoom(room.RoomNumber))
            {
                return Result.Failed("این اتاق وارد شده موجود هست");
            }
            _rooms.Add(room);
            return Result.Ok();
        }
        public  bool ExistRoom(int roomNumber)
        {
            foreach (Room r in _rooms)
            {
                if (r.RoomNumber == roomNumber)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <returns></returns>
        public Result RemoveRoom(int roomNumber)
        {
            Room delete = null;
            foreach (Room r in _rooms)
            {
                if (r.RoomNumber == roomNumber)
                {
                    delete = r;
                    break;
                }
            }
            if (delete != null)
            {
                _rooms.Remove(delete);
                return Result.Ok();
            }
            else
            {
                return Result.Failed(" همچین شماره اتاقی وجود ندارد");
            }
        }
        public static Room GetRoomByNuber(int roomNumber)
        {

            foreach (Room r in _rooms)
            {
                if (r.RoomNumber == roomNumber)
                    return r;
            }

            return null;
        }
        public static Result Validation(Room room)
        {
            if (room.RoomNumber < 100 || room.RoomNumber > 500)
            {
                return Result.Failed("شماره اتاق الزامی است");
            }
            if (room.Capacity <= 0)
            {
                return Result.Failed("ظرفیت نا مغتبر است");
            }
            if (room.Price <= 0)
            {
                return Result.Failed("مبلغ نا معتبر است");
            }
            return Result.Ok();
        }
    }
}
