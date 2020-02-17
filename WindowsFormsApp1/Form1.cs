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
    public partial class Form1 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password= ;database=loginform");
        MySqlCommand command;
        MySqlDataReader mdr;


        public Form1()
        {
            InitializeComponent();
        }

        public Form1(MySqlConnection connection)
        {
            this.connection = connection;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

           // if (textBox1.Text == "admin" && textBox2.Text =="123")
        //    {
                //show form2  ----- start ---- 
              //  var form2 = new Form2();
             //   form2.Show();
                // end  ----------- end -------
                // }


            // LOGIN BUTTON

            connection.Open();
            string selectQuery = "SELECT * FROM userinfo WHERE Username = '" + textBox1.Text + "' AND Password = '" + textBox2.Text + "';";
            command = new MySqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {

                var form2 = new Form2();
                   form2.Show();

            }
            else
            {

                MessageBox.Show("Incorrect Login Information! Try again.");
            }

            connection.Close();

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please input Username and Password", "Error");
            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ------   compute 2 numbers ------//csharp

            int num1, num2, sum;
            num1 = Convert.ToInt32(textBox3.Text);
            num2 = Convert.ToInt32(textBox4.Text);
            textBox5.Text = Convert.ToString((Convert.ToInt32(textBox3.Text) + Convert.ToInt32(textBox4.Text)));
            sum = num1 + num2;
           
            MessageBox.Show(sum.ToString());

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
