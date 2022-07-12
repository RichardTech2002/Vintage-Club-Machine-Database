﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using DatabaseProject;
using System.Configuration;


namespace User_Interface_For_Vintage_Club_Database
{
    public partial class Form2 : Form
    {
        DBAccess objDBAccess = new DBAccess();



        public Form2()
        {
            InitializeComponent();
        }



        public int Duh = 0;



        public void ShowMessageBox()
        {
            DialogResult msg = MessageBox.Show("There are empty fields! Would you like to continue?", "Empty Box", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            Duh = 0;

            if (msg == DialogResult.OK)
            {
                Duh = 0;
                MessageBoxDisplay.Text = "No";
            }
            if (msg == DialogResult.Cancel)
            {
                Duh = 0;
                IfFormEmpty();
            }
        }



        public void ColourReset()
        {
            label1.BackColor = Color.White;
            label8.BackColor = Color.White;
            label9.BackColor = Color.White;
            label10.BackColor = Color.White;
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            textBox5.BackColor = Color.White;
            textBox6.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
            comboBox2.BackColor = Color.White;
            comboBox3.BackColor = Color.White;
            pictureBox1.BackColor = Color.White;
            richTextBox1.BackColor = Color.White;
            richTextBox2.BackColor = Color.White;
            numericUpDown1.BackColor = Color.White;
        }



        public void BoxChecker()
        {
            if (textBox1.Text == "")
            {
                MessageBoxDisplay.Text = "Yes";
                Duh++;
            }
            if (textBox2.Text == "")
            {
                MessageBoxDisplay.Text = "Yes";
                Duh++;
            }
            if (textBox3.Text == "")
            {
                MessageBoxDisplay.Text = "Yes";
                Duh++;
            }
            if (textBox4.Text == "")
            {
                MessageBoxDisplay.Text = "Yes";
                Duh++;
            }
            if (comboBox1.Text == "")
            {
                MessageBoxDisplay.Text = "Yes";
                Duh++;
            }
            if (comboBox2.Text == "")
            {
                MessageBoxDisplay.Text = "Yes";
                Duh++;
            }
            if (comboBox3.Text == "")
            {
                MessageBoxDisplay.Text = "Yes";
                Duh++;
            }
            if (richTextBox1.Text == "")
            {
                MessageBoxDisplay.Text = "Yes";
                Duh++;
            }
            if (richTextBox2.Text == "")
            {
                MessageBoxDisplay.Text = "Yes";
                Duh++;
            }
            if (pictureBox1.Image == null)
            {
                MessageBoxDisplay.Text = "Yes";
                Duh++;
            }
            if (numericUpDown1.Text == "0")
            {
                MessageBoxDisplay.Text = "Yes";
                Duh++;
            }
            if (numericUpDown1.Text == "")
            {
                MessageBoxDisplay.Text = "Yes";
                Duh++;
            }
            if (textBox5.Text == "")
            {
                MessageBoxDisplay.Text = "Yes";
                Duh++;
            }
            if (textBox6.Text == "")
            {
                MessageBoxDisplay.Text = "Yes";
                Duh++;
            }
            if (Duh == 13)
            {
                DialogResult Blank = MessageBox.Show("You didn't even fill out any of the boxes, you old fool!","Empty Boxes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Blank == DialogResult.OK)
                {
                    Duh = 0;
                    ColourReset();
                }
            }
        }

        public void ClearBoxes()
        {
            MessageBoxDisplay.Text = "No";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            textBox1.SelectedItem = null;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            numericUpDown1.Text = "";
            pictureBox1.Image = null;
        }

        public void IfFormEmpty()
        {
            if (textBox1.Text == "")
            {
                label1.BackColor = Color.Red;
            }
            if (textBox2.Text == "")
            {
                textBox2.BackColor = Color.Red;
            }
            if (textBox3.Text == "")
            {
                textBox3.BackColor = Color.Red;
            }
            if (textBox4.Text == "")
            {
                textBox4.BackColor = Color.Red;
            }
            if (textBox5.Text == "")
            {
                textBox5.BackColor = Color.Red;
            }
            if (textBox6.Text == "")
            {
                textBox6.BackColor = Color.Red;
            }
            if (comboBox1.Text == "")
            {
                label8.BackColor = Color.Red;
            }
            if (comboBox2.Text == "")
            {
                label9.BackColor = Color.Red;
            }
            if (comboBox3.Text == "")
            {
                label10.BackColor = Color.Red;
            }
            if (richTextBox1.Text == "")
            {
                richTextBox1.BackColor = Color.Red;
            }
            if (richTextBox2.Text == "")
            {
                richTextBox2.BackColor = Color.Red;
            }
            if (numericUpDown1.Value == 0)
            {
                numericUpDown1.BackColor = Color.Red;
            }
            if (pictureBox1.Image == null)
            {
                pictureBox1.BackColor = Color.Red;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBoxDisplay.Text = "No";
            BoxChecker();

            if (MessageBoxDisplay.Text == "No")
            {
                string MachineType = textBox1.Text;
                decimal YearBuilt = numericUpDown1.Value;
                string OriginalOwner = textBox2.Text;
                string DateAcquired = textBox3.Text;
                string Description = richTextBox1.Text;
                string MaintainenceInformation = richTextBox2.Text;
                string RestorationStatus = comboBox1.Text;
                string MachineLocation = comboBox2.Text;
                string DonatedOrLoaned = comboBox3.Text;
                string LinkToTractorData = textBox4.Text;
                string Models = textBox5.Text;
                string Make = textBox6.Text;
                SqlCommand insertcommand = new SqlCommand("insert into General_Table(Machine_Type, Year_Built, Original_Owner, Date_Acquired, Description, Maintenence_Information, Machine_Location, Restoration_Status, Donated_Or_Loaned, Link_To_TractorData, Model, Make) values (@Machinetype, @YearBuilt, @OriginalOwner, @DateAcquired, @Description, @MaintenenceInformation, @MachineLocation, @RestorationStatus, @DonatedOrLoaned, @LinkToTractorData, @Model, @Make)");
                insertcommand.Parameters.AddWithValue("@MachineType", textBox1.Text);
                insertcommand.Parameters.AddWithValue("@YearBuilt", numericUpDown1.Value);
                insertcommand.Parameters.AddWithValue("@OriginalOwner", textBox2.Text);
                insertcommand.Parameters.AddWithValue("@DateAcquired", textBox3.Text);
                insertcommand.Parameters.AddWithValue("@Description", richTextBox1.Text);
                insertcommand.Parameters.AddWithValue("@MaintenenceInformation", richTextBox2.Text);
                insertcommand.Parameters.AddWithValue("@RestorationStatus", comboBox1.Text);
                insertcommand.Parameters.AddWithValue("@MachineLocation", comboBox2.Text);
                insertcommand.Parameters.AddWithValue("@DonatedOrLoaned", comboBox3.Text);
                insertcommand.Parameters.AddWithValue("@LinkToTractorData", textBox4.Text);
                insertcommand.Parameters.AddWithValue("@Model", textBox5.Text);
                insertcommand.Parameters.AddWithValue("@Make", textBox6.Text);

                int row = objDBAccess.executeQuery(insertcommand);

                if(row == 1)
                {
                    DialogResult Submit = MessageBox.Show("Information Submitted to the database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearBoxes();
                }
                else
                {
                    MessageBox.Show("Something went wrong. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            if (MessageBoxDisplay.Text == "Yes")
            {
                ShowMessageBox();
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ImageLocation = "";
            try
            {
                OpenFileDialog Dialog = new OpenFileDialog();
                Dialog.Filter = "All Files(*.*)|*.*| PNG files(*.png) |*.png|jpg files(*.jpg)|*.jpg";

                if (Dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ImageLocation = Dialog.FileName;
                    pictureBox1.ImageLocation = ImageLocation;
                }
            }
            catch
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ColourReset();
            string ImageLocation = "";
            try
            {
                OpenFileDialog Dialog = new OpenFileDialog();
                Dialog.Filter = "All Files(*.*)|*.*| PNG files(*.png) |*.png|jpg files(*.jpg)|*.jpg";

                if (Dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ImageLocation = Dialog.FileName;
                    pictureBox1.ImageLocation = ImageLocation;
                }
            }
            catch
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            ColourReset();
        }

        private void numericUpDown1_MouseClick(object sender, MouseEventArgs e)
        {
            ColourReset();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            ColourReset();
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            ColourReset();
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            ColourReset();
        }

        private void textBox4_MouseDown(object sender, MouseEventArgs e)
        {
            ColourReset();
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ColourReset();
        }

        private void richTextBox2_MouseClick(object sender, MouseEventArgs e)
        {
            ColourReset();
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            ColourReset();
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            ColourReset();
        }

        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
        {
            ColourReset();
        }

        private void textBox1_MouseHover_1(object sender, EventArgs e)
        {
            ColourReset();
        }

        private void comboBox1_MouseHover(object sender, EventArgs e)
        {
            ColourReset();
        }

        private void comboBox2_MouseHover(object sender, EventArgs e)
        {
            ColourReset();
        }

        private void comboBox3_MouseHover(object sender, EventArgs e)
        {
            ColourReset();
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            ColourReset();
        }
    }
}
