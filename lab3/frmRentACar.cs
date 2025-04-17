using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class frmRentACar : Form
    {
        private CarInventory carInventory;
        private CustomerInfo customerInfo= new CustomerInfo();
        private RentalTransaction transaction;
        private Car selectedCar;
        private int NumberOfDays;
        Car CarSelsctedInInventory;
        int carId;
        OleDbConnection myConnection;
        String strSQL;
        int selectedCarId;

        public frmRentACar(int carId)
        {
            InitializeComponent();
            this.carId = carId;

            /*this.carInventory = carInventory;
            CarSelsctedInInventory = car;*/
            LoadAvailableCars();
        }

        private void LoadAvailableCars()
        {
            myConnection = myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=Cars.accdb;"); ;
            strSQL = "SELECT * FROM Car WHERE Availability = True";
            OleDbCommand command = new OleDbCommand(strSQL, myConnection);
            myConnection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if(Convert.ToBoolean(reader["Availability"])== true)
                {
                    cmbRentCar.Items.Add(reader["Car ID"]);
                }
            }
            cmbRentCar.SelectedItem = carId;
                /*if (carInventory != null)
                {
                    foreach (var car in carInventory.cars)
                    {
                        if (car.CarAvailability == true)
                        {
                            cmbRentCar.Items.Add(car.CarID);
                        }
                    }
                }
                cmbRentCar.SelectedItem = CarSelsctedInInventory.CarID;*/

            }
        private void btnRentReceipt_Click(object sender, EventArgs e)
        {
            if (cmbRentCar.SelectedItem != null)
            {
                selectedCarId = int.Parse(cmbRentCar.SelectedItem.ToString());
                myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=Cars.accdb;");
                strSQL = "SELECT * FROM Car WHERE [Car ID] = @CarID";
                OleDbCommand command = new OleDbCommand(strSQL, myConnection);
                command.Parameters.AddWithValue("@CarID", selectedCarId);
                myConnection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                /*foreach (var car in carInventory.cars)
                {
                    if (selectedCarId == car.CarID){
                        selectedCar = car;
                    }*/
            }
                    customerInfo.Name = txtName.Text;
                    customerInfo.InsuranceInfo = txtInsuranceInfo.Text;
                    customerInfo.LicenseInfo = txtDriverLicense.Text;
                    customerInfo.ContactInfo = txtContactInfo.Text;
                    transaction = new RentalTransaction(carId);
                    transaction.Customer= customerInfo;
                    transaction.RentalLenght = int.Parse(txtNumberOfDays.Text);
                   //NumberOfDays = int.Parse(txtNumberOfDays.Text);
                    customerInfo.AddToCustomerTable(customerInfo);

                selectedCar = new Car();
                selectedCar.MarkAsRented(selectedCarId);
                frmRentReceipt frmRentReceipt = new frmRentReceipt(selectedCarId, customerInfo,transaction);
                frmRentReceipt.Show();
            }
            
           
            



        }

       
    }

