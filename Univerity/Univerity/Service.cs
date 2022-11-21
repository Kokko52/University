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
	public partial class Service : Form
	{
		public Service()
		{
			InitializeComponent();
			LoadDate();

			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;

			#region Выпадающий список ПАРЫ
				comboBox1.Items.AddRange(new string[] { "1 пара"});
				comboBox1.Items.AddRange(new string[] { "2 пара" });
				comboBox1.Items.AddRange(new string[] { "3 пара" });
				comboBox1.Items.AddRange(new string[] { "4 пара" });
			#endregion

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

			#region Выпадающий список ПРЕДМЕТ
				string ConnectionString3 = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
				string query3 = "SELECT sub_name FROM subject;";
				MySqlConnection con3 = new MySqlConnection(ConnectionString3);
				con3.Open();
				MySqlCommand command3 = new MySqlCommand(query3, con3);

				MySqlDataReader reader3 = command3.ExecuteReader();
				while (reader3.Read())
				{
					comboBox3.Items.AddRange(new string[] { reader3[0].ToString() });
				}
				reader3.Close();
				con3.Close();
				#endregion

			#region Выпадающий список ПРЕПОД
				string ConnectionString4 = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
				string query4 = "SELECT tc_surname FROM teacher;";
				MySqlConnection con4 = new MySqlConnection(ConnectionString4);
				con4.Open();
				MySqlCommand command4 = new MySqlCommand(query4, con4);

				using (MySqlDataReader reader4 = command4.ExecuteReader())
				{
					while (reader4.Read())
					{
						comboBox4.Items.AddRange(new string[] { reader4[0].ToString() });
					}
				}
				con4.Close();
				#endregion

		
			LoadUpgrade();

		}

		private void Service_Load(object sender, EventArgs e)
		{
			
		}
		void LoadUpgrade()
		{
			string ConnectionString = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
			MySqlConnection con = new MySqlConnection(ConnectionString);
			con.Open();
			string join = "SELECT timetable.idtimetable AS 'ID', timetable.pair_num AS '№ пары', timetable.date AS 'Дата',  timetable.group_n AS 'Группа',  subject.sub_name AS 'Предмет', teacher.tc_surname AS 'Преподаватель' FROM (subject INNER JOIN timetable ON subject.code = timetable.code_sub) INNER JOIN teacher ON teacher.id_tc = timetable.idteacher";
			MySqlCommand com = new MySqlCommand(join, con);	
			MySqlDataAdapter da = new MySqlDataAdapter(com);	
			DataTable table = new DataTable();
			da.Fill(table);
			
			dataGridView1.DataSource = table;
			dataGridView1.Sort(dataGridView1.Columns[3], ListSortDirection.Ascending);
			con.Close();
		}
		void LoadDate()
		{
			string ConnectionString = "host =localhost; database = mydb_kokurin; uid = root;pwd = root;charset = utf8";
			MySqlConnection connection = new MySqlConnection(ConnectionString);
			connection.Open();
			string query = "SELECT * FROM timetable;";
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
			
			string pair = comboBox1.Text;
			string group = comboBox2.Text;
			string sub = comboBox3.Text;
			string teacher = comboBox4.Text;


			string pr = "SELECT pair_num FROM timetable WHERE timetable.group_n = '" + group + "';";
			string ConnectionStrings = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
			string st = "";
			MySqlConnection cons = new MySqlConnection(ConnectionStrings);
			cons.Open();
			MySqlCommand coms = new MySqlCommand(pr, cons);
			MySqlDataReader reads = coms.ExecuteReader();
			for(int i = 0; i < reads.ToString().Length; ++i)
			{
			while (reads.Read())
			{
				 st = reads[i].ToString();
				if(st == pair)
				{
					MessageBox.Show("Действие не может быть выполнено!\n\n" + pair + " для группы - " + group + " уже стоит.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					goto m_stop;
				}
			}
			}
			reads.Close();
			cons.Close();
			m_stop:
			if(st == pair )
			{

			}
			else
			{
				DateTime data = Convert.ToDateTime(dateTimePicker1.Text);
				if (data < DateTime.Today)
				{
					MessageBox.Show("Не верный ввод даты!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else if (data > DateTime.Today.AddDays(7))
				{
					MessageBox.Show("Не верный ввод даты!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					string dataup = Convert.ToString(data);
					dataup = dataup.Split(' ')[0];

					string ConnectionString = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
					string subject = "SELECT code FROM subject WHERE sub_name ='" + sub + "';";
					string teacherr = "SELECT id_tc FROM teacher WHERE tc_surname ='" + teacher + "';";
					string query_para = "SELECT pair_num FROM timetable WHERE group_n ='" + group + "';";



					MySqlConnection con = new MySqlConnection(ConnectionString);
					con.Open();
					MySqlCommand parad = new MySqlCommand(query_para, con);



					MySqlCommand com = new MySqlCommand(subject, con);
					MySqlCommand tech = new MySqlCommand(teacherr, con);
					int subj = Convert.ToInt32(com.ExecuteScalar());
					int teach = Convert.ToInt32(tech.ExecuteScalar());
					con.Close();

					MySqlConnection con2 = new MySqlConnection(ConnectionString);
					con2.Open();

					string query = "INSERT INTO timetable(pair_num, date, group_n, code_sub, idteacher) VALUES('" + pair + "','" + dataup + "','" + group + "'," + subj + "," + teach + ");";
					MySqlCommand com1 = new MySqlCommand(query, con2);
					int num = com1.ExecuteNonQuery();

					con2.Close();
					LoadUpgrade();
			}



			


			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				int rowIndex = dataGridView1.CurrentCell.RowIndex;
				dataGridView1.Rows[rowIndex].Selected = true;
				string kill = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
				string ConnectionString = "host =localhost; database = mydb_kokurin; uid = root;pwd = root;charset = utf8";
				string query = String.Format("DELETE FROM timetable WHERE idtimetable = '" + kill + "';");
				MySqlConnection con = new MySqlConnection(ConnectionString);
				con.Open();
				MySqlCommand command = new MySqlCommand(query, con);
				int res = command.ExecuteNonQuery();
				MessageBox.Show("Удалено" + res.ToString(), "Внимание!", MessageBoxButtons.OK);
				con.Close();
				LoadUpgrade();
			}
		}
	}
}
