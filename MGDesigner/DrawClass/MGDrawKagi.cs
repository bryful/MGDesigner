using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGDesigner
{

	public class MGDrawKagi
	{
		public int KagiWeightH = 3;
		public int KagiWeightV = 3;
		
		public int KagiWidth = 20;
		public int KagiHeight = 20;
		
		//public int HorMargin = 10;
		//public int VurMargin = 10;

		public MGDrawKagi()
		{
		}
		public void Draw(Graphics g, SolidBrush sb, Point pos, KagiStyle ks)
		{
			if((g==null)|| (sb == null)) return;
			Point[] pnts;
			pnts = KagiPoints(pos, ks);
			g.FillPolygon(sb, pnts);
		}
		public void DrawEdge(Graphics g, SolidBrush sb, Rectangle rct, bool[] dflag, int hm=0,int vm=0)
		{
			Point pos;
			if((dflag.Length>=1) &&(dflag[0]==true))
			{
				pos = new Point(hm, vm);
				Draw(g, sb, pos, KagiStyle.TopLeft);
			}
			if ((dflag.Length >= 2) && (dflag[1] == true))
			{
				pos = new Point(rct.Right - 1 - hm, vm);
				Draw(g, sb, pos, KagiStyle.TopRight);
			}
			if ((dflag.Length >= 3) && (dflag[2] == true))
			{
				pos = new Point(rct.Right - 1 - hm, rct.Bottom - 1 - vm);
				Draw(g, sb, pos, KagiStyle.BottomRight);
			}
			if ((dflag.Length >= 4) && (dflag[3] == true))
			{
				pos = new Point(hm, rct.Bottom - 1 - vm);
				Draw(g, sb, pos, KagiStyle.BottomLeft);
			}
		}
		public Region KagiEdgeRegion(Rectangle rct, bool[] dflag, int hm = 0, int vm = 0)
		{
			GraphicsPath path = new GraphicsPath();

			Point pos;
			Point[] pnts;
			if ((dflag.Length >= 1) && (dflag[0] == true))
			{
				pos = new Point(hm, vm);
				pnts = KagiPoints( pos, KagiStyle.TopLeft);
				path.AddPolygon(pnts);
			}
			if ((dflag.Length >= 2) && (dflag[1] == true))
			{
				pos = new Point(rct.Right - 1 - hm, vm);
				pnts = KagiPoints(pos, KagiStyle.TopRight);
				path.AddPolygon(pnts);
			}
			if ((dflag.Length >= 3) && (dflag[2] == true))
			{
				pos = new Point(rct.Right - 1 - hm, rct.Bottom - 1 - vm);
				pnts = KagiPoints(pos, KagiStyle.BottomRight);
				path.AddPolygon(pnts);
			}
			if ((dflag.Length >= 4) && (dflag[3] == true))
			{
				pos = new Point(hm, rct.Bottom - 1 - vm);
				pnts = KagiPoints(pos, KagiStyle.BottomLeft);
				path.AddPolygon(pnts);
			}

			return new Region(path);

		}
		public Region KagiRegion(Point pos,KagiStyle kg)
		{
			byte[] types = new byte[6]
			{
				(byte)PathPointType.Line,
				(byte)PathPointType.Line,
				(byte)PathPointType.Line,
				(byte)PathPointType.Line,
				(byte)PathPointType.Line,
				(byte)PathPointType.Line
			};
			Point[] pnts = KagiPoints(pos,kg);
			GraphicsPath path = new GraphicsPath(pnts, types);
			return new Region(path);

		}
		private Point[] KagiPoints(Point pos,KagiStyle kg)
		{
			Point[] pnts = new Point[6];
			switch (kg)
			{
				case KagiStyle.TopLeft:
					pnts[0] = new Point(pos.X, pos.Y);
					pnts[1] = new Point(pos.X + KagiWidth, pos.Y);
					pnts[2] = new Point(pos.X + KagiWidth, pos.Y + KagiWeightV);
					pnts[3] = new Point(pos.X + KagiWeightH, pos.Y + KagiWeightV);
					pnts[4] = new Point(pos.X + KagiWeightH, pos.Y + KagiHeight);
					pnts[5] = new Point(pos.X, pos.Y + KagiHeight);
					break;
				case KagiStyle.TopRight:
					pnts[0] = new Point(pos.X, pos.Y);
					pnts[1] = new Point(pos.X - KagiWidth, pos.Y);
					pnts[2] = new Point(pos.X - KagiWidth, pos.Y + KagiWeightV);
					pnts[3] = new Point(pos.X - KagiWeightH, pos.Y + KagiWeightV);
					pnts[4] = new Point(pos.X - KagiWeightH, pos.Y + KagiHeight);
					pnts[5] = new Point(pos.X + 0, pos.Y + KagiHeight);
					break;
				case KagiStyle.BottomRight:
					pnts[0] = new Point(pos.X, pos.Y);
					pnts[1] = new Point(pos.X, pos.Y - KagiHeight);
					pnts[2] = new Point(pos.X - KagiWeightH, pos.Y - KagiHeight);
					pnts[3] = new Point(pos.X - KagiWeightH, pos.Y - KagiWeightV);
					pnts[4] = new Point(pos.X - KagiWidth , pos.Y  - KagiWeightV);
					pnts[5] = new Point(pos.X - KagiWidth , pos.Y);
					break;
				case KagiStyle.BottomLeft:
					pnts[0] = new Point(pos.X ,pos.Y);
					pnts[1] = new Point(pos.X, pos.Y -KagiHeight);
					pnts[2] = new Point(pos.X + KagiWeightH, pos.Y - KagiHeight);
					pnts[3] = new Point(pos.X + KagiWeightH, pos.Y - KagiWeightV);
					pnts[4] = new Point(pos.X + KagiWidth, pos.Y - KagiWeightV);
					pnts[5] = new Point(pos.X + KagiWidth, pos.Y);
					break;
			}
			return pnts;
		}

	}


}
