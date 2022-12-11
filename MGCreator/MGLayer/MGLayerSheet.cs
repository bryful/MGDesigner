using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MGCreator
{
	public class MGLayerSheet : MGLayer
	{
		public new readonly MGStyle MGStyle = MGStyle.Sheet;
		private float m_CellWidth = 120;
		public float CellWidth
		{
			get { return m_CellWidth; }
			set
			{
				m_CellWidth = value;
				ChkOffScr();
			}
		}
		private float m_CellHeight = 30;
		public float CellHeight
		{
			get { return m_CellHeight; }
			set
			{
				m_CellHeight = value;
				ChkOffScr();
			}
		}
		public MGLayerSheet(MGForm m) : base(m)
		{
			Name = "Cross";

			m_Size = new Size(200, 200);

			m_CellWidth = 120;
			m_CellHeight = 30;
			m_Back = MG_COL.Black;
			m_BackOpacity = 0;

			m_Frame = MG_COL.White;
			m_FrameOpacity = 100;
			m_FrameWeight = new Padding(2, 2, 2, 2);

			m_Line = MG_COL.White;
			m_LineOpacity = 100;
			m_LineWeight = 2;

		}
		// ***************************************************************************
		public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
		{
			SolidBrush sb = new SolidBrush(m_ForeColor);
			Pen p = new Pen(m_ForeColor);
			p.Width = 1;
			try
			{
				if (IsClear) g.Clear(Color.Transparent);

				Rectangle r2 = MarginRect(rct);
				Rectangle r = new Rectangle(
					r2.Left + m_FrameWeight.Left,
					r2.Top + m_FrameWeight.Top,
					r2.Width - m_FrameWeight.Left - m_FrameWeight.Right,
					r2.Height - m_FrameWeight.Top - m_FrameWeight.Bottom
					);
				if ((m_Back != MG_COL.Transparent) && (m_BackOpacity > 0))
				{
					sb.Color = GetColors(m_Back, m_BackOpacity);
					g.FillRectangle(sb, r2);
				}

				if ((m_Line != MG_COL.Transparent) && (m_LineOpacity > 0) && (m_LineWeight > 0))
				{
					p.Color = GetColors(m_Line, m_LineOpacity);
					p.Width = m_LineWeight;

					if (m_CellHeight > 0)
					{
						float y = r.Top;
						while (y < rct.Bottom)
						{
							g.DrawLine(p, r.Left, y, r.Right, y);
							y += m_CellHeight;
						}
					}
					if (m_CellWidth > 0)
					{
						float x = r.Left;
						while (x < rct.Right)
						{
							g.DrawLine(p, x, r.Top, x, r.Bottom);
							x += m_CellWidth;
						}
					}

				}
				if ((m_Frame != MG_COL.Transparent) && (m_FrameOpacity > 0))
				{
					sb.Color = GetColors(m_Frame, m_FrameOpacity);
					MGc.DrawFrame(g, sb, r2, m_FrameWeight);
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

			EditFloat m_cw = new EditFloat();
			m_cw.SetCaptionPropName("CellWidth");
			m_cw.SetValueMinMax(0, 1000);
			PList.Add(m_cw);

			EditFloat m_ch = new EditFloat();
			m_ch.SetCaptionPropName("CellHeight");
			m_ch.SetValueMinMax(0, 1000);
			PList.Add(m_ch);

			EditPadding m_fw = new EditPadding();
			m_fw.SetCaptionPropName("FrameWeight");
			PList.Add(m_fw);



			return PList;

		}
		public override List<Control> ParamsColors()
		{
			List<Control> PList = new List<Control>();

			EditMGColors m_B = new EditMGColors();
			m_B.SetCaptionPropName("Back");
			PList.Add(m_B);

			EditFloat m_BOpacity = new EditFloat();
			m_BOpacity.SetCaptionPropName("BackOpacity");
			m_BOpacity.SetValueMinMax(0, 100);
			PList.Add(m_BOpacity);

			EditMGColors m_C = new EditMGColors();
			m_C.SetCaptionPropName("Line");
			PList.Add(m_C);

			EditFloat m_CO = new EditFloat();
			m_CO.SetCaptionPropName("LineOpacity");
			m_CO.SetValueMinMax(0, 100);
			PList.Add(m_CO);

			EditMGColors m_F = new EditMGColors();
			m_F.SetCaptionPropName("Frame");
			PList.Add(m_F);

			EditFloat m_FO = new EditFloat();
			m_FO.SetCaptionPropName("FrameOpacity");
			m_FO.SetValueMinMax(0, 100);
			PList.Add(m_FO);


			return PList;
		}
		// ***************************************************************************
		public override JsonObject ToJson()
		{
			MGj jn = new MGj(base.ToJson());
			jn.SetMGStyle(MGStyle);
			jn.SetValue("CellWidth", m_CellWidth);
			jn.SetValue("CellHeight", m_CellHeight);
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

		}
	}
}
