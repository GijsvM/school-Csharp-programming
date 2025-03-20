///
/// class: Device.cs
///
///This file defines the abstract Device class, which serves as the base class for all device types (e.g., smartphones, smartwatches). 
///It includes common properties and methods for managing device details and assignments.
///
/// Name: Gijs van Maanen
/// Studentnumber: 548495
/// Date: 19 March 2025
///
///Version: 1.4
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoloClubApp
{
    internal abstract class Device
    {
        public int Id { get; }
        public string Name { get; }
        public string PlayerName { get; set; }
        public Device(int id, string name, string playerName = null)
        {
            Id = id;
            Name = name;
            PlayerName = playerName;
        }
        
        public abstract string GetDetails();

        public bool IsAssigned()
        {
            return PlayerName != null;
        }
        public Exception AssignDevice(string playerName, int? waterResistanceMeters)
        {
            if (IsAssigned())
            {
                throw new Exception("Device is already assigned");
            }
            else if (this is IWearable && waterResistanceMeters < 3)
            {
                throw new Exception("Water resistance meters should be 3 or more");
            }
            else if (this.Id == null)
            {
                throw new Exception("Device Id is null");
            }
            else
            {
                PlayerName = playerName;
                return null;
            }
        }


        public bool ReturnDevice()
        {
            if (!IsAssigned())
            {
                return false;
            }
            PlayerName = null;
            return true;
        }
    }
}
