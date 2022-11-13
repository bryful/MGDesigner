using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGDesigner
{
	public partial class MGKagiEdge : MGPlate
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
		private bool[] m_KagiEnabled = new bool[] { true, true, true, true };
		[Category("_MG")]
		public bool[] KagiEnabled
		{
			get { return m_KagiEnabled; }
			set
			{
				if (value.Length > 0) m_KagiEnabled[0] = value[0];
				if (value.Length > 1) m_KagiEnabled[1] = value[1];
				if (value.Length > 2) m_KagiEnabled[2] = value[2];
				if (value.Length > 3) m_KagiEnabled[3] = value[3];
				ChkRegion();
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
		private int m_kagiWidth = 30;
		[Category("_MG")]
		public int kagiWidth
		{
			get { return m_kagiWidth; }
			set
			{
				m_kagiWidth = value;
				ChkRegion();
				this.Invalidate();
			}
		}
		private int m_kagiHeight = 30;
		[Category("_MG")]
		public int kagiHeight
		{
			get { return m_kagiHeight; }
			set
			{
				m_kagiHeight = value;
				ChkRegion();
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
				ChkRegion();
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
				ChkRegion();
				this.Invalidate();
			}
		}
		private int m_kagiMarginH = 20;
		[Category("_MG")]
		public int kagiMarginH
		{
			get { return m_kagiMarginH; }
			set
			{
				m_kagiMarginH = value;
				ChkRegion();
				this.Invalidate();
			}
		}
		private int m_kagiMarginV = 20;
		[Category("_MG")]
		public int kagiMarginV
		{
			get { return m_kagiMarginV; }
			set
			{
				m_kagiMarginV = value;
				ChkRegion();
				this.Invalidate();
			}
		}
		public MGKagiEdge()
		{
			InitializeComponent();
			ChkRegion();
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Draw(pe.Graphics);
		}
		private void ChkRegion()
		{
			MGDrawKagi kagi = new MGDrawKagi();
			kagi.KagiWidth = m_kagiWidth;
			kagi.KagiHeight = m_kagiHeight;
			kagi.KagiWeightH = m_kagiWeightH;
			kagi.KagiWeightV = m_kagiWeightV;
			this.Region = kagi.KagiEdgeRegion(this.ClientRectangle, m_KagiEnabled, m_kagiMarginH, m_kagiMarginV);

		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkRegion();
		}
		protected override void Draw(Graphics g)
		{
			base.Draw(g);

			Color c = GetMGColor(m_Kagi, m_KagiOpacity, this.ForeColor);
			SolidBrush sb = new SolidBrush(c);
			try
			{
				MGDrawKagi kagi = new MGDrawKagi();
				kagi.KagiWidth = m_kagiWidth;
				kagi.KagiHeight = m_kagiHeight;
				kagi.KagiWeightH = m_kagiWeightH;
				kagi.KagiWeightV = m_kagiWeightV;
				kagi.DrawEdge(g, sb, this.ClientRectangle, m_KagiEnabled, m_kagiMarginH, m_kagiMarginV);
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
