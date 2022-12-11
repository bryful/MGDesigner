using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MGCreator.MGLayerLabel;

namespace MGCreator
{
	public class MGLayerParallelogram : MGLayer
	{
		public new readonly MGStyle MGStyle = MGStyle.Parallelogram;
		private float m_LeftSkew = 0;
		[Category("_MG_Parallelogram")]
		public float LeftSkew
		{
			get { return m_LeftSkew; }
			set
			{
				m_LeftSkew = value;
				if (m_LeftSkew < -60) m_LeftSkew = -60;
				else if (m_LeftSkew > 60) m_LeftSkew = 60;
				ChkOffScr();
			}
		}
		private float m_RightSkew = 0;
		[Category("_MG_Parallelogram")]
		public float RightSkew
		{
			get { return m_RightSkew; }
			set
			{
				m_RightSkew = value;
				if (m_RightSkew < -60) m_RightSkew = -60;
				else if (m_RightSkew > 60) m_RightSkew = 60;
				ChkOffScr();
			}
		}
		private bool m_IsHor = true;
		[Category("_MG_Parallelogram")]
		public bool IsHor
		{
			get { return m_IsHor; }
			set
			{
				m_IsHor = value;
				ChkOffScr();
			}
		}
		public MGLayerParallelogram(MGForm m) : base(m)
		{
			Name = "Parallelogram";
			m_Fill = MG_COL.White;
			m_FillOpacity = 100;
			m_Line = MG_COL.White;
			m_LineOpacity = 0;
			m_LineWeight = 2;

			m_LeftSkew = 0;
			m_RightSkew = 0;
			m_IsHor = true;
		}
		private float Tan(float h, float rot)
		{
			float r = Math.Abs(rot);
			if (r > 60) r = 60;
			float v = 1;
			if (rot < 0) v = -1;
			return (float)Math.Tan((double)r * Math.PI / 180) * h * v;
		}
		private PointF[] ParallelogramCalc(RectangleF rct)
		{
			PointF[] ret = new PointF[4];

			float lt;
			float rt;
			float lb;
			float rb;
			if (m_IsHor)
			{
				lt = rct.Left;
				rt = rct.Right;
				lb = rct.Left;
				rb = rct.Right;

				float l = Tan(rct.Height, m_LeftSkew);
				if (l >= 0)
				{
					lt = rct.Left + l;
				}
				else
				{
					lb = rct.Left - l;
				}
				float r = Tan(rct.Height, m_RightSkew);
				if (r >= 0)
				{
					rb = rct.Right - r;
				}
				else
				{
					rt = rct.Right +r;
				}
				ret[0] = new PointF(lt, rct.Top);
				ret[1] = new PointF(rt, rct.Top);
				ret[2] = new PointF(rb, rct.Bottom);
				ret[3] = new PointF(lb, rct.Bottom);
			}
			else
			{
				lt = rct.Left;
				rt = rct.Top;
				lb = rct.Height;
				rb = rct.Height;
				float l = Tan(rct.Width, m_LeftSkew);
				if (l >= 0)
				{
					rt = rct.Top + l;
				}
				else
				{
					lt = rct.Top - l;
				}
				float r = Tan(rct.Width, m_RightSkew);
				if (r >= 0)
				{
					lb = rct.Bottom - (r);

				}
				else
				{
					rb = rct.Height - (-r);
				}
				ret[0] = new PointF(rct.Left, lt);
				ret[1] = new PointF(rct.Right, rt);
				ret[2] = new PointF(rct.Right, rb);
				ret[3] = new PointF(rct.Left, lb);


			}

			return ret;
		}
		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{
			SolidBrush sb = new SolidBrush(m_BackColor);
			Pen p = new Pen(m_ForeColor);
			try
			{
				if (IsClear) g.Clear(Color.Transparent);
				Rectangle rct2 = MarginRect(rct);

				if ((m_FillOpacity > 0) && (m_Fill != MG_COL.Transparent))
				{
					PointF[] points2 = ParallelogramCalc(rct2);
					sb.Color = GetColors(m_Fill, m_FillOpacity); ;
					g.FillPolygon(sb, points2);
				}
				if ((m_LineOpacity > 0) && (m_LineWeight > 0)&&(m_Line != MG_COL.Transparent))
				{
					float ww = m_LineWeight / 2;
					RectangleF rct3 = new RectangleF(
						rct2.Left + ww,
						rct2.Top + ww,
						rct2.Width - m_LineWeight,
						rct2.Height - m_LineWeight
						);
					PointF[] points3 = ParallelogramCalc(rct3);
					p.Color = GetColors(m_Line, m_LineOpacity); ;
					p.Width = m_LineWeight;
					g.DrawPolygon(p, points3);

				}
			}
			catch
			{
			}
			finally
			{
				p.Dispose();
				sb.Dispose();
			}
		}
		public override List<Control> ParamsParam()
		{
			List<Control> PList = new List<Control>();
			//PList.AddRange(base.ParamsParam());

			EditFloat m_l = new EditFloat();
			m_l.SetCaptionPropName("LineWeight");
			m_l.SetValueMinMax(-60, 60);
			PList.Add(m_l);

			EditFloat m_s = new EditFloat();
			m_s.SetCaptionPropName("LeftSkew");
			m_s.SetValueMinMax(-60, 60);
			PList.Add(m_s);
			EditFloat m_b = new EditFloat();
			m_b.SetCaptionPropName("RightSkew");
			m_b.SetValueMinMax(-60, 60);
			PList.Add(m_b);
			EditBool m_f = new EditBool();
			m_f.SetCaptionPropName("IsHor");
			m_f.SetTrueFalseWord("Horizon", "Vurtial");
			PList.Add(m_f);

			return PList;
		}

