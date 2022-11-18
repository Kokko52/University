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
using System.Data.SqlClient;

namespace Univerity
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
			textBox1.PasswordChar = '*';
        }

		private void button1_Click(object sender, EventArgs e)
		{
			string user = comboBox1.Text;
			string pwd = textBox1.Text;
			string ConnectionString = "host =localhost; database = university; uid = root;pwd = root;charset = utf8";
			MySqlConnection connection = new MySqlConnection(ConnectionString);
			connection.Open();
		//	string query = "SELECT * FROM users WHERE users_name ='" + user + "'and users_pwd = '" + pwd + "'";
			string query = "SELECT users_privilege FROM users WHERE users_name ='" + user + "'and users_pwd = '" + pwd + "'";
			MySqlCommand command = new MySqlCommand(query, connection);

			try
			{
				string pr = command.ExecuteScalar().ToString();
				if (pr == "admin")
				{
					Admin form = new Admin();
					form.ShowDialog();
				}
				if (pr == "user")
				{
					User form = new User();
					form.ShowDialog();
					button2.Visible = false;
				}
				else if (pr != "admin" && pr != "user")
				{
					MessageBox.Show("Не верный логин или пароль! ", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					comboBox1.Text = "";
					textBox1.Text = "";
				}
			}
			catch(System.NullReferenceException)
			{
				MessageBox.Show("Не верный логин или пароль! ", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			connection.Close();
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

    }
}
