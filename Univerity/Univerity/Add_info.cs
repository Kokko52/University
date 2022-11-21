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
	public partial class Add_info : Form
	{
		public Add_info()
		{
			InitializeComponent();
			string rus = "group_name AS 'Группа', code AS 'Специальность'";
			LoadDate("mydb_kokurin.group", rus);
			comboBox2.Items.Clear();

			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
			
			#region Выпадающий список ГРУППЫ
			string ConnectionString2 = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
			string query2 = "SELECT group_name FROM mydb_kokurin.group;";
			MySqlConnection con2 = new MySqlConnection(ConnectionString2);
			con2.Open();
			MySqlCommand command2 = new MySqlCommand(query2, con2);

			MySqlDataReader reader2 = command2.ExecuteReader();
			while (reader2.Read())
			{
				comboBox2.Items.AddRange(new string[] { reader2[0].ToString() });
			}
			reader2.Close();
			con2.Close();
			#endregion

			#region Выпадающий список СПЕЦИАЛЬНОСТИ
			string ConnectionString = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
			string query = "SELECT code FROM speciality;";
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

	private void Add_info_Load(object sender, EventArgs e)
		{
		}

	#region TabControl
	private void change_tab(object sender, EventArgs e)
		{
			if (tabControl1.SelectedIndex == 0) { string rus = "group_name AS 'Группа', code AS 'Специальность'"; LoadDate("mydb_kokurin.group", rus); }
			if (tabControl1.SelectedIndex == 1) { string rus = "student_tk AS 'Студ. билет', st_surname AS 'Фамилия', st_name AS 'Имя', st_pt AS 'Отчество'"; LoadDate("student", rus); }
			if (tabControl1.SelectedIndex == 2) { string rus = "code 'ID', sub_name AS 'Название предмета'"; LoadDate("subject", rus); }
			if (tabControl1.SelectedIndex == 3) { string rus = "id_tc AS 'ID', tc_surname AS 'Фамилия', tc_name AS 'Имя', tc_pt AS 'Отчество'"; LoadDate("teacher", rus); }
			if (tabControl1.SelectedIndex == 4) { string rus = "code 'ID', spec_name AS 'Специальность'"; LoadDate("speciality", rus); }
		}
	#endregion

	#region Вывод таблицы
	void LoadDate(string str, string rus)
		{
			string ConnectionString = "host =localhost; database = mydb_kokurin; uid = root;pwd = root;charset = utf8";
			MySqlConnection connection = new MySqlConnection(ConnectionString);
			connection.Open();
			string query = "SELECT " + rus + " FROM " + str + ";";
			MySqlCommand command = new MySqlCommand(query, connection);
			MySqlDataAdapter da = new MySqlDataAdapter(command);
			DataTable table = new DataTable();
			da.Fill(table);
			dataGridView1.DataSource = table;
			//dataGridView1.Columns["code"].Width = 10;
			#region Запрет на изменение
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.ReadOnly = true;
			#endregion

			connection.Close();
		}
	#endregion

	private void button1_Click(object sender, EventArgs e)//
		{
			string group = textBox1.Text;
			string spec = comboBox1.Text;
			string ConnectionString = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
			string query = "INSERT INTO mydb_kokurin.group(group_name, code) VALUES('" + group + "','" + spec + "');";
			MySqlConnection con = new MySqlConnection(ConnectionString);
			con.Open();
			MySqlCommand com = new MySqlCommand(query, con);
			int num = com.ExecuteNonQuery();
			con.Close();
			string rus = "group_name AS 'Группа', code AS 'Специальность'";
			LoadDate("mydb_kokurin.group", rus);
			
			textBox1.Text = "";
			comboBox1.Text = "";
		}

		#region Выход
		private void button2_Click(object sender, EventArgs e) //
		{
			Hide();
			Menu form = new Menu(true);
			form.ShowDialog();
			this.Close();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Hide();
			Menu form = new Menu(true);
			form.ShowDialog();
		}

		private void button5_Click(object sender, EventArgs e)//
		{
			Hide();
			Menu form = new Menu(true);
			form.ShowDialog();
		}

		private void button7_Click(object sender, EventArgs e)//
		{
			Hide();
			Menu form = new Menu(true);
			form.ShowDialog();
		}

		private void button9_Click(object sender, EventArgs e)//
		{
			Hide();
			Menu form = new Menu(true);
			form.ShowDialog();
		}
		#endregion 

		private void button6_Click(object sender, EventArgs e)//
		{
			int zach = Convert.ToInt32(textBox3.Text);
			string fam = textBox4.Text;
			string name = textBox5.Text;
			string otch = textBox6.Text;
			string group = comboBox2.Text;
			//int gr = Convert.ToInt32(textBox15.Text);

			string ConnectionString = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
			string query = "INSERT INTO student(student_tk, st_surname, st_name, st_pt, group_name) VALUES(" + zach + ",'" + fam + "','" + name + "','" + otch + "','" + group + "');";
			MySqlConnection con = new MySqlConnection(ConnectionString);
			con.Open();
			MySqlCommand com = new MySqlCommand(query, con);
			int num = com.ExecuteNonQuery();
			con.Close();
			string rus = "student_tk AS 'Студ. билет', st_surname AS 'Фамилия', st_name AS 'Имя', st_pt AS 'Отчество'";
			LoadDate("student", rus);
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
			textBox6.Text = "";
			comboBox2.Text = "";
		}

		private void button8_Click(object sender, EventArgs e)//
		{
			int code = Convert.ToInt32(textBox7.Text);
			string name_s = textBox8.Text;

			string ConnectionString = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
			string query = "INSERT INTO subject(code, sub_name) VALUES(" + code + ",'" + name_s + "');";
			MySqlConnection con = new MySqlConnection(ConnectionString);
			con.Open();
			MySqlCommand com = new MySqlCommand(query, con);
			int num = com.ExecuteNonQuery();
			con.Close();
			string rus = "code 'ID', sub_name AS 'Название предмета'";
			LoadDate("subject", rus);
			textBox7.Text = "";
			textBox8.Text = "";
		}

		private void button10_Click(object sender, EventArgs e)
		{
			int id_t = Convert.ToInt32(textBox9.Text);
			string name_t = textBox11.Text;
			string surname_t = textBox10.Text;
			string otch = textBox12.Text;
			string ConnectionString = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
			string query = "INSERT INTO teacher(id_tc, tc_surname, tc_name, tc_pt) VALUES(" + id_t + ",'" + name_t + "','" + surname_t + "','" + otch + "');";
			MySqlConnection con = new MySqlConnection(ConnectionString);
			con.Open();
			MySqlCommand com = new MySqlCommand(query, con);
			int num = com.ExecuteNonQuery();
			con.Close();
			string rus = "id_tc AS 'ID', tc_surname AS 'Фамилия', tc_name AS 'Имя', tc_pt AS 'Отчество'";
			LoadDate("teacher", rus);
			textBox9.Text = "";
			textBox11.Text = "";
			textBox10.Text = "";
			textBox12.Text = "";

		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			string code = textBox13.Text;
			string name = textBox14.Text;
			string ConnectionString = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
			string query = "INSERT INTO speciality(code, spec_name) VALUES('" + code + "','" + name + "');";
			MySqlConnection con = new MySqlConnection(ConnectionString);
			con.Open();
			MySqlCommand com = new MySqlCommand(query, con);
			int num = com.ExecuteNonQuery();
			con.Close();
			string rus = "code 'ID', spec_name AS 'Специальность'";
			LoadDate("speciality", rus);
			textBox13.Text = "";
			textBox14.Text = "";
			
		}

		
	}
}
