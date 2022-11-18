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
	public partial class Work_users : Form
	{
		public Work_users()
		{
			InitializeComponent();
			LoadDate();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			string fio = textBox1.Text;
			string login = textBox2.Text;
			string pwd = textBox3.Text;
			string priv = textBox4.Text;
			string ConnectionString = "host = localhost;database = university; uid = root; pwd = root;charset = utf8";
			string query = String.Format("INSERT INTO users(users_name, users_login, users_pwd, users_privilege) VALUES('{0}', '{1}', '{2}', '{3}');", fio, login, pwd, priv);
			MySqlConnection connection = new MySqlConnection(ConnectionString);
			connection.Open();

			MySqlCommand com = new MySqlCommand(query, connection);
			int num = com.ExecuteNonQuery();
			LoadDate();
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			connection.Close();

		}
		void LoadDate()
		{
			string ConnectionString = "host =localhost; database = university; uid = root;pwd = root;charset = utf8";
			MySqlConnection connection = new MySqlConnection(ConnectionString);
			connection.Open();
			string query = "SELECT * FROM users";
			MySqlCommand command = new MySqlCommand(query, connection);
			MySqlDataAdapter da = new MySqlDataAdapter(command);
			DataTable table = new DataTable();
			da.Fill(table);
			dataGridView1.DataSource = table;

			#region Запрет на изменение
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.ReadOnly = true;
			#endregion

			connection.Close();
		}

		#region Выход с функции
		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion
	}
}
