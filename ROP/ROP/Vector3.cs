using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROP
{
    public class Vector3
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
            animState = new Vector3();
            CalcDisplacement();
        }
        public Vector3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector3(double x, double y, double z, Vector3 animState)
        {
            X = x;
            Y = y;
            Z = z;
            this.animState = new Vector3(animState);
            CalcDisplacement();
        }

        public Vector3(Vector3 v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
            CalcDisplacement();
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

        public override string ToString()
        {
            return "X:" + X.ToString("F3") + ",Y:" + Y.ToString("F3") + ",Z:" + Z.ToString("F3") + ", displacement:" + displacement.Y.ToString("F3") + ", lengthFrom0:" + lengthFrom0.Y.ToString("F3") + ", animState:" + animState.Y.ToString("F3");
        }

        public void CalcDisplacement()
        {            
            lengthFrom0 = new Vector3();
            lengthFrom0.X = Math.Sqrt(Y * Y + Z * Z);
            lengthFrom0.Y = Math.Sqrt(X * X + Z * Z);
            lengthFrom0.Z = Math.Sqrt(X * X + Y * Y);

            displacement = new Vector3();
            double uhelInsideX = 0.5 / lengthFrom0.X;
            double uhelInsideY = 0.5 / lengthFrom0.Y;
            double uhelInsideZ = 0.5 / lengthFrom0.Z;
            
            double uhelOutside = Math.PI / 4;
            if (Math.Abs(X) > 1)
            {
                //Z
                if (Z > 1)
                {
                    displacement.Y = uhelOutside * 1;
                }
                else if (Z > 0)
                {
                    displacement.Y = Math.PI / 2 - uhelInsideY;
                }
                else if (Z < -1)
                {
                    displacement.Y = uhelOutside * 3;
                }
                else
                {
                    displacement.Y = Math.PI / 2 + uhelInsideY;
                }

                //Y
                if (Y > 1)
                {
                    displacement.Z = uhelOutside * 1;
                }
                else if (Y > 0)
                {
                    displacement.Z = Math.PI / 2 - uhelInsideZ;
                }
                else if (Y < -1)
                {
                    displacement.Z = uhelOutside * 3;
                }
                else
                {
                    displacement.Z = Math.PI / 2 + uhelInsideZ;
                }
            }
            else if(Math.Abs(X) > 0)
            {
                //Z
                if (Z > 1)
                {
                    displacement.Y = uhelInsideY;
                }
                else if (Z > 0)
                {
                    displacement.Y = uhelOutside * 1;
                }
                else if (Z < -1)
                {
                    displacement.Y = Math.PI - uhelInsideY;
                }
                else
                {
                    displacement.Y = uhelOutside * 3;
                }

                //Y
                if (Y > 1)
                {
                    displacement.Z = uhelInsideZ;
                }
                else if (Y > 0)
                {
                    displacement.Z = uhelOutside * 1;
                }
                else if (Y < -1)
                {
                    displacement.Z = Math.PI - uhelInsideZ;
                }
                else
                {
                    displacement.Z = uhelOutside * 3;
                }
            }
            if (X < 0)
            {
                displacement.Y = Math.PI * 2 - displacement.Y;
                displacement.Z = Math.PI * 2 - displacement.Z;
            }
            if(Math.Abs(Z) > 1)
            {
                //Y
                if(Y > 1)
                {
                    displacement.X = uhelOutside * 1;
                }
                else if(Y > 0)
                {
                    displacement.X = Math.PI / 2 - uhelInsideX;
                }
                else if(Y < -1)
                {
                    displacement.X = uhelOutside * 3;
                }
                else
                {
                    displacement.X = Math.PI / 2 + uhelInsideX;
                }
            }
            else if(Math.Abs(Z) > 0)
            {
                //Y
                if (Y > 1)
                {
                    displacement.X = uhelInsideX;
                }
                else if (Y > 0)
                {
                    displacement.X = uhelOutside * 1;
                }
                else if (Y < -1)
                {
                    displacement.X = Math.PI - uhelInsideX;
                }
                else
                {
                    displacement.X = uhelOutside * 3;
                }
            }
            if (Z < 0)
            {
                displacement.X = Math.PI * 2 - displacement.X;
            }
        }
    }
}
