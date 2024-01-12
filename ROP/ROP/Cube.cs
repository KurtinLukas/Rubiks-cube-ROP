using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROP
{
    public class Cube : ICloneable
    {
        public Square[] squares;
        public int rotation = 0;
        public int position;

        public Cube(Square[] arr, int pos)
        {
            squares = arr;
            position = pos;
        }
        public Cube(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4, Vector3 v5, Vector3 v6, Vector3 v7, int pos)
        {
            squares = new Square[6];
            squares[0] = new Square(v0, v1, v2, v3);
            squares[1] = new Square(v0, v1, v5, v4);
            squares[2] = new Square(v4, v5, v6, v7);
            squares[3] = new Square(v3, v2, v6, v7);
            squares[4] = new Square(v0, v4, v7, v3);
            squares[5] = new Square(v1, v5, v6, v2);

            position = pos;
        }
        public Cube(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4, Vector3 v5, Vector3 v6, Vector3 v7, Color cF, Color cR, Color cB, Color cL, Color cD, Color cU, int pos)
        {
            squares = new Square[6];
            squares[0] = new Square(v0, v1, v2, v3, cF);
            squares[1] = new Square(v0, v1, v5, v4, cR);
            squares[2] = new Square(v4, v5, v6, v7, cB);
            squares[3] = new Square(v3, v2, v6, v7, cL);
            squares[4] = new Square(v0, v4, v7, v3, cD);
            squares[5] = new Square(v1, v5, v6, v2, cU);

            position = pos;
        }
        public Cube()
        {
            squares = new Square[6];

            position = 0;
        }

        public object Clone()
        {
            return new Cube(squares.Select(item => (Square)item.Clone()).ToArray(), position);
        }
    }
}
