using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROP
{
    public class Vector3 : ICloneable
    {
        public double X;
        public double Y;
        public double Z;


        public Vector3 lengthFrom0;

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Vector3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public object Clone()
        {
            return new Vector3(X, Y, Z);
        }

        public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vector3 operator *(Vector3 a, Vector3 b) => new Vector3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        public static Vector3 operator *(Vector3 a, double b) => new Vector3(a.X * b, a.Y * b, a.Z * b);
        public static Vector3 operator /(Vector3 a, Vector3 b)
        {
            if (b.X == 0 || b.Y == 0 || b.Z == 0)
                throw new DivideByZeroException();
            return new Vector3(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        }
        public static Vector3 operator /(Vector3 a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return new Vector3(a.X / b, a.Y / b, a.Z / b);
        }
    }
}
