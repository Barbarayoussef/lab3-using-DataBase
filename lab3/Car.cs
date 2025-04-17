using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace lab3
{
    public class Car
    {

        private string carCategory;
        private string carManufactor;
        private string carModel;
        private int carYear;
        private string carMileage;
        private decimal carRentalCost;
        private bool carAvailability = true;
        private string carDescription;
        private string carLocation;
        private string carImageURL;
        private int CarId;
        private string damages;
        public int CarID { get;  set; }
        

        OleDbConnection myConnection;
        string strSQL;

        public Car()
        {
            
        }
        public string CarCategory { get { return carCategory; } set { carCategory = value; } }
        public string CarManufactor { get { return carManufactor; } set { carManufactor = value; } }
        public string CarModel { get { return carModel; } set { carModel = value; } }
        public int CarYear { get { return carYear; } set { carYear = value; } }
        public string CarMileage { get { return carMileage; } set { carMileage = value; } }
        public decimal CarRentalCost { get { return carRentalCost; } set { carRentalCost = value; } }
        public bool CarAvailability { get { return carAvailability; } set { carAvailability = value; } }
        public string CarDescription { get { return carDescription; } set { carDescription = value; } }
        public string CarLocation { get { return carLocation; } set { carLocation = value; } }
        public string CarImageURL { get { return carImageURL; } set { carImageURL = value; } }
        public string Damages { get { return damages; } set { damages = value; } }

        public void MarkAsRented( int CarId)
        {
            this.CarId = CarId;
            myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=Cars.accdb;");
            strSQL = "UPDATE Car SET Availability = false WHERE [Car ID] = @CarID";
            OleDbCommand command = new OleDbCommand(strSQL, myConnection);
            command.Parameters.AddWithValue("@CarID", CarId);
            myConnection.Open();
            command.ExecuteNonQuery();
        }
    


        public void MarkAsAvailable(int CarId)
        {
            this.CarId = CarId;
            myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=Cars.accdb;");
            strSQL = "UPDATE Car SET Availability = true WHERE [Car ID] = @CarID";
            OleDbCommand command = new OleDbCommand(strSQL, myConnection);
            command.Parameters.AddWithValue("@CarID", CarId);
            myConnection.Open();
            command.ExecuteNonQuery();
        }

        public void UpdateDamages(int CarId,string damages)
        {
            this.CarId = CarId;
            this.damages = damages;
            myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=Cars.accdb;");
            strSQL = "UPDATE Car SET Damages = @Damages WHERE [Car ID] = @CarID";
            OleDbCommand command = new OleDbCommand(strSQL, myConnection);
            command.Parameters.AddWithValue("@Damages", damages);
            command.Parameters.AddWithValue("@CarID", CarId);
            myConnection.Open();
            command.ExecuteNonQuery();
        }
    }
    
   

    }





