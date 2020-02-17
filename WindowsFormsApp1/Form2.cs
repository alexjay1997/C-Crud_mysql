using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password= ;database=loginform");
        MySqlCommand command;
        MySqlDataReader mdr;
        MySqlDataAdapter da;

        public Form2()
        {
            InitializeComponent();
            DisplayData();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // *****************   insert function     **************************

            connection.Open();

            // ***************     checked if already exist  *********************

            string check_query = "Select * from userinfo where username='"+textBox_username.Text+"'";
            command = new MySqlCommand(check_query, connection);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {

                MessageBox.Show("already Exist!!");

                connection.Close();
            }
      

            //********************  End of Check    ************************


            else
            {
                connection.Close();

                connection.Open();
                string Insert_query = "Insert into userinfo (username,password) values ('" + textBox_username.Text + "','" + textBox_password.Text + "')";
                command = new MySqlCommand(Insert_query, connection);
                mdr = command.ExecuteReader();
                MessageBox.Show("successfully Added New Record!");


                connection.Close();
            }
      
        }

        private void DisplayData() {

            try
            {
                connection.Open();

         
                string SelectAll_query = "select * from userinfo ";
                command = new MySqlCommand(SelectAll_query, connection);

                da = new MySqlDataAdapter();
                da.SelectCommand = command;
                DataTable data_table = new DataTable();
                da.Fill(data_table);
                dataGridView1.DataSource = data_table; // here i have assign dTable object to the dataGridView1 object to display data.               
                                                   // MyConn2.Close();  
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
            connection.Close();

        }
       
    }
}
