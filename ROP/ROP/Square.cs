using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROP
{
    public class Square : ICloneable
    {
        public Vector3[] vectors;
        public Color color = Color.Black;
        public Vector3 normal;

        public Square(Vector3[] vArray)
        {
            vArray.CopyTo(vectors, 0);
        }
        public Square(Vector3[] vArray, Color c)
        {
            vectors = new Vector3[4];
            vArray.CopyTo(vectors, 0);
            color = c;
        }
        public Square(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3)
        {
            vectors = new Vector3[4];
            vectors[0] = v0;
            vectors[1] = v1;
            vectors[2] = v2;
            vectors[3] = v3;
            normal = (v1 - v0) * (v1 - v3);
        }
        public Square(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3, Color color)
        {
            vectors = new Vector3[4];
            vectors[0] = v0;
            vectors[1] = v1;
            vectors[2] = v2;
            vectors[3] = v3;
            this.color = color;
            normal = (v1 - v0) * (v3 - v0);
        }
        public Square()
        {
            vectors = new Vector3[4];
        }

        public object Clone()
        {
            return new Square(vectors.Select(item => (Vector3)vectors.Clone()).ToArray());
        }
        public Square Copy()
        {
            return new Square(vectors.ToArray(), color);
        }
        public Vector3 Middle()
        {
            return (vectors[0] - vectors[2]) / 2 + vectors[2];
        }
    }
}
