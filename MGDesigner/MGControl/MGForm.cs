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
	public enum FormDrawStyle
	{
		Frame = 0,
		Grid,
		Edge,
		Kagi
	}
	public partial class MGForm : Form
	{
		public event EventHandler? AntiChangeEvent;
		protected virtual void OnAntiChangeEvent(EventArgs e)
		{
			if (AntiChangeEvent != null)
			{
				AntiChangeEvent(this, e);
			}
		}
		private bool m_Anti = false;
		[Category("_MG")]
		public bool Anti
		{
			get { return m_Anti; }
			set
			{
				m_Anti = value;
				OnAntiChangeEvent(EventArgs.Empty);
				this.Invalidate();
			}
		}

		private MG_COLOR m_Back = MG_COLOR.BackColor;
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
		private Color BackCol
		{
			get
			{
				return (Color)GetColor(m_Back, this.ForeColor, this.BackColor,100);
			}

		}
		public MGForm()
		{
			this.FormBorderStyle = FormBorderStyle.None;
			InitializeComponent();
			Init();
			InitColor();
			SetEventHandler(this);
			SetMGNone(this, this);
		}

		public void Init()
		{

			this.SetStyle(
				ControlStyles.DoubleBuffer |
				ControlStyles.UserPaint |
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.SupportsTransparentBackColor,
				true);
			this.BackColor = Color.Black;
			this.ForeColor = Color.White;
			this.UpdateStyles();

		}       /// <summary>
				/// 子コントロールにMouseイベントハンドラを設定(再帰)
				/// </summary>
		public void SetEventHandler(Control objControl)
		{
			// イベントの設定
			// (親フォームにはすでにデザイナでマウスのイベントハンドラが割り当ててあるので除外)
			if (objControl != this)
			{
				objControl.MouseDown += (sender, e) => this.OnMouseDown(e);
				objControl.MouseMove += (sender, e) => this.OnMouseMove(e);
				objControl.MouseUp += (sender, e) => this.OnMouseUp(e);
			}

			// さらに子コントロールを検出する
			if (objControl.Controls.Count > 0)
			{
				foreach (Control objChildControl in objControl.Controls)
				{
					SetEventHandler(objChildControl);
				}
			}

		}
		public void SetMGNone(Control ctrl,MGForm mg)
		{
			if(ctrl is MGNone)
			{
				if (((MGNone)ctrl).MGForm == null)
					((MGNone)ctrl).MGForm = mg;
			}
			if (ctrl.Controls.Count > 0)
			{
				foreach (Control c in ctrl.Controls)
				{
					SetMGNone(c,mg);
				}
			}
		}
		private Point m_MD = new Point(0, 0);
		private int m_MD_Mode = 0;
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				m_MD_Mode = 1;
				m_MD = e.Location;
			}
			base.OnMouseDown(e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				int ax = e.X - m_MD.X;
				int ay = e.Y - m_MD.Y;
				if (m_MD_Mode == 1)
				{
					this.Location = new Point(ax + this.Left, ay + this.Top);
				}
			}
			base.OnMouseMove(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (m_MD_Mode != 0)
			{
				m_MD_Mode = 0;
				this.Invalidate();
			}
			base.OnMouseUp(e);
		}


		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
			Graphics g = pe.Graphics;
			if(m_Anti)
			{
				g.SmoothingMode = SmoothingMode.AntiAlias;
			}
			Draw(g);
		}
		// *****************************************************************
		private void DrawFrame(Graphics g,Pen p,Rectangle r)
		{
			if ((m_FrameWeight > 0)&&(m_Frame!=MG_COLOR.Transparent))
			{
				p.Color = (Color)GetColor(m_Frame, m_FrameOpacity);
				MG.Frame(g, p, m_FrameWeight, r);
			}
		}
		// *****************************************************************
		private void DrawGrid(Graphics g, Pen p, Rectangle r)
		{
			if ((m_GridWeight > 0)&&(m_Grid!=MG_COLOR.Transparent))
			{
				p.Color = (Color)GetColor(m_Grid, m_GridOpacity);
				p.Width = m_GridWeight;
				MG.Grid(g, p, m_GridWidth, m_GridHeight, r);
			}
		}
		// *****************************************************************
		private void DrawEdge(Graphics g, SolidBrush sb, Rectangle r)
		{

			if ((m_EdgeOpacity > 0)&&(m_Edge!=MG_COLOR.Transparent))
			{
				sb.Color = (Color)GetColor(m_Edge, m_EdgeOpacity);

				MG.Edge(g, sb,
					r,
					new SizeF(m_EdgeWidth, m_EdgeHeight),
					m_EdgeHorMargin,
					m_EdgeVurMargin
					);
			}
		}
		// *****************************************************************
		private void DrawKagi(Graphics g, SolidBrush sb, Rectangle r)
		{

			if ((m_KagiOpacity > 0)&&(m_Kagi!=MG_COLOR.Transparent))
			{
				sb.Color = (Color)GetColor(m_Kagi, m_KagiOpacity);
				MGDrawKagi kagi = new MGDrawKagi();
				kagi.KagiWidth = m_kagiWidth;
				kagi.KagiHeight = m_kagiHeight;
				kagi.KagiWeightH = m_kagiWeightH;
				kagi.KagiWeightV = m_kagiWeightV;
				kagi.DrawEdge(g, sb, r, m_KagiEnabled, m_kagiMarginH, m_kagiMarginV);
			}
		}
		// *****************************************************************
		protected virtual void Draw(Graphics g)
		{
			SolidBrush sb = new SolidBrush(Color.Transparent);
			Pen p = new Pen(this.ForeColor, 2); 
			try
			{
				sb.Color = BackCol;
				g.FillRectangle(sb, this.ClientRectangle);

				DrawGrid(g, p, this.ClientRectangle);
				DrawEdge(g, sb, this.ClientRectangle);
				DrawKagi(g, sb, this.ClientRectangle);
				DrawFrame(g, p, this.ClientRectangle);
			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}
		}
		private Bitmap CreateBitmapBase()
		{
			Bitmap bmp = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppArgb);
			Graphics g = Graphics.FromImage(bmp);
			
			SolidBrush sb = new SolidBrush(Color.Transparent);
			try
			{
				sb.Color = BackCol;
				g.FillRectangle(sb, this.ClientRectangle);
			}
			finally
			{
				sb.Dispose();
			}
			return bmp;
		}
		public Bitmap CreateBitmap()
		{
			Bitmap bmp = CreateBitmapBase();
			Graphics g = Graphics.FromImage(bmp);
			if (m_Anti) g.SmoothingMode = SmoothingMode.AntiAlias;
			
			SolidBrush sb = new SolidBrush(Color.Transparent);
			Pen p = new Pen(this.ForeColor, 2);
			try
			{
				DrawGrid(g, p, this.ClientRectangle);
				DrawEdge(g, sb, this.ClientRectangle);
				DrawKagi(g, sb, this.ClientRectangle);
				DrawFrame(g, p, this.ClientRectangle);
			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}
			return bmp;
		}
		public Bitmap CreateBitmapGrid()
		{
			Bitmap bmp = CreateBitmapBase();
			Graphics g = Graphics.FromImage(bmp);
			if (m_Anti) g.SmoothingMode = SmoothingMode.AntiAlias;

			Pen p = new Pen(this.ForeColor, 2);
			try
			{
				DrawGrid(g, p, this.ClientRectangle);
			}
			finally
			{
				p.Dispose();
			}
			return bmp;
		}
		public Bitmap CreateBitmapEdge()
		{
			Bitmap bmp = CreateBitmapBase();
			Graphics g = Graphics.FromImage(bmp);
			if (m_Anti) g.SmoothingMode = SmoothingMode.AntiAlias;

			SolidBrush sb = new SolidBrush(Color.Transparent);
			try
			{
				DrawEdge(g, sb, this.ClientRectangle);
			}
			finally
			{
				sb.Dispose();
			}
			return bmp;
		}
		public Bitmap CreateBitmapKagi()
		{
			Bitmap bmp = CreateBitmapBase();
			Graphics g = Graphics.FromImage(bmp);
			if (m_Anti) g.SmoothingMode = SmoothingMode.AntiAlias;
			SolidBrush sb = new SolidBrush(Color.Transparent);
			try
			{
				DrawKagi(g, sb, this.ClientRectangle);
			}
			finally
			{
				sb.Dispose();
			}
			return bmp;
		}
		public Bitmap CreateBitmapFrame()
		{
			Bitmap bmp = CreateBitmapBase();
			Graphics g = Graphics.FromImage(bmp);
			if (m_Anti) g.SmoothingMode = SmoothingMode.AntiAlias;

			Pen p = new Pen(this.ForeColor, 2);
			try
			{
				DrawFrame(g, p, this.ClientRectangle);
			}
			finally
			{
				p.Dispose();
			}
			return bmp;
		}
		public Bitmap ExportMix()
		{
			Bitmap ret = CreateBitmap();
			Graphics g = Graphics.FromImage(ret);
			if (this.Controls.Count>0)
			{
				foreach (Control c in this.Controls)
				{
					if (c is MGNone)
					{
						try
						{
							Bitmap b = ((MGNone)c).CreateBitmap();
							g.DrawImage(b, c.Location);
							b.Dispose();
						}
						catch
						{

						}
					}
				}
			}
			return ret;
		}
		public bool ExportMixToFile(string p)
		{
			bool ret = false;
			string n = p;
			if(n=="") return ret;
			string ext = Path.GetExtension(p).ToLower();
			if (ext != ".png")
			{
				p = Path.ChangeExtension(p, ".png");
			}
			Bitmap img = ExportMix();
			try
			{
				img.Save(n, ImageFormat.Png);
				ret = File.Exists(n);
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		public bool ExportMixToFile()
		{
			bool ret = false;
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "*.png|*.png|*.*|*.*";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				ret = ExportMixToFile(dlg.FileName);
			}
			return ret;
		}
		public bool ExportPartsToFile(string p)
		{
			bool ret = false;
			string p2 = p;
			string d = Path.GetDirectoryName(p2);
			string n = Path.GetFileNameWithoutExtension(p2);

			List<Control> lst = new List<Control>();
			if (this.Controls.Count > 0)
			{
				foreach (Control c in this.Controls)
				{
					if (c is MGNone)
					{
						lst.Add(c);
					}
				}
			}
			int cnt = lst.Count+2;

			Bitmap formMG = CreateBitmapBase();
			string nn = $"{n}_{cnt:00}_{this.Name}.png";
			string sn = Path.Combine(d, nn);
			formMG.Save(sn,ImageFormat.Png);
			formMG.Dispose();
			cnt--;

			Bitmap formMG2 = CreateBitmapGrid();
			nn = $"{n}_{cnt:00}_{this.Name}.png";
			sn = Path.Combine(d, nn);
			formMG2.Save(sn, ImageFormat.Png);
			formMG2.Dispose();
			cnt--;


			Bitmap formMG3 = CreateBitmapEdge();
			nn = $"{n}_{cnt:00}_{this.Name}.png";
			sn = Path.Combine(d, nn);
			formMG3.Save(sn, ImageFormat.Png);
			formMG3.Dispose();
			cnt--;

			Bitmap formMG4 = CreateBitmapKagi();
			nn = $"{n}_{cnt:00}_{this.Name}.png";
			sn = Path.Combine(d, nn);
			formMG4.Save(sn, ImageFormat.Png);
			formMG4.Dispose();
			cnt--;

			Bitmap formMG5 = CreateBitmapFrame();
			nn = $"{n}_{cnt:00}_{this.Name}.png";
			sn = Path.Combine(d, nn);
			formMG5.Save(sn, ImageFormat.Png);
			formMG5.Dispose();
			cnt--;

			if (lst.Count > 0)
			{
				foreach(var c in lst)
				{
					Bitmap a = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppArgb);
					Graphics g = Graphics.FromImage(a);
					Bitmap b = ((MGNone)c).CreateBitmap();
					g.DrawImage(b,c.Location);
					nn = $"{n}_{cnt:00}_{c.Name}.png";
					sn = Path.Combine(d, nn);
					a.Save(sn, ImageFormat.Png);
					cnt--;
					a.Dispose();
					b.Dispose();
				}
			}
			return ret;
		}
		public bool ExportPartsToFile()
		{
			bool ret = false;
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "*.png|*.png|*.*|*.*";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				ret = ExportPartsToFile(dlg.FileName);
			}
			return ret;
		}
	}
}
