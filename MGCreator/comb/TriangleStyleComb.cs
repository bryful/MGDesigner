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
    public partial class TriangleStyleComb : ComboBox
	{
		public class ValueChangedEventArgs : EventArgs
		{
			public TriangleStyle Value;
			public ValueChangedEventArgs(TriangleStyle v)
			{
				Value = v;
			}
		}
		public delegate void ValueChangedHandler(object sender, ValueChangedEventArgs e);
		public event ValueChangedHandler? ValueChanged;
		protected virtual void OnValueChanged(ValueChangedEventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}
		[Category("_MG")]
		public TriangleStyle TrainglrStyle
		{
			get
			{
				if (SelectedIndex >= 0)
				{
					return (TriangleStyle)SelectedIndex;

				}
				else
				{
					return TriangleStyle.Center;
				}
			}
			set
			{
				int idx =(int)value;
				if((idx>=0) && (idx<Items.Count))
				{
					if (SelectedIndex != idx)
					{
						SelectedIndex = idx;
					}
				}
			}
		}
		public TriangleStyleComb()
		{
			this.BackColor = Color.FromArgb(40, 40, 40);
			this.ForeColor = Color.LightGray;
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
		protected override void InitLayout()
		{
			base.InitLayout();
			DropDownStyle = ComboBoxStyle.DropDownList;
			Items.Clear();
			Items.AddRange(Enum.GetNames(typeof(TriangleStyle)));
			SelectedIndex = (int)TriangleStyle.Center;
		}
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			base.OnSelectedIndexChanged(e);
			if (SelectedIndex >= 0)
			{
				OnValueChanged(new ValueChangedEventArgs((TriangleStyle)SelectedIndex));
			}
		}
	}
}
