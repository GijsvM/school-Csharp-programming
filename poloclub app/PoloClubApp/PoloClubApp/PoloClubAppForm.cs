///
/// class: PoloClubAppForm.cs
///
///This file contains the PoloClubAppForm class, which is the main Windows Forms application for managing the 
///polo club's devices. It provides the user interface for viewing, assigning, returning, and generating reports for devices.
///
/// Name: Gijs van Maanen
/// Studentnumber: 548495
/// Date: 19 March 2025
///
///Version: 1.4
///
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PoloClubApp
{
    public partial class PoloClubAppForm : Form
    {
        // Provide your answers here
        private void btnViewAllWearables_Click(object sender, EventArgs e)
        {
            List<Device> wearables = myClub.GetAllWearables();
            lbOverview.Items.Clear();
            foreach (Device wearable in wearables)
            {
                lbOverview.Items.Add(wearable.GetDetails());
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            myClub.AssignDevice(Convert.ToInt32(cbDevice.Text), tbPlayerName.Text);
            

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            myClub.ReturnDevice(Convert.ToInt32(cbDevice.Text));

        }

        private void btnShowAssignedDevices_Click(object sender, EventArgs e)
        {
            List<Device> assignedDevices = myClub.GetAllAssignedDevicesByPlayer(tbPlayerName.Text);
            lbOverview.Items.Clear();
            foreach (Device device in assignedDevices)
            {
                lbOverview.Items.Add(device.GetDetails());
            }
        }


        private void btnGeneratePlayerTextReport_Click(object sender, EventArgs e)
        {
            List<string> report = myClub.GenerateReportPerPlayer(tbPlayerName.Text);
            lbOverview.Items.Clear();
            foreach (string line in report)
            {
                lbOverview.Items.Add(line);
            }
        }



        // -----The provided code below will not be graded, therefore should not be changed-----

        private Club myClub;
        public PoloClubAppForm()
        {
            InitializeComponent();
            myClub = new Club("Polo Koningen - powered by Gijs van Maanen");
            this.Text = myClub.Name;
            this.addSomeTestingStuff();
            this.fillComboBoxDevices();
        }

        private void addSomeTestingStuff()
        {
            myClub.AddDevice(new SmartPhone(101, "iPhone X"));
            myClub.AddDevice(new SmartWatch(202, "Apple Watch Sport", 5, 38));
            myClub.AddDevice(new FitTracker(300, "Fitbit Ionic", 1, "pink"));
            myClub.AddDevice(new SmartWatch(203, "Motorola Moto 360", 9, 40));
            myClub.AddDevice(new SmartPhone(102, "iPhone 9"));
            myClub.AddDevice(new SmartPhone(103, "Galaxy S9"));
            myClub.AddDevice(new FitTracker(301, "Fitbit Alta HR", 8, "blue"));
            myClub.AddDevice(new SmartPhone(104, "Pixels 2"));
            myClub.AddDevice(new SmartWatch(204, "Samsung Gear Sport", 2, 42));
            myClub.AddDevice(new FitTracker(302, "Fitbit Charge 2", 10, "black"));
            myClub.AddDevice(new FitTracker(303, "Misfit Ray", 0, "black"));

        }
        private void fillComboBoxDevices()
        {
            foreach (Device dev in myClub.GetAllDevices())
            {
                cbDevice.Items.Add(dev.Id);
            }
        }

        private void btnViewAllDevices_Click(object sender, EventArgs e)
        {
            this.lbOverview.Items.Clear();
            foreach (Device dev in myClub.GetAllDevices())
            {
                this.lbOverview.Items.Add(dev.GetDetails());
            }

        }

    }
}
