using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Week5_PersonClassinWindows;

namespace Midterm245
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnDelete.Enabled = false;
            btnDelete.Visible = false;
            btnUpdate.Enabled = false;
            btnUpdate.Visible = false;
            
        }


        public Form1(int intPersonID)
        {
            InitializeComponent();  //Creates and init's all form objects

            button1.Enabled = false;
            button1.Visible = false;

            //Gather info about this one person and store it in a datareader
            PersonV2 temp = new PersonV2();
            SqlDataReader dr = temp.FindOnePerson(intPersonID);

            //Use that info to fill out the form
            //Loop thru the records stored in the reader 1 record at a time
            // Note that since this is based on one person's ID, then we
            //  should only have one record
            while (dr.Read())
            {
                //Take the Name(s) from the datareader and copy them
                // into the appropriate text fields
                textFName.Text = dr["FirstName"].ToString();
                textMName.Text = dr["MiddleName"].ToString();
                textLName.Text = dr["LastName"].ToString();
                textStreet1.Text = dr["Street1"].ToString();
                textStreet2.Text = dr["Street2"].ToString();
                textCity.Text = dr["City"].ToString();
                textState.Text = dr["State"].ToString();
                textZipCode.Text = dr["ZipCode"].ToString();
                textPhone.Text = dr["Phone"].ToString();
                textCellphone.Text = dr["CellPhone"].ToString();
                textEmail.Text = dr["Email"].ToString();
                textInstagramURL.Text = dr["InstagramURL"].ToString();
                lblPersonID.Text = dr["PersonID"].ToString();


            }

        }


            private void button1_Click(object sender, EventArgs e)
        {

            lblFeedback.Text = "";
            PersonV2 temp = new PersonV2();
            


            temp.FName = textFName.Text;
            temp.MName = textMName.Text;
            temp.LName = textLName.Text;
            temp.Street1 = textStreet1.Text;
            temp.Street2 = textStreet2.Text;
            temp.City = textCity.Text;
            temp.State = textState.Text;
            temp.Zip = textZipCode.Text;
            temp.Email = textEmail.Text;
            temp.Phone = textPhone.Text;
            temp.InstagramURL = textInstagramURL.Text;
            temp.Cellphone = textCellphone.Text;
            



            //lblFeedback.Text = temp.AddARecord();

            if (temp.Feedback.Length == 0 )
            {
                lblFeedback.Text = temp.AddARecord();   //if no errors weh setting values, then perform the insertion into db
            }
            else
            {
                lblFeedback.Text = temp.Feedback;       //else...dispay the error msg
            }



        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            lblFeedback.Text = "";
            PersonV2 temp = new PersonV2();



            temp.FName = textFName.Text;
            temp.MName = textMName.Text;
            temp.LName = textLName.Text;
            temp.Street1 = textStreet1.Text;
            temp.Street2 = textStreet2.Text;
            temp.City = textCity.Text;
            temp.State = textState.Text;
            temp.Zip = textZipCode.Text;
            temp.Email = textEmail.Text;
            temp.Phone = textPhone.Text;
            temp.InstagramURL = textInstagramURL.Text;
            temp.Cellphone = textCellphone.Text;




            //lblFeedback.Text = temp.AddARecord();

            if (temp.Feedback.Length == 0)
            {
                lblFeedback.Text = temp.AddARecord();   //if no errors weh setting values, then perform the insertion into db
            }
            else
            {
                lblFeedback.Text = temp.Feedback;       //else...dispay the error msg
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 intPerson_ID = Convert.ToInt32(lblPersonID.Text);  //Get the ID from the Label

            //Create a EBook so we can use the delete method
            PersonV2 temp = new PersonV2();

            //Use the EBook ID and pass it to the delete function
            // and get the number of records deleted
            lblFeedback.Text = temp.DeleteOnePerson(intPerson_ID);

        }
    }
   
}
