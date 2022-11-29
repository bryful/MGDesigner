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
	public partial class MGFormSize : MGToolForm
	{
		[Category("_MG")]
		public bool IsShowPosSet
		{
			get { return resizeSetting1.Visible; }
			set 
			{ 
				resizeSetting1.Visible = value;
				lbSizePos.Visible = value;
			}
		}
		[Category("_MG")]
		public PosSet PosSet
		{
			get { return resizeSetting1.PosSet; }
			set { resizeSetting1.PosSet = value; }
		}
		[Category("_MG")]
		public Size FormSize
		{
			get
			{
				return new Size((int)numericUpDown1.Value, (int)numericUpDown2.Value);
			}
			set
			{
				numericUpDown1.Value = (decimal)value.Width;
				numericUpDown2.Value = (decimal)value.Height;
			}
		}
		public MGFormSize()
		{
			this.StartPosition = FormStartPosition.CenterScreen;
			InitializeComponent();
			numericUpDown1.Value = 1440;
			numericUpDown2.Value = 810;
			numericUpDown1.ValueChanged += NumericUpDown_ValueChanged;
			numericUpDown2.ValueChanged += NumericUpDown_ValueChanged;
		}

		private void NumericUpDown_ValueChanged(object? sender, EventArgs e)
		{
			NumericUpDown? nm = (NumericUpDown?)sender;
			if(nm == null) return;
		}
	}
}
