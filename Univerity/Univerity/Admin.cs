using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Univerity
{
	public partial class Admin : Form
	{
		public Admin()
		{
			InitializeComponent();
		}

		private void button7_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{

		}

		private void button6_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button7_Click_1(object sender, EventArgs e)
		{
			Work_users form = new Work_users();
			form.ShowDialog();
		}

		private void Admin_Load(object sender, EventArgs e)
		{

		}
	}

}
