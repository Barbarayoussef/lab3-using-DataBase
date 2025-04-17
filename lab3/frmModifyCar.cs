using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class frmModifyCar : Form
    {
        int CarId;
        Car car;
        CarInventory carInventory;
        public event EventHandler CarUpdated;

        public frmModifyCar(int carId)
        {
            InitializeComponent();
            CarId = carId;
            lblCarId.Text= carId.ToString();
        }

        private void frmModifyCar_Load(object sender, EventArgs e)
        {
            car= new Car();
            carInventory = new CarInventory();
            car=carInventory.GetCarDetails(CarId);
            cmbCarCategory.SelectedItem = car.CarCategory.ToString();
            txtCarModel.Text = car.CarModel.ToString();
            txtCarManufacturer.Text = car.CarManufactor.ToString();
            txtCarYear.Text= car.CarYear.ToString();
            txtCarMileage.Text = car.CarMileage.ToString();
            txtCost.Text=car.CarRentalCost.ToString();
            txtCarDescription.Text=car.CarDescription.ToString();
            txtCarLocation.Text=car.CarLocation.ToString();
            txtCarDamages.Text=car.Damages.ToString();
            txtImageURL.Text=car.CarImageURL.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Car car = new Car();
            car.CarID = CarId;
            car.CarCategory = cmbCarCategory.SelectedItem.ToString();
            car.CarModel = txtCarModel.Text;
            car.CarManufactor = txtCarManufacturer.Text;
            car.CarYear = int.Parse(txtCarYear.Text);
            car.CarMileage = txtCarMileage.Text;
            car.CarRentalCost = Decimal.Parse(txtCost.Text);
            car.CarDescription = txtCarDescription.Text;
            car.CarLocation = txtCarLocation.Text;
            car.Damages = txtCarDamages.Text;
            car.CarImageURL = txtImageURL.Text;

            carInventory.UpdateCar(car);
            CarUpdated?.Invoke(this, EventArgs.Empty);



        }
    }
}
