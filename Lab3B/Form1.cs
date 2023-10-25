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
    public partial class Form1 : Form
    {
        private bool hairdresserAdded = false;
        private int totalPrice = 0;
        int hairDresserPrice;
        List<int> total = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


       
        private void button1_Click(object sender, EventArgs e)
        {
            // Check if a hairdresser is selected
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a hairdresser.");
                return;
            }

            

            // Get the selected hairdresser
            string selectedHairdresser = comboBox1.SelectedItem.ToString();

            // Get the selected services
            List<string> selectedServices = new List<string>();
            foreach (var selectedItem in listBox1.SelectedItems)
            {
                selectedServices.Add(selectedItem.ToString());
            }

            
            if(comboBox1.SelectedIndex == 0) {
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



            //double totalPrice;
            listBox3.Items.Add($"${servicePrice}");
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (int i in total)
            {
                count += i;
                Console.WriteLine(count);
            }

            totalPrice = hairDresserPrice + count;
            textBox1.Text = "$"+totalPrice.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            // Check if at least one service is selected
            if (listBox1.SelectedIndex != -1)
            {
                button1.Enabled=true;
                button2.Enabled=true;
                return;
            } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;

        }
    }
}
