using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGDesigner
{
	public partial class MG
	{


		static private float Tan(float h, float rot)
		{
			float r = Math.Abs(rot);
			if (r > 45) r = 45;
			float v = -1;
			if (rot < 0) v = 1;
			return (float)Math.Tan((double)r * Math.PI / 180) * h *v;
		}
		/// <summary>
		/// 平行四辺形のポリゴンを返す
		/// </summary>
		/// <param name="w">横幅</param>
		/// <param name="h">縦幅</param>
		/// <param name="rot">角度 -90 から 90の間 </param>
		/// <returns></returns>
		static public PointF[] Parallelogram(float x, float y, float w, float h , float rot)
		{
			PointF[] points = new PointF[4];
			bool mflag = (rot < 0);
			float ax = Tan(h,rot);
			points[0] = new PointF(x, y);
			points[1] = new PointF(x + w, y);
			points[2] = new PointF(x + w + ax, y + h);
			points[3] = new PointF(x + ax, y + h);
			return points;
		}
		static public PointF[] AddPoints(PointF[] ps, float x, float y)
		{
			PointF[] ret = new PointF[ps.Length];
			if (ps.Length>0)
			{
				for(int i=0; i<ps.Length;i++)
				{
					ret[i].X = ps[i].X + x;
					ret[i].Y = ps[i].Y + y;
				}
			}
			return ret;
		}
		static public void DrawZebra(Graphics g, SolidBrush sb, Rectangle r, float w, float rot)
		{
			bool mflag = (rot < 0);

			if(mflag==false)
			{
				PointF[] points = Parallelogram(r.Left, r.Top, w, r.Height, rot);
				while (points[3].X<r.Right)
				{
					g.FillPolygon(sb, points);
					points = AddPoints(points, w * 2, 0);
				}
			}
			else
			{
				float ax = Tan(r.Height, rot);
				PointF[] points = Parallelogram(r.Left+ax, r.Top, w, r.Height, rot);
				while (points[0].X < r.Right)
				{
					g.FillPolygon(sb, points);
					points = AddPoints(points, w * 2, 0);
				}

			}

		}
		static public Region ZebraRegion(Rectangle r, float w, float rot)
		{
			GraphicsPath path = new GraphicsPath();
			bool mflag = (rot < 0);

			if (mflag == false)
			{
				PointF[] points = Parallelogram(r.Left, r.Top, w, r.Height, rot);
				while (points[3].X < r.Right)
				{
					path.AddPolygon(points);
					points = AddPoints(points, w * 2, 0);
				}
			}
			else
			{
				float ax = Tan(r.Height, rot);
				PointF[] points = Parallelogram(r.Left + ax, r.Top, w, r.Height, rot);
				while (points[0].X < r.Right)
				{
					path.AddPolygon(points);
					points = AddPoints(points, w * 2, 0);
				}

			}
			return new Region(path);

		}

	}
}
