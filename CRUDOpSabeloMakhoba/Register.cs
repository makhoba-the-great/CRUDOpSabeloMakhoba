using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUDOpSabeloMakhoba
{
    public partial class Register : Form
    {
        
        //DECLARE SQL call objects
        SqlConnection conn;
        SqlCommand cmd;
        

        public Register()
        {
            InitializeComponent();
            //SQL CONNECTION STRINGS
            conn = new SqlConnection(@"Data Source=DESKTOP-9S98IMU\SQLSERVER2022;Initial Catalog=CRUDEOperationDB;Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = conn;
            //btnSubReg.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void btnSubReg_Click(object sender, EventArgs e)
        {
            //TRY CATCH TO ENSURE THAT THE NUMBER DOES NOT EXIST AS YET
            try
            {
                //Ensure all edit boxes are filled before submitting
                if (edtA.Text != "" && edtA.Text != "" && edtEm.Text != "" && edtName.Text != "" &&
                       edtPhone.Text != "" && edtSur.Text != "")
                {
                    //Datetime variable to store time of reg
                    DateTime dt = new DateTime();
                    dt = DateTime.Now;
                    //SQL qury string with interpolation
                    string qry = $"insert into Members values('{edtPhone.Text}','{edtName.Text}','{edtSur.Text}','{edtEm.Text}','{int.Parse(edtA.Text)}','{dt}')";
                    cmd.CommandText = qry;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    
                    //Success message dialog 
                    MessageBox.Show("Successfully registered new member "+edtName.Text+"!");
                    edtPhone.Clear();
                    edtName.Clear();
                    edtSur.Clear();
                    edtEm.Clear();
                    edtA.Clear();
                    edtName.Focus();
                }
                else
                {
                    //SOME EDIT BOXES EMPTY error dialog box
                    MessageBox.Show("All fields must be filled!", "Error!");
                    edtPhone.Focus();
                }
            }
            catch (SqlException ex)
            {
                //Catch exception to display number already exists
                MessageBox.Show("The phone number is already registered!", "Error!");
            }
            conn.Close();
        }

        private void btnBck_Click(object sender, EventArgs e)
        {
            //NAVIGATE BACK BUTTON
            this.Hide();
            MainPage m=new MainPage();
            m.Show();
        }

        private void edtPhone_TextChanged(object sender, EventArgs e)
        {
            //ENSURE USER ENTERS ONLY DIGITS for the PHONE number
            if (System.Text.RegularExpressions.Regex.IsMatch(edtPhone.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter a valid phone number.", "Error!");
                edtPhone.Clear();
                edtPhone.Focus();
            }
        }

        private void edtA_TextChanged(object sender, EventArgs e)
        {
            //ENSURE USER ENTERS ONLY DIGITS for the AGE number
            if (System.Text.RegularExpressions.Regex.IsMatch(edtA.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter a valid digit.", "Error!");
                edtA.Clear();
                edtA.Focus();
            }
        }

        
    }
}
