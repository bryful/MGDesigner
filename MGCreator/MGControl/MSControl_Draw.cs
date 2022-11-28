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
					DrawMain(g, rct, IsClear);
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
		public void DrawFrame(Graphics g, Rectangle rct, bool IsClear = true)
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
