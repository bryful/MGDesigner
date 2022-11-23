using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGDesigner
{
	public partial class MG
	{
		#region Cross
		static public PointF[] CrossRegion(PointF pos, float w, float h, float weight)
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
		static public void Cross(Graphics g, Pen p,SolidBrush sb, PointF pos, float w, float h, float weight)
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
		#endregion

		#region Edge
		static public void Edge(Graphics g, SolidBrush sb,Rectangle rct, SizeF eg, float wm, float hm)
		{

			PointF[] pnts = new PointF[4];
			pnts[0] = new PointF(rct.Left + wm, rct.Top + hm);
			pnts[1] = new PointF(rct.Left + wm +eg.Width, rct.Top + hm);
			pnts[2] = new PointF(rct.Left + wm + eg.Width, rct.Top + hm + eg.Height);
			pnts[3] = new PointF(rct.Left + wm, rct.Top + hm + eg.Height);
			g.FillPolygon(sb,pnts);
			pnts[0] = new PointF(rct.Right - wm - eg.Width, rct.Top + hm);
			pnts[1] = new PointF(rct.Right - wm , rct.Top + hm);
			pnts[2] = new PointF(rct.Right - wm, rct.Top + hm + eg.Height);
			pnts[3] = new PointF(rct.Right - wm - eg.Width, rct.Top + hm + eg.Height);
			g.FillPolygon(sb, pnts);
			pnts[0] = new PointF(rct.Right - wm - eg.Width, rct.Bottom - hm - eg.Height);
			pnts[1] = new PointF(rct.Right - wm, rct.Bottom - hm - eg.Height);
			pnts[2] = new PointF(rct.Right - wm , rct.Bottom - hm);
			pnts[3] = new PointF(rct.Right - wm - eg.Width, rct.Bottom - hm);
			g.FillPolygon(sb, pnts);
			pnts[0] = new PointF(rct.Left + wm, rct.Bottom - hm - eg.Height);
			pnts[1] = new PointF(rct.Left + wm + eg.Width, rct.Bottom - hm - eg.Height);
			pnts[2] = new PointF(rct.Left + wm + eg.Width, rct.Bottom - hm);
			pnts[3] = new PointF(rct.Left + wm, rct.Bottom - hm);
			g.FillPolygon(sb, pnts);


		}

		#endregion
	}
}
