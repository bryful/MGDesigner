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

	public partial class MGMainForm : Form
	{
		private List<MGControl> m_MGControls = new List<MGControl>();
		private string [] MGControlsName()
		{
			string [] ret = new string [m_MGControls.Count];
			if(m_MGControls.Count > 0)
			{
				int idx =0;
				foreach(var c in m_MGControls)
				{
					ret[idx] = c.Name;
					idx++;
				}
			}
			return ret;

		}
		private void SetMGControlsName(string[] ary)
		{
			List<MGControl> nowList = GetMGControls();
			if(nowList.Count != m_MGControls.Count)
			{
				m_MGControls = nowList;
			}
			if (m_MGControls.Count == 0) return;
			if (m_MGControls.Count != ary.Length) return;
			List<MGControl> newList = new List<MGControl>();

			for(int i=0; i < ary.Length; i++)
			{
				int idx = FindMGControls(ary[i]);
				if(idx>=0)
				{
					newList.Add(m_MGControls[idx]);
					m_MGControls.RemoveAt(idx);
				}
			}
			if(m_MGControls.Count>0)
			{
				newList.AddRange(m_MGControls);
			}
			m_MGControls = newList;
			DrawAll();
		}
		public void SetIndex(int s,int n)
		{
			if((s>=0) && (s<m_MGControls.Count)&& (n >= 0) && (n < m_MGControls.Count)&&(s!=n))
			{
				MGControl ss = m_MGControls[s];
				m_MGControls.RemoveAt(s);
				m_MGControls.Insert(n,ss);
				DrawAll();
			}
		}
		[Category("_MGForm")]
		public string[] MGControls
		{
			get { return MGControlsName(); }
			set 
			{
				SetMGControlsName(value);
			}
		}


		public int MGControlsCount() { return m_MGControls.Count; }
		public int FindMGControls(string n)
		{
			int ret = -1;
			if (m_MGControls.Count > 0)
			{
				for (int i = 0; i < m_MGControls.Count; i++)
				{
					if (m_MGControls[i].Name == n)
					{
						ret = i;
						break;
					}
				}
			}
			return ret;
		}
		public void SwapMGControls(int idx0,int idx1)
		{

		}
		private bool m_Anti = false;
		[Category("_MGForm")]
		public bool Anti
		{
			get { return m_Anti; }
			set
			{
				m_Anti = value;
				DrawAll();
			}
		}
		private MG_COLORS m_Back = MG_COLORS.BackColor;
		[Category("_MGForm")]
		public MG_COLORS Back
		{
			get { return m_Back; }
			set
			{
				m_Back = value;
				this.Invalidate();
			}
		}
		public MGMainForm()
		{
			this.FormBorderStyle = FormBorderStyle.None;
			InitializeComponent();
			Init();
			InitColor();
			SetEventHandler(this);
			ChkMGControls();
			this.ControlAdded += MGMainForm_ControlAdded;
			this.ControlRemoved += MGMainForm_ControlRemoved;
		}

		private void MGMainForm_ControlRemoved(object? sender, ControlEventArgs e)
		{
			List<MGControl> nowList = GetMGControls();

			for (int i = m_MGControls.Count - 1; i >= 0; i--)
			{
				int idx = -1;
				for (int j = nowList.Count - 1; j >= 0; j--)
				{
					if(m_MGControls[i].Name == nowList[j].Name)
					{
						idx = i;
						break;
					}
				}
				if (idx < 0)
				{
					m_MGControls.RemoveAt(i);
				}
			}
			this.Invalidate();
		}

		private void MGMainForm_ControlAdded(object? sender, ControlEventArgs e)
		{
			List<MGControl> nowList = GetMGControls();
			for(int i= nowList.Count-1; i>=0; i--)
			{
				int idx = FindMGControls(nowList[i].Name);
				if(idx<0)
				{
					m_MGControls.Add(nowList[i]);
					nowList[i].ChkOffScr();
				}
			}
			this.Invalidate();
		}

		public List<MGControl> GetMGControls()
		{
			List<MGControl> ret = new List<MGControl>();
			if(this.Controls.Count>0)
			{
				foreach(var c in this.Controls)
				{
					if(c is MGControl)
					{
						ret.Add((MGControl)c);
					}
				}
			}
			return ret;
		}

		public void InitControls()
		{
			m_MGControls = GetMGControls();
		}

		public void ChkMGControls()
		{
			List<MGControl> trueList = GetMGControls();
			int o = m_MGControls.Count;
			int n = trueList.Count;
			if((o==0))
			{
				m_MGControls = trueList;
			}
		}
		public void DrawAll()
		{
			if (m_MGControls.Count > 0)
			{
				foreach (var c in m_MGControls)
				{
					c.ChkOffScr();
				}
			}
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

		}
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
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if(m_MGControls.Count>0)
			{
				foreach(MGControl s in m_MGControls)
				{
					s.SetControlPos();
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
			this.UpdateZOrder();
			//base.OnPaint(pe);
			Graphics g = pe.Graphics;
			if (m_Anti==false)
			{
				g.SmoothingMode = SmoothingMode.AntiAlias;
			}
			SolidBrush sb = new SolidBrush(Color.Transparent);
			Pen p = new Pen(this.ForeColor, 2);
			try
			{

				sb.Color = GetMG_Colors(m_Back);
				g.FillRectangle(sb, this.ClientRectangle);
				if(m_MGControls.Count>0)
				{
					foreach(var c in m_MGControls)
					{
						if(c is MGControl)
						{
							DrawControl(g, (MGControl)c);
						}
					}
				}
			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}

		}
		private void DrawControl(Graphics g, MGControl mc)
		{
			GraphicsPath path = new GraphicsPath();
			path.AddRectangle(this.ClientRectangle);
			Region region = new Region(path);
			g.SetClip(region, CombineMode.Replace);
			if (mc.IsFull)
			{
				mc.Draw(g, this.ClientRectangle,false);
			}
			else
			{
				g.DrawImage(mc.OffScr, mc.Location);
			}
		}
	}
}
