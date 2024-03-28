using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels
{
    public interface IHouseBuilder
    {
        void BuildRoom();
        void AddLights(int numberOfLights);
        void AddDoors(int numberOfDoors);
        void AddWindows(int numberOfWindows);
        void addAirConditioner();
        void addHeater();
        House GetHouse(); 
        void NameRoom(string name);
    }
}
