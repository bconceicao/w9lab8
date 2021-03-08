using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Week5_PersonClassinWindows;
using System.Data;
using System.Data.SqlClient;

namespace Midterm245
{
    class PersonV2 : Person
    {
        private string instagramURL;
        private string cellphone;
        private int personID;

        public string InstagramURL
        {
            get
            {
                return instagramURL;
            }

            set
            {
                instagramURL = value;
            }
        }

        public string Cellphone
        {
            get
            {
                return cellphone;
            }

            set
            {
                if (value.Length == 10)
                {
                    cellphone = value;
                }
                else
                {
                    feedback += "\nERROR: Cellphone number must be entered as 10 digit number.";
                }

                int intStr; bool intResultTryParse = int.TryParse(value, out intStr);
                if (intResultTryParse == true)
                {
                    cellphone = value;
                }
                else
                {
                    feedback += "\nERROR: Cellphone Number must be xxxxxxxxxx format.";
                }
            }
        }

        public int PersonID
        {
            get
            {
                return personID;
            }

            set
            {
                personID = value;
            }
        }

        public string AddARecord()
        {
            //Init string var
            string strResult = "";

            //Make a connection object
            SqlConnection Conn = new SqlConnection();

            //Initialize it's properties
            Conn.ConnectionString = @"Server=sql.neit.edu\sqlstudentserver,4500;Database=SE245_BConceicao;User Id=SE245_BConceicao;Password=008009391";     //Set the Who/What/Where of DB


            //*******************************************************************************************************
            // NEW
            //*******************************************************************************************************
            string strSQL = "INSERT INTO Persons (FirstName, MiddleName, LastName, Street1, Street2, City, State, ZipCode, Phone, CellPhone, Email, InstagramURL) VALUES (@FirstName, @MiddleName, @LastName,@Street1, @Street2, @City, @State, @ZipCode, @Phone , @Cellphone, @Email, @InstagramURL)";
            // Bark out our command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //Commander knows what to say
            comm.Connection = Conn;     //Where's the phone?  Here it is

            //Fill in the paramters (Has to be created in same sequence as they are used in SQL Statement)
            comm.Parameters.AddWithValue("@FirstName", FName);
            comm.Parameters.AddWithValue("@MiddleName", MName);
            comm.Parameters.AddWithValue("@LastName", LName);
            comm.Parameters.AddWithValue("@Street1", Street1);
            comm.Parameters.AddWithValue("@Street2", Street2);
            comm.Parameters.AddWithValue("@City", City);
            comm.Parameters.AddWithValue("@State", State);
            comm.Parameters.AddWithValue("@ZipCode", Zip);
            comm.Parameters.AddWithValue("@Phone", Phone);
            comm.Parameters.AddWithValue("@CellPhone", Cellphone);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@InstagramURL", InstagramURL);
            

            //*******************************************************************************************************





            //attempt to connect to the server
            try
            {
                Conn.Open();                                        //Open connection to DB - Think of dialing a friend on phone
                int intRecs = comm.ExecuteNonQuery();
                strResult = $"SUCCESS: Inserted {intRecs} records.";       //Report that we made the connection and added a record
                Conn.Close();                                       //Hanging up after phone call
            }
            catch (Exception err)                                   //If we got here, there was a problem connecting to DB
            {
                strResult = "ERROR: " + err.Message;                //Set feedback to state there was an error & error info
            }
            finally
            {

            }



            //Return resulting feedback string
            return strResult;
        }

        public DataSet SearchPersonV2(String strFName, String strLName)
        {

            DataSet ds = new DataSet();

            SqlCommand comm = new SqlCommand();

            String strSQL = "SELECT PersonID, FirstName, LastName FROM Persons WHERE 0=0";

            //If the First/Last Name is filled in include it as search criteria
            if (strFName.Length > 0)
            {
                strSQL += " AND FirstName LIKE @FirstName";
                comm.Parameters.AddWithValue("@FirstName", "%" + strFName + "%");
            }
            if (strLName.Length > 0)
            {
                strSQL += " AND LastName LIKE @LastName";
                comm.Parameters.AddWithValue("@LastName", "%" + strLName + "%");
            }


            //Make a connection object
            SqlConnection conn = new SqlConnection();

            
            conn.ConnectionString = @"Server=sql.neit.edu\sqlstudentserver,4500;Database=SE245_BConceicao;User Id=SE245_BConceicao;Password=008009391";     //Set the Who/What/Where 
            
            
            comm.CommandText = strSQL;  //Commander knows what to say
            comm.Connection = conn;

            //Create Data Adapter
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;


            //Get Data
            conn.Open();                //Open the connection (pick up the phone)
            da.Fill(ds, "PersonV2_Temp");     //Fill the dataset with results from database and call it "EBooks_Temp"
            conn.Close();               //Close the connection (hangs up phone)

            //Return the data
            return ds;


        }

