using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RoomDto
    {
        public int Id { get; set; }
       
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public string Display => $"Id:{Id} - {RoomNumber}";
        public RoomDto(string roomNumber, int capacity, decimal price)
        {
            RoomNumber = roomNumber;
            Capacity = capacity;
            Price = price;
        }
        public RoomDto(int id, string roomNumber, int capaCity, decimal price)
        {
            Id = id;
            RoomNumber = roomNumber;
            Capacity = capaCity;
            Price = price;
        }

        public OperationResult Validation(string roomNumber, int capaCity, decimal price)
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

