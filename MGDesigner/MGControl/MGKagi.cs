using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGDesigner
{
	public partial class MGKagi : MGNone
	{
		private MG_COLOR m_Kagi = MG_COLOR.White;
		[Category("_MG")]
		public MG_COLOR Kagi
		{
			get { return m_Kagi; }
			set
			{
				m_Kagi = value;
				this.Invalidate();
			}
		}
		private double m_KagiOpacity = 100;
		[Category("_MG")]
		public double KagiOpacity
		{
			get { return m_KagiOpacity; }
			set
			{
				m_KagiOpacity = value;
				this.Invalidate();
			}
		}
		private int m_kagiWeightH = 5;
		[Category("_MG")]
		public int kagiWeightH
		{
			get { return m_kagiWeightH; }
			set
			{
				m_kagiWeightH = value;
				chkKagi();
				this.Invalidate();
			}
		}
		private int m_kagiWeightV = 5;
		[Category("_MG")]
		public int kagiWeightV
		{
			get { return m_kagiWeightV; }
			set
			{
				m_kagiWeightV = value;
				chkKagi();
				this.Invalidate();
			}
		}
		private KagiStyle m_kagiStyle = KagiStyle.BottomLeft;
		[Category("_MG")]
		public KagiStyle kagiStyle
		{
			get { return m_kagiStyle; }
			set
			{
				SetKagi(value);
			}
		}
		public MGKagi()
		{
			InitializeComponent();
		}
		private void chkKagi()
		{
			MGDrawKagi kagi = new MGDrawKagi();
			kagi.KagiWidth = this.Width;
			kagi.KagiHeight = this.Height;
			kagi.KagiWeightH = m_kagiWeightH;
			kagi.KagiWeightV = m_kagiWeightV;
			Point p;
			switch (m_kagiStyle)
			{
				case KagiStyle.TopRight:
					p = new Point(this.Width, 0);
					break;
				case KagiStyle.BottomRight:
					p = new Point(this.Width, this.Height);
					break;
				case KagiStyle.BottomLeft:
					p = new Point(0, this.Height);
					break;
				case KagiStyle.TopLeft:
				default:
					p = new Point(0, 0);
					break;

			}
			this.Region = kagi.KagiRegion(p,m_kagiStyle);

		}
		private void SetKagi(KagiStyle ks)
		{
			m_kagiStyle = ks;
			chkKagi();
			this.Invalidate();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			chkKagi();
			this.Invalidate();
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Draw(pe.Graphics);
		}
		protected override void Draw(Graphics g)
		{
			base.Draw(g);

			Color c = GetMGColor(m_Kagi, m_KagiOpacity, this.ForeColor);
			SolidBrush sb = new SolidBrush(c);
			try
			{
				sb.Color = c;
				MGDrawKagi kagi = new MGDrawKagi();
				kagi.KagiWidth = this.Width;
				kagi.KagiHeight = this.Height;
				kagi.KagiWeightH = m_kagiWeightH;
				kagi.KagiWeightV = m_kagiWeightV;
				Point p;
				switch (m_kagiStyle)
				{
					case KagiStyle.TopRight:
						p = new Point(this.Width, 0);
						break;
					case KagiStyle.BottomRight:
						p = new Point(this.Width, this.Height);
						break;
					case KagiStyle.BottomLeft:
						p = new Point(0, this.Height);
						break;
					case KagiStyle.TopLeft:
					default:
						p = new Point(0, 0);
						break;

				}
				kagi.Draw(g, sb, p, m_kagiStyle);

			}
			catch
			{
				MessageBox.Show("a");
			}
			finally
			{
				sb.Dispose();
			}
		}
	}
}

