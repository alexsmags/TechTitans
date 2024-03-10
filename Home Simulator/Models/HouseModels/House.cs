using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels
{
    public class House
    {
        public List<Room> Rooms { get; set; } = new List<Room>();

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }
    }
}
