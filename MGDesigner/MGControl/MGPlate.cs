using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;

namespace MGDesigner
{
	public partial class MGPlate : Control
	{
		public int MgTag = 100;

		private MGForm? m_MGForm = null;
		[Category("__MG")]
		public MGForm? MGForm
		{
			get { return m_MGForm; }
			set 
			{
				SetMGForm(value);
			}
		}
		public void SetMGForm(MGForm m)
		{
			m_MGForm = m;
			if(m_MGForm != null)
			{
				m_MGForm.ColorChangedEvent += Mgf_ColorChangedEvent;
				m_MGForm.Invalidate();
			}
			this.Invalidate();
		}

		private void Mgf_ColorChangedEvent(object? sender, EventArgs e)
		{
			this.Invalidate();
		}

		private MG_COLOR m_Back = MG_COLOR.Transparent;
		[Category("_MG")]
		public MG_COLOR Back
		{
			get { return m_Back; }
			set
			{
				m_Back = value;
				this.Invalidate();
			}
		}
		private double m_BackOpacity = 100;
		[Category("_MG")]
		public double BackOpacity
		{
			get { return m_BackOpacity; }
			set
			{
				m_BackOpacity = value;
				this.Invalidate();
			}
		}
		public Color GetMGColor(MG_COLOR mgc,Color def)
		{
			return GetMGColor(mgc,100,def);
		}
		public Color GetMGColor(MG_COLOR mgc,double opa,Color def)
		{
			Color ret = def;
			if (m_MGForm != null)
			{
				ret = (Color)m_MGForm.GetColor(mgc, ForeColor, BackColor,opa);
			}
			return ret;
		}
		// **************************************************************************
		public MGPlate()
		{
			this.Location = new Point(0, 0);
			this.Size = new Size(100, 100);
			InitializeComponent();
			Init();
		}
		// **************************************************************************
		public void Init()
		{

			this.SetStyle(
				ControlStyles.DoubleBuffer |
				ControlStyles.UserPaint |
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.SupportsTransparentBackColor,
				true);
			this.BackColor = Color.Transparent;
			this.ForeColor = Color.White;
			this.UpdateStyles();

		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Draw(pe.Graphics);
		}
		protected virtual void Draw(Graphics g)
		{
			SolidBrush sb = new SolidBrush(this.BackColor);
			try
			{

				sb.Color = GetMGColor(m_Back, m_BackOpacity,this.BackColor);
				g.CompositingMode = CompositingMode.SourceOver;
				g.FillRectangle(sb, this.ClientRectangle);

			}
			finally
			{
				sb.Dispose();
			}
		}
		public Bitmap CreateBitmap()
		{
			Bitmap bmp = new Bitmap(this.Width, this.Height,PixelFormat.Format32bppArgb);
			Graphics g = Graphics.FromImage(bmp);
			Draw(g);
			return bmp;
		}

	}
}
