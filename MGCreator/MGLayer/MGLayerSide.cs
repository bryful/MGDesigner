using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MGCreator
{
	public class MGLayerSide : MGLayer
	{
		public new readonly MGStyle MGStyle = MGStyle.Side;

		private Size m_SideMargin = new Size(40, 40);
		public Size SideMargin
		{
			get { return m_SideMargin; }
			set
			{
				m_SideMargin = value;
				ChkOffScr();
			}
		}
		private Padding m_SideWeight = new Padding(20, 20, 20, 20);
		public Padding SideWeight
		{
			get { return m_SideWeight; }
			set
			{
				m_SideWeight = value;
				ChkOffScr();
			}
		}
		private KagiParam m_kp = new KagiParam();
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
		private bool[] m_SideFlags = new bool[4] { true, true, true, true };
		public bool SideTop
		{
			get { return m_SideFlags[0]; }
			set
			{
				m_SideFlags[0] = value;
				ChkOffScr();
			}
		}
		public bool SideLeft
		{
			get { return m_SideFlags[1]; }
			set
			{
				m_SideFlags[1] = value;
				ChkOffScr();
			}
		}
		public bool SideBottom
		{
			get { return m_SideFlags[2]; }
			set
			{
				m_SideFlags[2] = value;
				ChkOffScr();
			}
		}
		public bool SideRight
		{
			get { return m_SideFlags[3]; }
			set
			{
				m_SideFlags[3] = value;
				ChkOffScr();
			}
		}
		public MGLayerSide(MGForm m) : base(m)
		{
			Name = "Edge";
			m_Size = new Size(400, 400);
			m_Fill = MG_COL.White;
			m_FillOpacity = 100;
		}
		// ***************************************************************************
		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{
			SolidBrush sb = new SolidBrush(m_ForeColor);
			try
			{
				if (IsClear) g.Clear(Color.Transparent);

				Rectangle r = MarginRect(rct);
				sb.Color = GetColors(m_Fill, m_FillOpacity);

				if (m_SideFlags[0])
				{
					m_kp.Styles = KagiStyles.Top;
					m_kp.Rct = new Rectangle(
						r.X + m_SideMargin.Width,
						r.Y,
						r.Width - m_SideMargin.Width*2,
						m_SideWeight.Top);
					MGLayerKagi.DrawKagi(g,sb,m_kp);
				}
				if (m_SideFlags[1])
				{
					m_kp.Styles = KagiStyles.Right;
					m_kp.Rct = new Rectangle(
						r.Right - m_SideWeight.Right, 
						r.Y+m_SideMargin.Height,
						m_SideWeight.Right,
						r.Height - m_SideMargin.Height*2);
					MGLayerKagi.DrawKagi(g, sb, m_kp);
				}
				if (m_SideFlags[2])
				{
					m_kp.Styles = KagiStyles.Bottom;
					m_kp.Rct = new Rectangle(
						r.X + m_SideMargin.Width,
						r.Bottom - m_SideWeight.Bottom,
						r.Width - m_SideMargin.Width * 2,
						m_SideWeight.Bottom);
					MGLayerKagi.DrawKagi(g, sb, m_kp);
				}
				if (m_SideFlags[1])
				{
					m_kp.Styles = KagiStyles.Left;
					m_kp.Rct = new Rectangle(
						r.Left,
						r.Y + m_SideMargin.Height,
						m_SideWeight.Left,
						r.Height - m_SideMargin.Height * 2);
					MGLayerKagi.DrawKagi(g, sb, m_kp);
				}

			}
			finally
			{
				sb.Dispose();
			}
		}
		public override List<Control> ParamsParam()
		{
			List<Control> PList = new List<Control>();

			EditPadding m_sw = new EditPadding();
			m_sw.SetCaptionPropName("SideWeight");
			PList.Add(m_sw);

			EditSize m_sm = new EditSize();
			m_sm.SetCaptionPropName("SideMargin");
			PList.Add(m_sm);


			EditBool m_k0 = new EditBool();
			m_k0.SetCaptionPropName("SideTop");
			PList.Add(m_k0);
			EditBool m_k1 = new EditBool();
			m_k1.SetCaptionPropName("SideLeft");
			PList.Add(m_k1);
			EditBool m_k2 = new EditBool();
			m_k2.SetCaptionPropName("SideBottom");
			PList.Add(m_k2);
			EditBool m_k3 = new EditBool();
			m_k3.SetCaptionPropName("SideRight");
			PList.Add(m_k3);

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
			jn.SetValuePadding("SideWeight", m_SideWeight);
			jn.SetValueSize("SideMargin", m_SideMargin);

			jn.SetValue("SideTop", m_SideFlags[0]);
			jn.SetValue("SideLeft", m_SideFlags[1]);
			jn.SetValue("SideBottom", m_SideFlags[2]);
			jn.SetValue("SideRight", m_SideFlags[3]);

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
			if (jn.GetSize("SideMargin", ref m_SideMargin) == false) ret = false;
			if (jn.GetPadding("SideWeight", ref m_SideWeight) == false) ret = false;

			if (jn.GetBool("SideTop", ref m_SideFlags[0]) == false) ret = false;
			if (jn.GetBool("SideLeft", ref m_SideFlags[1]) == false) ret = false;
			if (jn.GetBool("SideBottom", ref m_SideFlags[2]) == false) ret = false;
			if (jn.GetBool("SideRight", ref m_SideFlags[3]) == false) ret = false;

			if (jn.GetFloat("TopHeight", ref m_kp.TopHeight) == false) ret = false;
			if (jn.GetFloat("BottomHeight", ref m_kp.BottomHeight) == false) ret = false;
			if (jn.GetFloat("LeftWidth", ref m_kp.LeftWidth) == false) ret = false;
			if (jn.GetFloat("RightWidth", ref m_kp.RightWidth) == false) ret = false;

		}
	}
}
