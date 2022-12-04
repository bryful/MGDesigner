﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGCreator
{
    public class MGLayerCircleScale : MGLayer
    {
        protected float m_CircleRot = 45;
        [Category("_MG")]
        public float CircleRot
        {
            get { return m_CircleRot; }
            set
            {
                m_CircleRot = value;
                ChkOffScr();
            }

        }
        protected float m_CircleRotOffset = 0;
        [Category("_MG")]
        public float CircleRotOffset
        {
            get { return m_CircleRotOffset; }
            set
            {
                m_CircleRotOffset = value;
                ChkOffScr();
            }

        }
        protected float m_CircleWidth = 20;
        [Category("_MG")]
        public float CircleWidth
        {
            get { return m_CircleWidth; }
            set
            {
                m_CircleWidth = value;
                ChkOffScr();
            }

        }
        public MGLayerCircleScale(MGForm m) : base(m)
        {
            Name = "CircleScale";
            m_Line = MG_COLORS.White;
            m_LineOpacity = 100;
            m_LineWeight = 2;
            m_CircleRot = 45;
            m_CircleRotOffset = 0;
            m_CircleWidth = 20;
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


                if (m_Line != MG_COLORS.Transparent && m_LineOpacity > 0 && m_LineWeight > 0)
                {
                    Rectangle r1 = MarginRect(rct);
                    float cx = r1.Left + (float)r1.Width / 2;
                    float cy = r1.Top + (float)r1.Height / 2;
                    float radius = r1.Width;
                    if (radius > r1.Height) radius = r1.Height;
                    radius /= 2;

                    Rectangle r2 = new Rectangle((int)(cx - radius), (int)(cy - radius), (int)(radius * 2), (int)(radius * 2));
                    p.Color = GetColors(m_Line, m_LineOpacity);
                    p.Width = m_LineWeight;

                    int rotCount = (int)(360 / m_CircleRot+0.5);

                    float l0 = radius;
                    float l1 = radius - m_CircleWidth;
                    if (l1 < 0) l1 = 0;

                    for (int i = 0; i < rotCount; i++)
                    {
                        float r = i * m_CircleRot - m_CircleRotOffset;
                        double xd = Math.Sin(r * Math.PI / 180);
                        double yd = Math.Cos(r * Math.PI / 180);
                        float x0 = (float)(cx + l0 * xd);
                        float y0 = (float)(cy + l0 * yd);
                        float x1 = (float)(cx + l1 * xd);
                        float y1 = (float)(cy + l1 * yd);
                        PointF[] pnts = new PointF[] { new PointF(x0, y0), new PointF(x1, y1) };
                        g.DrawLines(p, pnts);

                    }
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

            EditFloat m_LineWidth = new EditFloat();
            m_LineWidth.SetCaptionPropName("LineWeight");
            PList.Add(m_LineWidth);

            EditFloat m_cr = new EditFloat();
            m_cr.SetCaptionPropName("Rot", "CircleRot");
            m_cr.SetValueMinMax(1, 180);
            PList.Add(m_cr);

            EditFloat m_cro = new EditFloat();
            m_cro.SetCaptionPropName("RotOffset", "CircleRotOffset");
            m_cro.SetValueMinMax(-90, 90);
            PList.Add(m_cro);


            EditFloat m_cw = new EditFloat();
            m_cw.SetCaptionPropName("CircleWidth");
            m_cw.SetValueMinMax(1, 4000);
            PList.Add(m_cw);

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


            return PList;
        }
    }
}
