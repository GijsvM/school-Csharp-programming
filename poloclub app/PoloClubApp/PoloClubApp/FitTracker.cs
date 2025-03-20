///
/// class: FitTracker.cs
///
///This file defines the FitTracker class, which represents a fitness tracker device. It implements 
///the IWearable interface and includes properties for water resistance and other fitness-specific features.
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
    internal class FitTracker : Device, IWearable
    {
        public string DeviceType = "FitTracker";
        public int Id { get; }
        public string Name { get; }
        public string PlayerName { get; set; }
        public int WaterResistanceMeters { get; }
        public string Color { get; }


        public FitTracker(int id, string name, int waterResistanceMeters, string color) : base(id, name, null)
        {
            Id = id;
            Name = name;
            WaterResistanceMeters = waterResistanceMeters;
            Color = color;

        }

        public override string GetDetails()
        {
            return DeviceType + "Id: " + Id + ", Name: " + Name + ", Type: " + ", WaterResistanceMeters: " + WaterResistanceMeters + ", Color: " + Color;
        }

        public int GetWaterResistanceMeters()
        {
            return WaterResistanceMeters;

        }
    }
}
