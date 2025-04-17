using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class CustomerInfo
    {
        private string name;
        private string contactInfo;
        private string licenseInfo;
        private string insuranceInfo;
        OleDbConnection myConnection;
        private string strSQL;
        private string getIdSQL;
        private int customerID;



        public string Name { get { return name; } set { name = value; } }
        public string ContactInfo { get { return contactInfo; } set { contactInfo = value; } }
        public string LicenseInfo { get { return licenseInfo; } set { licenseInfo = value; } }
        public string InsuranceInfo { get {return insuranceInfo; } set { insuranceInfo = value; } }

        public void AddToCustomerTable(CustomerInfo customerInfo)
        {
            myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=Cars.accdb;");
            strSQL = "INSERT INTO Customer (Name,Contact,Driver_license,Insurance)" +
                "VALUES (@Name,@Contact,@Driver_license,@Insurance)";
            OleDbCommand command = new OleDbCommand(strSQL, myConnection);
            command.Parameters.AddWithValue("@Name", customerInfo.Name);
            command.Parameters.AddWithValue("@Contact", customerInfo.ContactInfo);
            command.Parameters.AddWithValue("@Driver_license", customerInfo.LicenseInfo);
            command.Parameters.AddWithValue("@Insurance", customerInfo.InsuranceInfo);
            myConnection.Open();
            command.ExecuteNonQuery();
            getIdSQL = "SELECT @@IDENTITY";
            OleDbCommand command1= new OleDbCommand(getIdSQL, myConnection);
            customerID = (int)command1.ExecuteScalar();
        }
        public int GetCustomerID() { return customerID; }

    }
}
