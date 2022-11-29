using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGCreator
{
	public partial class MGControl
	{
		public virtual void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{
			switch(m_MGStyle)
			{
				case MGStyle.Frame:
					DrawFrame(g, rct, IsClear);
					break;
				case MGStyle.Grid:
					DrawGrid(g, rct, IsClear);
					break;
				case MGStyle.Circle:
					DrawMain(g, rct, IsClear);
					break;
				case MGStyle.CircleScale:
					DrawMain(g, rct, IsClear);
					break;
				case MGStyle.Triangle:
					DrawMain(g, rct, IsClear);
					break;
				case MGStyle.Polygon:
					DrawMain(g, rct, IsClear);
					break;
				case MGStyle.Cross:
					DrawMain(g, rct, IsClear);
					break;
				case MGStyle.Zebra:
					DrawMain(g, rct, IsClear);
					break;
				case MGStyle.Label:
					DrawMain(g, rct, IsClear);
					break;
				case MGStyle.Parallelogram:
					DrawMain(g, rct, IsClear);
					break;
				case MGStyle.Scale:
					DrawMain(g, rct, IsClear);
					break;
				case MGStyle.Sheet:
					DrawMain(g, rct, IsClear);
					break;
				case MGStyle.Kagi:
					DrawMain(g, rct, IsClear);
					break;
				case MGStyle.Edge:
					DrawMain(g, rct, IsClear);
					break;
				case MGStyle.Side:
					DrawMain(g, rct, IsClear);
					break;
				default:
					DrawMain(g, rct, IsClear);
					break;
			}
		}
		// ************************************************************
		public void DrawMain(Graphics g, Rectangle rct, bool IsClear = true)
		{
			if (IsClear) g.Clear(Color.Transparent);
			Pen pen = new Pen(GetColors(m_Fill, 100), 3);
			SolidBrush sb = new SolidBrush(Color.Green);
			try
			{
				Rectangle rct2 = MarginRect(rct);
				g.FillRectangle(sb, rct2);
				MGC.DrawFrame(g, pen, 2, rct2);
			}
			finally
			{
				sb.Dispose();
				pen.Dispose();
			}
		}
		// ************************************************************
		public void DrawGrid(Graphics g, Rectangle rct, bool IsClear = true)
		{
			if (IsClear) g.Clear(Color.Transparent);
			Pen p = new Pen(GetColors(m_Fill, 100), 3);
			SolidBrush sb = new SolidBrush(Color.Green);
			Point offset = new Point(0, 0);
			try
			{
				Rectangle rct2 = MarginRect(rct);
				float cx = (float)rct2.Left + (float)rct2.Width / 2 + offset.X;
				float cy = (float)rct2.Top + (float)rct2.Height / 2 + offset.Y;

				//GraphicsPath path = new GraphicsPath();
				//path.AddRectangle(rct2);
				//g.SetClip(new Region(path), CombineMode.Replace);

				if ((m_LineOpacity > 0) && (m_Line != MG_COLORS.Transparent))
				{
					p.Color = GetColors(m_Line, m_LineOpacity);
					p.Width = m_LineWeight;

					// 水平線
					float y = cy;
					while (y >= rct2.Top)
					{
						g.DrawLine(p, rct2.Left, y, rct2.Right, y);
						y -= m_GridSize.Height;
					}
					y = cy + m_GridSize.Height;
					while (y < rct2.Bottom)
					{
						g.DrawLine(p, rct2.Left, y, rct2.Right, y);
						y += m_GridSize.Height;
					}
					float x = cx;
					while (x >= rct2.Left)
					{
						g.DrawLine(p, x, rct2.Top, x, rct2.Bottom);
						x -= m_GridSize.Width;
					}
					x = cx + m_GridSize.Width;
					while (x < rct2.Right)
					{
						g.DrawLine(p, x, rct2.Top, x, rct2.Bottom);
						x += m_GridSize.Width;
					}
				}
			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}
		}
		// ************************************************************
		public void DrawFrame(Graphics g, Rectangle rct, bool IsClear = true)
		{
			if (IsClear) g.Clear(Color.Transparent);
			Pen pen = new Pen(this.ForeColor, 3);
			SolidBrush sb = new SolidBrush(this.BackColor);
			try
			{
				Rectangle rct2 = MarginRect(rct);
				if ((m_Fill != MG_COLORS.Transparent) && (m_FillOpacity > 0))
				{
					sb.Color = GetColors(m_Fill, m_FillOpacity);
					g.FillRectangle(sb, rct2);
				}
				if ((m_Line != MG_COLORS.Transparent) && (m_LineOpacity > 0))
				{
					pen.Color = GetColors(m_Line, m_LineOpacity);
					MGC.DrawFrame(g, pen, (int)m_LineWeight, rct2);
				}
			}
			finally
			{
				sb.Dispose();
				pen.Dispose();
			}
		}
		public void DrawCircle(Graphics g, Rectangle rct, bool IsClear = true)
		{
			if (IsClear) g.Clear(Color.Transparent);
			Pen pen = new Pen(this.ForeColor, 3);
			SolidBrush sb = new SolidBrush(this.BackColor);
			try
			{
				Rectangle rct2 = MarginRect(rct);
				sb.Color = GetColors(m_Fill, m_FillOpacity);
				g.FillRectangle(sb, rct2);

				pen.Color = GetColors(m_Line, m_LineOpacity);
				MGC.DrawFrame(g, pen, (int)m_LineWeight, rct2);
			}
			finally
			{
				sb.Dispose();
				pen.Dispose();
			}
		}
	}
}
