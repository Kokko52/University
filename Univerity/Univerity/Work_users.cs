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
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.DefaultCellStyle.SelectionBackColor = Color.BlueViolet;
		}

		#region Добавление
		private void button4_Click(object sender, EventArgs e)
		{
			try
			{
				int idusers = Convert.ToInt32(textBox10.Text);
				string fio = textBox1.Text;
				string login = textBox2.Text;
				string pwd = textBox3.Text;
				string priv = textBox4.Text;
				string ConnectionString = "host = localhost;database = university; uid = root; pwd = root;charset = utf8";
				string query = String.Format("INSERT INTO users(idusers, users_name, users_login, users_pwd, users_privilege) VALUES({0}, '{1}', '{2}', '{3}', '{4}');", idusers, fio, login, pwd, priv);
				MySqlConnection connection = new MySqlConnection(ConnectionString);
				connection.Open();

				MySqlCommand com = new MySqlCommand(query, connection);
				int num = com.ExecuteNonQuery();
				LoadDate();
				textBox1.Text = "";
				textBox2.Text = "";
				textBox3.Text = "";
				textBox4.Text = "";
				textBox10.Text = "";
				connection.Close();
			}
			catch (System.FormatException)
			{
				MessageBox.Show("Не ккоректный ввод! ", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (System.OverflowException)
			{
				MessageBox.Show("Слишком длинная строка! ", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (System.ArgumentNullException)
			{
				MessageBox.Show("Присутствует устая строка! ", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}
		#endregion

		#region Редактирование
		private void button5_Click(object sender, EventArgs e)
		{
			int rowIndex = dataGridView1.CurrentCell.RowIndex; // номер выбраной строки в datagridview
			string primaryKey = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString(); // первичный ключ по которому будем обновлять

			string id = textBox9.Text;
			string name = textBox8.Text;
			string login = textBox6.Text;
			string pwd= textBox7.Text;
			string priv = textBox5.Text;
			string connectionString= "host = localhost; database = university; uid = root; pwd = root; charset = utf8";
			string query = "UPDATE users SET idusers ='" + id + "', users_name = '" + name + "', users_login = '" + login + "', users_pwd = '" + pwd + "', users_privilege = '" + priv + "' WHERE idusers = '" + primaryKey + "';";
			MessageBox.Show("Id  ='" + id + "'\nИмя пользователя = '" + name + "'\nЛогин = '" + login + "'\nПароль = '" + pwd + "'\nПривилегия = '" + priv + "'.", "Отредактировано");
			MySqlConnection con = new MySqlConnection(connectionString);
		
			con.Open();
			MySqlCommand com = new MySqlCommand(query, con);
			int res = com.ExecuteNonQuery();
			MessageBox.Show("Отредактирована " + res.ToString() + "строка", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			textBox9.Text = "";
			textBox8.Text = "";
			textBox7.Text = "";
			textBox6.Text = "";
			textBox5.Text = "";
			LoadDate();
			con.Close();
		}
		#endregion

		#region Удаление
		private void button6_Click(object sender, EventArgs e)
		{
			if(MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				int rowIndex = dataGridView1.CurrentCell.RowIndex; // номер выбраной строки в datagridview
				string primaryKey = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString(); // первичный ключ по которому будем обновлять

				string ConnectionString = "host = localhost; database = university; uid = root; pwd = root; charset = utf8";
				string query = "DELETE FROM users WHERE idusers =" + primaryKey + ";";
				MySqlConnection con = new MySqlConnection(ConnectionString);
				con.Open();
				MySqlCommand com = new MySqlCommand(query, con);
				int res = com.ExecuteNonQuery();
				MessageBox.Show("Удалено - " + res.ToString() + "cтр.", "Внимание!", MessageBoxButtons.OK);
				con.Close();
				LoadDate();
			}
			
		}
		#endregion

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

		private void label4_Click(object sender, EventArgs e)
		{

		}

		

		
	}
}
