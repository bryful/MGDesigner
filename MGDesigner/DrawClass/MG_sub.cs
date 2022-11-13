using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGDesigner
{
	public partial class MG
	{
		static public PointF[] CrossRegion(Point pos,int w,int h,int weight)
		{
			PointF[] pnts = new PointF[12];
			float c = weight / 2;
			pnts[0] = new PointF(pos.X - c, pos.Y - h);
			pnts[1] = new PointF(pos.X + c, pos.Y - h);
			pnts[2] = new PointF(pos.X + c, pos.Y - c);
			pnts[3] = new PointF(pos.X + w, pos.Y - c);
			pnts[4] = new PointF(pos.X + w, pos.Y + c);
			pnts[5] = new PointF(pos.X + c, pos.Y + c);
			pnts[6] = new PointF(pos.X + c, pos.Y + h);
			pnts[7] = new PointF(pos.X - c, pos.Y + h);
			pnts[8] = new PointF(pos.X - c, pos.Y + c);
			pnts[9] = new PointF(pos.X - w, pos.Y + c);
			pnts[10] = new PointF(pos.X - w, pos.Y - c);
			pnts[11] = new PointF(pos.X - c, pos.Y - c);
			return pnts;
		}
		static public void Cross(Graphics g, Pen p,SolidBrush sb, Point pos, int w, int h, int weight)
		{
			PointF[] pnts = CrossRegion(pos, w, h, weight);
			if((sb.Color.A>0))
			{
				g.FillPolygon(sb, pnts);
			}
			if ((p.Width > 0) && (p.Color.A > 0))
			{
				g.DrawPolygon(p, pnts);
			}
		}
	}
}
