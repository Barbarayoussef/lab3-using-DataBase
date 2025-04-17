using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class frmCarInventory : Form
    {
        CarInventory inventory;
        Car selctedCar;
        int carId;

        OleDbConnection myConnection;
        OleDbDataAdapter myDataAdapter;
        DataSet carDataSet;
        DataTable carTable;
        String strSQL;
        public frmCarInventory(CarInventory carInventory)
        {
            InitializeComponent();
            inventory = carInventory;


        }

        private void frmCarInventory_Load(object sender, EventArgs e)
        {
            dgvCars.DataSource = inventory.LoadDataGridView();

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string selectedCategory = cmbCarCategory.SelectedItem.ToString();
            dgvCars.DataSource = inventory.FindCarsByCategory(selectedCategory);

           
        }

       
        private void DisplayCarDetails(Car car)
        {
            lblCarId.Text = selctedCar.CarID.ToString();
            lblYear.Text = selctedCar.CarYear.ToString();
            lblManufacturer.Text = selctedCar.CarManufactor.ToString();
            lblModel.Text = selctedCar.CarModel.ToString();
            lblCategory.Text = selctedCar.CarCategory.ToString();
            lblRentalCost.Text = selctedCar.CarRentalCost.ToString();
            lblAvailability.Text = Convert.ToBoolean(selctedCar.CarAvailability) ? "Available" : "Rented";
            lblDescription.Text = selctedCar.CarDescription.ToString();
            lblLocation.Text = selctedCar.CarLocation.ToString();
            lblCarMilage.Text = selctedCar.CarMileage.ToString();
            lblDamages.Text = string.IsNullOrWhiteSpace(selctedCar.Damages) ? "None" : selctedCar.Damages;
            pictureBoxCar.Load(selctedCar.CarImageURL.ToString());

            panelDetails.Visible = true;
        }

        private void btnRentCar_Click(object sender, EventArgs e)
        {
            frmRentACar frmRentACar = new frmRentACar(carId);
            frmRentACar.Show();
        }

        private void dgvCars_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dgvCars.SelectedRows[0];
                carId = int.Parse(selectedRow.Cells[0].Value.ToString());
                selctedCar = inventory.GetCarDetails(carId);
                DisplayCarDetails(selctedCar);
               
               

            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count > 0)
            {
                int carId = Convert.ToInt32(dgvCars.SelectedRows[0].Cells["Car ID"].Value);
                frmModifyCar frmModifyCar = new frmModifyCar(carId);
                frmModifyCar.CarUpdated += FrmModifyCar_CarUpdated;
                frmModifyCar.Show();
                panelDetails.Visible = false;

            }
        }
        private void FrmModifyCar_CarUpdated(object sender, EventArgs e)
        {
            RefreshCarDataGridView();
            
        }
        private void RefreshCarDataGridView()
        {
            dgvCars.DataSource = inventory.LoadDataGridView();

        }
    }
}
