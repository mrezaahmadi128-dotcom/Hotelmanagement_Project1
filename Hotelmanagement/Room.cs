using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelmanagement
{
    public class Room
    {
        public string RoomNumber { get; set; }
        public int Capacity {  get; set; }
        public decimal Price {  get; set; }
        public Room(string roomNumber, int capacity, decimal price)
        {
            RoomNumber = roomNumber;
            Capacity = capacity;
            Price = price;
        }

    }
}
