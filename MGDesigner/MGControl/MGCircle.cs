﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace MGDesigner
{
	public partial class MGCircle : MGPlate
	{
		private int[] m_Radius = new int[] {100,50};
		[Category("_MG")]
		public int[] Radius
		{
			get { return m_Radius; }
			set
			{
				m_Radius = value;
				if (m_Radius.Length <= 0) m_Radius = new int[] { CRadius() };
				ChkCircle();
				this.Invalidate();
			}
		}
		private int[] m_Weight = new int[] {2, 2 };
		[Category("_MG")]
		public int[] Weight
		{
			get { return m_Weight; }
			set
			{
				m_Weight = value;
				if (m_Weight.Length <= 0) m_Weight = new int[] { 2 };
				ChkCircle();
				this.Invalidate();
			}
		}
		private Color[] m_Colors = new Color[] { Color.White,Color.White };
		[Category("_MG")]
		public Color[] Colors
		{
			get { return m_Colors; }
			set
			{
				m_Colors = value;
				if (m_Colors.Length <= 0) m_Colors = new Color[] { Color.White };

				this.Invalidate();
			}
		}
		private int CRadius()
		{
			int ret = this.Width / 2 - m_Weight[0] / 2;
			int h = this.Height / 2 - m_Weight[0] / 2;
			if (ret > h) ret = h;
			return ret;
		}
		public MGCircle()
		{
			InitializeComponent();
			ChkCircle();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkCircle();
			this.Invalidate();
		}
		private void ChkCircle()
		{
			int sr = m_Radius[0];
			int dr = CRadius();
			m_Radius[0] = dr;
			if(m_Radius.Length>1)
			{
				int a = dr - sr;
				for(int i=1; i< m_Radius.Length;i++) m_Radius[i] += a;
			}
			GraphicsPath path =new GraphicsPath();
			//丸を描く
			int mx = this.Width;
			if (mx > this.Height) mx = this.Height;
			mx /= 2;


			path.AddEllipse(new Rectangle(this.Width / 2 - mx, this.Height / 2 - mx, mx * 2, mx * 2));
			int mn = 5000;
			int idx = -1;
			int cnt = -1;
			if (m_Radius.Length >0)
			{

				foreach (int i in m_Radius)
				{
					if (mn > i)
					{
						idx = cnt;
						mn = i;
					}
					cnt++;
				}
			}
			if ((mn > 0)&&(cnt>=0))
			{
				if (cnt >= m_Weight.Length) cnt = m_Weight.Length - 1;
				mn -= m_Weight[cnt] / 2;
				path.AddEllipse(new Rectangle(this.Width / 2 - mn, this.Height / 2 - mn, mn * 2, mn * 2));
			}
			this.Region = new Region(path);
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Draw(pe.Graphics);
		}
		private Rectangle CircleRect(int r)
		{
			int cx = this.Width / 2;
			int cy = this.Height / 2;

			return new Rectangle(cx-r, cy-r, r*2, r*2);
		}
		protected override void Draw(Graphics g)
		{
			base.Draw(g);

			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			Pen p = new Pen(this.ForeColor);
			try
			{
				p.Color =m_Colors[0];
				p.Width = m_Weight[0];
				g.DrawEllipse(p, CircleRect(m_Radius[0]));

				if (m_Radius.Length > 1)
				{
					int idx = 0;
					for(int i=1; i < m_Radius.Length; i++)
					{
						int r = m_Radius[i];
						if ((r >= m_Radius[0])||(r<0)) continue;
						idx = i;
						if (idx >= m_Weight.Length) idx = m_Weight.Length - 1;
						int w = m_Weight[idx];
						idx = i;
						if (idx >= m_Colors.Length) idx = m_Colors.Length - 1;
						Color c = m_Colors[idx];
						p.Color = c;
						p.Width = w;
						g.DrawEllipse(p, CircleRect(r));

					}
				}

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
