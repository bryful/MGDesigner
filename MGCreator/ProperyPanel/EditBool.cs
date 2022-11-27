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
	public class BoolValueChangedEventArgs : EventArgs
	{
		public bool BoolValue = false;
		public BoolValueChangedEventArgs(bool b)
		{
			BoolValue = b;
		}
	}
	public partial class EditBool : Edit
	{
		public delegate void BoolValueChangedHandler(object sender, BoolValueChangedEventArgs e);
		public event BoolValueChangedHandler? BoolValueChanged;
		protected virtual void OnBoolValueChanged(BoolValueChangedEventArgs e)
		{
			if (BoolValueChanged != null)
			{
				BoolValueChanged(this, e);
			}
		}
		//public new readonly MGStyle MGStyle = MGStyle.ALL;
		// ****************************************************************************
		protected bool m_BoolValue = false;
		public bool BoolValue
		{
			get { return m_BoolValue; }
			set 
			{
				if(m_BoolValue != value)
				{
					m_BoolValue = value;
					OnBoolValueChanged(new BoolValueChangedEventArgs(m_BoolValue));
				}
				this.Invalidate();
			}
		}
		// **********************************************************

		public EditBool()
		{
			this.Size = new Size(180, 20);
			this.MinimumSize = new Size(220, 20);
			this.MaximumSize = new Size(0, 20);
			Caption = "Bool";
			InitializeComponent();
			ChkSize();
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			Pen p = new Pen(this.ForeColor);
			SolidBrush sb = new SolidBrush(this.BackColor);
			Graphics g = pe.Graphics;
			try
			{
				Rectangle r = new Rectangle(m_CaptionWidth, 0, this.Width - m_CaptionWidth, this.Height);
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
				sb.Color = this.ForeColor;

				g.DrawString($"{m_BoolValue.ToString()}", this.Font, sb, r, sf);
			}
			finally
			{
				p.Dispose();
				sb.Dispose();
			}


		}
		public void ChkSize()
		{
			//this.SuspendLayout();
			//this.ResumeLayout();
			this.Invalidate();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{ 
			if (e.X > m_CaptionWidth)
			{
				_EventFLag = false;
				BoolValue = !BoolValue;
				_EventFLag = true;
			}
			base.OnMouseDown(e);
		}

	}
}