        public SqlDataReader FindOnePerson(int intPersonID)
        {
            //Create and Initialize the DB Tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //My Connection String
            string strConn = GetConnected();

            //My SQL command string to pull up one Person's data
            string sqlString =
           "SELECT * FROM Persons WHERE PersonID = @PersonID;";

            //Tell the connection object the who, what, where, how
            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@PersonID", intPersonID);

            //Open the DataBase Connection and Yell our SQL Command
            conn.Open();

            //Return some form of feedback
            return comm.ExecuteReader();   //Return the dataset to be used by others (the calling form)

        }

        public string DeleteOnePerson(int intPersonID)
        {
            Int32 intRecords = 0;
            string strResult = "";

            //Create and Initialize the DB Tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //My Connection String
            string strConn = GetConnected();

            //My SQL command string to pull up one EBook's data
            string sqlString =
           "DELETE FROM Persons WHERE PersonID = @PersonID;";

            //Tell the connection object the who, what, where, how
            conn.ConnectionString = strConn;

            //Give the command object info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@PersonID", intPersonID);

            try
            {
                //Open the connection
                conn.Open();

                //Run the Delete and store the number of records effected
                intRecords = comm.ExecuteNonQuery();
                strResult = intRecords.ToString() + " Records Deleted.";
            }
            catch (Exception err)
            {
                strResult = "ERROR: " + err.Message;                //Set feedback to state there was an error & error info
            }
            finally
            {
                //close the connection
                conn.Close();
            }

            return strResult;


        }

        public string UpdateARecord()
        {
            Int32 intRecords = 0;
            string strResult = "";

            string strSQL = "INSERT INTO Persons (FirstName, MiddleName, LastName, Street1, Street2, City, State, ZipCode, Phone, CellPhone, Email, InstagramURL) VALUES (@FirstName, @MiddleName, @LastName,@Street1, @Street2, @City, @State, @ZipCode, @Phone , @Cellphone, @Email, @InstagramURL) WHERE PersonID = @PersonID;)";

            SqlConnection conn = new SqlConnection();
            string strConn = GetConnected();
            conn.ConnectionString = strConn;

            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;

            comm.Connection = conn;

            comm.Parameters.AddWithValue("@FirstName", FName);
            comm.Parameters.AddWithValue("@MiddleName", MName);
            comm.Parameters.AddWithValue("@LastName", LName);
            comm.Parameters.AddWithValue("@Street1", Street1);
            comm.Parameters.AddWithValue("@Street2", Street2);
            comm.Parameters.AddWithValue("@City", City);
            comm.Parameters.AddWithValue("@State", State);
            comm.Parameters.AddWithValue("@ZipCode", Zip);
            comm.Parameters.AddWithValue("@Phone", Phone);
            comm.Parameters.AddWithValue("@CellPhone", Cellphone);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@InstagramURL", InstagramURL);
            comm.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                conn.Open();                                        //Open connection to DB - Think of dialing a friend on phone
                int intRecs = comm.ExecuteNonQuery();
                strResult = $"SUCCESS: Inserted {intRecords} records.";       //Report that we made the connection and added a record
                conn.Close();                                       //Hanging up after phone call
            }
            catch (Exception err)                                   //If we got here, there was a problem connecting to DB
            {
                strResult = "ERROR: " + err.Message;                //Set feedback to state there was an error & error info
            }
            finally
            {

            }



            //Return resulting feedback string
            return strResult;

        }


        private string GetConnected()
        {
            return "Server=sql.neit.edu\\sqlstudentserver,4500;Database=SE245_BConceicao;User Id=SE245_BConceicao;Password=008009391";
        }

        public PersonV2() : base()  //Calls the parents constructor
        {
            cellphone = "";
            instagramURL = "";
        }



    }
}
