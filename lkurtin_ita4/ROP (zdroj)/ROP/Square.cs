using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROP
{
    public class Square
    {
        public Vector3[] vectors = new Vector3[4];
        public Color color = Color.Black;
        //public Vector3 normal;

        public Square(Vector3[] vArray)
        {
            vectors[0] = new Vector3(vArray[0].X, vArray[0].Y, vArray[0].Z);
            vectors[1] = new Vector3(vArray[1].X, vArray[1].Y, vArray[1].Z);
            vectors[2] = new Vector3(vArray[2].X, vArray[2].Y, vArray[2].Z);
            vectors[3] = new Vector3(vArray[3].X, vArray[3].Y, vArray[3].Z);
        }
        public Square(Vector3[] vArray, Color c) : this(vArray)
        {
            color = c;
        }
        public Square(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3)
        {
            vectors[0] = v0;
            vectors[1] = v1;
            vectors[2] = v2;
            vectors[3] = v3;
            //normal = (v1 - v0) * (v1 - v3);
        }
        public Square(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3, Color color) : this(v0,v1,v2,v3)
        {
            this.color = color;
            //normal = (v1 - v0) * (v3 - v0);
        }
        public Square()
        {

        }
        public Square Copy()
        {
            return new Square(vectors.Select(item => new Vector3(item.X, item.Y, item.Z, item.animState)).ToArray(), color);
        }
        public Vector3 Middle()
        {
            return (vectors[0] - vectors[2]) / 2 + vectors[2];
        }
    }
}
