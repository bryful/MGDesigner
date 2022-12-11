using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MGCreator
{
	public enum KagiStyles
	{
		TopLeft,
		Top,
		TopRight,
		Right,
		BottomRight,
		Bottom,
		BottomLeft,
		Left
	};
	public class KagiParam
	{
		public KagiStyles Styles = KagiStyles.TopLeft;
		public float TopHeight = 6;
		public float BottomHeight = 6;
		public float LeftWidth = 6;
		public float RightWidth = 6;
		public Rectangle Rct = new Rectangle(0, 0, 100, 100);
	}

	public class MGLayerKagi : MGLayer
	{
		public new readonly MGStyle MGStyle = MGStyle.Kagi;
		private KagiParam m_kp = new KagiParam();
		public int KagiStyle
		{
			get { return (int)m_kp.Styles; }
			set
			{
				if((value>=(int)KagiStyles.TopLeft)&& (value <= (int)KagiStyles.Left))
				m_kp.Styles = (KagiStyles)value;
				ChkOffScr();
			}
		}
		public float TopHeight
		{
			get { return m_kp.TopHeight; }
			set
			{
				m_kp.TopHeight = value;
				ChkOffScr();
			}
		}
		public float BottomHeight
		{
			get { return m_kp.BottomHeight; }
			set
			{
				m_kp.BottomHeight = value;
				ChkOffScr();
			}
		}
		public float LeftWidth
		{
			get { return m_kp.LeftWidth; }
			set
			{
				m_kp.LeftWidth = value;
				ChkOffScr();
			}
		}
		public float RightWidth
		{
			get { return m_kp.RightWidth; }
			set
			{
				m_kp.RightWidth = value;
				ChkOffScr();
			}
		}
		public MGLayerKagi(MGForm m) : base(m)
		{
			Name = "Kagi";
			m_Fill = MG_COL.White;
			m_FillOpacity = 100;

		}
		static public void DrawKagi(Graphics g, SolidBrush sb, KagiParam kp)
		{
			PointF[] ps;
			Rectangle r = kp.Rct;
			switch (kp.Styles)
			{
				case KagiStyles.TopLeft:
					ps = new PointF[6];
					ps[0] = new PointF(r.Left, r.Top);
					ps[1] = new PointF(r.Right, r.Top);
					ps[2] = new PointF(r.Right, r.Top + kp.TopHeight);
					ps[3] = new PointF(r.Left + kp.LeftWidth, r.Top + kp.TopHeight);
					ps[4] = new PointF(r.Left + kp.LeftWidth, r.Bottom);
					ps[5] = new PointF(r.Left, r.Bottom);
					break;
				case KagiStyles.Top:
					ps = new PointF[8];
					ps[0] = new PointF(r.Left, r.Top);
					ps[1] = new PointF(r.Right, r.Top);
					ps[2] = new PointF(r.Right, r.Bottom);
					ps[3] = new PointF(r.Right - kp.RightWidth, r.Bottom);
					ps[4] = new PointF(r.Right - kp.RightWidth, r.Top + kp.TopHeight);
					ps[5] = new PointF(r.Left + kp.LeftWidth, r.Top + kp.TopHeight);
					ps[6] = new PointF(r.Left + kp.LeftWidth, r.Bottom);
					ps[7] = new PointF(r.Left, r.Bottom);
					break;
				case KagiStyles.TopRight:
					ps = new PointF[6];
					ps[0] = new PointF(r.Left, r.Top);
					ps[1] = new PointF(r.Right, r.Top);
					ps[2] = new PointF(r.Right, r.Bottom);
					ps[3] = new PointF(r.Right - kp.RightWidth, r.Bottom);
					ps[4] = new PointF(r.Right - kp.RightWidth, r.Top + kp.TopHeight);
					ps[5] = new PointF(r.Left, r.Top + kp.TopHeight);
					break;
				case KagiStyles.Right:
					ps = new PointF[8];
					ps[0] = new PointF(r.Left, r.Top);
					ps[1] = new PointF(r.Right, r.Top);
					ps[2] = new PointF(r.Right, r.Bottom);
					ps[3] = new PointF(r.Left, r.Bottom);
					ps[4] = new PointF(r.Left, r.Bottom - kp.BottomHeight);
					ps[5] = new PointF(r.Right - kp.RightWidth, r.Bottom - kp.BottomHeight);
					ps[6] = new PointF(r.Right - kp.RightWidth, r.Top + kp.TopHeight);
					ps[7] = new PointF(r.Left, r.Top + kp.TopHeight);
					break;
				case KagiStyles.BottomRight:
					ps = new PointF[6];
					ps[0] = new PointF(r.Right - kp.RightWidth, r.Top);
					ps[1] = new PointF(r.Right, r.Top);
					ps[2] = new PointF(r.Right, r.Bottom);
					ps[3] = new PointF(r.Left, r.Bottom);
					ps[4] = new PointF(r.Left, r.Bottom - kp.BottomHeight);
					ps[5] = new PointF(r.Right - kp.RightWidth, r.Bottom - kp.BottomHeight);
					break;
				case KagiStyles.Bottom:
					ps = new PointF[8];
					ps[0] = new PointF(r.Left, r.Top);
					ps[1] = new PointF(r.Left + kp.LeftWidth, r.Top);
					ps[2] = new PointF(r.Left + kp.LeftWidth, r.Bottom - kp.BottomHeight);
					ps[3] = new PointF(r.Right - kp.RightWidth, r.Bottom - kp.BottomHeight);
					ps[4] = new PointF(r.Right - kp.RightWidth, r.Top);
					ps[5] = new PointF(r.Right, r.Top);
					ps[6] = new PointF(r.Right, r.Bottom);
					ps[7] = new PointF(r.Left, r.Bottom);
					break;
				case KagiStyles.BottomLeft:
					ps = new PointF[6];
					ps[0] = new PointF(r.Left, r.Top);
					ps[1] = new PointF(r.Left + kp.LeftWidth, r.Top);
					ps[2] = new PointF(r.Left + kp.LeftWidth, r.Bottom - kp.BottomHeight);
					ps[3] = new PointF(r.Right, r.Bottom - kp.BottomHeight);
					ps[4] = new PointF(r.Right, r.Bottom);
					ps[5] = new PointF(r.Left, r.Bottom);
					break;
				case KagiStyles.Left:
				default:
					ps = new PointF[8];
					ps[0] = new PointF(r.Left, r.Top);
					ps[1] = new PointF(r.Right, r.Top);
					ps[2] = new PointF(r.Right, r.Top + kp.TopHeight);
					ps[3] = new PointF(r.Left + kp.LeftWidth, r.Top + kp.TopHeight);
					ps[4] = new PointF(r.Left + kp.LeftWidth, r.Bottom - kp.BottomHeight);
					ps[5] = new PointF(r.Right, r.Bottom - kp.BottomHeight);
					ps[6] = new PointF(r.Right, r.Bottom);
					ps[7] = new PointF(r.Left, r.Bottom);
					break;
			}
			g.FillPolygon(sb, ps);
		}
		// ***************************************************************************
		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{
			SolidBrush sb = new SolidBrush(m_ForeColor);
			try
			{
				if (IsClear) g.Clear(Color.Transparent);

				Rectangle r = MarginRect(rct);
				m_kp.Rct = r;
				sb.Color = GetColors(m_Fill, m_FillOpacity);
				DrawKagi(g, sb, m_kp);
				/*
				PointF[] ps;
				switch(m_KagiStyle)
				{
					case KagiStyles.TopLeft:
						ps = new PointF[6];
						ps[0] = new PointF(r.Left,r.Top);
						ps[1] = new PointF(r.Right, r.Top);
						ps[2] = new PointF(r.Right, r.Top + m_kp.TopHeight);
						ps[3] = new PointF(r.Left+m_kp.LeftWidth, r.Top + m_kp.TopHeight);
						ps[4] = new PointF(r.Left + m_kp.LeftWidth, r.Bottom);
						ps[5] = new PointF(r.Left , r.Bottom);
						break;
					case KagiStyles.Top:
						ps = new PointF[8];
						ps[0] = new PointF(r.Left, r.Top);
						ps[1] = new PointF(r.Right, r.Top);
						ps[2] = new PointF(r.Right, r.Bottom);
						ps[3] = new PointF(r.Right-m_kp.RightWidth, r.Bottom);
						ps[4] = new PointF(r.Right - m_kp.RightWidth, r.Top+m_kp.TopHeight);
						ps[5] = new PointF(r.Left + m_kp.LeftWidth, r.Top + m_kp.TopHeight);
						ps[6] = new PointF(r.Left + m_kp.LeftWidth, r.Bottom);
						ps[7] = new PointF(r.Left, r.Bottom);
						break;
					case KagiStyles.TopRight:
						ps = new PointF[6];
						ps[0] = new PointF(r.Left, r.Top);
						ps[1] = new PointF(r.Right, r.Top);
						ps[2] = new PointF(r.Right, r.Bottom);
						ps[3] = new PointF(r.Right-m_kp.RightWidth, r.Bottom);
						ps[4] = new PointF(r.Right - m_kp.RightWidth, r.Top + m_kp.TopHeight);
						ps[5] = new PointF(r.Left, r.Top + m_kp.TopHeight);
						break;
					case KagiStyles.Right:
						ps = new PointF[8];
						ps[0] = new PointF(r.Left, r.Top);
						ps[1] = new PointF(r.Right, r.Top);
						ps[2] = new PointF(r.Right, r.Bottom);
						ps[3] = new PointF(r.Left, r.Bottom);
						ps[4] = new PointF(r.Left, r.Bottom-m_kp.BottomHeight);
						ps[5] = new PointF(r.Right-m_kp.RightWidth, r.Bottom - m_kp.BottomHeight);
						ps[6] = new PointF(r.Right - m_kp.RightWidth, r.Top + m_kp.TopHeight);
						ps[7] = new PointF(r.Left, r.Top + m_kp.TopHeight);
						break;
					case KagiStyles.BottomRight:
						ps = new PointF[6];
						ps[0] = new PointF(r.Right-m_kp.RightWidth, r.Top);
						ps[1] = new PointF(r.Right, r.Top);
						ps[2] = new PointF(r.Right, r.Bottom);
						ps[3] = new PointF(r.Left, r.Bottom);
						ps[4] = new PointF(r.Left, r.Bottom-m_kp.BottomHeight);
						ps[5] = new PointF(r.Right - m_kp.RightWidth, r.Bottom - m_kp.BottomHeight);
						break;
					case KagiStyles.Bottom:
						ps = new PointF[8];
						ps[0] = new PointF(r.Left, r.Top);
						ps[1] = new PointF(r.Left+m_kp.LeftWidth, r.Top);
						ps[2] = new PointF(r.Left + m_kp.LeftWidth, r.Bottom-m_kp.BottomHeight);
						ps[3] = new PointF(r.Right - m_kp.RightWidth, r.Bottom - m_kp.BottomHeight);
						ps[4] = new PointF(r.Right - m_kp.RightWidth, r.Top);
						ps[5] = new PointF(r.Right, r.Top);
						ps[6] = new PointF(r.Right, r.Bottom);
						ps[7] = new PointF(r.Left, r.Bottom);
						break;
					case KagiStyles.BottomLeft:
						ps = new PointF[6];
						ps[0] = new PointF(r.Left, r.Top);
						ps[1] = new PointF(r.Left+m_kp.LeftWidth, r.Top);
						ps[2] = new PointF(r.Left + m_kp.LeftWidth, r.Bottom-m_kp.BottomHeight);
						ps[3] = new PointF(r.Right, r.Bottom - m_kp.BottomHeight);
						ps[4] = new PointF(r.Right, r.Bottom);
						ps[5] = new PointF(r.Left, r.Bottom);
						break;
					case KagiStyles.Left:
					default:
						ps = new PointF[8];
						ps[0] = new PointF(r.Left, r.Top);
						ps[1] = new PointF(r.Right, r.Top);
						ps[2] = new PointF(r.Right, r.Top + m_kp.TopHeight);
						ps[3] = new PointF(r.Left + m_kp.LeftWidth, r.Top + m_kp.TopHeight);
						ps[4] = new PointF(r.Left + m_kp.LeftWidth, r.Bottom -m_kp.BottomHeight);
						ps[5] = new PointF(r.Right, r.Bottom - m_kp.BottomHeight);
						ps[6] = new PointF(r.Right, r.Bottom);
						ps[7] = new PointF(r.Left, r.Bottom);
						break;
				}
				g.FillPolygon(sb, ps);
				*/
			}
			finally
			{
				sb.Dispose();
			}
		}
		public override List<Control> ParamsParam()
		{
			List<Control> PList = new List<Control>();

			EditComb m_cmp = new EditComb();
			m_cmp.SetCaptionPropName("KagiStyle");
			m_cmp.SetItems(Enum.GetNames(typeof(KagiStyles)));
			PList.Add(m_cmp);


			EditFloat m_th = new EditFloat();
			m_th.SetCaptionPropName("TopHeight");
			m_th.SetValueMinMax(0, 1000);
			PList.Add(m_th);

			EditFloat m_bh = new EditFloat();
			m_bh.SetCaptionPropName("BottomHeight");
			m_bh.SetValueMinMax(0, 1000);
			PList.Add(m_bh);

			EditFloat m_lw = new EditFloat();
			m_lw.SetCaptionPropName("LeftWidth");
			m_lw.SetValueMinMax(0, 1000);
			PList.Add(m_lw);

			EditFloat m_rw = new EditFloat();
			m_rw.SetCaptionPropName("RightWidth");
			m_rw.SetValueMinMax(0, 1000);
			PList.Add(m_rw);

			return PList;

		}
		public override List<Control> ParamsColors()
		{
			List<Control> PList = new List<Control>();

			EditMGColors m_B = new EditMGColors();
			m_B.SetCaptionPropName("Fill");
			PList.Add(m_B);

			EditFloat m_BOpacity = new EditFloat();
			m_BOpacity.SetCaptionPropName("FillOpacity");
			m_BOpacity.SetValueMinMax(0, 100);
			PList.Add(m_BOpacity);

			return PList;
		}
		// ***************************************************************************
		public override JsonObject ToJson()
		{
			MGj jn = new MGj(base.ToJson());
			jn.SetMGStyle(MGStyle);
			jn.SetValue("KagiStyle", (int)m_kp.Styles);
			jn.SetValue("TopHeight", m_kp.TopHeight);
			jn.SetValue("BottomHeight", m_kp.BottomHeight);
			jn.SetValue("LeftWidth", m_kp.LeftWidth);
			jn.SetValue("RightWidth", m_kp.RightWidth);
			return jn.Obj;
		}
		// ***************************************************************************
		public override void FromJson(JsonObject jo)
		{
			bool ret = false;
			if (jo == null) return;
			base.FromJson(jo);
			MGj jn = new MGj(jo);
			int v = 0;
			if (jn.GetInt("KagiStyle", ref v) == false) ret = false; else m_kp.Styles = (KagiStyles)v;
			if (jn.GetFloat("TopHeight", ref m_kp.TopHeight) == false) ret = false;
			if (jn.GetFloat("BottomHeight", ref m_kp.BottomHeight) == false) ret = false;
			if (jn.GetFloat("LeftWidth", ref m_kp.LeftWidth) == false) ret = false;
			if (jn.GetFloat("RightWidth", ref m_kp.RightWidth) == false) ret = false;

		}
	}
}
