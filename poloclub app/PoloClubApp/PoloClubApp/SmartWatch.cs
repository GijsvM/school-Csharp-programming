///
/// class: SmartWatch.cs
///
///This file defines the SmartWatch class, which represents a smartwatch device. It implements the IWearable interface 
///and includes properties for water resistance and screen size, along with methods to get device details.
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
using System.Xml.Linq;

namespace PoloClubApp
{
    internal class SmartWatch : Device, IWearable
    {
        public string DeviceType = "Watch";
        public int WaterResistanceMeters { get; }
        public int ScreenSize { get; }

        ///  Initializes a new SmartWatch with specified ID, name, player name, water resistance, and screen size.
        public SmartWatch(int id, string name, int waterResistanceMeters, int screenSize) : base(id, name, null)
        {
          
           WaterResistanceMeters = waterResistanceMeters;
           ScreenSize = screenSize;
        }

        /// Returns a string representation of the SmartWatch details.
        public override string GetDetails()
        {
            return DeviceType + "Id: " + Id + ", Name: " + Name +  ", WaterResistanceMeters: " + WaterResistanceMeters + ", ScreenSize: " + ScreenSize;
        }

        /// Returns the water resistance of the SmartWatch in meters.
        public int GetWaterResistanceMeters()
        {
            return WaterResistanceMeters;
        }
    }
}
