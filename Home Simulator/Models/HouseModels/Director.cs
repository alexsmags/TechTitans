using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models.HouseModels
{
    public class Director
    {
        private IHouseBuilder _builder;

        public Director(IHouseBuilder builder)
        {
            _builder = builder;
        }

        public void ConstructHouse(List<Dictionary<string, object>> roomFeatures)
        {
            _builder.addAirConditioner();

            foreach (var features in roomFeatures)
            {
                _builder.BuildRoom();

                if (features.TryGetValue("Lights", out var lights) && lights is int lightsCount)
                {
                    _builder.AddLights(lightsCount);
                }

                if (features.TryGetValue("Doors", out var doors) && doors is int doorsCount)
                {
                    _builder.AddDoors(doorsCount);
                }

                if (features.TryGetValue("Windows", out var windows) && windows is int windowsCount)
                {
                    _builder.AddWindows(windowsCount);
                }

                if (features.TryGetValue("Name", out var name) && name is string roomName)
                {
                    _builder.NameRoom(roomName);
                }
            }
        }
    }
}
