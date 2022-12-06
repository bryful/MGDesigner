using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MGCreator
{
    public class MGj
    {
        public JsonObject? Obj = null;
        // ******************************************
        public MGj(JsonObject? obj=null)
        {
            Obj = obj;
        }
		// ******************************************
		public bool Save(string? p)
        {
			bool ret = false;
			if ((Obj==null)||(p == null) || (p == "")) return ret;
			try
			{
				string js = Obj.ToJsonString();
				File.WriteAllText(p, js);
				ret = true;
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		// ******************************************
		public JsonObject? Load(string? p)
        {
			JsonObject? ret = null;
			if ((p == null) || (p == "")) return ret;
			try
			{
				if (File.Exists(p) == true)
				{
					string str = File.ReadAllText(p);
					if (str != "")
					{
						var doc = JsonNode.Parse(str);
						if (doc != null)
						{
							Obj = (JsonObject)doc;
							ret = Obj;
						}
					}
				}
            }
            catch
            {
                Obj = null;
                ret = null; ;
			}
			return ret;
		}
		// ******************************************
		public JsonArray? GetArray(string key)
        {
            JsonArray? ja = null;

			if (Obj == null) return ja;
			if (Obj.ContainsKey(key))
			{
				ja = Obj[key].AsArray();
			}
            return ja;
		}

		// ******************************************
		public void SetValue(string key, JsonNode? value)
        {
            if (Obj != null)
            {
                if(Obj.ContainsKey(key))
                {
                    Obj[key] = value;
                }
                else
                {
					Obj.Add(key, value);
				}
			}
        }
		public void SetValue(string key, MG_COL value)
		{
			if (Obj != null)
			{
				if (Obj.ContainsKey(key))
				{
					Obj[key] = (int)value;
				}
				else
				{
					Obj.Add(key, (int)value);
				}
			}
		}
		public string? ValueStr(string key)
        {
            string? ret = null;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    ret = Obj[key].GetValue<string>();
                }
            }
            return ret;
        }
        public int? ValueInt(string key)
        {
            int? ret = null;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    ret = Obj[key].GetValue<int>();
                }
            }
            return ret;
        }
        public float? ValueFloat(string key)
        {
            float? ret = null;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    ret = Obj[key].GetValue<float>();
                }
            }
            return ret;
        }
        public double? ValueDouble(string key)
        {
            double? ret = null;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    ret = Obj[key].GetValue<double>();
                }
            }
            return ret;
        }
        public bool? ValueBool(string key)
        {
            bool? ret = null;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    ret = Obj[key].GetValue<bool>();
                }
            }
            return ret;
        }
        public Color? ValueColor(string key)
        {
            Color? ret = null;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    JsonArray ja = Obj[key].AsArray();
                    if (ja != null && ja.Count >= 3)
                    {
                        try
                        {
                            int r = ja[0].GetValue<int>();
                            if (r < 0) r = 0; else if (r > 255) r = 2555;
                            int g = ja[1].GetValue<int>();
                            if (g < 0) g = 0; else if (g > 255) g = 2555;
                            int b = ja[2].GetValue<int>();
                            if (b < 0) b = 0; else if (b > 255) b = 2555;
                            ret = Color.FromArgb(r, g, b);
                        }
                        catch { }
                    }
                }
            }
            return ret;
        }
        public void SetValueColor(string key, Color c)
        {
            if (Obj == null) return;
            JsonArray ja = new JsonArray();
            ja.Add(c.R);
            ja.Add(c.G);
            ja.Add(c.B);
            if(Obj.ContainsKey(key))
            {
                Obj[key] = ja;
            }
            else
            {
				Obj.Add(key, ja);
			}
		}
		public void SetValueColors(string key, Color[] c)
		{
			if (Obj == null) return;
			JsonArray ja = new JsonArray();
            if (c.Length>0)
            {
                for(int i=0;i<c.Length; i++)
                {
                    Color c2 = c[i];
					JsonArray ja1 = new JsonArray();
					ja1.Add(c2.R);
					ja1.Add(c2.G);
					ja1.Add(c2.B);

                    ja.Add(ja1);
				}
			}
            if(Obj.ContainsKey(key))
            {
                Obj[key] = ja;

            }
            else
            {
                Obj.Add(key, ja);
            }
		}
		public bool GetValueColors(string key, ref Color[] c)
		{
            bool ret = false;
			if (Obj == null) return ret;
            if(Obj.ContainsKey(key))
            {
				JsonArray? ja = Obj[key].AsArray();
                if(ja!=null)
                {
                    if (ja.Count != (int)MG_COL.Transparent) return ret;
                    Color [] result = new Color[ja.Count];
                    for(int i=0; i<ja.Count;i++)
                    {
                        bool b = false;
                        JsonArray? a = ja[i].AsArray();

						if (a != null && a.Count >= 3)
						{
							int? v0 = a[0].GetValue<int?>();
							int? v1 = a[1].GetValue<int?>();
							int? v2 = a[2].GetValue<int?>();
							if (v0 != null && v1 != null && v2 != null)
							{
                                result[i] 
                                    = Color.FromArgb((int)v0, (int)v1, (int)v2);
                                b = true;
							}
						}
                        if (b == false) return ret;

					}
                    c = result;
                    ret = true;
                }
			}
            return ret;
		}
		public Point? ValuePoint(string key)
        {
            Point? ret = null;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    JsonArray ja = Obj[key].AsArray();
                    if (ja != null && ja.Count >= 2)
                    {
                        try
                        {
                            int v1 = ja[0].GetValue<int>();
                            int v2 = ja[1].GetValue<int>();
                            ret = new Point(v1, v2);
                        }
                        catch { }
                    }
                }
            }
            return ret;
        }
        public void SetValuePoint(string key, Point c)
        {
            if (Obj == null) return;
            JsonArray ja = new JsonArray();
            ja.Add(c.X);
            ja.Add(c.Y);
            if (Obj.ContainsKey(key))
            {
                Obj[key]= ja;
            }
            else
            {
				Obj.Add(key, ja);
			}
		}
        public Size? ValueSize(string key)
        {
            Size? ret = null;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    JsonArray ja = Obj[key].AsArray();
                    if (ja != null && ja.Count >= 2)
                    {
                        try
                        {
                            int v1 = ja[0].GetValue<int>();
                            int v2 = ja[1].GetValue<int>();
                            ret = new Size(v1, v2);
                        }
                        catch { }
                    }
                }
            }
            return ret;
        }
        public void SetValueSize(string key, Size c)
        {
            if (Obj == null) return;
            JsonArray ja = new JsonArray();
            ja.Add(c.Width);
            ja.Add(c.Height);
            if(Obj.ContainsKey(key))
            {
				Obj[key] =  ja;
			}
            else
            {
				Obj.Add(key, ja);
			}
		}
        public Padding? ValuePadding(string key)
        {
            Padding? ret = null;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    JsonArray ja = Obj[key].AsArray();
                    if (ja != null && ja.Count >= 4)
                    {
                        try
                        {
                            int v0 = ja[0].GetValue<int>();
                            int v1 = ja[1].GetValue<int>();
                            int v2 = ja[2].GetValue<int>();
                            int v3 = ja[3].GetValue<int>();
                            ret = new Padding(v0, v1, v2, v3);
                        }
                        catch { }
                    }
                }
            }
            return ret;
        }
        public void SetValuePadding(string key, Padding c)
        {
            if (Obj == null) return;
            JsonArray ja = new JsonArray();
            ja.Add(c.Left);
            ja.Add(c.Top);
            ja.Add(c.Right);
            ja.Add(c.Bottom);
            if(Obj.ContainsKey(key))
            {
				Obj[key] = ja;
			}
            else
            {
				Obj.Add(key, ja);
			}
		}
        public Rectangle? ValueRectangle(string key)
        {
            Rectangle? ret = null;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    JsonArray ja = Obj[key].AsArray();
                    if (ja != null && ja.Count >= 4)
                    {
                        try
                        {
                            int v0 = ja[0].GetValue<int>();
                            int v1 = ja[1].GetValue<int>();
                            int v2 = ja[2].GetValue<int>();
                            int v3 = ja[3].GetValue<int>();
                            ret = new Rectangle(v0, v1, v2, v3);
                        }
                        catch { }
                    }
                }
            }
            return ret;
        }
        public void SetValueRectangle(string key, Rectangle c)
        {
            if (Obj == null) return;
            JsonArray ja = new JsonArray();
            ja.Add(c.Left);
            ja.Add(c.Top);
            ja.Add(c.Width);
            ja.Add(c.Height);
            if (Obj.ContainsKey(key))
            {
                Obj[key] = ja;
            }
            else
            {
				Obj.Add(key, ja);

			}
		}

        public bool GetStr(string key, ref string s, string? def = null)
        {
            bool ret = false;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    string? v = Obj[key].GetValue<string>();
                    if (v != null)
                    {
                        s = v;
                        ret = true;
                    }
                }
            }
            if (ret == false && def != null) s = def;
            return ret;
        }
        public bool GetInt(string key, ref int s, int? def = null)
        {
            bool ret = false;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    int? v = Obj[key].GetValue<int?>();
                    if (v != null)
                    {
                        s = (int)v;
                        ret = true;
                    }
                }
            }
            if (ret == false && def != null) s = (int)def;
            return ret;
        }
        public bool GetFloat(string key, ref float s, float? def = null)
        {
            bool ret = false;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    float? v = Obj[key].GetValue<float?>();
                    if (v != null)
                    {
                        s = (float)v;
                        ret = true;
                    }
                }
            }
            if (ret == false && def != null) s = (float)def;
            return ret;
        }
        public bool GetDouble(string key, ref double s, double? def = null)
        {
            bool ret = false;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    double? v = Obj[key].GetValue<double?>();
                    if (v != null)
                    {
                        s = (double)v;
                        ret = true;
                    }
                }
            }
            if (ret == false && def != null) s = (double)def;
            return ret;
        }
        public bool GetBool(string key, ref bool s, bool? def = null)
        {
            bool ret = false;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    bool? v = Obj[key].GetValue<bool?>();
                    if (v != null)
                    {
                        s = (bool)v;
                        ret = true;
                    }
                }
            }
            if (ret == false && def != null) s = (bool)def;
            return ret;
        }
        public bool GetRectangle(string key, ref Rectangle s, Rectangle? def = null)
        {
            bool ret = false;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    JsonArray? ja = Obj[key].AsArray();
                    if (ja != null && ja.Count >= 4)
                    {
                        int? v0 = ja[0].GetValue<int?>();
                        int? v1 = ja[1].GetValue<int?>();
                        int? v2 = ja[2].GetValue<int?>();
                        int? v3 = ja[3].GetValue<int?>();
                        if (v0 != null && v1 != null && v2 != null && v3 != null)
                        {
                            s = new Rectangle((int)v0, (int)v1, (int)v2, (int)v3);
                            ret = true;
                        }
                    }
                }
            }
            if (ret == false && def != null) s = (Rectangle)def;
            return ret;
        }
        public bool GetPadding(string key, ref Padding s, Padding? def = null)
        {
            bool ret = false;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    JsonArray? ja = Obj[key].AsArray();
                    if (ja != null && ja.Count >= 4)
                    {
                        int? v0 = ja[0].GetValue<int?>();
                        int? v1 = ja[1].GetValue<int?>();
                        int? v2 = ja[2].GetValue<int?>();
                        int? v3 = ja[3].GetValue<int?>();
                        if (v0 != null && v1 != null && v2 != null && v3 != null)
                        {
                            s = new Padding((int)v0, (int)v1, (int)v2, (int)v3);
                            ret = true;
                        }
                    }
                }
            }
            if (ret == false && def != null) s = (Padding)def;
            return ret;
        }
        public bool GetPoint(string key, ref Point s, Point? def = null)
        {
            bool ret = false;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    JsonArray? ja = Obj[key].AsArray();
                    if (ja != null && ja.Count >= 2)
                    {
                        int? v0 = ja[0].GetValue<int?>();
                        int? v1 = ja[1].GetValue<int?>();
                        if (v0 != null && v1 != null)
                        {
                            s = new Point((int)v0, (int)v1);
                            ret = true;
                        }
                    }
                }
            }
            if (ret == false && def != null) s = (Point)def;
            return ret;
        }
        public bool GetSize(string key, ref Size s, Size? def = null)
        {
            bool ret = false;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    JsonArray? ja = Obj[key].AsArray();
                    if (ja != null && ja.Count >= 2)
                    {
                        int? v0 = ja[0].GetValue<int?>();
                        int? v1 = ja[1].GetValue<int?>();
                        if (v0 != null && v1 != null)
                        {
                            s = new Size((int)v0, (int)v1);
                            ret = true;
                        }
                    }
                }
            }
            if (ret == false && def != null) s = (Size)def;
            return ret;
        }
        public bool GetColor(string key, ref Color s, Color? def = null)
        {
            bool ret = false;
            if (Obj != null)
            {
                if (Obj.ContainsKey(key))
                {
                    JsonArray? ja = Obj[key].AsArray();
                    if (ja != null && ja.Count >= 3)
                    {
                        int? v0 = ja[0].GetValue<int?>();
                        int? v1 = ja[1].GetValue<int?>();
                        int? v2 = ja[2].GetValue<int?>();
                        if (v0 != null && v1 != null && v2 != null)
                        {
                            s = Color.FromArgb((int)v0, (int)v1, (int)v2);
                            ret = true;
                        }
                    }
                }
            }
            if (ret == false && def != null) s = (Color)def;
            return ret;
        }
		public bool GetMGColor(string key, ref MG_COL s, MG_COL? def = null)
		{
			bool ret = false;
			if (Obj != null)
			{
				if (Obj.ContainsKey(key))
				{
					int? v = Obj[key].GetValue<int?>();
					if (v != null)
					{
						s = (MG_COL)v;
						ret = true;
					}
				}
			}
			if (ret == false && def != null) s = (MG_COL)def;
			return ret;
		}
		// *************************************************************************************
		public void SetMGStyle(MGStyle ms)
		{
			if (Obj != null)
			{
				string key = "MGStyle";
				if (Obj.ContainsKey(key))
                {
                    Obj[key] = (int)ms;
                }
                else
                {
					Obj.Add(key, (int)ms);
				}
			}
		}
		// *************************************************************************************
		public bool GetMGStyle(ref MGStyle? ms)
		{
			bool ret = false;
            if (Obj != null)
            {
                string key = "MGStyle";

				if (Obj.ContainsKey(key))
				{
					int? v = Obj[key].GetValue<int?>();
					if (v != null)
					{
						ms = (MGStyle)v;
						ret = true;
					}
				}
			}
			return ret;
		}
		// *****************************************************************
		static public JsonArray RectangleToJson(Rectangle sz)
        {
            JsonArray arr = new JsonArray();
            arr.Add(sz.Left);
            arr.Add(sz.Top);
            arr.Add(sz.Width);
            arr.Add(sz.Height);
            return arr;
        }
        static public Rectangle? JsonToRectangle(JsonObject jo)
        {
            Rectangle? ret = null;
            JsonArray ar = jo.AsArray();
            if (ar == null) return ret;
            if (ar.Count >= 4)
            {
                ret = new Rectangle(
                    ar[0].GetValue<int>(),
                    ar[1].GetValue<int>(),
                    ar[2].GetValue<int>(),
                    ar[3].GetValue<int>()
                    );
            }
            return ret;
        }
        static public JsonArray PaddingToJson(Padding p)
        {
            JsonArray arr = new JsonArray();
            arr.Add(p.Left);
            arr.Add(p.Top);
            arr.Add(p.Right);
            arr.Add(p.Bottom);
            return arr;
        }
        static public Padding? JsonToPadding(JsonObject jo)
        {
            Padding? ret = null;
            JsonArray ar = jo.AsArray();
            if (ar == null) return ret;
            if (ar.Count >= 4)
            {
                ret = new Padding(
                    ar[0].GetValue<int>(),
                    ar[1].GetValue<int>(),
                    ar[2].GetValue<int>(),
                    ar[3].GetValue<int>()
                    );
            }
            return ret;
        }
        static public JsonArray SizeToJson(Size sz)
        {
            JsonArray arr = new JsonArray();
            arr.Add(sz.Width);
            arr.Add(sz.Height);
            return arr;
        }
        static public Size? JsonToSize(JsonObject jo)
        {
            Size? ret = null;
            JsonArray ar = jo.AsArray();
            if (ar == null) return ret;
            if (ar.Count >= 2)
            {
                ret = new Size(
                    ar[0].GetValue<int>(),
                    ar[1].GetValue<int>()
                    );
            }
            return ret;
        }
        static public JsonArray ColorToJson(Color sz)
        {
            JsonArray arr = new JsonArray();
            arr.Add(sz.R);
            arr.Add(sz.G);
            arr.Add(sz.B);
            return arr;
        }
        static public Color? JsonToColor(JsonObject jo)
        {
            Color? ret = null;
            JsonArray ar = jo.AsArray();
            if (ar == null) return ret;
            if (ar.Count >= 3)
            {
                ret = Color.FromArgb(
                    ar[0].GetValue<int>(),
                    ar[1].GetValue<int>(),
                    ar[2].GetValue<int>()
                    );
            }
            return ret;
        }
        static public Color? JsonToColor(JsonArray ar)
        {
            Color? ret = null;
            if (ar == null) return ret;
            if (ar.Count >= 3)
            {
                ret = Color.FromArgb(
                    ar[0].GetValue<int>(),
                    ar[1].GetValue<int>(),
                    ar[2].GetValue<int>()
                    );
            }
            return ret;
        }

    }
}
