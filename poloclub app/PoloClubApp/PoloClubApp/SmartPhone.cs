///
/// class: SmartPhone.cs
///
///This file defines the SmartPhone class, which represents a smartphone device. It includes properties and methods 
///specific to smartphones, such as getting device details and managing assignments to players.
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
    //
    internal class SmartPhone : Device
    {
        public string DeviceType = "SmartPhone";
        public int Id { get; }
        public string Name { get; }

        public string PlayerName { get; set; }
      
        public SmartPhone(int id, string name) : base(id, name, null)
        {
            Id = id;
            Name = name;
        }
        public override string GetDetails()
        {
            return DeviceType + "Id: " + Id + ", Name: " + Name;
        }
    }
}
