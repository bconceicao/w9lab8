using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Midterm245
{
    public partial class SearchPeople : Form
    {
        public SearchPeople()
        {
            InitializeComponent();
        }

        private void btnSearchBooks_Click(object sender, EventArgs e)
        {
            PersonV2 temp = new PersonV2();

            DataSet ds = temp.SearchPersonV2(textFname.Text, textLname.Text);

            dgvResults.DataSource = ds;
            dgvResults.DataMember = ds.Tables["PersonV2_Temp"].ToString();

        }

        private void dgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Gather the information (Gathers the row clicked, then chooses the first cell's data
            string strPersonID = dgvResults.Rows[e.RowIndex].Cells[0].Value.ToString();

            //Display data in Pop-up
            MessageBox.Show(strPersonID);

            //Convert the string over to an integer
            int intPersonID = Convert.ToInt32(strPersonID);

            //Create the editor form, passing it one EBook's ID and show it
            // NOTE THAT THE ID BEING PASSED WILL CALL THE OVERLOADED VERSION
            // OF THE CONSTRUCTOR...TELL IT, IN ESSENCE THAT WE ARE PULLING UP
            // RATHER THAN ADDING DATA 
            Form1 Editor = new Form1(intPersonID);
            Editor.ShowDialog();
        }
    }
}
