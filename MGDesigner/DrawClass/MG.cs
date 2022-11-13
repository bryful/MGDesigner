using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGDesigner
{
	public class MG
	{
		static public void Frame(Graphics g,Pen p,Rectangle r)
		{
			float pw = p.Width;
			if (pw < 1) return;
			p.Width = 1;
			Rectangle r2 = new Rectangle(r.X, r.Y, r.Width - 1, r.Height - 1);
			for (int i = 0; i < (int)pw;i++)
			{
				g.DrawRectangle(p, r2);
				r2 = new Rectangle(r2.X+1, r2.Y+1, r2.Width - 2, r2.Height - 2);
			}
			p.Width = pw;

		}
		static public void Frame(Graphics g, Pen p, int w,Rectangle r)
		{
			if (w < 1) return;
			float pw = p.Width;
			p.Width = 1;
			Rectangle r2 = new Rectangle(r.X, r.Y, r.Width - 1, r.Height - 1);
			for (int i = 0; i < w; i++)
			{
				g.DrawRectangle(p, r2);
				r2 = new Rectangle(r2.X + 1, r2.Y + 1, r2.Width - 2, r2.Height - 2);
			}
			p.Width = pw;

		}
		static public void GradV(Graphics g,Color c0, Color c1, Rectangle rct)
		{
			LinearGradientBrush gb = new LinearGradientBrush(
					rct,
					c0,
					c1,
					LinearGradientMode.Vertical);
			try
			{
				g.FillRectangle(gb, rct);
			}
			catch
			{
				gb.Dispose();
			}

		}
		static public void GradV(Graphics g, Color c0, Color c1, Color c2, Rectangle rct)
		{
			Rectangle r = new Rectangle(rct.X, rct.Y, rct.Width, rct.Height);
			LinearGradientBrush gb = new LinearGradientBrush(
				r,
				c0,
				c2,
				LinearGradientMode.Vertical);
			ColorBlend blend = new ColorBlend();
			blend.Positions = new float[] { 0, 0.5f, 1 };
			blend.Colors = new Color[] { c0, c1, c2 };
			gb.InterpolationColors = blend;
			g.FillRectangle(gb, r);
			gb.Dispose();

		}

		public enum TrainglrStyle
		{
			Top,
			Right,
			Bottom,
			Left,
			Center
		}
		static public void Polygon(Graphics g, Pen p, int cnt,PointF pos, float length, float rot)
		{
			if (cnt < 3) cnt = 3; else if (cnt > 12) cnt = 12;
			PointF[] pnts = new PointF[cnt];


			float r = rot;
			for (int i = 0; i < cnt; i++)
			{
				double x = (double)length * Math.Sin(r * Math.PI / 180);
				double y = (double)length * Math.Cos(r * Math.PI / 180);
				pnts[i] = new PointF((float)x + pos.X, -(float)y + pos.Y);
				r += 360 / cnt;
			}
			g.DrawPolygon(p, pnts);


		}
		static public Region PolygonRegion(int cnt ,PointF pos, float length, float rot)
		{
			if (cnt < 3) cnt = 3; else if (cnt > 12) cnt = 12;
			byte[] types = new byte[cnt];
			for (int i = 0; i < cnt; i++) types[i] = (byte)PathPointType.Line;
			Point[] pnts = new Point[cnt];
			float r = rot;
			for (int i = 0; i < cnt; i++)
			{
				double x = (double)(length) * Math.Sin(r * Math.PI / 180);
				double y = (double)(length) * Math.Cos(r * Math.PI / 180);
				pnts[i] = new Point((int)(x + pos.X), (int)(-y + pos.Y));
				r += 360 / cnt;
			}
			GraphicsPath path = new GraphicsPath(pnts, types);
			return new Region(path);
		}
		static public void Triangle(Graphics g,Pen p, PointF pos, float length,float rot)
		{
			PointF[] pnts = new PointF[3];


			float r = rot;
			for(int i=0; i<3;i++)
			{
				double x = (double)length * Math.Sin(r * Math.PI / 180);
				double y = (double)length * Math.Cos(r * Math.PI / 180);
				pnts[i] = new PointF((float)x+pos.X, -(float)y+pos.Y);
				r += 360 / 3;
			}
			g.DrawPolygon(p,pnts);
		}
		static public void Triangle(Graphics g, Pen p, Rectangle rct , float pw,TrainglrStyle ts = TrainglrStyle.Top)
		{
			
			PointF[] pnts = new PointF[3];
			switch(ts)
			{
				case TrainglrStyle.Top:
					pnts[0] = new PointF((float)rct.Left + (float)rct.Width / 2, (float)rct.Top + pw);
					pnts[1] = new PointF((float)rct.Left + (float)rct.Width-pw, (float)rct.Bottom-pw);
					pnts[2] = new PointF((float)rct.Left +pw, (float)rct.Bottom-pw);
					break;
				case TrainglrStyle.Right:
					pnts[0] = new PointF((float)rct.Left + pw, (float)rct.Top + pw);
					pnts[1] = new PointF((float)rct.Left + (float)rct.Width - pw, (float)rct.Top + (float)rct.Height/2);
					pnts[2] = new PointF((float)rct.Left + pw, (float)rct.Bottom - pw);
					break;
				case TrainglrStyle.Bottom:
					pnts[0] = new PointF((float)rct.Left + pw, (float)rct.Top + pw);
					pnts[1] = new PointF((float)rct.Left + (float)rct.Width - pw, (float)rct.Top + pw);
					pnts[2] = new PointF((float)rct.Left + (float)rct.Width/2, (float)rct.Bottom - pw);
					break;
				case TrainglrStyle.Left:
					pnts[0] = new PointF((float)rct.Left + (float)rct.Width - pw, (float)rct.Top + pw);
					pnts[1] = new PointF((float)rct.Left +  pw, (float)rct.Top + (float)rct.Height / 2);
					pnts[2] = new PointF((float)rct.Left + (float)rct.Width - pw, (float)rct.Bottom - pw);
					break;
			}
			g.DrawPolygon(p, pnts);
		}
		static public Region TriangleRegion(PointF pos, float length, float rot)
		{
			byte[] types = new byte[3]
			{
				(byte)PathPointType.Line,
				(byte)PathPointType.Line,
				(byte)PathPointType.Line
			};
			Point[] pnts = new Point[3];
			float r = rot;
			for (int i = 0; i < 3; i++)
			{
				double x = (double)(length) * Math.Sin(r * Math.PI / 180);
				double y = (double)(length) * Math.Cos(r * Math.PI / 180);
				pnts[i] = new Point((int)(x + pos.X), (int)(-y + pos.Y));
				r += 360 / 3;
			}
			GraphicsPath path = new GraphicsPath(pnts, types);
			return new Region(path);
		}
		static public Region TriangleRegion(Rectangle rct, float pw, TrainglrStyle ts = TrainglrStyle.Top)
		{
			byte[] types = new byte[3]
			{
				(byte)PathPointType.Line,
				(byte)PathPointType.Line,
				(byte)PathPointType.Line
			};
			int p = (int)pw;
			Point[] pnts = new Point[3];
			switch (ts)
			{
				case TrainglrStyle.Top:
					pnts[0] = new Point(rct.Left + rct.Width / 2, rct.Top - p);
					pnts[1] = new Point(rct.Left + rct.Width + p, rct.Bottom + p);
					pnts[2] = new Point(rct.Left - p, rct.Bottom + p);
					break;
				case TrainglrStyle.Right:
					pnts[0] = new Point(rct.Left - p, rct.Top - p);
					pnts[1] = new Point(rct.Left + rct.Width + p, rct.Top + rct.Height / 2);
					pnts[2] = new Point(rct.Left - p, rct.Bottom + p);
					break;
				case TrainglrStyle.Bottom:
					pnts[0] = new Point(rct.Left - p, rct.Top - p);
					pnts[1] = new Point(rct.Left + rct.Width + p, rct.Top - p);
					pnts[2] = new Point(rct.Left + rct.Width / 2, rct.Bottom + p);
					break;
				case TrainglrStyle.Left:
					pnts[0] = new Point(rct.Left + rct.Width + p, rct.Top - p);
					pnts[1] = new Point(rct.Left - p, rct.Top + rct.Height / 2);
					pnts[2] = new Point(rct.Left + rct.Width + p, rct.Bottom + p);
					break;
			}
			GraphicsPath path = new GraphicsPath(pnts, types);
			return new Region(path);
		}
		static public void Grid(Graphics g ,Pen p, float gw, float gh, Rectangle rct)
		{
			float cx = (float)rct.Left + (float)rct.Width / 2;
			float cy = (float)rct.Top + (float)rct.Height / 2;
			int cnt = 0;
			//まず横線上
			PointF[] pnts = new PointF[2];
			pnts[0] = new PointF((float)rct.Left, cy);
			pnts[1] = new PointF((float)rct.Right, cy);
			g.DrawLines(p,pnts);
			cnt = (int)((rct.Height / 2) / gh)+1;
			for (int i=1; i<=cnt; i++)
			{
				float yy = cy - i * gh;
				if(yy>=rct.Top)
				{
					pnts[0] = new PointF((float)rct.Left, yy);
					pnts[1] = new PointF((float)rct.Right, yy);
					g.DrawLines(p, pnts);
				}
				 yy = cy + i * gh;
				if (yy < rct.Bottom)
				{
					pnts[0] = new PointF((float)rct.Left, yy);
					pnts[1] = new PointF((float)rct.Right, yy);
					g.DrawLines(p, pnts);
				}
			}
			pnts[0] = new PointF(cx, (float)rct.Top);
			pnts[1] = new PointF(cx, (float)rct.Bottom);
			g.DrawLines(p, pnts);

			cnt = (int)((rct.Width  / 2) / gw)+1;
			for (int i = 1; i <= cnt; i++)
			{
				float xx = cx - i * gw;
				if (xx >= rct.Left)
				{
					pnts[0] = new PointF(xx,(float)rct.Top);
					pnts[1] = new PointF(xx,(float)rct.Bottom);
					g.DrawLines(p, pnts);
				}
				xx = cx + i * gw;
				if (xx < rct.Right)
				{
					pnts[0] = new PointF(xx, (float)rct.Top);
					pnts[1] = new PointF(xx, (float)rct.Bottom);
					g.DrawLines(p, pnts);
				}
			}

		}
	}
}
