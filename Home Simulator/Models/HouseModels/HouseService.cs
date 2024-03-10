using Home_Simulator.Models.HouseModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models
{
    public class HouseService
    {
        private readonly IHouseBuilder _builder;
        private Director _director;

        public HouseService(IHouseBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _director = new Director(_builder);
        }

        public House CreateHouseFromTextFile(string fileContent)
        {
            var roomFeatures = new List<Dictionary<string, object>>(); // Change to object to handle mixed types

            // Split the file content into lines
            var lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (var line in lines)
            {
                if (String.IsNullOrWhiteSpace(line) || !line.Contains(": "))
                {
                    continue;
                }

                // Extract room name and features
                var parts = line.Split(new[] { ": " }, StringSplitOptions.None);
                var roomName = parts[0]; // Extracted room name or number
                var features = parts[1];
                var featurePairs = features.Split(new[] { ", " }, StringSplitOptions.None);

                var featureDict = new Dictionary<string, object>
                {
                    { "Name", roomName } // Add room name to the dictionary
                };

                foreach (var pair in featurePairs)
                {
                    var keyValue = pair.Split('=');
                    if (keyValue.Length == 2 && int.TryParse(keyValue[1], out int value))
                    {
                        featureDict.Add(keyValue[0], value);
                    }
                }

                if (featureDict.Count > 0)
                {
                    roomFeatures.Add(featureDict);
                }
            }

            _director.ConstructHouse(roomFeatures);
            return _builder.GetHouse();
        }
    }
}
