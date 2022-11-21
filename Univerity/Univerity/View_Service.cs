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
	public partial class View_Service : Form
	{
		public View_Service()
		{
			InitializeComponent();
			LoadUpgrade();
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
		}
		void LoadUpgrade()
		{
			string ConnectionString = "host = localhost; database = mydb_kokurin; uid = root; pwd = root; charset = utf8";
			MySqlConnection con = new MySqlConnection(ConnectionString);
			con.Open();
			string join = "SELECT timetable.idtimetable, timetable.pair_num AS '№ пары', timetable.date AS 'Дата',  timetable.group_n AS 'Группа',  subject.sub_name AS 'Предмет', teacher.tc_surname AS 'Преподаватель' FROM (subject INNER JOIN timetable ON subject.code = timetable.code_sub) INNER JOIN teacher ON teacher.id_tc = timetable.idteacher";
			MySqlCommand com = new MySqlCommand(join, con);//	
			MySqlDataAdapter da = new MySqlDataAdapter(com);//		
			DataTable table = new DataTable();
			da.Fill(table);
			dataGridView1.DataSource = table;
			#region Запрет на изменение
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.ReadOnly = true;
			#endregion
			dataGridView1.Columns["idtimetable"].Visible = false;
			con.Close();

		}
		private void button1_Click_1(object sender, EventArgs e)
		{
			this.Close();
		}

		private void View_Service_Load(object sender, EventArgs e)
		{

		}
	}
}
