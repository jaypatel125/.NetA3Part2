/*
Author: Jay Patel, 000881881
Date: 28/10/2023
Purpose: Lab 3 Part B
I, Jay Patel, 000881881, certify that this material is my original work.  No other person's work has been used without due acknowledgement.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3B
{
    /// <summary>
    /// The main form of the application.
    /// </summary>
    public partial class Form1 : Form
    {
        private bool hairdresserAdded = false;
        private int totalPrice = 0;
        int hairDresserPrice;
        List<int> total = new List<int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the form.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Disable Add Service and Calculate Total Price Buttons on form load
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the "Add Service" button.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            // Check if a hairdresser is selected
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a hairdresser.");
                return;
            }

             bool addServiceUsed = false;

            // Enable Calculate Total Price Button only if Add Service Button is used for the first time
            button2.Enabled = !addServiceUsed;

            // Set the bool to true if Add Service Button is used
            addServiceUsed = true;

            // Get the selected hairdresser
            string selectedHairdresser = comboBox1.SelectedItem.ToString();

            // Get the selected services
            List<string> selectedServices = new List<string>();
            foreach (var selectedItem in listBox1.SelectedItems)
            {
                selectedServices.Add(selectedItem.ToString());
            }

            // Set the price based on the selected hairdresser
            if (comboBox1.SelectedIndex == 0) {
                comboBox1.Enabled = false;
                hairDresserPrice = 30;

            } else if(comboBox1.SelectedIndex == 1)
            {
                comboBox1.Enabled = false;
                hairDresserPrice = 45;
            } else if (comboBox1.SelectedIndex == 2)
            {comboBox1.Enabled = false;
                hairDresserPrice = 40;
            } else if (comboBox1.SelectedIndex == 3)
            {comboBox1.Enabled = false;
                hairDresserPrice = 50;
            } else
            {comboBox1.Enabled = false;
                hairDresserPrice = 55;
            }

            // Add the selected hairdresser if it hasn't been added before
            if (!hairdresserAdded)
            {
                listBox2.Items.Add($"{comboBox1.SelectedItem.ToString()}");
                listBox3.Items.Add($"${hairDresserPrice}");
                hairdresserAdded = true;
            }


            int servicePrice = 0;
            

            foreach (var selectedItemIndex in listBox1.SelectedIndices)
            {
                // Use the index to calculate the service price
                switch (selectedItemIndex)
                {
                    case 0:
                        servicePrice = 30;
                        total.Add(servicePrice);
                        break;
                    case 1:
                        servicePrice = 20;
                        total.Add(servicePrice);
                        break;
                    case 2:
                        servicePrice = 40;
                        total.Add(servicePrice);
                        break;
                    case 3:
                        servicePrice = 50;
                        total.Add(servicePrice);
                        break;
                    case 4:
                        servicePrice = 200;
                        total.Add(servicePrice);
                        break;
                    case 5:
                        servicePrice = 60;
                        total.Add(servicePrice);
                        break;
                }
                Console.WriteLine(servicePrice);
            }
            


            // Display the selected hairdresser, services, and total price in the ListBox         
            foreach (var service in selectedServices)
            {
                listBox2.Items.Add(service);
                listBox2.Enabled = false;
                listBox3.Enabled = false;
            }



            // Add the service price to the ListBox
            listBox3.Items.Add($"${servicePrice}");
            

        }

        /// <summary>
        /// Handles the Click event of the "Calculate Total Price" button.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            // Calculate and display the total price
            int count = 0;
            foreach (int i in total)
            {
                count += i;
                Console.WriteLine(count);
            }

            totalPrice = hairDresserPrice + count;
            textBox1.Text = "$"+totalPrice.ToString();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the services ListBox.
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            // Check if at least one service is selected
            if (listBox1.SelectedIndex != -1)
            {
                button1.Enabled=true;
                return;
            } 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the "Reset" button.
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            // Reset hairdresser selection
            comboBox1.SelectedIndex = 0;

            // Clear charged items and prices ListBox
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            // Clear total price label
            textBox1.Clear();

            // Disable Add Service and Calculate Total Price Buttons
            button1.Enabled = false;
            button2.Enabled = false;

            // Enable hairdresser selection
            comboBox1.Enabled = true;

            // Reset the flag to indicate that no hairdresser has been added
            hairdresserAdded = false;

            // Set focus to the Hairdresser ComboBox
            comboBox1.Focus();
        }

        /// <summary>
        /// Handles the Click event of the "Exit" button.
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            // Exit the application
            Application.Exit();
        }
    }
}
