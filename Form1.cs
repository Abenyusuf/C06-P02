//Name : Ahmed Benyusuf
//Class and Section (CS 313 01)
//Assignment (Program 02 Chapter 06)
//Description of the Program : This program uses methods to calculate the charges for an automotive shop.
//The user can input the parts and labor charges, and select from a list of services to add to the total.
//The program will calculate the total charges, including tax, and display the results to the user.
//The user can also clear the form and exit the program.




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C06_P02
{
    public partial class JoesAutomotive : Form
    {
        public JoesAutomotive()
        {
            InitializeComponent();
        }


private void CalculateButton_Click(object sender, EventArgs e)
        {
            double partsCharges = PartsCharges();
            double laborCharges = LaborCharges();
            double taxCharges = TaxCharges(partsCharges);
            double serviceAndLaborCharges = ServiceAndLaborCharges(laborCharges);
            double totalCharges = TotalCharges(partsCharges, laborCharges, taxCharges);

            PartsOutputTextBox.Text = partsCharges.ToString("c");
            TaxOutputTextBox.Text = taxCharges.ToString("c");
            ServiceLaborOutputTextBox.Text = serviceAndLaborCharges.ToString("c");
            TotalOutputTextBox.Text = totalCharges.ToString("c");
        }

        private double CalcServiceCharge(CheckBox checkBox, double charge)
        {
            return checkBox.Checked ? charge : 0.00;
        }
        // this will return whether or not the checkbox is checked, and if not checked return 0.

        private double PartsCharges()
        {
            double.TryParse(PartsTextBox.Text, out double partsCharges);
            return partsCharges;
        }
        // this method will return the value of the parts textbox. 

        private double LaborCharges()
        {
            double.TryParse(LaborTextBox.Text, out double laborHours);
            return laborHours * 75.00; // Multiply the labor hours by $75.00 per hour
        }
        // this method will return the value of the labor textbox multiplied by 75.00 to get the labor charges.

        private double TaxCharges(double partsCharges)
        {
            return partsCharges * 0.09; // 8.99% tax rate
        }
        // this method will return the value of the parts charges multiplied by 0.09 to get the tax charges.

        private double OilChangeCharges()
        {
            return CalcServiceCharge(OilChangeCheckBox, 50.00);
        }
        // this method will return the value of the oil change checkbox, and if checked return 50.00.

        private double LubeCharges()
        {
            return CalcServiceCharge(LubeJobCheckBox, 40.00);
        }
        // this method will return the value of the lube job checkbox, and if checked return 40.00.

        private double RadiatorFlushCharges()
        {
            return CalcServiceCharge(RadiatorFlushCheckBox, 100.00);
        }
        // this method will return the value of the radiator flush checkbox, and if checked return 100.00.

        private double TransmissionFlushCharges()
        {
            return CalcServiceCharge(TransmissionFlushCheckBox, 120.00);
        }
        // this method will return the value of the transmission flush checkbox, and if checked return 120.00.

        private double InspectionCharges()
        {
            return CalcServiceCharge(InspectionCheckBox, 35.00);
        }
        // this method will return the value of the inspection checkbox, and if checked return 35.00.

        private double MufflerCharges()
        {
            return CalcServiceCharge(ReplaceMufflerCheckBox, 150.00);
        }
        // this method will return the value of the replace muffler checkbox, and if checked return 150.00.

        private double TireRotationCharges()
        {
            return CalcServiceCharge(TireRotationCheckBox, 25.00);
        }
        // this method will return the value of the tire rotation checkbox, and if checked return 25.00.

        private double ServiceAndLaborCharges(double laborCharges)
        {
            return OilChangeCharges() + LubeCharges() + RadiatorFlushCharges() + TransmissionFlushCharges() + InspectionCharges() + MufflerCharges() + TireRotationCharges() + laborCharges;
        }
        // this method will return the sum of all the service charges and the labor charges.

        private double TotalCharges(double partsCharges, double laborCharges, double taxCharges)
        {
            double serviceAndLaborCharges = ServiceAndLaborCharges(laborCharges);
            return serviceAndLaborCharges + partsCharges + taxCharges;
        }
        // this method will return the sum of the service and labor charges, the parts charges, and the tax charges.

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();

            //exits the program
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            // Clear all text fields
            PartsTextBox.Text = string.Empty;
            LaborTextBox.Text = string.Empty;
            PartsOutputTextBox.Text = string.Empty;
            TaxOutputTextBox.Text = string.Empty;
            ServiceLaborOutputTextBox.Text = string.Empty;
            TotalOutputTextBox.Text = string.Empty;

            // Uncheck all checkboxes
            OilChangeCheckBox.Checked = false;
            LubeJobCheckBox.Checked = false;
            RadiatorFlushCheckBox.Checked = false;
            TransmissionFlushCheckBox.Checked = false;
            InspectionCheckBox.Checked = false;
            ReplaceMufflerCheckBox.Checked = false;
            TireRotationCheckBox.Checked = false;
        }
    }
}
