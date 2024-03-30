using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROP
{
    public class Cube
    {
        public Square[] squares = new Square[6];
        //sudé = rohy, liché = hrany; správná originální pozice
        public int cubeIndex = -1;
        public int rotateAxis = -1;

        public Cube(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4, Vector3 v5, Vector3 v6, Vector3 v7, Color cF, Color cR, Color cB, Color cL, Color cD, Color cU, int pos)
        {
            squares[0] = new Square(v0, v1, v2, v3, cF);
            squares[1] = new Square(v0, v1, v5, v4, cR);
            squares[2] = new Square(v4, v5, v6, v7, cB);
            squares[3] = new Square(v3, v2, v6, v7, cL);
            squares[4] = new Square(v0, v4, v7, v3, cD);
            squares[5] = new Square(v1, v5, v6, v2, cU);

            cubeIndex = pos;
        }
        public Cube()
        {
            
        }

        public Cube(Cube c)
        {
            c.squares.Select(item => item.Copy()).ToArray().CopyTo(squares, 0); //
            this.cubeIndex = c.cubeIndex;
            this.rotateAxis = c.rotateAxis;
        }
    }
}
