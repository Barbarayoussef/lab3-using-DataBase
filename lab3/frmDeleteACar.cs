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
    public partial class frmDeleteACar : Form
    {
        OleDbConnection myConnection;
        OleDbDataAdapter myDataAdapter;
        DataSet carDataSet;
        DataTable carTable;
        String strSQL;
        CarInventory carInventory;
        public frmDeleteACar(CarInventory carInventory)
        {
            InitializeComponent();
            this.carInventory = carInventory;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string selectedCategory = cmbCarCategory.SelectedItem.ToString();
            dgvCars.DataSource = carInventory.FindCarsByCategory(selectedCategory);
        }

        private void frmDeleteACar_Load(object sender, EventArgs e)
        {
            dgvCars.DataSource=carInventory.LoadDataGridView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count > 0)
            {
                int carId = Convert.ToInt32(dgvCars.SelectedRows[0].Cells["Car ID"].Value);
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this car?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                   carInventory.DeleteCar(carId);
                    dgvCars.Rows.RemoveAt(dgvCars.SelectedRows[0].Index);
                    dgvCars.Refresh();
                }
            }
        }
    }
}
