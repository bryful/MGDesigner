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
	public class MGC
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
	}
}
