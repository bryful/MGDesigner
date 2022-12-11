using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;


namespace MGCreator
{

	public class MGLayerScale : MGLayer
	{
		public enum ScaleTypes
		{
			Left,
			Right,
			Top,
			Bottom,
			HorSide,
			VirSide
		};
		public class ScalePrm
		{
			public float Inter = 50;
			public bool IsCenter = true;
			public int ShortCount = 0;
			public float Length = 20;
			public float Weight = 2;
			public float CenterLength = 70;
			public float CenterWeight = 2;
			public float ShortLength = 40;
			public float ShortWeight = 1;
			public float Offset = 1;

			public ScalePrm()
			{
			}
			public void Copy(ScalePrm sp)
			{
				Inter = sp.Inter;
				IsCenter = sp.IsCenter;
				ShortCount = sp.ShortCount;
				Length = sp.Length;
				Weight = sp.Weight;
				CenterLength = sp.CenterLength;
				CenterWeight = sp.CenterWeight;
				ShortLength = sp.ShortLength;
				ShortWeight = sp.ShortWeight;
				Offset = sp.Offset;
		}
	}
		private ScalePrm m_SP = new ScalePrm();

		public new readonly MGStyle MGStyle = MGStyle.Scale;
		public float Inter
		{
			get { return m_SP.Inter; }
			set 
			{
				m_SP.Inter = value;
				if (m_SP.Inter < 10) m_SP.Inter = 10;
				ChkOffScr();

			}
		}
		public bool IsCenter
		{
			get { return m_SP.IsCenter; }
			set
			{
				m_SP.IsCenter = value;
				ChkOffScr();
			}
		}
		public int ShortCount
		{
			get { return m_SP.ShortCount; }
			set
			{
				m_SP.ShortCount = value;
				ChkOffScr();
			}
		}
		public float Length
		{
			get { return m_SP.Length; }
			set
			{
				m_SP.Length = value;
				ChkOffScr();
			}
		}
		public float Weight
		{
			get { return m_SP.Weight; }
			set
			{
				m_SP.Weight = value;
				ChkOffScr();
			}
		}
		public float CenterLength
		{
			get { return m_SP.CenterLength; }
			set
			{
				m_SP.CenterLength = value;
				ChkOffScr();
			}
		}
		public float CenterWeight
		{
			get { return m_SP.CenterWeight; }
			set
			{
				m_SP.CenterWeight = value;
				ChkOffScr();
			}
		}
		public float ShortLength
		{
			get { return m_SP.ShortLength; }
			set
			{
				m_SP.ShortLength = value;
				ChkOffScr();
			}
		}
		public float ShortWeight
		{
			get { return m_SP.ShortWeight; }
			set
			{
				m_SP.ShortWeight = value;
				ChkOffScr();
			}
		}
		public float Offset
		{
			get { return m_SP.Offset; }
			set
			{
				m_SP.Offset = value;
				ChkOffScr();
			}
		}
		private ScaleTypes m_ScaleType = ScaleTypes.Left;
		public int ScaleType
		{
			get { return (int)m_ScaleType; }
			set
			{
				if((value>=(int)ScaleTypes.Left)&&(value <= (int)ScaleTypes.VirSide))
				{
					m_ScaleType =(ScaleTypes)value;
					ChkOffScr();
				}
			}
		}
		public MGLayerScale(MGForm m) : base(m)
		{
			Name = "scale";
			m_Size = new Size(200, 200);
			m_Line = MG_COL.White;
			m_LineOpacity = 100;
		}
		// ***************************************************************************
		public void DrawScaleLeftRight(Graphics g, Pen p,ScalePrm sp, Rectangle rct, bool IsLeft)
		{
			float c = rct.Top + (float)rct.Height / 2 +sp.Offset;

			float st = (float)rct.Left;
			if(IsLeft==false) st = (float)rct.Right;
			float edl = st + sp.Length;
			if (IsLeft == false) edl = st - sp.Length;

			float edc = st + sp.Length * sp.CenterLength / 100;
			if (IsLeft == false) edc = st - sp.Length * sp.CenterLength / 100;
			float eds = st + sp.Length * sp.ShortLength / 100;
			if (IsLeft == false) eds = st - sp.Length * sp.ShortLength / 100;


			// 起点を描画
			p.Width = sp.Weight;
			g.DrawLine(p, st, c, edl, c);

			int MainC = (m_SP.ShortCount + 1) * 2;
			int CenerC = (m_SP.ShortCount + 1);
			float ir = sp.Inter / MainC;
			float cc = c - ir;
			int cnt = 1;
			while (cc>rct.Top)
			{
				if ((cnt % MainC) == 0)
				{
					p.Width = sp.Weight;
					g.DrawLine(p, st, cc, edl, cc);
				}
				else if (sp.IsCenter)
				{
					if (((cnt % CenerC) == 0))
					{
							p.Width = sp.CenterWeight;
							g.DrawLine(p, st, cc, edc, cc);
					}
					else
					{
						p.Width = sp.ShortWeight;
						g.DrawLine(p, st, cc, eds, cc);
					}
				}
				cc -= ir;
				cnt++;
			}
			cc = c + ir;
			cnt = 1;
			while (cc < rct.Bottom)
			{
				if ((cnt % MainC) == 0)
				{
					p.Width = sp.Weight;
					g.DrawLine(p, st, cc, edl, cc);
				}
				else if (sp.IsCenter)
				{
					if (((cnt % CenerC) == 0))
					{
						p.Width = sp.CenterWeight;
						g.DrawLine(p, st, cc, edc, cc);
					}
					else
					{
						p.Width = sp.ShortWeight;
						g.DrawLine(p, st, cc, eds, cc);
					}

				}
				cc += ir;
				cnt++;
			}
		}
		// ***************************************************************************
		public void DrawScaleTopBottom(Graphics g, Pen p, ScalePrm sp, Rectangle rct, bool IsTop)
		{
			float c = rct.Left + (float)rct.Width / 2 + sp.Offset;

			float st = (float)rct.Top;
			if (IsTop == false) st = (float)rct.Bottom;
			float edl = st + sp.Length;
			if (IsTop == false) edl = st - sp.Length;

			float edc = st + sp.Length * sp.CenterLength / 100;
			if (IsTop == false) edc = st - sp.Length * sp.CenterLength / 100;
			float eds = st + sp.Length * sp.ShortLength / 100;
			if (IsTop == false) eds = st - sp.Length * sp.ShortLength / 100;


			// 起点を描画
			p.Width = sp.Weight;
			g.DrawLine(p, c, st, c, edl);

			int MainC = (m_SP.ShortCount + 1) * 2;
			int CenerC = (m_SP.ShortCount + 1);
			float ir = sp.Inter / MainC;
			float cc = c - ir;
			int cnt = 1;
			while (cc > rct.Top)
			{
				if ((cnt % MainC) == 0)
				{
					p.Width = sp.Weight;
					g.DrawLine(p, cc, st, cc, edl);
				}
				else if (sp.IsCenter)
				{
					if (((cnt % CenerC) == 0))
					{
						p.Width = sp.CenterWeight;
						g.DrawLine(p, cc, st, cc, edc);
					}
					else
					{
						if (m_SP.ShortCount > 0)
						{
							p.Width = sp.ShortWeight;
							g.DrawLine(p, cc, st, cc, eds);
						}
					}
				}
				cc -= ir;
				cnt++;
			}
			cc = c + ir;
			cnt = 1;
			while (cc < rct.Bottom)
			{
				if ((cnt % MainC) == 0)
				{
					p.Width = sp.Weight;
					g.DrawLine(p, cc, st, cc, edl);
				}else if (sp.IsCenter)
				{
					if (((cnt % CenerC) == 0))
					{
							p.Width = sp.CenterWeight;
							g.DrawLine(p, cc, st, cc, edc);
					}
					else
					{
						if (m_SP.ShortCount > 0)
						{
							p.Width = sp.ShortWeight;
							g.DrawLine(p, cc, st, cc, eds);
						}
					}
				}
				cc += ir;
				cnt++;
			}
		}
		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{
			SolidBrush sb = new SolidBrush(m_ForeColor);
			Pen p = new Pen(m_ForeColor);
			p.Width = 1;
			try
			{
				if (IsClear) g.Clear(Color.Transparent);
				p.Color = GetColors(m_Line, m_LineOpacity);
				Rectangle r = MarginRect(rct);
				switch(m_ScaleType)
				{
					case ScaleTypes.Left:
						DrawScaleLeftRight(g, p, m_SP, r, true);
						break;
					case ScaleTypes.Right:
						DrawScaleLeftRight(g, p, m_SP, r, false);
						break;
					case ScaleTypes.Top:
						DrawScaleTopBottom(g, p, m_SP, r, true);
						break;
					case ScaleTypes.Bottom:
						DrawScaleTopBottom(g, p, m_SP, r, false);
						break;
					case ScaleTypes.HorSide:
						DrawScaleTopBottom(g, p, m_SP, r, true);
						DrawScaleTopBottom(g, p, m_SP, r, false);
						break;
					case ScaleTypes.VirSide:
						DrawScaleLeftRight(g, p, m_SP, r, true);
						DrawScaleLeftRight(g, p, m_SP, r, false);
						break;
				}

			}
			finally
			{
				sb.Dispose();
				p.Dispose();
			}
		}
		public override List<Control> ParamsParam()
		{
			List<Control> PList = new List<Control>();

			EditComb m_st = new EditComb();
			m_st.SetItems(Enum.GetNames(typeof(ScaleTypes)));
			m_st.SetCaptionPropName("ScaleType");

			PList.Add(m_st);


			EditFloat m_i = new EditFloat();
			m_i.SetCaptionPropName("Inter");
			m_i.SetValueMinMax(10,3000);
			PList.Add(m_i);

			EditFloat m_l = new EditFloat();
			m_l.SetCaptionPropName("Length");
			m_l.SetValueMinMax(0, 1000);
			PList.Add(m_l);

			EditFloat m_w = new EditFloat();
			m_w.SetCaptionPropName("Weight");
			m_w.SetValueMinMax(0, 50);
			PList.Add(m_w);
			EditFloat m_of = new EditFloat();
			m_of.SetCaptionPropName("Offset");
			m_of.SetValueMinMax(-1000, 1000);
			PList.Add(m_of);

			EditBool m_b = new EditBool();
			m_b.SetCaptionPropName("IsCenter");
			m_b.SetTrueFalseWord("Draw Center", "No Center");
			PList.Add(m_b);
			EditFloat m_cl = new EditFloat();
			m_cl.SetCaptionPropName("CenterLength");
			m_cl.SetValueMinMax(0, 200);
			PList.Add(m_cl);

			EditFloat m_cw = new EditFloat();
			m_cw.SetCaptionPropName("CenterWeight");
			m_cw.SetValueMinMax(0, 50);
			PList.Add(m_cw);

			EditInt m_sc = new EditInt();
			m_sc.SetCaptionPropName("ShortCount");
			m_sc.SetValueMinMax(0, 4);
			PList.Add(m_sc);

			EditFloat m_sl = new EditFloat();
			m_sl.SetCaptionPropName("ShortLength");
			m_sl.SetValueMinMax(0, 200);
			PList.Add(m_sl);

			EditFloat m_sw = new EditFloat();
			m_sw.SetCaptionPropName("ShortWeight");
			m_sw.SetValueMinMax(0, 50);
			PList.Add(m_sw);


			return PList;

		}
		public override List<Control> ParamsColors()
		{
			List<Control> PList = new List<Control>();

			EditMGColors m_gc = new EditMGColors();
			m_gc.SetCaptionPropName("Line");
			PList.Add(m_gc);

			EditFloat m_gco = new EditFloat();
			m_gco.SetCaptionPropName("LineOpacity");
			m_gco.SetValueMinMax(0, 100);
			PList.Add(m_gco);

			return PList;
		}
		// ***************************************************************************
		public override JsonObject ToJson()
		{

			MGj jn = new MGj(base.ToJson());
			jn.SetMGStyle(MGStyle);
			jn.SetValue("Inter", m_SP.Inter);
			jn.SetValue("IsCenter", m_SP.IsCenter);
			jn.SetValue("ShortCount", m_SP.ShortCount);
			jn.SetValue("Length", m_SP.Length);
			jn.SetValue("CenterLength", m_SP.CenterLength);
			jn.SetValue("CenterWeight", m_SP.CenterWeight);
			jn.SetValue("ShortLength", m_SP.ShortLength);
			jn.SetValue("ShortWeight", m_SP.ShortWeight);
			jn.SetValue("Offset", m_SP.Offset);
			jn.SetValue("ScaleType", (int)m_ScaleType);

			return jn.Obj;
		}
		public override void FromJson(JsonObject jo)
		{
			bool ret = false;
			if (jo == null) return;
			base.FromJson(jo);
			MGj jn = new MGj(jo);
			if (jn.GetFloat("Inter", ref m_SP.Inter) == false) ret = false;
			if (jn.GetBool("IsCenter", ref m_SP.IsCenter) == false) ret = false;
			if (jn.GetInt("ShortCount", ref m_SP.ShortCount) == false) ret = false;
			if (jn.GetFloat("Length", ref m_SP.Length) == false) ret = false;
			if (jn.GetFloat("CenterLength", ref m_SP.CenterLength) == false) ret = false;
			if (jn.GetFloat("CenterWeight", ref m_SP.CenterWeight) == false) ret = false;
			if (jn.GetFloat("Offset", ref m_SP.Offset) == false) ret = false;
			int v = 0;
			if (jn.GetInt("ScaleType", ref v))
			{
				m_ScaleType = (ScaleTypes)v;
			}
			else
			{
				ret = false;
			}


		}
	}
}
