using Home_Simulator.Models.ProfileModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.ProfileReader
{
    public static class ProfileReaderService
    {
        private static string _filePath = @"..\..\ProfileReader\ProfileList.txt";

        public static ObservableCollection<User> LoadUsers()
        {
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException("The user profile file was not found.", _filePath);
            }

            ObservableCollection<User> users = new ObservableCollection<User>();

            string[] lines = File.ReadAllLines(_filePath);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("name="))
                {
                    var keyValuePairs = line.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(part => part.Split('='))
                                 .Where(part => part.Length == 2) 
                                 .ToDictionary(part => part[0].Trim(), part => part[1].Trim());

                    keyValuePairs.TryGetValue("name", out string name);
                    keyValuePairs.TryGetValue("age", out string ageString);
                    keyValuePairs.TryGetValue("UserType", out string userTypeString);

                    UserType? userType = null;
                    if (!string.IsNullOrEmpty(userTypeString))
                    {
                        userType = (UserType)Enum.Parse(typeof(UserType), userTypeString, ignoreCase: true);
                    }

                    int age = 0;
                    int.TryParse(ageString, out age);

                    var user = new User(name, age, userType);
                    users.Add(user);

                }
            }

            return users;
        }

        public static void SaveUsers(ObservableCollection<User> users)
        {
            List<string> lines = users.Select(user =>
                $"User: name={user.Name}, age={user.Age}, UserType={user.Type?.ToString() ?? "None"}").ToList();

            File.WriteAllLines(_filePath, lines);
        }

        public static void AddUser(User user)
        {
            string userLine = $"User: name={user.Name}, age={user.Age}, UserType={user.Type?.ToString() ?? "None"}";

            using (StreamWriter sw = File.AppendText(_filePath))
            {
                sw.WriteLine(userLine);
            }

        }

        public static void RemoveUser(User user)
        {
            var lines = File.ReadAllLines(_filePath).ToList();

            string userLine = $"User: name={user.Name}, age={user.Age}, UserType={user.Type?.ToString() ?? "None"}";

            var lineToRemove = lines.FirstOrDefault(line => line.Equals(userLine, StringComparison.OrdinalIgnoreCase));

            if (lineToRemove != null)
            {
                lines.Remove(lineToRemove);

                File.WriteAllLines(_filePath, lines);

            }
        }

    }
}
