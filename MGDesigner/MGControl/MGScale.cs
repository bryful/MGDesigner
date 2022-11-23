using Microsoft.VisualBasic;
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
	public enum MGScaleType
	{
		Vur,
		Left,
		Right,
		Hor,
		Top,
		Bottom
	};
	public partial class MGScale : MGControl
	{
		private MGScale? m_MGScale = null;
		[Category("_MG_Scale")]
		public MGScale? MGScale_
		{
			get { return m_MGScale; }
			set
			{
				if(m_MGScale == this) return;
				m_MGScale = value;
				if(m_MGScale != null)
				{
					SetLocSize();
					m_MGScale.LocationChanged += M_MGScale_LocationChanged;
					m_MGScale.Resize += M_MGScale_LocationChanged;
				}
			}
		}
		private void SetLocSize()
		{
			if (m_MGScale == null) return;

			ScaleType = m_MGScale.ScaleType;
			float cx = m_MGScale.Left + m_MGScale.Width / 2;
			float cy = m_MGScale.Top + m_MGScale.Height / 2;

			Point p;
			switch(m_ScaleStlye)
			{
				case MGScaleType.Vur:
				case MGScaleType.Hor:
					p = new Point(
						(int)(cx - this.Width / 2),
						(int)(cy - this.Height / 2)
						);
					break;
				case MGScaleType.Right:
					p = new Point(
						(int)(m_MGScale.Right-this.Width),
						(int)(cy - this.Height / 2)
						);
					break;
				case MGScaleType.Left:
					p = new Point(
						(int)(m_MGScale.Left),
						(int)(cy - this.Height / 2)
						);
					break;
				case MGScaleType.Top:
					p = new Point(
						(int)(cx - this.Width / 2),
						(int)(m_MGScale.Top)
						);
					break;
				case MGScaleType.Bottom:
					p = new Point(
						(int)(cx - this.Width / 2),
						(int)(m_MGScale.Bottom -this.Height)
						);
					break;
					default:
					return;
			}
			if (p != this.Location) this.Location = p;

		}
		private void SetLocSizeParent()
		{
			if (m_MGScale == null) return;

			ScaleType = m_MGScale.ScaleType;
			float cx = this.Left + m_MGScale.Width / 2;
			float cy = this.Top + m_MGScale.Height / 2;

			Point p;
			switch (m_ScaleStlye)
			{
				case MGScaleType.Vur:
				case MGScaleType.Hor:
					p = new Point(
						(int)(cx - m_MGScale.Width / 2),
						(int)(cy - m_MGScale.Height / 2)
						);
					break;
				case MGScaleType.Right:
					p = new Point(
						(int)(this.Right - m_MGScale.Width),
						(int)(cy - m_MGScale.Height / 2)
						);
					break;
				case MGScaleType.Left:
					p = new Point(
						(int)(this.Left),
						(int)(cy - m_MGScale.Height / 2)
						);
					break;
				case MGScaleType.Top:
					p = new Point(
						(int)(cx - m_MGScale.Width / 2),
						(int)(this.Top)
						);
					break;
				case MGScaleType.Bottom:
					p = new Point(
						(int)(cx - m_MGScale.Width / 2),
						(int)(this.Bottom - m_MGScale.Height)
						);
					break;
				default:
					return;
			}
			if (m_MGScale.Location != p) m_MGScale.Location = p;

		}
		private void M_MGScale_LocationChanged(object? sender, EventArgs e)
		{
			SetLocSize();
		}

		private MGScaleType m_ScaleStlye = MGScaleType.Left;
		[Category("_MG_Scale")]
		public MGScaleType ScaleType
		{
			get { return m_ScaleStlye; }
			set
			{
				m_ScaleStlye = value;
				ChkOffScr();
			}
		}
		private float m_Offset = 0;
		[Category("_MG_Scale")]
		public float Offset
		{
			get { return m_Offset; }
			set
			{
				m_Offset = value;
				ChkOffScr();
			}
		}
		private float m_Inter = 40;
		[Category("_MG_Scale")]
		public float Inter
		{
			get { return m_Inter; }
			set
			{
				if(value < 0)value = 0;
				m_Inter = value;
				ChkOffScr();
			}
		}
		private float m_Weight = 4;
		[Category("_MG_Scale")]
		public float Weight
		{
			get { return m_Weight; }
			set
			{
				if (value < 0) value = 0;
				m_Weight = value;
				ChkOffScr();
			}
		}
		private float m_WeightH = 2;
		[Category("_MG_Scale")]
		public float WeightH
		{
			get { return m_WeightH; }
			set
			{
				if (value < 0) value = 0;
				m_WeightH = value;
				ChkOffScr();
			}
		}
		private float m_Length = 20;
		[Category("_MG_Scale")]
		public float Length
		{
			get { return m_Length; }
			set
			{
				if (value < 0) value = 0;
				m_Length = value;
				ChkOffScr();
			}
		}
		private float m_LengthHPer = 0.5f;
		[Category("_MG_Scale")]
		public float LengthHPer
		{
			get { return m_LengthHPer; }
			set
			{
				if (value < 0) value = 0;
				m_LengthHPer = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_ScaleColor = MG_COLORS.White;
		[Category("_MG_Scale")]
		public MG_COLORS ScaleColor
		{
			get { return m_ScaleColor; }
			set
			{
				m_ScaleColor = value;
				ChkOffScr();
			}
		}
		private MG_COLORS m_ScaleColorH = MG_COLORS.GrayLight;
		[Category("_MG_Scale")]
		public MG_COLORS ScaleColorH
		{
			get { return m_ScaleColorH; }
			set
			{
				m_ScaleColorH = value;
				ChkOffScr();
			}
		}
		public MGScale()
		{
			InitializeComponent();
		}
		protected override void OnLocationChanged(EventArgs e)
		{
			if (m_MGScale != null)
			{
				//SetLocSizeParent();
			}
			base.OnLocationChanged(e);
		}
		protected override void OnResize(EventArgs e)
		{
			if (m_MGScale != null)
			{
				SetLocSize();
			}
			base.OnResize(e);
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			//base.OnPaint(pe);
		}
		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{
			//base.Draw(g, rct, IsClear);
			Color cl = GetMG_Colors(m_ScaleColor, 100);
			Color ch = GetMG_Colors(m_ScaleColorH, 100);
			Pen p = new Pen(cl);
			try
			{
				if(IsClear)g.Clear(Color.Transparent);
				Rectangle rct2 = MarginRect(rct);
				float cx = (float)rct2.Left + (float)rct.Width / 2;
				float cy = (float)rct2.Top + (float)rct.Height / 2;
				float x, y;
				float len = m_Length;
				float lenH = m_Length *m_LengthHPer;
				int cnt = 0;
				float interH = m_Inter / 2;
				switch(m_ScaleStlye)
				{
					case MGScaleType.Vur:
						if (len <= 0) len = rct2.Width;
						lenH = len * m_LengthHPer;

						y = cy + m_Offset;
						p.Width = m_Weight;
						g.DrawLine(p, cx - len/2, y, cx + len / 2, y) ;
						cnt=1;
						y = cy - interH + m_Offset;
						while (y>=rct2.Top)
						{
							if(cnt%2==0)
							{
								p.Color = cl;
								p.Width = m_Weight;
								g.DrawLine(p, cx - len / 2, y, cx + len / 2, y);
							}
							else
							{
								if(m_WeightH>0)
								{
									p.Color = ch;
									p.Width = m_WeightH;
									g.DrawLine(p, cx - lenH / 2, y, cx + lenH / 2, y);
								}
							}
							cnt++;
							y -= interH;
						}
						cnt = 1;
						y = cy + interH + m_Offset;
						while (y < rct2.Bottom)
						{
							if (cnt % 2 == 0)
							{
								p.Color = cl;
								p.Width = m_Weight;
								g.DrawLine(p, cx - len / 2, y, cx + len / 2, y);
							}
							else
							{
								if (m_WeightH > 0)
								{
									p.Color = ch;
									p.Width = m_WeightH;
									g.DrawLine(p, cx - lenH / 2, y, cx + lenH / 2, y);
								}
							}
							cnt++;
							y += interH;
						}
						break;
					case MGScaleType.Left:
						if (len <= 0) len = rct2.Width;
						lenH = len * m_LengthHPer;

						y = cy + m_Offset;
						p.Width = m_Weight;
						g.DrawLine(p, rct2.Left, y, rct2.Left +len, y);
						cnt = 1;
						y = cy - interH + m_Offset;
						while (y >= rct2.Top)
						{
							if (cnt % 2 == 0)
							{
								p.Color = cl;
								p.Width = m_Weight;
								g.DrawLine(p, rct2.Left, y, rct2.Left + len, y);
							}
							else
							{
								if (m_WeightH > 0)
								{
									p.Color = ch;
									p.Width = m_WeightH;
									g.DrawLine(p, rct2.Left, y, rct2.Left + lenH, y);
								}
							}
							cnt++;
							y -= interH;
						}
						cnt = 1;
						y = cy + interH + m_Offset;
						while (y < rct2.Bottom)
						{
							if (cnt % 2 == 0)
							{
								p.Color = cl;
								p.Width = m_Weight;
								g.DrawLine(p, rct2.Left, y, rct2.Left + len, y);
							}
							else
							{
								if (m_WeightH > 0)
								{
									p.Color = ch;
									p.Width = m_WeightH;
									g.DrawLine(p, rct2.Left, y, rct2.Left + lenH, y);
								}
							}
							cnt++;
							y += interH;
						}
						break;
					case MGScaleType.Right:
						if (len <= 0) len = rct2.Width;
						lenH = len * m_LengthHPer;

						y = cy + m_Offset;
						p.Width = m_Weight;
						g.DrawLine(p, rct2.Right-len, y, rct2.Right, y);
						cnt = 1;
						y = cy - interH + m_Offset;
						while (y >= rct2.Top)
						{
							if (cnt % 2 == 0)
							{
								p.Color = cl;
								p.Width = m_Weight;
								g.DrawLine(p, rct2.Right - len, y, rct2.Right, y);
							}
							else
							{
								if (m_WeightH > 0)
								{
									p.Color = ch;
									p.Width = m_WeightH;
									g.DrawLine(p, rct2.Right - lenH, y, rct2.Right, y);
								}
							}
							cnt++;
							y -= interH;
						}
						cnt = 1;
						y = cy + interH + m_Offset;
						while (y < rct2.Bottom)
						{
							if (cnt % 2 == 0)
							{
								p.Color = cl;
								p.Width = m_Weight;
								g.DrawLine(p, rct2.Right - len, y, rct2.Right, y);
							}
							else
							{
								if (m_WeightH > 0)
								{
									p.Color = ch;
									p.Width = m_WeightH;
									g.DrawLine(p, rct2.Right - lenH, y, rct2.Right, y);
								}
							}
							cnt++;
							y += interH;
						}
						break;
					case MGScaleType.Hor:
						if (len <= 0) len = rct2.Height;
						lenH = len * m_LengthHPer;

						x = cx + m_Offset;
						p.Width = m_Weight;
						g.DrawLine(p, x, cy - len / 2, x, cy + len / 2);
						cnt = 1;
						x = cx - interH + m_Offset;
						while (x >= rct2.Left)
						{
							if (cnt % 2 == 0)
							{
								p.Color = cl;
								p.Width = m_Weight;
								g.DrawLine(p, x, cy - len / 2, x, cy + len / 2);
							}
							else
							{
								if (m_WeightH > 0)
								{
									p.Color = ch;
									p.Width = m_WeightH;
									g.DrawLine(p, x, cy - lenH / 2, x, cy + lenH / 2);
								}
							}
							cnt++;
							x -= interH;
						}
						cnt = 1;
						x = cx + interH + m_Offset;
						while (x < rct2.Right)
						{
							if (cnt % 2 == 0)
							{
								p.Color = cl;
								p.Width = m_Weight;
								g.DrawLine(p, x, cy - len / 2, x, cy + len / 2);
							}
							else
							{
								if (m_WeightH > 0)
								{
									p.Color = ch;
									p.Width = m_WeightH;
									g.DrawLine(p, x, cy - lenH / 2, x, cy + lenH / 2);
								}
							}
							cnt++;
							x += interH;
						}
						break;
					case MGScaleType.Top:
						if (len <= 0) len = rct2.Height;
						lenH = len * m_LengthHPer;

						x = cx + m_Offset;
						p.Width = m_Weight;
						g.DrawLine(p, x, rct2.Top, x, rct2.Top + len);
						cnt = 1;
						x = cx - interH + m_Offset;
						while (x >= rct2.Left)
						{
							if (cnt % 2 == 0)
							{
								p.Color = cl;
								p.Width = m_Weight;
								g.DrawLine(p, x, rct2.Top, x, rct2.Top + len);
							}
							else
							{
								if (m_WeightH > 0)
								{
									p.Color = ch;
									p.Width = m_WeightH;
									g.DrawLine(p, x, rct2.Top, x, rct2.Top + lenH);
								}
							}
							cnt++;
							x -= interH;
						}
						cnt = 1;
						x = cx + interH + m_Offset;
						while (x < rct2.Right)
						{
							if (cnt % 2 == 0)
							{
								p.Color = cl;
								p.Width = m_Weight;
								g.DrawLine(p, x, rct2.Top, x, rct2.Top + len);
							}
							else
							{
								if (m_WeightH > 0)
								{
									p.Color = ch;
									p.Width = m_WeightH;
									g.DrawLine(p, x, rct2.Top, x, rct2.Top + lenH);
								}
							}
							cnt++;
							x += interH;
						}
						break;
					case MGScaleType.Bottom:
						if (len <= 0) len = rct2.Height;
						lenH = len * m_LengthHPer;

						x = cx + m_Offset;
						p.Width = m_Weight;
						g.DrawLine(p, x, rct2.Bottom -len, x, rct2.Bottom);
						cnt = 1;
						x = cx - interH + m_Offset;
						while (x >= rct2.Left)
						{
							if (cnt % 2 == 0)
							{
								p.Color = cl;
								p.Width = m_Weight;
								g.DrawLine(p, x, rct2.Bottom - len, x, rct2.Bottom);
							}
							else
							{
								if (m_WeightH > 0)
								{
									p.Color = ch;
									p.Width = m_WeightH;
									g.DrawLine(p, x, rct2.Bottom - lenH, x, rct2.Bottom);
								}
							}
							cnt++;
							x -= interH;
						}
						cnt = 1;
						x = cx + interH + m_Offset;
						while (x < rct2.Right)
						{
							if (cnt % 2 == 0)
							{
								p.Color = cl;
								p.Width = m_Weight;
								g.DrawLine(p, x, rct2.Bottom - len, x, rct2.Bottom);
							}
							else
							{
								if (m_WeightH > 0)
								{
									p.Color = ch;
									p.Width = m_WeightH;
									g.DrawLine(p, x, rct2.Bottom - lenH, x, rct2.Bottom);
								}
							}
							cnt++;
							x += interH;
						}
						break;
				}

			}
			finally
			{
				p.Dispose();
			}
		}
	}
}
