///
/// class: Club.cs
///
///This file contains the Club class, which manages the collection of devices in the polo club. 
///It provides methods to add, assign, return, and generate reports for devices, as well as retrieve all wearables.
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
using System.IO;
using System.Windows.Forms;

namespace PoloClubApp
{
    class Club
    {
        private string name;            // the name of the club
        private List<Device> devices;   // a list of devices

        public Club(string name)
        {
            this.name = name;
            this.devices = new List<Device>();
        }

        public string Name { get { return this.name; } } // read only property for Name


        //-----Provide your answers here-----

        public List<Device> GetAllWearables()
        {
            List<Device> wearables = new List<Device>();

            foreach (Device dev in this.devices)
            {
                if (dev is SmartWatch || dev is FitTracker)
                {
                    wearables.Add(dev);
                }
            }
            return wearables;
        }
        public void AssignDevice(int id, string playerName)
        {
            Device device = GetDeviceById(id);
            if(device == null)
            {
                throw new Exception("Device not found");
            }
            if (!(device is IWearable))
            {
                device.AssignDevice(playerName, null);
            }
            else
            {
                IWearable wearable = (IWearable)device;
                device.AssignDevice(playerName, wearable.GetWaterResistanceMeters());
            }

        }
        public bool ReturnDevice(int id)
        {
            Device device = GetDeviceById(id);
            return device.ReturnDevice();
        }

        public List<Device> GetAllAssignedDevicesByPlayer(string playerName)
        {
            List<Device> assignedDevices = new List<Device>();
            foreach (Device dev in this.devices)
            {
                if (dev.PlayerName == playerName)
                {
                    assignedDevices.Add(dev);
                }
            }
            return assignedDevices;
        }

        public List<String> GenerateReportPerPlayer(string playerName)
        {
            string returnString = "List of devices assigned to " + playerName;
            List<String> lines = new List<String>();
            List<Device> assignedDevices = GetAllAssignedDevicesByPlayer(playerName);

            lines.Add(returnString);
            string currentDeviceType = "SmartPhone";

            lines.Add("Phones");
            lines.Add("-");
            foreach (Device dev in assignedDevices)
            {
                if (dev is SmartPhone)
                {
                    lines.Add(dev.GetDetails());
                }
            }
            lines.Add("Wearables");
            lines.Add("-");
            foreach (Device dev in assignedDevices)
            {
                if (!(dev is SmartPhone))
                {
                    lines.Add(dev.GetDetails());
                }
            }

            int phoneCount = 0;
            int wearableCount = 0;
            foreach (Device dev in assignedDevices)
            {
                if (dev is SmartPhone)
                {
                    phoneCount++;
                }
                if (dev is IWearable)
                {
                    wearableCount++;
                }
            }

            lines.Add("Total: " + assignedDevices.Count + " devices, " + phoneCount + " phones and " + wearableCount + " wearables");

            return lines;
        }



        // -----The provided code below will not be graded, therefore should not be changed-----

        /// <summary>
        /// Provides all devices to the caller.
        /// </summary>
        /// <returns>List of devices</returns>
        public List<Device> GetAllDevices()
        {
            return this.devices;
        }

        /// <summary>
        /// Adds a device to the list of devices if unique id is provided.
        /// </summary>
        /// <param name="device">device to be added</param>
        public void AddDevice(Device device)
        {
            foreach (Device dev in this.devices)
            {
                if (dev.Id == device.Id)
                {
                    return;
                }
            }
            devices.Add(device);
        }

        /// <summary>
        /// Provides a device by a given id.
        /// </summary>
        /// <param name="id">the unique identity number of the requested device.</param>
        /// <returns>A device when found, otherwise null</returns>
        public Device GetDeviceById(int id)
        {
            foreach (Device dev in this.devices)
            {
                if (dev.Id == id)
                {
                    return dev;
                }
            }
            return null;
        }

    }
}

