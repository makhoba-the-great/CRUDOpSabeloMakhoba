using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CRUDOpSabeloMakhoba
{
    public partial class ViewMembers : Form
    {
        //DECLARE SQL call objects
        SqlConnection conn;
        SqlCommand cmd;
        public ViewMembers()
        {
            InitializeComponent();
            //ON FORM SHOW hide unnecessary components to minimize user input errors
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            dataGridView1.Visible = false;
            button4.Visible = false;
            button2.Visible = false;
            button1.Visible = false;


            //INITIALISE DATABASE CONNECTION
            conn = new SqlConnection(@"Data Source=DESKTOP-9S98IMU\SQLSERVER2022;Initial Catalog=CRUDEOperationDB;Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }


        //EDIT USER button
        private void button2_Click(object sender, EventArgs e)
        {
            //HIDE UNNECESSARY COMPONENTS
            dataGridView1.Visible=false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            button4.Visible=true;
            button1.Visible=false;
            button2.Visible=false;

        }

        //VIEW DETAILS BUTTON
        private void button3_Click(object sender, EventArgs e)
        {
            //label1.Visible = true;
            //label2.Visible = true;
            //label3.Visible = true;
            //label4.Visible = true;
            //textBox1.Visible = true;
            //textBox2.Visible = true;
            //textBox3.Visible = true;
            //textBox4.Visible = true;

            //ENSURE DATA ENTERED
            if (textBox5.Text != "")
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                dataGridView1.Visible = false;
                button4.Visible = false;
                

                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"select * from Members where PNumber={textBox5.Text}";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                //ENSURE NUMBER EXISTS IN DB
                if (dt.Rows.Count==0)
                {
                    MessageBox.Show("Phone number does not exist!", "Error!");
                    textBox5.Clear();
                    textBox5.Focus();
                }
                else
                {
                    //IF NUMBER EXISTS THEN SHOW DATAGRID
                    dataGridView1.Visible = true;
                    button2.Visible = true;
                    button1.Visible = true;
                    //da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    
                }


                //textBox1.Text=da.ToString();
                //textBox2.Visible = true;
                //textBox3.Visible = true;
                //textBox4.Visible = true;
                conn.Close();
            }
            else
                //ENSURE USER ENTERS A PHONE NUMBER
                MessageBox.Show("Phone number cannot be empty!", "Error!");
        }

        //DELETE USER BUTTON 
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible=false;
            button1.Visible = false;
            string query = $"delete Members where PNumber={textBox5.Text}";
            cmd.CommandText = query;
            conn.Open();
            cmd.ExecuteNonQuery();
            dataGridView1.DataSource = query;
            conn.Close();
            MessageBox.Show("Successfully deleted member!");
        }
        //SUBMIT UPDATE BUTTON
        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = $"update Members set Name='" + textBox1.Text + "',Surname='" + textBox2.Text + "',email='" + textBox3.Text + "',age='" + int.Parse(textBox4.Text) + "' where PNumber='" + textBox5.Text + "' ";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully updated member!");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox5.Focus();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
        }
        //BACK BUTTON
        private void btnBck_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage m=new MainPage();  
            m.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //ENSURE USER ENTERS A VALID AGE
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter a valid digit.","Error!");
                textBox4.Clear();
                textBox4.Focus();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //ENSURE USER ENTERS A VALID phone number
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter a valid phone number.", "Error!");
                textBox5.Clear();
                textBox5.Focus();
            }
        }
    }
}
