using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            for (int i = 0; i < 3; i++)
            {
                bottom[0, i] = 0; bottom[1, i] = 0; bottom[2, i] = 0;
                top[0, i] = 1; top[1, i] = 1; top[2, i] = 1;
                right[0, i] = 2; right[1, i] = 2; right[2, i] = 2;
                left[0, i] = 3; left[1, i] = 3; left[2, i] = 3;
                front[0, i] = 4; front[1, i] = 4; front[2, i] = 4;
                back[0, i] = 5; back[1, i] = 5; back[2, i] = 5;
            }

            RenderMatrix();
            cube.squares[0] = new Square(new Vector3(-1, -1, 1), new Vector3(-1, 1, 1), new Vector3(1, 1, 1), new Vector3(1, -1, 1));
            cube.squares[1] = new Square(new Vector3(-1, -1, -1), new Vector3(-1, 1, -1), new Vector3(-1, 1, 1), new Vector3(-1, -1, 1));
            cube.squares[2] = new Square(new Vector3(-1, -1, 1), new Vector3(-1, 1, 1), new Vector3(1, 1, 1), new Vector3(1, -1, 1));
            cube.squares[3] = new Square(new Vector3(1, -1, -1), new Vector3(1, 1, -1), new Vector3(1, 1, 1), new Vector3(1, -1, 1));
            cube.squares[4] = new Square(new Vector3(-1, -1, -1), new Vector3(-1, -1, 1), new Vector3(1, -1, 1), new Vector3(1, -1, -1));
            cube.squares[5] = new Square(new Vector3(-1, 1, -1), new Vector3(-1, 1, 1), new Vector3(1, 1, 1), new Vector3(1, 1, -1));
            redraw = true;

            // scale_x     0       0        translation_X
            //    0         scale_y 0       translation_Y
            //      0       0       scale_z translation_Z
            //      0       0       0         1           
        }

        //bílá = 0; žlutá = 1; červená = 2; oranžová = 3; modrá = 4; zelená = 5
        public int[,] bottom = new int[3, 3];
        public int[,] top = new int[3, 3];
        public int[,] right = new int[3, 3];
        public int[,] left = new int[3, 3];
        public int[,] front = new int[3, 3];
        public int[,] back = new int[3, 3];

        public double[,] projectionMatrix = new double[4, 4];
        public double[,] XRotationMatrix = new double[4, 4];
        public double[,] ZRotationMatrix = new double[4, 4];

        public double anim = 0;

        public string historieTahu = "";
        public bool redraw = false;

        Cube cube = new Cube();

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        public void DrawSquare(Graphics g, Square s)
        {
            Square d = new Square(); //Výsledný polygon
            Square t = new Square(); //offset polygon
            Square rotaceZ = new Square(); //první rotace polygon
            Square rotaceX = new Square(); //druhá rotace polygon

            for (int i = 0; i < 4; i++)
            {
                rotaceZ.vectors[i] = MultiplyMatrixVector(s.vectors[i], ZRotationMatrix);
                rotaceX.vectors[i] = MultiplyMatrixVector(rotaceZ.vectors[i], XRotationMatrix);
                t.vectors[i] = rotaceX.vectors[i];
                t.vectors[i].Z += 3;
                d.vectors[i] = MultiplyMatrixVector(t.vectors[i], projectionMatrix);
                d.vectors[i].X = (d.vectors[i].X + 1) * 0.5 * pictureBox1.Width;
                d.vectors[i].Y = (d.vectors[i].Y + 1) * 0.5 * pictureBox1.Height;
                //t.vectors[i].Z -= 3; // temporary fix for offset, because of reference from t -> s
            }
            g.DrawPolygon(new Pen(Brushes.Black, 3) , new PointF[]{
                                                    new PointF((float)d.vectors[0].X, (float)d.vectors[0].Y), 
                                                    new PointF((float)d.vectors[1].X, (float)d.vectors[1].Y), 
                                                    new PointF((float)d.vectors[2].X, (float)d.vectors[2].Y), 
                                                    new PointF((float)d.vectors[3].X, (float)d.vectors[3].Y)});
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Form1.ActiveForm.Refresh();

        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            historieTahu += "R";
            label2.Text = "Historie: " + historieTahu;
            TurnRight();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            historieTahu += "L";
            label2.Text = "Historie: " + historieTahu;
            TurnLeft();
        }

        private void buttonTop_Click(object sender, EventArgs e)
        {
            historieTahu += "U";
            label2.Text = "Historie: " + historieTahu;
            TurnUp();
        }

        private void buttonBottom_Click(object sender, EventArgs e)
        {
            historieTahu += "D";
            label2.Text = "Historie: " + historieTahu;
            TurnDown();
        }

        private void buttonFront_Click(object sender, EventArgs e)
        {
            historieTahu += "F";
            label2.Text = "Historie: " + historieTahu;
            TurnFront();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            historieTahu += "B";
            label2.Text = "Historie: " + historieTahu;
            TurnBack();
        }

        public void TurnRight()
        {

            int[] buff = { top[2, 0], top[2, 1], top[2, 2] };
            top[2, 0] = front[2, 0];
            top[2, 1] = front[2, 1];
            top[2, 2] = front[2, 2];
            front[2, 0] = bottom[2, 0];
            front[2, 1] = bottom[2, 1];
            front[2, 2] = bottom[2, 2];
            bottom[2, 0] = back[0, 2];
            bottom[2, 1] = back[0, 1];
            bottom[2, 2] = back[0, 0];
            back[0, 2] = buff[0];
            back[0, 1] = buff[1];
            back[0, 0] = buff[2];
            int buffCorner = right[0, 0];
            right[0, 0] = right[0, 2];
            right[0, 2] = right[2, 2];
            right[2, 2] = right[2, 0];
            right[2, 0] = buffCorner;
            int buffEdge = right[1, 0];
            right[1, 0] = right[0, 1];
            right[0, 1] = right[1, 2];
            right[1, 2] = right[2, 1];
            right[2, 1] = buffEdge;
            Form1.ActiveForm.Refresh();
        }
        public void TurnLeft()
        {
            int[] buff = { top[0, 0], top[0, 1], top[0, 2] };
            top[0, 0] = back[2, 2];
            top[0, 1] = back[2, 1];
            top[0, 2] = back[2, 0];
            back[2, 2] = bottom[0, 0];
            back[2, 1] = bottom[0, 1];
            back[2, 0] = bottom[0, 2];
            bottom[0, 0] = front[0, 0];
            bottom[0, 1] = front[0, 1];
            bottom[0, 2] = front[0, 2];
            front[0, 0] = buff[0];
            front[0, 1] = buff[1];
            front[0, 2] = buff[2];
            int buffCorner = left[0, 0];
            left[0, 0] = left[0, 2];
            left[0, 2] = left[2, 2];
            left[2, 2] = left[2, 0];
            left[2, 0] = buffCorner;
            int buffEdge = left[1, 0];
            left[1, 0] = left[0, 1];
            left[0, 1] = left[1, 2];
            left[1, 2] = left[2, 1];
            left[2, 1] = buffEdge;
            Form1.ActiveForm.Refresh();
        }
        public void TurnUp()
        {
            int[] buff = { front[0, 0], front[1, 0], front[2, 0] };
            front[0, 0] = right[0, 0];
            front[1, 0] = right[1, 0];
            front[2, 0] = right[2, 0];
            right[0, 0] = back[0, 0];
            right[1, 0] = back[1, 0];
            right[2, 0] = back[2, 0];
            back[0, 0] = left[0, 0];
            back[1, 0] = left[1, 0];
            back[2, 0] = left[2, 0];
            left[0, 0] = buff[0];
            left[1, 0] = buff[1];
            left[2, 0] = buff[2];
            int buffCorner = top[0, 0];
            top[0, 0] = top[0, 2];
            top[0, 2] = top[2, 2];
            top[2, 2] = top[2, 0];
            top[2, 0] = buffCorner;
            int buffEdge = top[1, 0];
            top[1, 0] = top[0, 1];
            top[0, 1] = top[1, 2];
            top[1, 2] = top[2, 1];
            top[2, 1] = buffEdge;
            Form1.ActiveForm.Refresh();
        }
        public void TurnDown()
        {
            int[] buff = { front[0, 2], front[1, 2], front[2, 2] };
            front[0, 2] = left[0, 2];
            front[1, 2] = left[1, 2];
            front[2, 2] = left[2, 2];
            left[0, 2] = back[0, 2];
            left[1, 2] = back[1, 2];
            left[2, 2] = back[2, 2];
            back[0, 2] = right[0, 2];
            back[1, 2] = right[1, 2];
            back[2, 2] = right[2, 2];
            right[0, 2] = buff[0];
            right[1, 2] = buff[1];
            right[2, 2] = buff[2];
            int buffCorner = bottom[0, 0];
            bottom[0, 0] = bottom[0, 2];
            bottom[0, 2] = bottom[2, 2];
            bottom[2, 2] = bottom[2, 0];
            bottom[2, 0] = buffCorner;
            int buffEdge = bottom[1, 0];
            bottom[1, 0] = bottom[0, 1];
            bottom[0, 1] = bottom[1, 2];
            bottom[1, 2] = bottom[2, 1];
            bottom[2, 1] = buffEdge;
            Form1.ActiveForm.Refresh();
        }
        public void TurnFront()
        {
            int[] buff = { top[0, 2], top[1, 2], top[2, 2] };
            top[0, 2] = left[2, 2];
            top[1, 2] = left[2, 1];
            top[2, 2] = left[2, 0];
            left[2, 0] = bottom[0, 0];
            left[2, 1] = bottom[1, 0];
            left[2, 2] = bottom[2, 0];
            bottom[2, 0] = right[0, 0];
            bottom[1, 0] = right[0, 1];
            bottom[0, 0] = right[0, 2];
            right[0, 0] = buff[0];
            right[0, 1] = buff[1];
            right[0, 2] = buff[2];
            int buffCorner = front[0, 0];
            front[0, 0] = front[0, 2];
            front[0, 2] = front[2, 2];
            front[2, 2] = front[2, 0];
            front[2, 0] = buffCorner;
            int buffEdge = front[1, 0];
            front[1, 0] = front[0, 1];
            front[0, 1] = front[1, 2];
            front[1, 2] = front[2, 1];
            front[2, 1] = buffEdge;
            Form1.ActiveForm.Refresh();
        }
        public void TurnBack()
        {
            int[] buff = { top[0, 0], top[1, 0], top[2, 0] };
            top[0, 0] = right[2, 0];
            top[1, 0] = right[2, 1];
            top[2, 0] = right[2, 2];
            right[2, 0] = bottom[2, 2];
            right[2, 1] = bottom[1, 2];
            right[2, 2] = bottom[0, 2];
            bottom[2, 2] = left[0, 2];
            bottom[1, 2] = left[0, 1];
            bottom[0, 2] = left[0, 0];
            left[0, 2] = buff[0];
            left[0, 1] = buff[1];
            left[0, 0] = buff[2];
            int buffCorner = back[0, 0];
            back[0, 0] = back[0, 2];
            back[0, 2] = back[2, 2];
            back[2, 2] = back[2, 0];
            back[2, 0] = buffCorner;
            int buffEdge = back[1, 0];
            back[1, 0] = back[0, 1];
            back[0, 1] = back[1, 2];
            back[1, 2] = back[2, 1];
            back[2, 1] = buffEdge;
            Form1.ActiveForm.Refresh();
        }

        private void buttonAlgorithm_Click(object sender, EventArgs e)
        {
            Algorithm(textBoxAlgorithm.Text);
            historieTahu += textBoxAlgorithm.Text;
        }

        public void Algorithm(string alg)
        {
            string tahy = "RLUDFB";
            for (int i = 0; i < alg.Length; i++)
            {
                if (tahy.Contains(alg[i]))
                {
                    if (i + 1 < alg.Length)
                    {
                        if (alg[i + 1] == '\'')
                        {
                            switch (alg[i])
                            {
                                case 'R': TurnRight(); TurnRight(); TurnRight(); break;
                                case 'L': TurnLeft(); TurnLeft(); TurnLeft(); break;
                                case 'U': TurnUp(); TurnUp(); TurnUp(); break;
                                case 'D': TurnDown(); TurnDown(); TurnDown(); break;
                                case 'F': TurnFront(); TurnFront(); TurnFront(); break;
                                case 'B': TurnBack(); TurnBack(); TurnBack(); break;
                            }
                            continue;
                        }
                        else if (alg[i + 1] == '2')
                        {
                            alg = alg.Remove(i + 1, 1).Insert(i + 1, alg[i].ToString());
                        }
                    }
                    switch (alg[i])
                    {
                        case 'R': TurnRight(); break;
                        case 'L': TurnLeft(); break;
                        case 'U': TurnUp(); break;
                        case 'D': TurnDown(); break;
                        case 'F': TurnFront(); break;
                        case 'B': TurnBack(); break;
                        default: MessageBox.Show("error v algoritmu"); break;
                    }
                }
            }
            //Render();
        }

        private void algorithm2_Click(object sender, EventArgs e)
        {
            textBoxAlgorithm.Text = "D2U2R2L2F2B2";
        }

        private void algorithm1_Click(object sender, EventArgs e)
        {
            textBoxAlgorithm.Text = "U'L'U'F'R2B'RFUB2UB'LU'FURF'";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        //Projection

        public void RenderMatrix()
        {
            float znear = 0.1f;
            float zfar = 1000;
            float fov = 90;
            float aspectRatio = pictureBox1.Height / pictureBox1.Width;

            // { aspectRatio / tan(fov/2)           0                     0             0
            // {                0             1/tan(fov/2)                0                  0
            // {                0                   0              zfar/(zfar-znear)        (-zfar * znear) / (zfar - znear)
            // {                0                   0                     1                      0

            double fovRad = Math.Tan(fov * 0.5 / 180 * Math.PI);
            projectionMatrix[0, 0] = aspectRatio  / fovRad;
            projectionMatrix[1, 1] = fovRad;
            projectionMatrix[2, 2] = zfar / (zfar - znear);
            projectionMatrix[3, 2] = (-zfar * znear) / (zfar - znear);
            projectionMatrix[2, 3] = 1;


            ZRotationMatrix[0, 0] = Math.Cos(anim);
            ZRotationMatrix[0, 1] = Math.Sin(anim);
            ZRotationMatrix[1, 0] = -Math.Sin(anim);
            ZRotationMatrix[1, 1] = Math.Cos(anim);
            ZRotationMatrix[2, 2] = 1;
            ZRotationMatrix[3, 3] = 1;

            XRotationMatrix[0, 0] = 1;
            XRotationMatrix[1, 1] = Math.Cos(anim * 0.5);
            XRotationMatrix[1, 2] = Math.Sin(anim * 0.5);
            XRotationMatrix[2, 1] = -Math.Sin(anim * 0.5);
            XRotationMatrix[2, 2] = Math.Cos(anim * 0.5);
            XRotationMatrix[3, 3] = 1;
        }

        public Vector3 MultiplyMatrixVector(Vector3 input, double[,] m)
        {
            Vector3 output = new Vector3();
            output.X = input.X * m[0, 0] + input.Y * m[1,0] + input.Z * m[2,0] + m[3,0];
            output.Y = input.X * m[0, 1] + input.Y * m[1, 1] + input.Z * m[2, 1] + m[3, 1];
            output.Z = input.X * m[0, 2] + input.Y * m[1, 2] + input.Z * m[2, 2] + m[3, 2];
            double w = input.X * m[0, 3] + input.Y * m[1, 3] + input.Z * m[2, 3] + m[3, 3];
            if(w != 0)
            {
                output.X /= w;
                output.Y /= w;
                output.Z /= w;
            }
            return output;
        }


        //Algorithm stuff
        private void solveButton_Click(object sender, EventArgs e)
        {
            string solve = "";
            for (int i = historieTahu.Length - 1; i >= 0; i--)
            {
                if (historieTahu[i] == '\'')
                {
                    solve += historieTahu[i - 1];
                    i--;
                }
                else if (historieTahu[i] == '2')
                {
                    solve += historieTahu[i - 1] + "2";
                    i--;
                }
                else solve += historieTahu[i] + "\'";
                historieTahu = historieTahu.Remove(i);
            }
            label2.Text = "Historie: " + historieTahu;
            Algorithm(solve);
            ActiveForm.Refresh();
        }

        private void scrambleButton_Click(object sender, EventArgs e)
        {
            string moves = "RLUDFB2'";
            Random rng = new Random();
            string scramble = moves[rng.Next(0, 6)].ToString();
            for (int i = 1; i < 20; i++)
            {
                char m;
                do
                    m = moves[rng.Next(0, 8)];
                while (m == scramble[i - 1] || (m == '\'' && scramble[i - 1] == '2') || (m == '2' && scramble[i - 1] == '\''));
                scramble += m;
            }
            historieTahu += scramble;
            label2.Text = "Historie: " + historieTahu;
            Algorithm(scramble);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            redraw = true;
            Refresh();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            RenderMatrix();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            anim += 0.02;
            ZRotationMatrix[0, 0] = Math.Cos(anim);
            ZRotationMatrix[0, 1] = Math.Sin(anim);
            ZRotationMatrix[1, 0] = -Math.Sin(anim);
            ZRotationMatrix[1, 1] = Math.Cos(anim);
            ZRotationMatrix[2, 2] = 1;
            ZRotationMatrix[3, 3] = 1;

            XRotationMatrix[0, 0] = 1;
            XRotationMatrix[1, 1] = Math.Cos(anim * 0.5);
            XRotationMatrix[1, 2] = Math.Sin(anim * 0.5);
            XRotationMatrix[2, 1] = -Math.Sin(anim * 0.5);
            XRotationMatrix[2, 2] = Math.Cos(anim * 0.5);
            XRotationMatrix[3, 3] = 1;

            redraw = true;
            Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen borderPen = new Pen(Color.Black, 5);
            Brush[] brushes = new Brush[6];
            brushes[0] = Brushes.White;
            brushes[1] = Brushes.Yellow;
            brushes[2] = Brushes.Red;
            brushes[3] = Brushes.Orange;
            brushes[4] = Brushes.Blue;
            brushes[5] = Brushes.Green;

            Graphics g = e.Graphics;

            if (redraw)
            {
                foreach (Square s in cube.squares)
                {
                    DrawSquare(g, s);
                }
                redraw = false;
            }
            /*

            g.FillRectangle(Brushes.Black, new Rectangle(535, 195, 80, 240));
            g.FillRectangle(Brushes.Black, new Rectangle(455, 275, 320, 80));
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //síť kostky
                    //g.FillRectangle(brushes[bottom[i, j]], new Rectangle(540 + i * 25, 360 + j * 25, 20, 20));
                    //g.FillRectangle(brushes[top[i, j]], new Rectangle(540 + i * 25, 200 + j * 25, 20, 20));
                    //g.FillRectangle(brushes[right[i, j]], new Rectangle(620 + i * 25, 280 + j * 25, 20, 20));
                    //g.FillRectangle(brushes[left[i, j]], new Rectangle(460 + i * 25, 280 + j * 25, 20, 20));
                    //g.FillRectangle(brushes[front[i, j]], new Rectangle(540 + i * 25, 280 + j * 25, 20, 20));
                    //g.FillRectangle(brushes[back[i, j]], new Rectangle(700 + i * 25, 280 + j * 25, 20, 20));
                }
            
            }
            */
        }
    }

    public class Vector3
    {
        public double X;
        public double Y;
        public double Z;
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
    }
    public class Square
    {
        public Vector3[] vectors;
        public Square(Vector3[] vArray)
        {
            vectors = vArray;
        }
        public Square(Vector3 v0, Vector3 v1, Vector3 v2, Vector3 v3)
        {
            vectors = new Vector3[4];
            vectors[0] = v0;
            vectors[1] = v1;
            vectors[2] = v2;
            vectors[3] = v3;
        }
        public Square()
        {
            vectors = new Vector3[4];
        }
    }
    public class Cube
    {
        public Square[] squares;
        
        public Cube(Square[] arr)
        {
            squares = arr;
        }
        public Cube(Square s0, Square s1, Square s2, Square s3, Square s4, Square s5)
        {
            squares = new Square[6];
            squares[0] = s0;
            squares[1] = s1;
            squares[2] = s2;
            squares[3] = s3;
            squares[4] = s4;
            squares[5] = s5;
        }
        public Cube()
        {
            squares = new Square[6];
        }
    }
}
