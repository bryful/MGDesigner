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
	public partial class MGNone : Control
	{
		public int MgTag = 100;

		private MGForm? m_MGForm = null;
		private bool m_Anti = false;
		[Category("_MG")]
		public bool Anti
		{
			get { return m_Anti; }
			set
			{
				m_Anti = value;
				this.Invalidate();
			}
		}
		[Category("_MG")]
		public PointF CenterPos
		{
			get 
			{
				float x = (float)this.Left + (float)this.Width / 2;
				float y = (float)this.Top + (float)this.Height / 2;
				return new PointF(x,y); 
			}
			set
			{
				float x = value.X - (float)this.Width / 2;
				float y = value.Y - (float)this.Height / 2;
				this.Location = new Point((int)x, (int)y);
			}
		}
		[Category("_MG")]
		public float CenterX
		{
			get
			{
				return (float)this.Left + (float)this.Width / 2;
			}
			set
			{
				float x = value - (float)this.Width / 2;
				this.Location = new Point((int)x, this.Top);
			}
		}
		[Category("_MG")]
		public float CenterY
		{
			get
			{
				return (float)this.Top + (float)this.Height / 2;
			}
			set
			{
				float y = value - (float)this.Height / 2;
				this.Location = new Point(this.Left, (int)y);
			}
		}

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
				m_Anti = m.Anti;
				m_MGForm.ColorChangedEvent += Mgf_ColorChangedEvent;
				m_MGForm.AntiChangeEvent += M_MGForm_AntiChangeEvent;
				m_MGForm.Invalidate();
			}
			this.Invalidate();
		}

		private void M_MGForm_AntiChangeEvent(object? sender, EventArgs e)
		{
			if (m_MGForm != null)
			{
				m_Anti = m_MGForm.Anti;
				this.Invalidate();
			}
		}

		private void Mgf_ColorChangedEvent(object? sender, EventArgs e)
		{
			this.Invalidate();
		}

		/*
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
		*/
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
		public MGNone()
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
			Graphics g = pe.Graphics;
			if (m_Anti) g.SmoothingMode = SmoothingMode.AntiAlias;
			Draw(g);
		}
		public void ClearFill(Graphics g)
		{

			SolidBrush sb = new SolidBrush(Color.Transparent);
			try
			{
				g.FillRectangle(sb, this.ClientRectangle);

			}
			finally
			{
				sb.Dispose();
			}
		}
		protected virtual void Draw(Graphics g)
		{
			ClearFill(g);
		}
		public Bitmap CreateBitmap()
		{
			Bitmap bmp = new Bitmap(this.Width, this.Height,PixelFormat.Format32bppArgb);
			Graphics g = Graphics.FromImage(bmp);
			if (m_Anti) g.SmoothingMode = SmoothingMode.AntiAlias;
			Draw(g);
			return bmp;
		}

	}
}
