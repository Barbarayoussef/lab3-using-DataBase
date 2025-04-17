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
    public partial class frmReturnCar : Form
    {
        CarInventory carInventory;
        OleDbConnection myConnection;
        String strSQL;
        string damages;
        public frmReturnCar(CarInventory carInventory)
        {
            InitializeComponent();
            this.carInventory = carInventory;
            //carInventory.cars = carInventory.LoadCarInventory();
        }

        private void frmReturnCar_Load(object sender, EventArgs e)
        {
            PopulateRentedCarsComboBox();
        }

        private void btnReturnSuccess_Click(object sender, EventArgs e)
        {
            if (cmbReturnedCar.SelectedItem != null)
            {

                int selectedCarId = (int)cmbReturnedCar.SelectedItem;
                Car car = new Car();
                car.Damages=txtDamages.Text;
                car.UpdateDamages(selectedCarId, car.Damages);
                car.MarkAsAvailable(selectedCarId);
                PopulateRentedCarsComboBox();
                ClearCarDetails();

                
            }
            
        }
        private void PopulateRentedCarsComboBox()
        {
            cmbReturnedCar.Items.Clear(); // Clear in case of reloading
            myConnection = myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=Cars.accdb;"); ;
            strSQL = "SELECT * FROM Car WHERE Availability = False";
            OleDbCommand command = new OleDbCommand(strSQL, myConnection);
            myConnection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (Convert.ToBoolean(reader["Availability"]) == false)
                {
                    cmbReturnedCar.Items.Add(reader["Car ID"]);
                }
            }
            /*foreach (Car car in carInventory.cars)
            {
                if (!car.CarAvailability) // Only show rented cars
                {
                    cmbReturnedCar.Items.Add(car.CarID);
                }
            }*/
        }

        private void ClearCarDetails() { 
            cmbReturnedCar.Items.Clear();
            cmbReturnedCar.SelectedItem = null;
            txtDamages.Text= string.Empty;
            txtUpdatedMileage.Text= string.Empty;
        }


    }
    }

