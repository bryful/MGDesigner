using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGDesigner
{
	public enum ScaleStlye
	{
		Vur,
		Hor,
		Left,
		Right,
		Top,
		Bottom
	}


	public class MGDrawScale
	{
		public float BaseInter = 6;
		public float Weight = 2;
		public float length = 20;
		public float[] WeightPers = new float[] { 100, 50, 50, 75, 50, 50 };
		public float[] LengthPers = new float[] { 100, 25, 25, 50, 25, 25 };
		public Color[] Colors = new Color[] { 
			Color.White, Color.Gray, Color.Gray, Color.LightGray, Color.Gray, Color.Gray };
		public Rectangle rect = new Rectangle(0, 0, 100, 100);
		public float Offset = 0;

		public void Draw(Graphics g,Pen p,Rectangle r, ScaleStlye ss)
		{
			if ((WeightPers.Length<=0)||(LengthPers.Length<=0) || (Colors.Length <= 0)) return;
			float cx = (float)r.Left + (float)r.Width / 2;
			float cy = (float)r.Top + (float)r.Height / 2;

			float w = 0;
			float l = 0;
			float x = 0;
			float y = 0;
			int idx = 0;
			Color c;
			switch (ss)
			{
				case ScaleStlye.Vur:

					y = cy + Offset;
					idx = 0;
					while (y>=r.Top)
					{
						w = Weight * WeightPers[idx % WeightPers.Length] / 100;
						l = length * LengthPers[idx % LengthPers.Length] / 100;
						c = Colors[idx % Colors.Length];
						p.Width = w;
						p.Color = c;
						if ((w > 0) && (l > 0))
						{
							g.DrawLine(p, cx - l / 2, y, cx + l / 2, y);
						}
						idx++;
						y -= BaseInter;
					}
					idx = 1;
					y = y = cy + Offset + BaseInter; 
					while (y <= r.Bottom)
					{
						w = Weight * WeightPers[idx % WeightPers.Length] / 100;
						l = length * LengthPers[idx % LengthPers.Length] / 100;
						c = Colors[idx % Colors.Length];
						p.Width = w;
						p.Color = c;
						if ((w > 0) && (l > 0))
						{
							g.DrawLine(p, cx - l / 2, y, cx + l / 2, y);
						}
						idx++;
						y += BaseInter;
					}
					break;
				case ScaleStlye.Hor:
					x = cx + Offset;
					idx = 0;
					while (x >= r.Left)
					{
						w = Weight * WeightPers[idx % WeightPers.Length] / 100;
						l = length * LengthPers[idx % LengthPers.Length] / 100;
						c = Colors[idx % Colors.Length];
						p.Width = w;
						p.Color = c;
						if ((w > 0) && (l > 0))
						{
							g.DrawLine(p, x, cy - l/2, x, cy + l/2);
						}
						idx++;
						x -= BaseInter;
					}
					idx = 1;
					x = cx + Offset + BaseInter;
					while (x <= r.Right)
					{
						w = Weight * WeightPers[idx % WeightPers.Length] / 100;
						l = length * LengthPers[idx % LengthPers.Length] / 100;
						c = Colors[idx % Colors.Length];
						p.Width = w;
						p.Color = c;
						if ((w > 0) && (l > 0))
						{
							g.DrawLine(p, x, cy - l / 2, x, cy + l / 2);
						}
						idx++;
						x += BaseInter;
					}
					break;
				case ScaleStlye.Left:
					y = cy + Offset;
					idx = 0;
					while (y >= r.Top)
					{
						w = Weight * WeightPers[idx % WeightPers.Length] / 100;
						l = length * LengthPers[idx % LengthPers.Length] / 100;
						c = Colors[idx % Colors.Length];
						p.Width = w;
						p.Color = c;
						if ((w > 0) && (l > 0))
						{
							g.DrawLine(p, r.Left, y, r.Left + l, y);
						}
						idx++;
						y -= BaseInter;
					}
					idx = 1;
					y = cy + Offset + BaseInter;
					while (y <= r.Bottom)
					{
						w = Weight * WeightPers[idx % WeightPers.Length] / 100;
						l = length * LengthPers[idx % LengthPers.Length] / 100;
						c = Colors[idx % Colors.Length];
						p.Width = w;
						p.Color = c;
						if ((w > 0) && (l > 0))
						{
							g.DrawLine(p, r.Left, y, r.Left + l, y);
						}
						idx++;
						y += BaseInter;
					}
					break;
				case ScaleStlye.Right:
					y = cy + Offset;
					idx = 0;
					while (y >= r.Top)
					{
						w = Weight * WeightPers[idx % WeightPers.Length] / 100;
						l = length * LengthPers[idx % LengthPers.Length] / 100;
						c = Colors[idx % Colors.Length];
						p.Width = w;
						p.Color = c;
						if ((w > 0) && (l > 0))
						{
							g.DrawLine(p, r.Right - l, y, r.Right, y);
						}
						idx++;
						y -= BaseInter;
					}
					idx = 1;
					y = cy + Offset + BaseInter;
					while (y <= r.Bottom)
					{
						w = Weight * WeightPers[idx % WeightPers.Length] / 100;
						l = length * LengthPers[idx % LengthPers.Length] / 100;
						c = Colors[idx % Colors.Length];
						p.Width = w;
						p.Color = c;
						if ((w > 0) && (l > 0))
						{
							g.DrawLine(p, r.Right -l, y, r.Right, y);
						}
						idx++;
						y += BaseInter;
					}
					break;
				case ScaleStlye.Top:
					x = cx + Offset;
					idx = 0;
					while (x >= r.Left)
					{
						w = Weight * WeightPers[idx % WeightPers.Length] / 100;
						l = length * LengthPers[idx % LengthPers.Length] / 100;
						c = Colors[idx % Colors.Length];
						p.Width = w;
						p.Color = c;
						if ((w > 0) && (l > 0))
						{
							g.DrawLine(p, x, r.Top, x, r.Top + l);
						}
						idx++;
						x -= BaseInter;
					}
					idx = 1;
					x = cx + Offset + BaseInter;
					while (x <= r.Right)
					{
						w = Weight * WeightPers[idx % WeightPers.Length] / 100;
						l = length * LengthPers[idx % LengthPers.Length] / 100;
						c = Colors[idx % Colors.Length];
						p.Width = w;
						p.Color = c;
						if ((w > 0) && (l > 0))
						{
							g.DrawLine(p, x, r.Top, x, r.Top + l);
						}
						idx++;
						x += BaseInter;
					}
					break;
				case ScaleStlye.Bottom:
					x = cx + Offset;
					idx = 0;
					while (x >= r.Left)
					{
						w = Weight * WeightPers[idx % WeightPers.Length] / 100;
						l = length * LengthPers[idx % LengthPers.Length] / 100;
						c = Colors[idx % Colors.Length];
						p.Width = w;
						p.Color = c;
						if ((w > 0) && (l > 0))
						{
							g.DrawLine(p, x, r.Bottom-l, x, r.Bottom);
						}
						idx++;
						x -= BaseInter;
					}
					idx = 1;
					x = cx + Offset + BaseInter;
					while (x <= r.Right)
					{
						w = Weight * WeightPers[idx % WeightPers.Length] / 100;
						l = length * LengthPers[idx % LengthPers.Length] / 100;
						c = Colors[idx % Colors.Length];
						p.Width = w;
						p.Color = c;
						if ((w > 0) && (l > 0))
						{
							g.DrawLine(p, x, r.Bottom - l, x, r.Bottom);
						}
						idx++;
						x += BaseInter;
					}
					break;
			}
		}
	}
}
