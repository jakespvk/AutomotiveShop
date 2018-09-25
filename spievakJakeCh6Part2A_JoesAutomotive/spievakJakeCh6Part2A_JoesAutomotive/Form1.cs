using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spievakJakeCh6Part2A_JoesAutomotive
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        const int OIL_CHANGE = 26;
        const int LUBE_JOB = 18;
        const int RADIATOR_FLUSH = 30;
        const int TRANNY_FLUSH = 80;
        const int INSPECTION = 15;
        const int MUFFLER_REPLACE = 100;
        const int TIRE_ROTATION = 20;
        const int HOURLY_RATE = 20;

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateIntInput(string input)
        {
            bool flag = true;

            try
            {
                int output = int.Parse(input);
            }
            catch
            {
                flag = false;
                
            }
            
            // ???? Maybe instead just write a validate method for the checkboxes and a separate one for the
            // textboxes and then pass each item to the method? That will probably be just as long code wise?
            // Idk, something to consider. ????

            return flag;
        }

        private bool CheckBoxChecked(CheckBox x)
        {
            if (x.Checked)
            {
                return true;
            }
            return false;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            //Take the information from the form 
            //Validate it
            //And write it to the listbox in table format

            //Use form 
            /* 
             * outputlistbox.items.add(item1 + "/t" + item2 + "/t" + item3);
             * 
             * to write in table format in the listbox.
             */

            if (ValidateIntInput(carYearTBox.Text) && ValidateIntInput(mileageTBox.Text))
            {
                if (customerNameTBox.Text != "" && carYearTBox.Text != "" && carMakeTBox.Text != "" && carModelTBox.Text != "" &&
                    carColorTBox.Text != "" && licenseNumberTBox.Text != "" && mileageTBox.Text != "")
                {
                    if (oilChangeCheckBox.Checked || lubeJobCheckBox.Checked || radiatorFlushCheckBox.Checked || trannyFlushCheckBox.Checked
                    || inspectionCheckBox.Checked || mufflerCheckBox.Checked || tireRotationCheckBox.Checked || otherServiceCheckBox.Checked)
                    {
                        outputListBox.Items.Add(serviceDatePicker.Text);
                        outputListBox.Items.Add(customerNameTBox.Text);
                        outputListBox.Items.Add(carYearTBox.Text + " " + carMakeTBox.Text + " " + carModelTBox.Text + ", " + carColorTBox.Text);
                        outputListBox.Items.Add("License Plate: " + licenseNumberTBox.Text);
                        outputListBox.Items.Add("Mileage: " + mileageTBox.Text);
                        outputListBox.Items.Add("___________________________________________________________________________");
                        outputListBox.Items.Add("\n");
                        outputListBox.Items.Add("Service Rendered" + "\t" + "\t" + "\t" + "Cost" + "\t" + "\t" + "\t" + "Labor");
                        outputListBox.Items.Add("\n");


                        if (CheckBoxChecked(oilChangeCheckBox))
                        {
                            outputListBox.Items.Add("Oil Change" + "\t" + "\t" + "\t" + OIL_CHANGE.ToString("c") + " + " + (.5 * HOURLY_RATE).ToString("c") + "(Labor)"
                                + "\t" + "0.5 hours");
                        }
                        if (CheckBoxChecked(lubeJobCheckBox))
                        {

                        }
                        if (CheckBoxChecked(radiatorFlushCheckBox))
                        {

                        }
                        if (CheckBoxChecked(trannyFlushCheckBox))
                        {

                        }
                        if (CheckBoxChecked(inspectionCheckBox))
                        {

                        }
                        if (CheckBoxChecked(mufflerCheckBox))
                        {

                        }
                        if (CheckBoxChecked(tireRotationCheckBox))
                        {

                        }
                        if (CheckBoxChecked(otherServiceCheckBox))
                        {

                        }

                        outputListBox.Items.Add("\n");
                        outputListBox.Items.Add("___________________________________________________________________________");
                        outputListBox.Items.Add("\n");
                        outputListBox.Items.Add("Other" + "\t" + "\t" + "\t" + "Cost" + "\t" + "\t" + "\t" + "Notes/Description");
                        outputListBox.Items.Add("Parts" + "\t" + "\t" + "\t" + extraPartsPriceTBox.Text);
                        outputListBox.Items.Add("Labor" + "\t" + "\t" + "\t" + ConvertBoolToInt(ValidateIntInput(otherServiceNumHrsTBox.Text), otherServiceNumHrsTBox.Text)
                            + "\t" + "\t" + "\t" + notesRichTBox.Text);

                    }
                    else
                    {
                        MessageBox.Show("Please choose one of the services listed.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter values for each of the fields.");
                }
            }
            else
            {
                MessageBox.Show("Please enter only numerical values.");
            }


        }

        private int ConvertBoolToInt (bool flag, string string1)
        {
            int x = 0;

            if (flag)
            {
                x = int.Parse(string1);
            }

            return x;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            //Clear the left side of form (services)
            oilChangeCheckBox.Checked = false;
            lubeJobCheckBox.Checked = false;
            radiatorFlushCheckBox.Checked = false;
            trannyFlushCheckBox.Checked = false;
            inspectionCheckBox.Checked = false;
            mufflerCheckBox.Checked = false;
            tireRotationCheckBox.Checked = false;
            otherServiceCheckBox.Checked = false;
            otherServiceNumHrsTBox.Clear();
            extraPartsCheckBox.Checked = false;
            extraPartsPriceTBox.Clear();

            //Clear the vehicle info (top right)
            customerNameTBox.Clear();
            serviceDatePicker.ResetText();
            carYearTBox.Clear();
            carMakeTBox.Clear();
            carModelTBox.Clear();
            carColorTBox.Clear();
            licenseNumberTBox.Clear();
            mileageTBox.Clear();
            notesRichTBox.Clear();

            //Clear the output listbox
            outputListBox.Items.Clear();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }

    
}
