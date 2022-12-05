using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MGCreator
{

    public class MGLayerZebra : MGLayer
    {
		public new readonly MGStyle MGStyle = MGStyle.Zebra;

		protected float m_Rot = 45;
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
        protected float m_ZebraWidth = 45;
        [Category("_MG")]
        public float ZebraWidth
        {
            get { return m_ZebraWidth; }
            set
            {
                m_ZebraWidth = value;
                ChkOffScr();
            }

        }
        protected float m_ZebraOpacity = 100;
        [Category("_MG")]
        public float ZebraOpacity
        {
            get { return m_ZebraOpacity; }
            set
            {
                m_ZebraOpacity = value;
                ChkOffScr();
            }

        }
        public MGLayerZebra(MGForm m) : base(m)
        {
            Name = "Zebra";
            m_Back = MG_COLORS.Black;
            m_BackOpacity = 0;

            m_Fill = MG_COLORS.White;
            m_FillOpacity = 100;

            m_Rot = 45;
            m_ZebraWidth = 20;

            m_Frame = MG_COLORS.White;
            m_FrameOpacity = 0;
            m_FrameWeight = new Padding(2, 2, 2, 2);
        }
        public override void Draw(Graphics g, Rectangle rct, bool IsClear = true)
        {
            if (m_MGForm == null) return;
            Color c = m_MGForm.GetMGColors(m_Fill, m_FillOpacity);
            Color b = m_MGForm.GetMGColors(m_Back, m_BackOpacity);

            SolidBrush sb = new SolidBrush(b);
            //Pen p = new Pen(c);
            try
            {
                if (IsClear) g.Clear(Color.Transparent);

                Rectangle rct2 = MarginRect(rct);
                Point[] ps = new Point[]
                {
                    new Point(rct2.Left,rct2.Top),
                    new Point(rct2.Right,rct2.Top),
                    new Point(rct2.Right,rct2.Bottom),
                    new Point(rct2.Left,rct2.Bottom)
                };
                GraphicsPath path = new GraphicsPath();
                path.AddPolygon(ps);
                Region region = new Region(path);
                g.SetClip(region, CombineMode.Replace);

                if (m_BackOpacity > 0 && m_Back != MG_COLORS.Transparent)
                {
                    sb.Color = b;
                    g.FillRectangle(sb, rct2);
                }
                if (m_FillOpacity > 0 && m_Fill != MG_COLORS.Transparent && m_ZebraWidth > 0)
                {
                    sb.Color = c;
                    MGc.DrawZebra(g, sb, rct2, m_ZebraWidth, m_Rot);
                }
                if (m_FrameOpacity > 0 && m_Frame != MG_COLORS.Transparent)
                {
                    sb.Color = m_MGForm.GetMGColors(m_Frame, m_FrameOpacity);
                    MGc.DrawFrame(g, sb, rct2, m_FrameWeight);
                }
            }
            catch
            {
            }
            finally
            {
                //p.Dispose();
                sb.Dispose();
            }



        }
        public override List<Control> ParamsParam()
        {
            List<Control> PList = new List<Control>();

            EditFloat m_T = new EditFloat();
            m_T.SetCaptionPropName("Rot");
            m_T.SetValueMinMax(-45, 45);
            PList.Add(m_T);


            EditFloat m_zw = new EditFloat();
            m_zw.SetCaptionPropName("ZebraWidth");
            PList.Add(m_zw);

            EditPadding m_P = new EditPadding();
            m_P.SetCaptionPropName("FrameWeight");
            PList.Add(m_P);


            return PList;

        }
        public override List<Control> ParamsColors()
        {
            List<Control> PList = new List<Control>();



            EditMGColors m_D = new EditMGColors();
            m_D.SetCaptionPropName("Fill");
            PList.Add(m_D);

            EditFloat m_DO = new EditFloat();
            m_DO.SetCaptionPropName("FillOpacity");
            m_DO.SetValueMinMax(0, 100);
            PList.Add(m_DO);

            EditMGColors m_C = new EditMGColors();
            m_C.SetCaptionPropName("Back");
            PList.Add(m_C);

            EditFloat m_CO = new EditFloat();
            m_CO.SetCaptionPropName("BackOpacity");
            m_CO.SetValueMinMax(0, 100);
            PList.Add(m_CO);

            EditMGColors m_G = new EditMGColors();
            m_G.SetCaptionPropName("Frame");
            PList.Add(m_G);

            EditFloat m_GO = new EditFloat();
            m_GO.SetCaptionPropName("FrameOpacity");
            m_GO.SetValueMinMax(0, 100);
            PList.Add(m_GO);
            return PList;
        }
		public override JsonObject ToJson()
		{

			MGj jn = new MGj(base.ToJson());
            jn.SetMGStyle(MGStyle);
			jn.SetValue("Rot", m_Rot);
			jn.SetValue("ZebraWidth", m_ZebraWidth);
			jn.SetValue("ZebraOpacity", m_ZebraOpacity);

			return jn.Obj;
		}
		public override void FromJson(JsonObject jo)
		{
			bool ret = false;
			if (jo == null) return;
			base.FromJson(jo);
			MGj jn = new MGj(jo);
			int v = 0;
			if (jn.GetFloat("Rot", ref m_Rot) == false) ret = false;
			if (jn.GetFloat("ZebraWidth", ref m_ZebraWidth) == false) ret = false;
			if (jn.GetFloat("ZebraOpacity", ref m_ZebraOpacity) == false) ret = false;

		}
	}
}
