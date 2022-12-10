using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{
	public partial class Form1 : Form
	{
		public enum AAA
		{
			A,
			B,
			C
		};
		public Form1()
		{

			InitializeComponent();
			editComb1.SetCaptionPropName("AAA");
			editComb1.SetItems(Enum.GetNames(typeof(AAA)));

		}

		private void mgMain1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void mgControl1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("aa");
		}

		private void mgIcon2_Click(object sender, EventArgs e)
		{

		}

		private void editComb1_ValueChanged(object sender, EditComb.ValueChangedEventArgs e)
		{
			textBox1.Text = e.TagName + "/"+e.Value.ToString(); ;
		}
	}
}
