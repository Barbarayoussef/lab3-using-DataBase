using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class RentalTransaction
    {
       
        
        private CustomerInfo customer;
        private DateTime rentalDate = DateTime.Now;
        private int rentalLenght;
        private decimal subTotalCost;
        private decimal tax = 0.70m;
        private decimal total;
        OleDbConnection myConnection;
        private string strSQL;
        private int CarId;
        private decimal rentalCost;
       
        public RentalTransaction(int CarId)
        {
            this.CarId = CarId;
            
        }
        public CustomerInfo Customer { get { return customer; } set { customer = value; } }
        public int RentalLenght { get { return rentalLenght; } set { rentalLenght = value; } }

        
        public decimal Tax { get { return tax; } }
        public DateTime RentalDate { get { return rentalDate; } }

        public decimal CalculateSubTotalCost()
        {
            myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=Cars.accdb;");
            strSQL = "SELECT [Rental Cost] FROM Car WHERE [Car ID]=@CarID";
            OleDbCommand command = new OleDbCommand(strSQL, myConnection);
            command.Parameters.AddWithValue("@CarId", CarId);
            myConnection.Open();
            rentalCost= (decimal)command.ExecuteScalar();
            subTotalCost= rentalLenght * rentalCost;
            return subTotalCost;

        }
        public decimal CalculateTotalCost() {
            total = subTotalCost * tax;
            total += subTotalCost; 
            return total;
        }
        public void AddToRentalTable()
        {
            myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=Cars.accdb;");
            strSQL = "INSERT INTO Rental_Transaction (Customer_ID, Number_of_days, Date_Time, Car_ID, Cost_per_day, SubTotal, Total_Cost) " +
         "VALUES (@Customer_ID, @Number_of_days, @Date_Time, @Car_ID, @Cost_per_day, @SubTotal, @Total_Cost)";
            OleDbCommand command = new OleDbCommand(strSQL, myConnection);
            command.Parameters.AddWithValue("@Customer_ID",customer.GetCustomerID());
            command.Parameters.AddWithValue("@Number_of_days",rentalLenght);
            command.Parameters.AddWithValue("@Date_Time",rentalDate);
            command.Parameters.AddWithValue("@CarId", CarId);
            command.Parameters.AddWithValue("@Cost_per_day", rentalCost);
            command.Parameters.AddWithValue("@SubTotal", subTotalCost);
            command.Parameters.AddWithValue("@Total_Cost", total);
            myConnection.Open();
            command.ExecuteNonQuery();
        }
    }
}
