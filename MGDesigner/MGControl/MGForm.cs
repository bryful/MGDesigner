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
	public enum MG_COLOR
	{
		White = 0,
		Black,
		Gray,
		Red,
		Green,
		Blue,
		Cyan,
		Yellow,
		Magenta,
		Orange,

		GrayDrak,
		RedDark,
		GreenDark,
		BlueDark,
		CyanDark,
		YellowDark,
		MagentaDark,
		OrangeDark,

		GrayLight,
		RedLight,
		GreenLight,
		BlueLight,
		CyanLight,
		YellowLight,
		MagentaLight,
		OrangeLight,
		C0,
		C1,
		C2,
		C3,
		C4,
		C5,
		C6,
		C7,
		C8,
		C9,
		ForeColor,
		BackColor,
		Transparent
	}
	public partial class MGForm : Form
	{
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
			InitColorC();
			SetEventHandler(this);
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
			Draw(pe.Graphics);
		}
		protected virtual void Draw(Graphics g)
		{
			SolidBrush sb = new SolidBrush(Color.Transparent);
			Pen p = new Pen(this.ForeColor, 2); 
			try
			{
				sb.Color = BackCol;
				g.FillRectangle(sb, this.ClientRectangle);

				if (m_GridWeight>0)
				{
					p.Color = (Color)GetColor(m_Grid,m_GridOpacity);
					p.Width = m_GridWeight;
					MG.Grid(g, p, m_GridWidth, m_GridHeight, this.ClientRectangle);
				}


				if(m_FrameWeight > 0)
				{
					p.Color = (Color)GetColor(m_Frame,m_FrameOpacity);
					MG.Frame(g, p, m_FrameWeight,this.ClientRectangle);
				}
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

		public void ChkCntrol()
		{
			string s = "";
			if(this.Controls.Count>0)
			{
				foreach(Control c in this.Controls)
				{
					if (s != "") s += "\r\n";
					if (c is MGPlate)
					{
						s += c.Name + "MGP";
					}
					else
					{
						s += c.Name + "None";
					}
				}
			}
			MessageBox.Show(s);
			
		}
		public Bitmap ExportMix()
		{
			Bitmap ret = CreateBitmap();
			Graphics g = Graphics.FromImage(ret);
			if (this.Controls.Count>0)
			{
				foreach (Control c in this.Controls)
				{
					if (c is MGPlate)
					{
						try
						{
							Bitmap b = ((MGPlate)c).CreateBitmap();
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
					if (c is MGPlate)
					{
						lst.Add(c);
					}
				}
			}
			int cnt = lst.Count+1;

			Bitmap formMG = CreateBitmap();
			string nn = $"{n}_{cnt:00}_{this.Name}.png";
			string sn = Path.Combine(d, nn);
			formMG.Save(sn,ImageFormat.Png);
			formMG.Dispose();
			cnt--;
			if(lst.Count > 0)
			{
				foreach(var c in lst)
				{
					Bitmap a = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppArgb);
					Graphics g = Graphics.FromImage(a);
					Bitmap b = ((MGPlate)c).CreateBitmap();
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
