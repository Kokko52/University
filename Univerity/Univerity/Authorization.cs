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
using System.Windows.Forms;

namespace Univerity
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
			comboBox1.Items.Clear();
			textBox1.PasswordChar = '*';

			#region Выпадающий список
			string ConnectionString = "host = localhost; database = university; uid = root; pwd = root; charset = utf8";
			string query = "SELECT users_name FROM users where users_privilege = \'user\';";
			MySqlConnection con = new MySqlConnection(ConnectionString);
			con.Open();
			MySqlCommand command = new MySqlCommand(query, con);

			MySqlDataReader reader = command.ExecuteReader();
			while (reader.Read())
			{
				comboBox1.Items.AddRange(new string[] { reader[0].ToString() });
			}
			reader.Close();
			con.Close();
			#endregion
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
				this.Visible = false;
				if (pr == "admin")
				{
					admin.usr = user;
					admin.pwd = pwd;
					Menu form = new Menu(true);
					form.ShowDialog();
				//Work_users form1 = new Work_users();
				//form1.textBox10.Text = "dfsdfsdfsfs";
				}
				if (pr == "user")
				{

					Menu form = new Menu(false);
					//form.Size = new Size(250, 200);
					form.ShowDialog();
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

		private void Authorization_Load(object sender, EventArgs e)
		{

		}
    }
}
