using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGCreator
{
    public class MGc
    {
        static public void DrawFrame(Graphics g, Pen p, int weight, Rectangle r)
        {
            float pw = p.Width;
            p.Width = 1;
            Rectangle r2 = new Rectangle(r.X, r.Y, r.Width - 1, r.Height - 1);
            for (int i = 0; i < weight; i++)
            {
                g.DrawRectangle(p, r2);
                r2 = new Rectangle(r2.X + 1, r2.Y + 1, r2.Width - 2, r2.Height - 2);
            }
        }
		static public void Fill(Graphics g, SolidBrush sb, Rectangle r)
		{
			Rectangle r2 = new Rectangle(r.X, r.Y, r.Width - 1, r.Height -1);
			g.FillRectangle(sb, r2);
		}
		static public void DrawFrame(Graphics g, SolidBrush sb, Rectangle r,Padding p)
		{
            if((p.Left<=0)&& (p.Right<=0)&&(p.Top<=0)&&(p.Bottom<=0))
            {
                return;
            }
			if ((p.Top + p.Bottom>=r.Height)|| (p.Right + p.Left >= r.Width))
			{
                g.FillRectangle(sb, r);
                return;
            }
            Rectangle r2;
            if(p.Top>0)
            {
                r2 = new Rectangle(r.Left, r.Top, r.Width, p.Top);
                g.FillRectangle(sb, r2);
            }
			if (p.Bottom > 0)
			{
				r2 = new Rectangle(r.Left, r.Bottom- p.Bottom, r.Width, p.Bottom);
				g.FillRectangle(sb, r2);
			}
            int h = r.Height - p.Top - p.Bottom;
            if (h > 0)
            {
                if (p.Left > 0)
                {
                    r2 = new Rectangle(
                        r.Left, 
                        r.Top + p.Top, 
                        p.Left,
                        h);
					g.FillRectangle(sb, r2);
				}
				if (p.Right > 0)
                {
                    r2 = new Rectangle(
                        r.Right - p.Right,
                        r.Top + p.Top,
                        p.Right,
                        h);
					g.FillRectangle(sb, r2);
				}
			}
		}
	}
}
