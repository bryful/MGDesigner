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

namespace MGCreator
{
    public partial class MGLayerPolygon : MGLayer
    {
		public new readonly MGStyle MGStyle = MGStyle.Polygon;

		protected int m_Count = 4;
        [Category("_MG")]
        public int Count
        {
            get { return m_Count; }
            set
            {
                m_Count = value;
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
        public MGLayerPolygon(MGForm m) : base(m)
        {
            Name = "Polygon";
            m_Line = MG_COL.White;
            m_LineOpacity = 100;
            m_LineWeight = 2;
            m_Fill = MG_COL.White;
            m_FillOpacity = 0;
            m_Count = 4;
            m_Rot = 0;
        }


        public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
        {
            if (m_MGForm == null) return;
            SolidBrush sb = new SolidBrush(m_BackColor);
            Pen p = new Pen(m_ForeColor);
            try
            {
                if (IsClear) g.Clear(Color.Transparent);
                Rectangle rct2 = MarginRect(rct);
                float radius = rct2.Width;
                if (radius > rct2.Height) radius = rct2.Height;
                radius /= 2;

                float cx = rct2.Left + (float)rct2.Width / 2;
                float cy = rct2.Top + (float)rct2.Height / 2;

                if (m_FillOpacity > 0 && m_Fill != MG_COL.Transparent)
                {
                    sb.Color = m_MGForm.GetMGColors(m_Fill, m_FillOpacity);
                    PointF[] pnts = MGc.PolygonPolygon(m_Count, new PointF(cx, cy), radius, m_Rot);
                    g.FillPolygon(sb, pnts);

                }
                if (m_LineOpacity > 0 && m_Line != MG_COL.Transparent && m_LineWeight > 0)
                {
                    sb.Color = m_MGForm.GetMGColors(m_Line, m_LineOpacity);
                    p.Width = m_LineWeight;
                    PointF[] pnts = MGc.PolygonPolygon(m_Count, new PointF(cx, cy), radius - m_LineWeight, m_Rot);
                    g.DrawPolygon(p, pnts);

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

            EditInt m_I = new EditInt();
            m_I.SetCaptionPropName("Count");
            m_I.SetValueMinMax(3, 12);
            PList.Add(m_I);


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
			jn.SetValue("Count", (int)m_Count);
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
			if (jn.GetInt("Count", ref v) == false) ret = false;
			if (jn.GetFloat("Rot", ref m_Rot) == false) ret = false;

		}
	}
}
