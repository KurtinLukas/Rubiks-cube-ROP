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
        public Vector3 displacement;
        public Vector3 animState;

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            lengthFrom0 = new Vector3();
            displacement = new Vector3();
            animState = new Vector3();

            lengthFrom0.X = Math.Sqrt(y * y + z * z);
            lengthFrom0.Y = Math.Sqrt(x * x + z * z);
            lengthFrom0.Z = Math.Sqrt(x * x + y * y);

            double uhelInsideX = 0.5 / lengthFrom0.X;
            double uhelInsideY = 0.5 / lengthFrom0.Y;
            double uhelInsideZ = 0.5 / lengthFrom0.Z;
            //je to správná cesta
            double uhelOutside = Math.PI / 4;
            switch (Math.Abs(x))
            {
                case 1.5:
                    switch (z)
                    {
                        case 1.5:
                            displacement.Y = uhelOutside * 1;
                            break;
                        case 0.5:
                            displacement.Y = Math.PI/2 - uhelInsideY;
                            break;
                        case -0.5:
                            displacement.Y = Math.PI/2 + uhelInsideY;
                            break;
                        case -1.5:
                            displacement.Y = uhelOutside * 3;
                            break;
                    }
                    switch (y)
                    {
                        case 1.5:
                            displacement.Z = uhelOutside * 1;
                            break;
                        case 0.5:
                            displacement.Z = Math.PI / 2 - uhelInsideZ;
                            break;
                        case -0.5:
                            displacement.Z = Math.PI / 2 + uhelInsideZ;
                            break;
                        case -1.5:
                            displacement.Z = uhelOutside * 3;
                            break;
                    }
                    break;
                case 0.5:
                    switch (z)
                    {
                        case 1.5:
                            displacement.Y = uhelInsideY;
                            break;
                        case 0.5:
                            displacement.Y = uhelOutside * 1;
                            break;
                        case -0.5:
                            displacement.Y = uhelOutside * 3;
                            break;
                        case -1.5:
                            displacement.Y = Math.PI - uhelInsideY;
                            break;
                    }
                    switch (y)
                    {
                        case 1.5:
                            displacement.Z = uhelInsideZ;
                            break;
                        case 0.5:
                            displacement.Z = uhelOutside * 1;
                            break;
                        case -0.5:
                            displacement.Z = uhelOutside * 3;
                            break;
                        case -1.5:
                            displacement.Z = Math.PI - uhelInsideZ;
                            break;
                    }
                    break;
            }
            if (x < 0)
            {
                displacement.Y = Math.PI * 2 - displacement.Y;
                displacement.Z = Math.PI * 2 - displacement.Z;
            }
            switch (Math.Abs(z))
            {
                case 1.5:
                    switch (y)
                    {
                        case 1.5:
                            displacement.X = uhelOutside * 1;
                            break;
                        case 0.5:
                            displacement.X = Math.PI/2 - uhelInsideX;
                            break;
                        case -0.5:
                            displacement.X = Math.PI/2 + uhelInsideX;
                            break;
                        case -1.5:
                            displacement.X = uhelOutside * 3;
                            break;
                    }
                    break;
                case 0.5:
                    switch (y)
                    {
                        case 1.5:
                            displacement.X = uhelInsideX;
                            break;
                        case 0.5:
                            displacement.X = uhelOutside * 1;
                            break;
                        case -0.5:
                            displacement.X = uhelOutside * 3;
                            break;
                        case -1.5:
                            displacement.X = Math.PI - uhelInsideX;
                            break;
                    }
                    break;
            }
            if(z < 0)
            {
                displacement.X = Math.PI * 2 - displacement.X;
            }
        }
        public Vector3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector3(double x, double y, double z, Vector3 lengthFrom0, Vector3 displacement, Vector3 animState)
        {
            X = x;
            Y = y;
            Z = z;
            this.lengthFrom0 = new Vector3(lengthFrom0);
            this.displacement = new Vector3(displacement);
            this.animState = new Vector3(animState);
        }
        /// <summary>
        /// Negeneruje standardní vektor, chybí mu vlastnosti lengthFrom0, displacement, animState !
        /// Kopíruje se pouze X,Y,Z
        /// </summary>
        /// <param name="v"></param>
        public Vector3(Vector3 v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        public object Clone()
        {
            return new Vector3(X, Y, Z, lengthFrom0, displacement, animState);
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
