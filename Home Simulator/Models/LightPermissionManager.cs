using Home_Simulator.Models.HouseModels;
using Home_Simulator.Models.ProfileModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Simulator.Models
{
    public class LightPermissionManager
    {



        public void UpdateLightPermissionsForAllUsers(ObservableCollection<Room> rooms, User currentUser)
        {
            foreach (var room in rooms)
            {

                foreach (var light in room.Lights)
                {
                    light.UserHasAccess = false;
                }
            }

            if (currentUser != null)
            {
                if (currentUser.CurrentLocation is Room currentRoom)
                {
                    if (currentUser.Type == UserType.Child || currentUser.Type == UserType.Guest)
                    {
                        foreach (var light in currentRoom.Lights)
                        {
                            light.UserHasAccess = true;
                        }
                    }

                    else
                    {
                        if (currentUser.Type != UserType.Stranger)
                        {
                            foreach (var room in rooms)
                            {
                                foreach (var light in room.Lights)
                                {
                                    light.UserHasAccess = true;
                                }
                            }
                        }

                    }
                }

                else if (currentUser.CurrentLocation == null)
                {
                    if (currentUser.Type == UserType.Mother || currentUser.Type == UserType.Father)
                    {
                        foreach (var room in rooms)
                        {
                            foreach (var light in room.Lights)
                            {
                                light.UserHasAccess = true;
                            }
                        }
                    }

                    else
                    {
                        foreach (var room in rooms)
                        {
                            foreach (var light in room.Lights)
                            {
                                light.UserHasAccess = false;
                            }
                        }
                    }
                }
            }

            
        }
    }
}
