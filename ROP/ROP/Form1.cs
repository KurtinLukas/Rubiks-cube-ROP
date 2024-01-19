using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ROP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            RenderMatrix();

            //generace kostiček a jejich pozicí
            {
                Vector3 b = new Vector3(0, 0, 0);
                cubes[0, 0] = new Cube(new Vector3(-1.5, +0.5, +0.5)+b, new Vector3(-1.5, 1.5, 0.5)+b, new Vector3(-0.5, 1.5, 0.5)+b, new Vector3(-0.5, 0.5, 0.5)+b,
                                                     new Vector3(-1.5, 0.5, 1.5)+b, new Vector3(-1.5, 1.5, 1.5)+b, new Vector3(-0.5, 1.5, 1.5)+b, new Vector3(-0.5, 0.5, 1.5)+b,
                                                     Color.Black, Color.Orange, Color.Green, Color.Black, Color.Black, Color.Yellow, 0);
                cubes[1, 0] = new Cube(new Vector3(-0.5, 0.5, 0.5)+b, new Vector3(-0.5, 1.5, 0.5)+b, new Vector3(0.5, 1.5, 0.5)+b, new Vector3(0.5, 0.5, 0.5)+b,
                                                     new Vector3(-0.5, 0.5, 1.5)+b, new Vector3(-0.5, 1.5, 1.5)+b, new Vector3(0.5, 1.5, 1.5)+b, new Vector3(0.5, 0.5, 1.5)+b,
                                                     Color.Black, Color.Black, Color.Green, Color.Black, Color.Black, Color.Yellow, 1);
                cubes[2, 0] = new Cube(new Vector3(0.5, 0.5, 0.5)+b, new Vector3(0.5, 1.5, 0.5)+b, new Vector3(1.5, 1.5, 0.5)+b, new Vector3(1.5, 0.5, 0.5)+b,
                                                     new Vector3(0.5, 0.5, 1.5)+b, new Vector3(0.5, 1.5, 1.5)+b, new Vector3(1.5, 1.5, 1.5)+b, new Vector3(1.5, 0.5, 1.5)+b,
                                                     Color.Black, Color.Black, Color.Green, Color.Red, Color.Black, Color.Yellow, 2);
                cubes[3, 0] = new Cube(new Vector3(-1.5, 0.5, -0.5)+b, new Vector3(-1.5, 1.5, -0.5)+b, new Vector3(-0.5, 1.5, -0.5)+b, new Vector3(-0.5, 0.5, -0.5)+b,
                                                     new Vector3(-1.5, 0.5, 0.5)+b, new Vector3(-1.5, 1.5, 0.5)+b, new Vector3(-0.5, 1.5, 0.5)+b, new Vector3(-0.5, 0.5, 0.5)+b,
                                                     Color.Black, Color.Orange, Color.Black, Color.Black, Color.Black, Color.Yellow, 3);
                cubes[4, 0] = new Cube(new Vector3(-0.5, 0.5, -0.5)+b, new Vector3(-0.5, 1.5, -0.5)+b, new Vector3(0.5, 1.5, -0.5)+b, new Vector3(0.5, 0.5, -0.5)+b,
                                                     new Vector3(-0.5, 0.5, 0.5)+b, new Vector3(-0.5, 1.5, 0.5)+b, new Vector3(0.5, 1.5, 0.5)+b, new Vector3(0.5, 0.5, 0.5)+b,
                                                     Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, Color.Yellow, 4);
                cubes[5, 0] = new Cube(new Vector3(0.5, 0.5, -0.5)+b, new Vector3(0.5, 1.5, -0.5)+b, new Vector3(1.5, 1.5, -0.5)+b, new Vector3(1.5, 0.5, -0.5)+b,
                                                     new Vector3(0.5, 0.5, 0.5)+b, new Vector3(0.5, 1.5, 0.5)+b, new Vector3(1.5, 1.5, 0.5)+b, new Vector3(1.5, 0.5, 0.5)+b,
                                                     Color.Black, Color.Black, Color.Black, Color.Red, Color.Black, Color.Yellow, 5);
                cubes[6, 0] = new Cube(new Vector3(-1.5, 0.5, -1.5) +b, new Vector3(-1.5, 1.5, -1.5) +b, new Vector3(-0.5, 1.5, -1.5) +b, new Vector3(-0.5, 0.5, -1.5) +b,
                                                     new Vector3(-1.5, 0.5, -0.5)+b, new Vector3(-1.5, 1.5, -0.5)+b, new Vector3(-0.5, 1.5, -0.5)+b, new Vector3(-0.5, 0.5, -0.5)+b,
                                                     Color.Blue, Color.Orange, Color.Black, Color.Black, Color.Black, Color.Yellow, 6);
                cubes[7, 0] = new Cube(new Vector3(-0.5, 0.5, -1.5) +b, new Vector3(-0.5, 1.5, -1.5) +b, new Vector3(0.5, 1.5, -1.5) +b, new Vector3(0.5, 0.5, -1.5) +b,
                                                     new Vector3(-0.5, 0.5, -0.5)+b, new Vector3(-0.5, 1.5, -0.5)+b, new Vector3(0.5, 1.5, -0.5)+b, new Vector3(0.5, 0.5, -0.5)+b,
                                                     Color.Blue, Color.Black, Color.Black, Color.Black, Color.Black, Color.Yellow, 7);
                cubes[8, 0] = new Cube(new Vector3(0.5, 0.5, -1.5) +b, new Vector3(0.5, 1.5, -1.5) +b, new Vector3(1.5, 1.5, -1.5) +b, new Vector3(1.5, 0.5, -1.5) +b,
                                                     new Vector3(0.5, 0.5, -0.5)+b, new Vector3(0.5, 1.5, -0.5)+b, new Vector3(1.5, 1.5, -0.5)+b, new Vector3(1.5, 0.5, -0.5)+b,
                                                     Color.Blue, Color.Black, Color.Black, Color.Red, Color.Black, Color.Yellow, 8);

                cubes[0, 1] = new Cube(new Vector3(-1.5, -0.5, 0.5)+b, new Vector3(-1.5, 0.5, 0.5)+b, new Vector3(-0.5, 0.5, 0.5)+b, new Vector3(-0.5, -0.5, 0.5)+b,
                                                     new Vector3(-1.5, -0.5, 1.5) +b, new Vector3(-1.5, 0.5, 1.5) +b, new Vector3(-0.5, 0.5, 1.5) +b, new Vector3(-0.5, -0.5, 1.5) +b,
                                                     Color.Black, Color.Orange, Color.Green, Color.Black, Color.Black, Color.Black, 10);
                cubes[1, 1] = new Cube(new Vector3(-0.5, -0.5, 0.5)+b, new Vector3(-0.5, 0.5, 0.5)+b, new Vector3(0.5, 0.5, 0.5)+b, new Vector3(0.5, -0.5, 0.5)+b,
                                                     new Vector3(-0.5, -0.5, 1.5)+b, new Vector3(-0.5, 0.5, 1.5)+b, new Vector3(0.5, 0.5, 1.5)+b, new Vector3(0.5, -0.5, 1.5)+b,
                                                     Color.Black, Color.Black, Color.Green, Color.Black, Color.Black, Color.Black, 11);
                cubes[2, 1] = new Cube(new Vector3(0.5, -0.5, 0.5)+b, new Vector3(0.5, 0.5, 0.5)+b, new Vector3(1.5, 0.5, 0.5)+b, new Vector3(1.5, -0.5, 0.5)+b,
                                                     new Vector3(0.5, -0.5, 1.5)+b, new Vector3(0.5, 0.5, 1.5)+b, new Vector3(1.5, 0.5, 1.5)+b, new Vector3(1.5, -0.5, 1.5)+b,
                                                     Color.Black, Color.Black, Color.Green, Color.Red, Color.Black, Color.Black, 12);
                cubes[3, 1] = new Cube(new Vector3(-1.5, -0.5, -0.5)+b, new Vector3(-1.5, 0.5, -0.5)+b, new Vector3(-0.5, 0.5, -0.5)+b, new Vector3(-0.5, -0.5, -0.5)+b,
                                                     new Vector3(-1.5, -0.5, 0.5)+b, new Vector3(-1.5, 0.5, 0.5)+b, new Vector3(-0.5, 0.5, 0.5)+b, new Vector3(-0.5, -0.5, 0.5)+b,
                                                     Color.Black, Color.Orange, Color.Black, Color.Black, Color.Black, Color.Black, 13);
                cubes[4, 1] = new Cube(new Vector3(-0.5, -0.5, -0.5)+b, new Vector3(-0.5, 0.5, -0.5)+b, new Vector3(0.5, 0.5, -0.5)+b, new Vector3(0.5, -0.5, -0.5)+b,
                                                     new Vector3(-0.5, -0.5, 0.5)+b, new Vector3(-0.5, 0.5, 0.5)+b, new Vector3(0.5, 0.5, 0.5)+b, new Vector3(0.5, -0.5, 0.5)+b,
                                                     Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, 14);
                cubes[5, 1] = new Cube(new Vector3(0.5, -0.5, -0.5)+b, new Vector3(0.5, 0.5, -0.5)+b, new Vector3(1.5, 0.5, -0.5)+b, new Vector3(1.5, -0.5, -0.5)+b,
                                                     new Vector3(0.5, -0.5, 0.5)+b, new Vector3(0.5, 0.5, 0.5)+b, new Vector3(1.5, 0.5, 0.5)+b, new Vector3(1.5, -0.5, 0.5)+b,
                                                     Color.Black, Color.Black, Color.Black, Color.Red, Color.Black, Color.Black, 15);
                cubes[6, 1] = new Cube(new Vector3(-1.5, -0.5, -1.5) +b, new Vector3(-1.5, 0.5, -1.5) +b, new Vector3(-0.5, 0.5, -1.5) +b, new Vector3(-0.5, -0.5, -1.5) +b,
                                                     new Vector3(-1.5, -0.5, -0.5)+b, new Vector3(-1.5, 0.5, -0.5)+b, new Vector3(-0.5, 0.5, -0.5)+b, new Vector3(-0.5, -0.5, -0.5)+b,
                                                     Color.Blue, Color.Orange, Color.Black, Color.Black, Color.Black, Color.Black, 16);
                cubes[7, 1] = new Cube(new Vector3(-0.5, -0.5, -1.5) +b, new Vector3(-0.5, 0.5, -1.5) +b, new Vector3(0.5, 0.5, -1.5) +b, new Vector3(0.5, -0.5, -1.5) +b,
                                                     new Vector3(-0.5, -0.5, -0.5)+b, new Vector3(-0.5, 0.5, -0.5)+b, new Vector3(0.5, 0.5, -0.5)+b, new Vector3(0.5, -0.5, -0.5)+b,
                                                     Color.Blue, Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, 17);
                cubes[8, 1] = new Cube(new Vector3(0.5, -0.5, -1.5) +b, new Vector3(0.5, 0.5, -1.5) +b, new Vector3(1.5, 0.5, -1.5) +b, new Vector3(1.5, -0.5, -1.5) +b,
                                                     new Vector3(0.5, -0.5, -0.5)+b, new Vector3(0.5, 0.5, -0.5)+b, new Vector3(1.5, 0.5, -0.5)+b, new Vector3(1.5, -0.5, -0.5)+b,
                                                     Color.Blue, Color.Black, Color.Black, Color.Red, Color.Black, Color.Black, 18);

                cubes[0, 2] = new Cube(new Vector3(-1.5, -1.5, 0.5)+b, new Vector3(-1.5, -0.5, 0.5)+b, new Vector3(-0.5, -0.5, 0.5)+b, new Vector3(-0.5, -1.5, 0.5)+b,
                                                     new Vector3(-1.5, -1.5, 1.5)+b, new Vector3(-1.5, -0.5, 1.5)+b, new Vector3(-0.5, -0.5, 1.5)+b, new Vector3(-0.5, -1.5, 1.5)+b,
                                                     Color.Black, Color.Orange, Color.Green, Color.Black, Color.White, Color.Black, 20);
                cubes[1, 2] = new Cube(new Vector3(-0.5, -1.5, 0.5)+b, new Vector3(-0.5, -0.5, 0.5)+b, new Vector3(0.5, -0.5, 0.5)+b, new Vector3(0.5, -1.5, 0.5)+b,
                                                     new Vector3(-0.5, -1.5, 1.5)+b, new Vector3(-0.5, -0.5, 1.5)+b, new Vector3(0.5, -0.5, 1.5)+b, new Vector3(0.5, -1.5, 1.5)+b,
                                                     Color.Black, Color.Black, Color.Green, Color.Black, Color.White, Color.Black, 21);
                cubes[2, 2] = new Cube(new Vector3(0.5, -1.5, 0.5)+b, new Vector3(0.5, -0.5, 0.5)+b, new Vector3(1.5, -0.5, 0.5)+b, new Vector3(1.5, -1.5, 0.5)+b,
                                                     new Vector3(0.5, -1.5, 1.5)+b, new Vector3(0.5, -0.5, 1.5)+b, new Vector3(1.5, -0.5, 1.5)+b, new Vector3(1.5, -1.5, 1.5)+b,
                                                     Color.Black, Color.Black, Color.Green, Color.Red, Color.White, Color.Black, 22);
                cubes[3, 2] = new Cube(new Vector3(-1.5, -1.5, -0.5)+b, new Vector3(-1.5, -0.5, -0.5)+b, new Vector3(-0.5, -0.5, -0.5)+b, new Vector3(-0.5, -1.5, -0.5)+b,
                                                     new Vector3(-1.5, -1.5, 0.5)+b, new Vector3(-1.5, -0.5, 0.5)+b, new Vector3(-0.5, -0.5, 0.5)+b, new Vector3(-0.5, -1.5, 0.5)+b,
                                                     Color.Black, Color.Orange, Color.Black, Color.Black, Color.White, Color.Black, 23);
                cubes[4, 2] = new Cube(new Vector3(-0.5, -1.5, -0.5)+b, new Vector3(-0.5, -0.5, -0.5)+b, new Vector3(0.5, -0.5, -0.5)+b, new Vector3(0.5, -1.5, -0.5)+b,
                                                     new Vector3(-0.5, -1.5, 0.5)+b, new Vector3(-0.5, -0.5, 0.5)+b, new Vector3(0.5, -0.5, 0.5)+b, new Vector3(0.5, -1.5, 0.5)+b,
                                                     Color.Black, Color.Black, Color.Black, Color.Black, Color.White, Color.Black, 24);
                cubes[5, 2] = new Cube(new Vector3(0.5, -1.5, -0.5)+b, new Vector3(0.5, -0.5, -0.5)+b, new Vector3(1.5, -0.5, -0.5)+b, new Vector3(1.5, -1.5, -0.5)+b,
                                                     new Vector3(0.5, -1.5, 0.5)+b, new Vector3(0.5, -0.5, 0.5)+b, new Vector3(1.5, -0.5, 0.5)+b, new Vector3(1.5, -1.5, 0.5)+b,
                                                     Color.Black, Color.Black, Color.Black, Color.Red, Color.White, Color.Black, 25);
                cubes[6, 2] = new Cube(new Vector3(-1.5, -1.5, -1.5) +b, new Vector3(-1.5, -0.5, -1.5) +b, new Vector3(-0.5, -0.5, -1.5) +b, new Vector3(-0.5, -1.5, -1.5) +b,
                                                     new Vector3(-1.5, -1.5, -0.5)+b, new Vector3(-1.5, -0.5, -0.5)+b, new Vector3(-0.5, -0.5, -0.5)+b, new Vector3(-0.5, -1.5, -0.5)+b,
                                                     Color.Blue, Color.Orange, Color.Black, Color.Black, Color.White, Color.Black, 26);
                cubes[7, 2] = new Cube(new Vector3(-0.5, -1.5, -1.5) +b, new Vector3(-0.5, -0.5, -1.5) +b, new Vector3(0.5, -0.5, -1.5) +b, new Vector3(0.5, -1.5, -1.5) +b,
                                                     new Vector3(-0.5, -1.5, -0.5)+b, new Vector3(-0.5, -0.5, -0.5)+b, new Vector3(0.5, -0.5, -0.5)+b, new Vector3(0.5, -1.5, -0.5)+b,
                                                     Color.Blue, Color.Black, Color.Black, Color.Black, Color.White, Color.Black, 27);
                cubes[8, 2] = new Cube(new Vector3(0.5, -1.5, -1.5) +b, new Vector3(0.5, -0.5, -1.5) +b, new Vector3(1.5, -0.5, -1.5) +b, new Vector3(1.5, -1.5, -1.5) +b,
                                                     new Vector3(0.5, -1.5, -0.5)+b, new Vector3(0.5, -0.5, -0.5)+b, new Vector3(1.5, -0.5, -0.5)+b, new Vector3(1.5, -1.5, -0.5)+b,
                                                     Color.Blue, Color.Black, Color.Black, Color.Red, Color.White, Color.Black, 28);
            }

            // scale_x     0       0        translation_X
            //    0         scale_y 0       translation_Y
            //      0       0       scale_z translation_Z
            //      0       0       0         1           
        }

        //bílá = 0; žlutá = 1; červená = 2; oranžová = 3; modrá = 4; zelená = 5

        public double[,] projectionMatrix = new double[4, 4];
        public double[,] XRotationMatrix = new double[4, 4];
        public double[,] ZRotationMatrix = new double[4, 4];
        public double[,] animationZRotationMatrix = new double[4, 4];
        public double[,] animationXRotationMatrix = new double[4, 4];

        public string animateTurn = "E";
        public double turnAnimX = 0;
        public double turnAnimZ = 0;
        public double anim = 0;
        public double rotX = 0;
        public double rotZ = 0;

        public string historieTahu = "";

        Cube[,] cubes = new Cube[9, 3];


        private void buttonRight_Click(object sender, EventArgs e)
        {
            historieTahu += "R";
            label2.Text = "Historie: " + historieTahu;
            Turn("R");
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            historieTahu += "L";
            label2.Text = "Historie: " + historieTahu;
            Turn("L");
        }

        private void buttonTop_Click(object sender, EventArgs e)
        {
            historieTahu += "U";
            label2.Text = "Historie: " + historieTahu;
            Turn("U");
        }

        private void buttonBottom_Click(object sender, EventArgs e)
        {
            historieTahu += "D";
            label2.Text = "Historie: " + historieTahu;
            Turn("D");
        }

        private void buttonFront_Click(object sender, EventArgs e)
        {
            historieTahu += "F";
            label2.Text = "Historie: " + historieTahu;
            Turn("F");
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            historieTahu += "B";
            label2.Text = "Historie: " + historieTahu;
            Turn("B");
        }

        public void Turn(string input)
        {
            if(input.Length == 1)
            {
                switch (input[0])
                {
                    case 'R': 
                        
                        break;
                    case 'L': 
                        
                        break;
                    case 'U':
                        animateTurn = "U";
                        for (int i = 0; i < 7; i++)
                        {
                            //cubes[0,i] = 
                        }
                        break;
                    case 'D':
                        for(int i = 0; i < 9; i++)
                        {

                        }
                        break;
                    case 'F': 
                        
                        break;
                    case 'B': 
                        
                        break;
                }
            }
            if(input.Last() == '\'') 
            {
                //switch (input[0])
                //{
                //    case 'R': Turn("RRR"); break;
                //    case 'L': Turn("LLL"); break;
                //    case 'U': Turn("UUU"); break;
                //    case 'D': Turn("DDD"); break;
                //    case 'F': Turn("FFF"); break;
                //    case 'B': Turn("BBB"); break;
                //}
            }
            else if(input.Last() == '2')
            {
                //Turn(input[0].ToString());
            }
        }

        private void buttonAlgorithm_Click(object sender, EventArgs e)
        {
            Algorithm(textBoxAlgorithm.Text);
            historieTahu += textBoxAlgorithm.Text;
        }

        public void Algorithm(string alg)
        {
            string tahy = "RLUDFB";
            Stopwatch sw = new Stopwatch();
            for (int i = 0; i < alg.Length; i++)
            {
                if (tahy.Contains(alg[i]))
                {
                    sw.Restart();
                    string turn = alg[i].ToString();
                    if (i + 1 < alg.Length)
                    {
                        if (alg[i + 1] == '\'')
                        {
                            turn += "\'";
                            i++;
                            continue;
                        }
                        else if (alg[i + 1] == '2')
                        {
                            turn += "2";
                            i++;
                        }
                    }
                    Turn(turn);
                    //while(sw.ElapsedMilliseconds < 200)
                    {

                    }
                    pictureBox1.Refresh();
                }
            }
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
            if (pictureBox1.Height < pictureBox1.Width)
                aspectRatio = pictureBox1.Width / pictureBox1.Height;

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
        }

        private void scrambleButton_Click(object sender, EventArgs e)
        {
            string moves = "RLUDFB2'";
            Random rng = new Random();
            string scramble = moves[rng.Next(0, 6)].ToString();
            for (int i = 1; i < 20; i++)
            {
                scramble += MoveRandom(rng);
            }
            historieTahu += scramble;
            label2.Text = "Historie: " + historieTahu;
            Algorithm(scramble);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            RenderMatrix();
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            anim += 0.01;
            ZRotationMatrix[0, 0] = Math.Cos(rotX);
            ZRotationMatrix[0, 1] = Math.Sin(rotX);
            ZRotationMatrix[1, 0] = -Math.Sin(rotX);
            ZRotationMatrix[1, 1] = Math.Cos(rotX);
            ZRotationMatrix[2, 2] = 1;
            ZRotationMatrix[3, 3] = 1;

            XRotationMatrix[0, 0] = 1;
            XRotationMatrix[1, 1] = Math.Cos(rotZ * 0.5);
            XRotationMatrix[1, 2] = Math.Sin(rotZ * 0.5);
            XRotationMatrix[2, 1] = -Math.Sin(rotZ * 0.5);
            XRotationMatrix[2, 2] = Math.Cos(rotZ * 0.5);
            XRotationMatrix[3, 3] = 1;

            if(animateTurn == "E")
            {
                turnAnimX = anim;
                turnAnimZ = anim;
            }
            else
            {
                turnAnimZ += 0.02;
                animationZRotationMatrix[0, 0] = Math.Cos(turnAnimZ);
                animationZRotationMatrix[0, 1] = Math.Sin(turnAnimZ);
                animationZRotationMatrix[1, 0] = -Math.Sin(turnAnimZ);
                animationZRotationMatrix[1, 1] = Math.Cos(turnAnimZ);
                animationZRotationMatrix[2, 2] = 1;
                animationZRotationMatrix[3, 3] = 1;

                animationXRotationMatrix[0, 0] = 1;
                animationXRotationMatrix[1, 1] = Math.Cos(turnAnimX * 0.5);
                animationXRotationMatrix[1, 2] = Math.Sin(turnAnimX * 0.5);
                animationXRotationMatrix[2, 1] = -Math.Sin(turnAnimX * 0.5);
                animationXRotationMatrix[2, 2] = Math.Cos(turnAnimX * 0.5);
                animationXRotationMatrix[3, 3] = 1;
            }

            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //add all squares to a list and sort by Z position, draw from far to near
            List<Square> squareSort = new List<Square>();
            switch (animateTurn)
            {
                case "U":
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            for (int k = cubes[i, j].squares.Length - 1; k > 0; k--)
                            {
                                squareSort.Add(computeVectors(cubes[i, j].squares[k], true));

                            }
                        }
                    }
                    break;
            }
            foreach (Cube c in cubes)
            {
                foreach(Square squ in c.squares.Where(w => w.color != Color.Black))
                {
                    if (!squareSort.Contains(squ))
                        squareSort.Add(computeVectors(squ, false));
                }
            }
            squareSort = squareSort.OrderByDescending(q => q.Middle().Z).ToList();
            foreach (Square s in squareSort)
            {
                DrawSquare(g, s);
            }
        }

        public Square computeVectors(Square s, bool turnAnimation)
        {
            Square d = s.Copy(); //Výsledný polygon
            Square t = new Square(); //offset polygon
            Square rotaceZ = new Square(); //první rotace polygon
            Square rotaceX = new Square(); //druhá rotace polygon
            if (turnAnimation)
            {
                for (int i = 0; i < 4; i++)
                {
                    rotaceZ.vectors[i] = MultiplyMatrixVector(s.vectors[i], animationZRotationMatrix);
                    rotaceX.vectors[i] = MultiplyMatrixVector(rotaceZ.vectors[i], animationXRotationMatrix);
                    t.vectors[i] = rotaceX.vectors[i];
                    t.vectors[i].Z += 8;
                    d.vectors[i] = MultiplyMatrixVector(t.vectors[i], projectionMatrix);
                    d.vectors[i].X = (d.vectors[i].X + 1) * 0.5 * pictureBox1.Width;
                    d.vectors[i].Y = (d.vectors[i].Y + 1) * 0.5 * pictureBox1.Height;
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    rotaceZ.vectors[i] = MultiplyMatrixVector(s.vectors[i], ZRotationMatrix);
                    rotaceX.vectors[i] = MultiplyMatrixVector(rotaceZ.vectors[i], XRotationMatrix);
                    t.vectors[i] = rotaceX.vectors[i];
                    t.vectors[i].Z += 8;
                    d.vectors[i] = MultiplyMatrixVector(t.vectors[i], projectionMatrix);
                    d.vectors[i].X = (d.vectors[i].X + 1) * 0.5 * pictureBox1.Width;
                    d.vectors[i].Y = (d.vectors[i].Y + 1) * 0.5 * pictureBox1.Height;
                }
            }
            return d;
        }

        public void DrawSquare(Graphics g, Square s)
        {            
            Brush b = GetBrush(s.color);
            if (b != Brushes.Black)
            {
                g.FillPolygon(b, new PointF[]{
                                                        new PointF((float)s.vectors[0].X, (float)s.vectors[0].Y),
                                                        new PointF((float)s.vectors[1].X, (float)s.vectors[1].Y),
                                                        new PointF((float)s.vectors[2].X, (float)s.vectors[2].Y),
                                                        new PointF((float)s.vectors[3].X, (float)s.vectors[3].Y)});
                g.DrawPolygon(new Pen(Brushes.Black, 1), new PointF[]{
                                                        new PointF((float)s.vectors[0].X, (float)s.vectors[0].Y),
                                                        new PointF((float)s.vectors[1].X, (float)s.vectors[1].Y),
                                                        new PointF((float)s.vectors[2].X, (float)s.vectors[2].Y),
                                                        new PointF((float)s.vectors[3].X, (float)s.vectors[3].Y)});
            }
        }

        private Brush GetBrush(Color c)
        {
            return new SolidBrush(c);
        }

        public string MoveRandom(Random rng2)
        {
            string moves = "RLUDFB";
            string scramble = moves[rng2.Next(0, 6)].ToString();
            int m = rng2.Next(0, 4);
            if (m == 3)
                scramble += "2";
            else if (m == 2)
                scramble += "\'";
            return scramble;
        }

        Point oldMouse = MousePosition;
        bool moveCube = false;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            moveCube = true;
            oldMouse = MousePosition;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveCube)
            {
                //řádně vypočítat rotaci nebo změnit způsob otáčení
                if(rotZ%(Math.PI*2) >Math.PI)
                    rotX -= (double)(oldMouse.X - MousePosition.X) / 100;
                else rotX += (double)(oldMouse.X - MousePosition.X) / 100;
                rotZ -= (double)(oldMouse.Y - MousePosition.Y)/100;
                oldMouse = MousePosition;
            }
            label1.Text = "RotZ:" + rotZ + "\nRotX" + rotX;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            moveCube = false;
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            float aspectRatio = pictureBox2.Width / pictureBox2.Height;
            int width = Convert.ToInt32(pictureBox2.Size.Width/4 *aspectRatio);
            int height = Convert.ToInt32(pictureBox2.Size.Height/3*aspectRatio);
            Graphics g = e.Graphics;
            
            g.FillRectangle(Brushes.Black, new Rectangle(new Point(0, height), new Size(pictureBox2.Size.Width, height)));
            g.FillRectangle(Brushes.Black, new Rectangle(new Point(width, 0), new Size(width, pictureBox2.Size.Height)));
            
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    Cube c = cubes[j, i];
                    foreach(Square s in c.squares)
                    {
                        Brush b = Brushes.Black;
                        //not working
                        if (b == Brushes.Black) break;

                        g.FillRectangle(b, new Rectangle(new Point(i,j), new Size((width-5)/3, (height-5)/3)));
                    }
                }
            }
        }
    }
}