		public override List<Control> ParamsColors()
		{
			List<Control> PList = new List<Control>();


			EditMGColors m_fm = new EditMGColors();
			m_fm.SetCaptionPropName("Fill");
			PList.Add(m_fm);

			EditFloat m_fmo = new EditFloat();
			m_fmo.SetCaptionPropName("FillOpacity");
			m_fmo.SetValueMinMax(0, 100);
			PList.Add(m_fmo);

			EditMGColors m_l = new EditMGColors();
			m_l.SetCaptionPropName("Line");
			PList.Add(m_l);

			EditFloat m_lo = new EditFloat();
			m_lo.SetCaptionPropName("LineOpacity");
			m_lo.SetValueMinMax(0, 100);
			PList.Add(m_lo);

			//PList.AddRange(base.ParamsColors());
			return PList;
		}
		// ***************************************************************************
		public override JsonObject ToJson()
		{

			MGj jn = new MGj(base.ToJson());
			jn.SetMGStyle(MGStyle);
			jn.SetValue("Fill",(int)m_Fill);
			jn.SetValue("FillOpacity", (float)m_FillOpacity);
			jn.SetValue("Line", (int)m_Line);
			jn.SetValue("LineOpacity", (float)m_LineOpacity);
			jn.SetValue("LineWeight", (float)m_LineWeight);

			jn.SetValue("LeftSkew", (float)m_LeftSkew);
			jn.SetValue("RightSkew", (float)m_RightSkew);
			jn.SetValue("IsHor", (bool)m_IsHor);

			return jn.Obj;
		}
		public override void FromJson(JsonObject jo)
		{
			bool ret = false;
			if (jo == null) return;
			base.FromJson(jo);
			MGj jn = new MGj(jo);
			int v = 0;
			if (jn.GetInt("Fill", ref v)) 
			{
				m_Fill = (MG_COL)v;
			}
			else
			{
				ret = false;
			}
			if (jn.GetFloat("FillOpacity", ref m_FillOpacity) == false) ret = false;
			if (jn.GetInt("Line", ref v))
			{
				m_Line = (MG_COL)v;
			}
			else
			{
				ret = false;
			}
			if (jn.GetFloat("LineOpacity", ref m_LineOpacity) == false) ret = false;
			if (jn.GetFloat("LineWeight", ref m_LineWeight) == false) ret = false;
			if (jn.GetFloat("LeftSkew", ref m_LeftSkew) == false) ret = false;
			if (jn.GetFloat("RightSkew", ref m_RightSkew) == false) ret = false;
			if (jn.GetBool("IsHor", ref m_IsHor) == false) ret = false;

		}
	}
}
