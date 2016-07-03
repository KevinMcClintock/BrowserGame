using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace GameMiniProject
{
public struct Point3D
    {
        public double X;
        public double Y;
        public double Z;
        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Point3D(string x, string y, string z)
        {
            X = Convert.ToDouble(x);
            Y = Convert.ToDouble(y);
            Z = Convert.ToDouble(z);
        }

        public Point ToPoint() { return new Point(Convert.ToInt32(X), Convert.ToInt32(Y)); }
        public Size ToSize() { return new Size(Convert.ToInt32(X), Convert.ToInt32(Y)); }
        public DecimalPoint ToDecimalPoint() { return new DecimalPoint(X, Y); }
    }

    public struct DecimalPoint {

        public double X;
        public double Y;
        public DecimalPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Point ToPoint() { return new Point(Convert.ToInt32(X), Convert.ToInt32(Y)); }
    }
    public delegate void SendObjects(ref GameObject Object1, ref GameObject Object2);

}
