using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGDesigner
{


	public partial class MGFrame : MGPlate
	{
		private MG_COLOR m_Frame = MG_COLOR.White;
		[Category("_MG")]
		public MG_COLOR Frame
		{
			get { return m_Frame; }
			set
			{
				m_Frame = value;
				this.Invalidate();
			}
		}
		private int m_FrameWeight = 2;
		[Category("_MG")]
		public int FrameWeight
		{
			get { return m_FrameWeight; }
			set
			{
				m_FrameWeight = value;
				this.Invalidate();
			}
		}
		private double m_FrameOpacity = 100;
		[Category("_MG")]
		public double FrameOpacity
		{
			get { return m_FrameOpacity; }
			set
			{
				m_FrameOpacity = value;
				this.Invalidate();
			}
		}
		public MGFrame()
		{
			InitializeComponent();
			Back = MG_COLOR.Transparent;
		}
		
		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Draw(pe.Graphics);
		}
		
		protected override void Draw(Graphics g)
		{
			base.Draw(g);

			Color c = GetMGColor(m_Frame, m_FrameOpacity, this.ForeColor);
			Debug.WriteLine(c.ToString());
			Pen p = new Pen(c);
			try
			{
				p.Color = c;
				MG.Frame(g, p, m_FrameWeight, this.ClientRectangle);
			}
			catch
			{
				MessageBox.Show("a");
			}
			finally
			{
				p.Dispose();
			}
		}
		
	}
}
