using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace lab3
{
    public class CarInventory
    {
        public List<Car> cars { get; set; }
        OleDbConnection myConnection;
        string strSQL;
        OleDbDataAdapter myDataAdapter;
        DataSet carDataSet;
        DataTable carTable;
        int CarID;
        Car car =new Car();
        public CarInventory()
        {
            cars = new List<Car>();
        }
        public void AddCar(Car car)
        {
            myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=Cars.accdb;");
            strSQL = "INSERT INTO Car (Model, Manufacturer, Category, [Rental Cost], Availability,[Year], Millage, Description, Location, [Image URL]) " +
             "VALUES (@Model, @Manufacturer, @Category, @RentalCost, @Availability, @Year, @Millage, @Description, @Location, @ImageURL)";
           OleDbCommand command = new OleDbCommand(strSQL, myConnection);
            command.Parameters.AddWithValue("@Model", car.CarModel);
            command.Parameters.AddWithValue("@Manufacturer", car.CarManufactor);
            command.Parameters.AddWithValue("@Category", car.CarCategory);
            command.Parameters.AddWithValue("@RentalCost", car.CarRentalCost);
            command.Parameters.AddWithValue("@Availability", car.CarAvailability);
            command.Parameters.AddWithValue("@Year", car.CarYear);
            command.Parameters.AddWithValue("@Millage", car.CarMileage);
            command.Parameters.AddWithValue("@Description", car.CarDescription);
            command.Parameters.AddWithValue("@Location", car.CarLocation);
            command.Parameters.AddWithValue("@ImageURL", car.CarImageURL);
            myConnection.Open();
            command.ExecuteNonQuery();
        }

        public void DeleteCar(int CarId)
        {
            CarID = CarId;
            myConnection = myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=Cars.accdb;"); ;
            strSQL = "DELETE FROM Car WHERE [Car ID] = @CarID";
            OleDbCommand command = new OleDbCommand(strSQL, myConnection);
            command.Parameters.AddWithValue("@CarID", CarID);
            myConnection.Open();
            command.ExecuteNonQuery();
            

        }
        public DataTable LoadDataGridView()
        {
            myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=Cars.accdb;");
            strSQL = "SELECT [Car ID],Model,Manufacturer,Category,Year,Availability,[Rental Cost],Damages FROM Car";
            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);
            carDataSet = new DataSet("CarTable");
            myDataAdapter.Fill(carDataSet, "CarTable");

            carTable = carDataSet.Tables["CarTable"];
            return carTable;
        }
        public DataTable FindCarsByCategory(string category)
        {
            myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=Cars.accdb;");
            strSQL = "SELECT [Car ID],Model,Manufacturer,Category,Year,Availability,[Rental Cost],Damages FROM Car WHERE Availability=true AND Category =@category";
            OleDbCommand command = new OleDbCommand(strSQL, myConnection);
            command.Parameters.AddWithValue("@category", category);
            myDataAdapter = new OleDbDataAdapter(command);
            
            carDataSet = new DataSet("CarTable");
            myDataAdapter.Fill(carDataSet, "CarTable");

            carTable = carDataSet.Tables["CarTable"];
            return carTable;
        }

        public void UpdateCar(Car car)
        {
            this.car = car;
            myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=Cars.accdb;");
            strSQL = strSQL = "UPDATE Car SET Model=@Model, Manufacturer=@Manufacturer, Category=@Category, " +
             "[Rental Cost]=@RentalCost,[Year]=@Year, " +
             "Millage=@Millage, Description=@Description, Location=@Location, [Image URL]=@ImageURL, Damages=@Damages " +
             "WHERE [Car ID] = @CarID";
            OleDbCommand command = new OleDbCommand(strSQL, myConnection);
           
            command.Parameters.AddWithValue("@Model", car.CarModel);
            command.Parameters.AddWithValue("@Manufacturer", car.CarManufactor);
            command.Parameters.AddWithValue("@Category", car.CarCategory);
            command.Parameters.AddWithValue("@RentalCost", car.CarRentalCost);
            command.Parameters.AddWithValue("@Year", car.CarYear);
            command.Parameters.AddWithValue("@Millage", car.CarMileage);
            command.Parameters.AddWithValue("@Description", car.CarDescription);
            command.Parameters.AddWithValue("@Location", car.CarLocation);
            command.Parameters.AddWithValue("@ImageURL", car.CarImageURL);
            command.Parameters.AddWithValue("@Damages", car.Damages);
            command.Parameters.AddWithValue("@CarID", car.CarID);
            myConnection.Open();
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Car record updated successfully!");
            }
            else
            {
                MessageBox.Show("Car record update failed.");
            }


        }
        public Car GetCarDetails(int CarID) {
            myConnection = myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=Cars.accdb;"); ;
            strSQL = "SELECT * FROM Car WHERE [Car ID] = @CarID";
            OleDbCommand command = new OleDbCommand(strSQL, myConnection);
            command.Parameters.AddWithValue("@CarID", CarID);
            myConnection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                car.CarID = (int)reader["Car ID"];
                car.CarModel = (string)reader["Model"];
                car.CarManufactor = (string)reader["Manufacturer"];
                car.CarYear = (Int16)reader["Year"];
                car.CarCategory = (string)reader["Category"];
                car.CarRentalCost = (decimal)reader["Rental Cost"];
                car.CarAvailability = Convert.ToBoolean(reader["Availability"]) ? true : false;
                car.CarMileage = (string)reader["Millage"];
                car.CarDescription = (string)reader["Description"];
                car.CarLocation = (string)reader["Location"];
                car.CarImageURL=(string)reader["Image URL"];
                car.Damages = reader["Damages"] != DBNull.Value ? (string)reader["Damages"] : string.Empty;


            }
            return car;

        }
    }
       

    }

