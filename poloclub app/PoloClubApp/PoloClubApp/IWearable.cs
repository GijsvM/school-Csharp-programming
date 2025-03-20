///
/// class: IWearable.cs
///
///This file defines the IWearable interface, which specifies a method to get the water resistance level of wearable devices. 
///It is implemented by classes representing wearable devices like smartwatches and fitness trackers.
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
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PoloClubApp
{
    interface IWearable
    { 
        ///Returns the water resistance level of the wearable device in meters.
        int GetWaterResistanceMeters();
       
    }
}
