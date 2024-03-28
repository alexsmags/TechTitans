using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels
{
    public class HouseBuilder : IHouseBuilder
    {
        private House _house = new House();

        public void BuildRoom()
        {
            _house.AddRoom(new Room());
        }

        
        public void AddLights(int numberOfLights)
        {
            Room room = _house.Rooms[_house.Rooms.Count - 1];
            for (int i = 0; i < numberOfLights; i++)
            {
                room.Lights.Add(new Light());
            }
        }
        public void AddDoors(int numberOfDoors)
        {
            Room room = _house.Rooms[_house.Rooms.Count - 1];
            for (int i = 0; i < numberOfDoors; i++)
            {
                room.Doors.Add(new Door());
            }
        }
        public void AddWindows(int numberOfWindows)
        {
            Room room = _house.Rooms[_house.Rooms.Count - 1];
            for (int i = 0; i < numberOfWindows; i++)
            {
                room.Windows.Add(new Window());
            }
        }
        public void addAirConditioner()
        {
            _house.AirConditioner = new AirConditioner(); 
        }
        public void addHeater()
        {
            _house.Heater = new Heater();
        }
        public House GetHouse()
        {
            House result = _house;
            _house = new House(); // Reset for the next build
            return result;
        }
        public void NameRoom(string name)
        {
            Room room = _house.Rooms.Last();
            room.Name = name;
        }
    }
}
