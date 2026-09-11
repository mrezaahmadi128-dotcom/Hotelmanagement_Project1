using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelmanagement
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int Capacity {  get; set; }
        public decimal Price {  get; set; }
        public Room(string roomNumber, int capacity, decimal price)
        {
            RoomNumber = roomNumber;
            Capacity = capacity;
            Price = price;
        }
        public Room(int id,string roomNumber,int capaCity,decimal price) 
        {
            Id= id;
            RoomNumber= roomNumber;
            Capacity= capaCity;
            Price= price;
        }

        public  Result Validation(string roomNumber, int capaCity, decimal price)
        {
            if (string.IsNullOrWhiteSpace(roomNumber))
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
        
    }

}
