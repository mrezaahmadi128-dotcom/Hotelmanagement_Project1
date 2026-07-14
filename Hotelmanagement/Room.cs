using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelmanagement
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public int Capacity {  get; set; }
        public decimal Price {  get; set; }
        public Room(int roomNumber, int capacity, decimal price)
        {
            RoomNumber = roomNumber;
            Capacity = capacity;
            Price = price;
        }

        public static Result Validation(int roomNumber, int capaCity, decimal price)
        {
            if (roomNumber < 100 || roomNumber > 500)
            {
                return Result.Failed("شماره اتاق الزامی است");
            }
            if (capaCity <= 0)
            {
                return Result.Failed("ظرفیت نا مغتبر است");
            }
            if (price <= 0)
            {
                return Result.Failed("مبلغ نا معتبر است");
            }
            return Result.Ok();
        }
        public  Result Update(int roomNumber, int capaCity, decimal price)
        {
            Result result = Validation(roomNumber, capaCity, price);
            if (!result.Success)
                return result;
            RoomNumber = roomNumber;
            Capacity = capaCity;
            Price = price;
            return Result.Ok();
        }
    }

}
