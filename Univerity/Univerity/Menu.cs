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
	public partial class Menu : Form
	{
		public bool realClose = false;
		public Menu()
		{
			InitializeComponent();
		}

		private void button7_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			Hide();
			Rm_info form = new Rm_info();
			form.ShowDialog();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button7_Click_1(object sender, EventArgs e)
		{
			Hide();
			Work_users form = new Work_users();
			form.ShowDialog();
		}

		
		bool loginpasswd;
		public Menu(bool admin)
        {
            loginpasswd = admin;
            InitializeComponent();
        }
		private void Menu_Load(object sender, EventArgs e)
		{
			if (loginpasswd == false)
			{
				button1.Visible = true;
				button2.Visible = false;
				button3.Visible = false;
				button4.Visible = true;
				button5.Visible = true;
				button5.Location = new Point(70,155);
				button6.Visible = true;
				button7.Visible = false;
			}
			else
			{
				button1.Enabled = true;
				button2.Enabled = true;
				button3.Enabled = true;
				button4.Enabled = true;
				button5.Visible = true;
				button6.Visible = true;
				button7.Visible = true;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Hide();
			Add_info form = new Add_info();
			form.ShowDialog();

		}

		private void button4_Click(object sender, EventArgs e)
		{
			Service form = new Service();
			form.ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			View_Service form = new View_Service();
			form.ShowDialog();
		}
	}

}
