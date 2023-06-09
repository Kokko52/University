﻿using System;
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
			dataGridView1.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
			comboBox1.Items.AddRange(new string[] {"user"});
			comboBox1.Items.AddRange(new string[] { "admin" });
		
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
				string priv = comboBox1.Text;
				if(priv != "user" && priv != "admin")
				{
					MessageBox.Show("Не ккоректный ввод поля \"Привилегия\"! ", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					string ConnectionString = "host = localhost;database = mydb_kokurin; uid = root; pwd = root;charset = utf8";
					string query = String.Format("INSERT INTO users(id_usr, name_usr, login_usr, pwd_usr, users_privilege) VALUES({0}, '{1}', '{2}', '{3}', '{4}');", idusers, fio, login, pwd, priv);
					MySqlConnection connection = new MySqlConnection(ConnectionString);
					connection.Open();

					MySqlCommand com = new MySqlCommand(query, connection);
					int num = com.ExecuteNonQuery();
					LoadDate();
					textBox1.Text = "";
					textBox2.Text = "";
					textBox3.Text = "";
					comboBox1.Text = "";
					textBox10.Text = "";
					connection.Close();
				}
				
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
				MessageBox.Show("Присутствует пустая строка! ", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}
		#endregion

		#region Редактирование
		private void button5_Click(object sender, EventArgs e)
		{
			int rowIndex = dataGridView1.CurrentCell.RowIndex; // номер выбраной строки в datagridview
			string primaryKey = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString(); // первичный ключ по которому будем обновлять
			int id = 0;
			if (textBox9.Text == "")
			{
				 id = 0;
				 goto m_go;
			}
			 id = Convert.ToInt32(textBox9.Text);
			m_go:
			if (id == 0)
			{
				int rowIndex_id = dataGridView1.CurrentCell.RowIndex; // номер выбраной строки в datagridview
				string primaryKey_id = dataGridView1.Rows[rowIndex_id].Cells[0].Value.ToString(); // первичный ключ по которому будем обновлять
			id = Convert.ToInt32(primaryKey_id);
			}
			string name = textBox8.Text;
			if (name == "")
			{
				int rowIndex_name = dataGridView1.CurrentCell.RowIndex; // номер выбраной строки в datagridview
				string primaryKey_name = dataGridView1.Rows[rowIndex_name].Cells[1].Value.ToString(); // первичный ключ по которому будем обновлять
				name = primaryKey_name;
			}
			string login = textBox6.Text;
			if (login == "")
			{
				int rowIndex_login = dataGridView1.CurrentCell.RowIndex; // номер выбраной строки в datagridview
				string primaryKey_login = dataGridView1.Rows[rowIndex_login].Cells[2].Value.ToString(); // первичный ключ по которому будем обновлять
				login = primaryKey;
			}
			string pwd= textBox7.Text;
			if (pwd == "")
			{
				int rowIndex_pwd = dataGridView1.CurrentCell.RowIndex; // номер выбраной строки в datagridview
				string primaryKey_pwd = dataGridView1.Rows[rowIndex_pwd].Cells[3].Value.ToString(); // первичный ключ по которому будем обновлять
				pwd = primaryKey;
			}
			string priv = comboBox2.Text;
			if (priv == "")
			{
				int rowIndex_priv = dataGridView1.CurrentCell.RowIndex; // номер выбраной строки в datagridview
				string primaryKey_priv = dataGridView1.Rows[rowIndex_priv].Cells[4].Value.ToString(); // первичный ключ по которому будем обновлять
				priv = primaryKey_priv;
			}
			if (priv != "user" && priv != "admin")
			{
				MessageBox.Show("Не ккоректный ввод поля \"Привилегия\"! ", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				string connectionString = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
				string query = "UPDATE users SET id_usr =" + id + ", name_usr = '" + name + "', login_usr = '" + login + "', pwd_usr = '" + pwd + "', users_privilege = '" + priv + "' WHERE idusers = '" + primaryKey + "';";
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
				comboBox2.Text = "";
				LoadDate();
				con.Close();
			}
			
		}
		#endregion

		#region Удаление
		private void button6_Click(object sender, EventArgs e)
		{
			int rowIndex = dataGridView1.CurrentCell.RowIndex; // номер выбраной строки в datagridview
			string primaryKey = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString(); // первичный ключ по которому будем обновлять
			string primaryKey2 = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString(); // первичный ключ по которому будем обновлять
			if(admin.usr == primaryKey && admin.pwd == primaryKey2)
			{
				MessageBox.Show("Невозможно выполнить действие", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				
			}
			else if(MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				rowIndex = dataGridView1.CurrentCell.RowIndex; // номер выбраной строки в datagridview
				primaryKey = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString(); // первичный ключ по которому будем обновлять

				string ConnectionString = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
				string query = "DELETE FROM users WHERE id_usr =" + primaryKey + ";";
				MySqlConnection con = new MySqlConnection(ConnectionString);
				con.Open();
				MySqlCommand com = new MySqlCommand(query, con);
				int res = com.ExecuteNonQuery();
				MessageBox.Show("Удалено - " + res.ToString() + " cтр.", "Внимание!", MessageBoxButtons.OK);
				con.Close();
				LoadDate();
			}
			
		}
		#endregion

		void LoadDate()
		{
			string ConnectionString = "host =localhost; database = mydb_kokurin; uid = root;pwd = root;charset = utf8";
			MySqlConnection connection = new MySqlConnection(ConnectionString);
			connection.Open();
			string query = "SELECT id_usr AS 'ID', name_usr AS 'ФИО', login_usr AS 'Логин', pwd_usr AS 'Пароль' FROM users";
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
			Hide();
			Menu form = new Menu(true);
			form.ShowDialog();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Hide();
			Menu form = new Menu(true);
			form.ShowDialog();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Hide();
			Menu form = new Menu(true);
			form.ShowDialog();
		}
		#endregion

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void Work_users_Load(object sender, EventArgs e)
		{

		}

		private void tabPage1_Click(object sender, EventArgs e)
		{

		}

		private void label11_Click(object sender, EventArgs e)
		{
			textBox2.Text = "";
			int[] ans = new int[7];
			string pwd = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890_-!#$%&*+,-./:;<=>?@\\";
			Random rnd = new Random();
			int j = rnd.Next(8, 15);
			for(int i = 0; i <= j; ++i)
			{
				textBox2.Text += pwd[rnd.Next(pwd.Length)];
			}
		}
		private void label12_Click_1(object sender, EventArgs e)
		{
			textBox7.Text = "";
			int[] ans = new int[7];
			string pwd = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890_-!#$%&*+,-./:;<=>?@\\";
			Random rnd = new Random();
			int j = rnd.Next(8, 15);
			for (int i = 0; i <= j; ++i)
			{
				textBox7.Text += pwd[rnd.Next(pwd.Length)];
			}
		}

		private void textBox7_TextChanged(object sender, EventArgs e)
		{

		}
		
	}
	public static class admin
	{
		public static string usr;
		public static string pwd;
	}
}
