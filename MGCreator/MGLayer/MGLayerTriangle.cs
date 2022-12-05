using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MGCreator
{
    public enum TriangleStyle
    {
        Top,
        Right,
        Bottom,
        Left,
        Center
    }
    public class MGLayerTriangle : MGLayer
    {
		public new readonly MGStyle MGStyle = MGStyle.Triangle;

		protected TriangleStyle m_TriangleStyle = TriangleStyle.Center;
        [Category("_MG")]
        public TriangleStyle TriangleStyle
        {
            get { return m_TriangleStyle; }
            set
            {
                m_TriangleStyle = value;
                ChkOffScr();
            }

        }
        protected float m_Rot = 0;
        [Category("_MG")]
        public float Rot
        {
            get { return m_Rot; }
            set
            {
                m_Rot = value;
                ChkOffScr();
            }

        }
        public MGLayerTriangle(MGForm m) : base(m)
        {
            Name = "Triangle";
            m_Line = MG_COLORS.White;
            m_LineOpacity = 100;
            m_LineWeight = 2;
            m_Fill = MG_COLORS.White;
            m_FillOpacity = 0;
            m_TriangleStyle = TriangleStyle.Center;
            m_Rot = 0;
        }
        // ***************************************************************************
        public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
        {
            if (m_MGForm == null) return;
            Pen p = new Pen(m_ForeColor);
            SolidBrush sb = new SolidBrush(m_ForeColor);
            try
            {
                if (IsClear) g.Clear(Color.Transparent);
                Rectangle rct2 = MarginRect(rct);
                float cx = rct2.Left + (float)rct2.Width / 2;
                float cy = rct2.Top + (float)rct2.Height / 2;
                float radius = rct2.Width;
                if (radius > rct2.Height) radius = rct2.Height;
                radius /= 2;
                sb.Color = MGForm.GetMGColors(m_Fill, m_FillOpacity);
                p.Color = MGForm.GetMGColors(m_Line, m_LineOpacity);
                p.Width = m_LineWeight;
                switch (m_TriangleStyle)
                {
                    case TriangleStyle.Center:
                        MGc.Triangle(g, p, sb, new PointF(cx, cy), radius, m_Rot);
                        break;
                    default:
                        if (m_FillOpacity > 0 && m_Fill != MG_COLORS.Transparent)
                        {

                            PointF[] t2 = MGc.TrianglePolygon(rct2, m_TriangleStyle);
                            g.FillPolygon(sb, t2);
                        }
                        if (m_LineOpacity > 0 && m_Line != MG_COLORS.Transparent && m_LineWeight > 0)
                        {
                            RectangleF rct3 = new RectangleF(
                                (float)rct2.Left + m_LineWeight,
                                (float)rct2.Top + m_LineWeight,
                                (float)rct2.Width - m_LineWeight * 2,
                                (float)rct2.Height - m_LineWeight * 2
                                );

                            PointF[] t3 = MGc.TrianglePolygon(rct3, m_TriangleStyle);
                            g.DrawPolygon(p, t3);
                        }

                        break;
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

            EditTriangleStyle m_T = new EditTriangleStyle();
            m_T.SetCaptionPropName("TriangleStyle");
            PList.Add(m_T);


            EditFloat m_LineWidth = new EditFloat();
            m_LineWidth.SetCaptionPropName("LineWeight");
            PList.Add(m_LineWidth);

            EditFloat m_cr = new EditFloat();
            m_cr.SetCaptionPropName("Rot", "Rot");
            m_cr.SetValueMinMax(1, 180);
            PList.Add(m_cr);



            return PList;

        }
        public override List<Control> ParamsColors()
        {
            List<Control> PList = new List<Control>();

            EditMGColors m_C = new EditMGColors();
            m_C.SetCaptionPropName("Line");
            PList.Add(m_C);

            EditFloat m_CO = new EditFloat();
            m_CO.SetCaptionPropName("LineOpacity");
            m_CO.SetValueMinMax(0, 100);
            PList.Add(m_CO);

            EditMGColors m_D = new EditMGColors();
            m_D.SetCaptionPropName("Fill");
            PList.Add(m_D);

            EditFloat m_DO = new EditFloat();
            m_DO.SetCaptionPropName("FillOpacity");
            m_DO.SetValueMinMax(0, 100);
            PList.Add(m_DO);


            return PList;
        }
		public override JsonObject ToJson()
		{

			MGj jn = new MGj(base.ToJson());
			jn.SetMGStyle(MGStyle);
			jn.SetValue("TriangleStyle", (int)m_TriangleStyle);
			jn.SetValue("Rot", m_Rot);
			return jn.Obj;
		}
		public override void FromJson(JsonObject jo)
		{
			bool ret = false;
			if (jo == null) return;
			base.FromJson(jo);
			MGj jn = new MGj(jo);
            int v = 0;

            if (jn.GetInt("TriangleStyle", ref v) == true) { m_TriangleStyle = (TriangleStyle)v; } else { ret = false; }
			if (jn.GetFloat("Rot", ref m_Rot) == false) ret = false;


		}
	}
}
