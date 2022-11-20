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
	public partial class Rm_info : Form
	{
		public Rm_info()
		{
			InitializeComponent();
			LoadDate("mydb_kokurin.group");
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.DefaultCellStyle.SelectionBackColor = Color.BlueViolet;
		}
		void LoadDate(string str)
		{
			string ConnectionString = "host =localhost; database = mydb_kokurin; uid = root;pwd = root;charset = utf8";
			MySqlConnection connection = new MySqlConnection(ConnectionString);
			connection.Open();
			string query = "SELECT * FROM " + str + ";";
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

		private void button1_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы действительно хотите изменить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				int rowIndex = dataGridView1.CurrentCell.RowIndex; // номер выбраной строки в datagridview
				string primaryKey = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString(); // первичный ключ по которому будем обновлять

				string name = textBox1.Text;
				string spec = textBox2.Text;
				string ConnectingString = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
				string query = "UPDATE mydb_kokurin.group SET group_name ='" + name + "', code ='" + spec + "'  WHERE group_name ='" + primaryKey + "';";
				MySqlConnection con = new MySqlConnection(ConnectingString);
				con.Open();
				MySqlCommand com = new MySqlCommand(query, con);
				MessageBox.Show(query);
				int res = com.ExecuteNonQuery();
				MessageBox.Show("Отредактированно " + res.ToString(), "Внимание!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

				textBox1.Text = "";
				textBox2.Text = "";
				con.Close();
				LoadDate(" mydb_kokurin.group");
			}

		}

		private void Rm_info_Load(object sender, EventArgs e)
		{

		}
		private void change_tab(object sender, EventArgs e)
		{
			if (tabControl1.SelectedIndex == 0) LoadDate("mydb_kokurin.group");
			if (tabControl1.SelectedIndex == 1) LoadDate("student");
			if (tabControl1.SelectedIndex == 2) LoadDate("subject");
			if (tabControl1.SelectedIndex == 3) LoadDate("teacher");
			if (tabControl1.SelectedIndex == 4) LoadDate("speciality");
		}
		

		private void button6_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				int rowIndex = dataGridView1.CurrentCell.RowIndex; // номер выбраной строки в datagridview
				string primaryKey = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString(); // первичный ключ по которому будем обновлять

				string zach = textBox3.Text;
				string surname = textBox4.Text;
				string name = textBox5.Text;
				string otch = textBox6.Text;
				string gr = textBox14.Text;

				string ConnectingString = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
				string query = "UPDATE student SET student_tk ='" + zach + "', st_surname ='" + surname + "', st_name ='" + name + "', st_pt ='" + otch + "', group_name ='" + gr + "'  WHERE student_tk ='" + primaryKey + "';";
				MySqlConnection con = new MySqlConnection(ConnectingString);
				con.Open();
				MySqlCommand com = new MySqlCommand(query, con);
				int res = com.ExecuteNonQuery();
				MessageBox.Show("Отредактированно " + res.ToString(), "Внимание!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

				textBox1.Text = "";
				con.Close();
				LoadDate("student");
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				int rowIndex = dataGridView1.CurrentCell.RowIndex; // номер выбраной строки в datagridview
				string primaryKey = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString(); // первичный ключ по которому будем обновлять

				string code = textBox7.Text;
				string name = textBox8.Text;


				string ConnectingString = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
				string query = "UPDATE subject SET code ='" + code + "', sub_name ='" + name + "' WHERE code ='" + primaryKey + "';";
				MySqlConnection con = new MySqlConnection(ConnectingString);
				con.Open();
				MySqlCommand com = new MySqlCommand(query, con);
				int res = com.ExecuteNonQuery();
				MessageBox.Show("Отредактированно " + res.ToString(), "Внимание!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

				textBox1.Text = "";
				con.Close();
				LoadDate("subject");
			}
		}

		private void button10_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				int rowIndex = dataGridView1.CurrentCell.RowIndex; // номер выбраной строки в datagridview
				string primaryKey = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString(); // первичный ключ по которому будем обновлять

				string id = textBox9.Text;
				string surname = textBox10.Text;
				string name = textBox11.Text;
				string otch = textBox12.Text;

				string ConnectingString = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
				string query = "UPDATE teacher SET id_tc='" + id + "', tc_surname ='" + surname + "', tc_name ='" + name + "', tc_pt ='" + otch + "' WHERE id_tc='" + primaryKey + "';";
				MySqlConnection con = new MySqlConnection(ConnectingString);
				con.Open();
				MySqlCommand com = new MySqlCommand(query, con);
				int res = com.ExecuteNonQuery();
				MessageBox.Show("Отредактированно " + res.ToString(), "Внимание!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

				textBox1.Text = "";
				con.Close();
				LoadDate("teacher");
			}
		}

		#region ВЫХОД
		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button14_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		private void button12_Click(object sender, EventArgs e)
		{
			if(MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
			int rowIndex = dataGridView1.CurrentCell.RowIndex;
			dataGridView1.Rows[rowIndex].Selected = true;
			string kill = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
			string ConnectionString = "host =localhost; database = mydb_kokurin; uid = root;pwd = root;charset = utf8";
			string query = String.Format("DELETE FROM mydb_kokurin.group WHERE group_name = '" + kill + "';");
			MySqlConnection con = new MySqlConnection(ConnectionString);
			con.Open();
			MySqlCommand command = new MySqlCommand(query, con);
			int res = command.ExecuteNonQuery();
			MessageBox.Show("Удалено" + res.ToString(), "Внимание!", MessageBoxButtons.OK);
			con.Close();
			LoadDate("mydb_kokurin.group");
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				int rowIndex = dataGridView1.CurrentCell.RowIndex;
				dataGridView1.Rows[rowIndex].Selected = true;
				string kill = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
				string ConnectionString = "host =localhost; database =mydb_kokurin; uid = root;pwd = root;charset = utf8";
				string query = String.Format("DELETE FROM student WHERE student_tk = '" + kill + "';");
				MySqlConnection con = new MySqlConnection(ConnectionString);
				con.Open();
				MySqlCommand command = new MySqlCommand(query, con);
				int res = command.ExecuteNonQuery();
				MessageBox.Show("Удалено" + res.ToString(), "Внимание!", MessageBoxButtons.OK);
				con.Close();
				LoadDate("student");
			}
		}

		private void button15_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				int rowIndex = dataGridView1.CurrentCell.RowIndex; // номер выбраной строки в datagridview
				string primaryKey = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString(); // первичный ключ по которому будем обновлять

				string name = textBox13.Text;
				string spec = textBox15.Text;
				string ConnectingString = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
				string query = "UPDATE speciality SET code ='" + name + "', spec_name ='" + spec + "'  WHERE code ='" + primaryKey + "';";
				MySqlConnection con = new MySqlConnection(ConnectingString);
				con.Open();
				MySqlCommand com = new MySqlCommand(query, con);
				MessageBox.Show(query);
				int res = com.ExecuteNonQuery();
				MessageBox.Show("Отредактированно " + res.ToString(), "Внимание!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

				textBox1.Text = "";
				textBox2.Text = "";
				con.Close();
				LoadDate("mydb_kokurin");
			}
		}

		private void button13_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				int rowIndex = dataGridView1.CurrentCell.RowIndex;
				dataGridView1.Rows[rowIndex].Selected = true;
				string kill = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
				string ConnectionString = "host =localhost; database = mydb_kokurin; uid = root;pwd = root;charset = utf8";
				string query = String.Format("DELETE FROM speciality WHERE code = '" + kill + "';");
				MySqlConnection con = new MySqlConnection(ConnectionString);
				con.Open();
				MySqlCommand command = new MySqlCommand(query, con);
				int res = command.ExecuteNonQuery();
				MessageBox.Show("Удалено" + res.ToString(), "Внимание!", MessageBoxButtons.OK);
				con.Close();
				LoadDate("speciality");
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				int rowIndex = dataGridView1.CurrentCell.RowIndex;
				dataGridView1.Rows[rowIndex].Selected = true;
				string kill = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
				string ConnectionString = "host =localhost; database = mydb_kokurin; uid = root;pwd = root;charset = utf8";
				string query = String.Format("DELETE FROM subject WHERE code = '" + kill + "';");
				MySqlConnection con = new MySqlConnection(ConnectionString);
				con.Open();
				MySqlCommand command = new MySqlCommand(query, con);
				int res = command.ExecuteNonQuery();
				MessageBox.Show("Удалено" + res.ToString(), "Внимание!", MessageBoxButtons.OK);
				con.Close();
				LoadDate("subject");
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				int rowIndex = dataGridView1.CurrentCell.RowIndex;
				dataGridView1.Rows[rowIndex].Selected = true;
				string kill = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
				string ConnectionString = "host =localhost; database = mydb_kokurin; uid = root;pwd = root;charset = utf8";
				string query = String.Format("DELETE FROM teacher WHERE id_tc = '" + kill + "';");
				MySqlConnection con = new MySqlConnection(ConnectionString);
				con.Open();
				MySqlCommand command = new MySqlCommand(query, con);
				int res = command.ExecuteNonQuery();
				MessageBox.Show("Удалено" + res.ToString(), "Внимание!", MessageBoxButtons.OK);
				con.Close();
				LoadDate("teacher");
			}
		}

		
	}
}
