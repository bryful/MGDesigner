﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGCreator
{
    public class MGs
    {
        // *****************************************************************
        static public string ValueToString(Padding p)
        {
            return $"{p.Left},{p.Right},{p.Top},{p.Bottom}";
        }
		static public string ValueToString(Point p)
		{
			return $"{p.X},{p.Y}";
		}
		// *****************************************************************
		static public string ValueToString(Color p)
        {
            return $"{p.R},{p.G},{p.B}";
        }
		// *****************************************************************
		static public string ValueToString(Size sz)
		{
			return $"{sz.Width},{sz.Height}";
		}
		// *****************************************************************
		static public bool StringToValue(string s, ref Padding pad)
        {
            bool ret = false;
            string[] sa = s.Split(',');
            if (sa.Length == 0)
            {
                ret = false;
            }
            else if (sa.Length == 1)
            {
                int v = 0;
                if (int.TryParse(sa[0], out v))
                {
                    pad = new Padding(v, v, v, v);
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            else
            {
                int v0 = pad.Left;
                int v1 = pad.Top;
                int v2 = pad.Right;
                int v3 = pad.Bottom;
                if (sa.Length > 0)
                {
                    if (int.TryParse(sa[0], out v0) == false) v0 = pad.Left;
                }
                if (sa.Length > 1)
                {
                    if (int.TryParse(sa[1], out v1) == false) v1 = pad.Top;
                }
                if (sa.Length > 2)
                {
                    if (int.TryParse(sa[2], out v2) == false) v2 = pad.Right;
                }
                if (sa.Length > 3)
                {
                    if (int.TryParse(sa[3], out v3) == false) v3 = pad.Bottom;
                }
                pad = new Padding(v0, v1, v2, v3);
                ret = true;
            }
            return ret;
        }
        // *****************************************************************
        static public bool StringToValue(string s, ref Color col)
        {
            bool ret = false;
            string[] sa = s.Split(',');
            if (sa.Length == 0)
            {
                ret = false;
            }
            else if (sa.Length == 1)
            {
                int v = 0;
                if (int.TryParse(sa[0], out v))
                {
                    col = Color.FromArgb(v, v, v);
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            else
            {
                int v0 = col.R;
                int v1 = col.G;
                int v2 = col.B;
                if (sa.Length > 0)
                {
                    if (int.TryParse(sa[0], out v0) == false) v0 = col.R;
                    if (v0 < 0) v0 = 0; else if (v0 > 255) v0 = 255;
                }
                if (sa.Length > 1)
                {
                    if (int.TryParse(sa[1], out v1) == false) v1 = col.G;
                    if (v1 < 0) v1 = 0; else if (v1 > 255) v1 = 255;
                }
                if (sa.Length > 2)
                {
                    if (int.TryParse(sa[2], out v2) == false) v2 = col.B;
                    if (v2 < 0) v2 = 0; else if (v2 > 255) v2 = 255;
                }
                col = Color.FromArgb(v0, v1, v2);
                ret = true;
            }
            return ret;
        }
		// *****************************************************************
		static public bool StringToValue(string s, ref Size sz)
		{
			bool ret = false;
            if (s == "") return ret;
			string[] sa = s.Split(',');
			if (sa.Length == 0)
			{
				ret = false;
			}
			else if (sa.Length == 1)
			{
				int v = 0;
				if (int.TryParse(sa[0], out v))
				{
					sz = new Size(v, v);
					ret = true;
				}
				else
				{
					ret = false;
				}
			}
			else
			{
				int v0 = sz.Width;
				int v1 = sz.Height;
				if (sa.Length > 0)
				{
					if (int.TryParse(sa[0], out v0) == false) v0 = sz.Width;
				}
				if (sa.Length > 1)
				{
					if (int.TryParse(sa[1], out v1) == false) v1 = sz.Height;
				}
				sz = new Size(v0, v1);
				ret = true;
			}
			return ret;
		}
		static public bool StringToValue(string s, ref Point sz)
		{
			bool ret = false;
			if (s == "") return ret;
			string[] sa = s.Split(',');
			if (sa.Length == 0)
			{
				ret = false;
			}
			else if (sa.Length == 1)
			{
				int v = 0;
				if (int.TryParse(sa[0], out v))
				{
					sz = new Point(v, v);
					ret = true;
				}
				else
				{
					ret = false;
				}
			}
			else
			{
				int v0 = sz.X;
				int v1 = sz.Y;
				if (sa.Length > 0)
				{
					if (int.TryParse(sa[0], out v0) == false) v0 = sz.X;
				}
				if (sa.Length > 1)
				{
					if (int.TryParse(sa[1], out v1) == false) v1 = sz.Y;
				}
				sz = new Point(v0, v1);
				ret = true;
			}
			return ret;
		}
	}
}