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
        }

        //bílá = 0; žlutá = 1; červená = 2; oranžová = 3; modrá = 4; zelená = 5
        public int[,] bottom = new int[3,3];
        public int[,] top = new int[3, 3];
        public int[,] right = new int[3, 3];
        public int[,] left = new int[3, 3];
        public int[,] front = new int[3, 3];
        public int[,] back = new int[3, 3];

        public Point[,,] cubeVertices = new Point[2, 2, 2]; //x, y, z
        public int cubeWidth = 240;
        public Point basePoint = new Point(45, 45);

        public int frontSide = 4;
        public int upSide = 1;
        public int rightSide = 2;

        private void Form1_Load(object sender, EventArgs e)
        {
            cubeVertices[0, 0, 0] = new Point(0, (int)(cubeWidth*1.5));
            cubeVertices[1, 0, 0] = new Point(cubeWidth, (int)(cubeWidth * 1.5));
            cubeVertices[0, 1, 0] = new Point(0, cubeWidth/2);
            cubeVertices[1, 1, 0] = new Point(cubeWidth, cubeWidth/2);
            cubeVertices[0, 0, 1] = new Point(cubeWidth/2, cubeWidth);
            cubeVertices[1, 0, 1] = new Point((int)(cubeWidth*1.5), cubeWidth);
            cubeVertices[0, 1, 1] = new Point(cubeWidth/2, 0);
            cubeVertices[1, 1, 1] = new Point((int)(cubeWidth*1.5), 0);

            for (int i = 0; i < 3; i++)
            {
                bottom[0, i] = 0; bottom[1, i] = 0; bottom[2, i] = 0;
                top[0, i] = 1; top[1, i] = 1; top[2, i] = 1;
                right[0, i] = 2; right[1, i] = 2; right[2, i] = 2;
                left[0, i] = 3;left[1, i] = 3; left[2, i] = 3;
                front[0, i] = 4; front[1, i] = 4; front[2, i] = 4;
                back[0, i] = 5; back[1, i] = 5; back[2, i] = 5;
            }
            Render();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
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
            g.FillPolygon(brushes[4], new Point[] { cubeVertices[0, 0, 0], cubeVertices[0, 1, 0], cubeVertices[1, 1, 0], cubeVertices[1,0,0] }); //F
            g.FillPolygon(brushes[1], new Point[] { cubeVertices[0,1,0],cubeVertices[0,1,1],cubeVertices[1,1,1],cubeVertices[1,1,0] });//U
            g.FillPolygon(brushes[2], new Point[] { cubeVertices[1,1,0],cubeVertices[1,1,1],cubeVertices[1,0,1],cubeVertices[1,0,0] });//R

            g.FillPolygon(brushes[3], new Point[] { cubeVertices[0, 1, 0], cubeVertices[0, 1, 1], cubeVertices[0, 0, 1], cubeVertices[0, 0, 0] });//L
            g.FillPolygon(brushes[5], new Point[] { cubeVertices[0, 0, 1], cubeVertices[0, 1, 1], cubeVertices[1, 1, 1], cubeVertices[1, 0, 1] });//B
            g.FillPolygon(brushes[0], new Point[] { cubeVertices[0, 0, 0], cubeVertices[0, 0, 1], cubeVertices[1, 0, 1], cubeVertices[1, 0, 0] });//D

            g.DrawEllipse(new Pen(Color.Gold, 2), 0, (float)(Math.Sin(vertical) * cubeWidth + cubeWidth*0.5), 2 * cubeWidth, (float)(Math.Sin(-vertical) * cubeWidth * 2));
            g.DrawEllipse(new Pen(Color.Gray, 2), 0, (float)(Math.Sin(vertical) * cubeWidth + cubeWidth * 1.75), 2 * cubeWidth, (float)(Math.Sin(-vertical) * cubeWidth * 2));

            g.DrawEllipse(new Pen(Color.DarkBlue, 2), 
                (float)(Math.Sin(horizontal) * cubeWidth), 
                (float)(Math.Sin(vertical) * cubeWidth + cubeWidth), 
                (float)(Math.Sin(-horizontal) * cubeWidth), 
                (float)(Math.Sin(-vertical) * cubeWidth * 2));

            //g.FillRectangle(Brushes.Black, new Rectangle(535, 195, 80, 240));
            //g.FillRectangle(Brushes.Black, new Rectangle(455, 275, 320, 80));
            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        //síť kostky
            //        g.FillRectangle(brushes[bottom[i, j]], new Rectangle(540 + i * 25, 360 + j * 25, 20, 20));
            //        g.FillRectangle(brushes[top[i, j]], new Rectangle(540 + i * 25, 200 + j * 25, 20, 20));
            //        g.FillRectangle(brushes[right[i, j]], new Rectangle(620 + i * 25, 280 + j * 25, 20, 20));
            //        g.FillRectangle(brushes[left[i, j]], new Rectangle(460 + i * 25, 280 + j * 25, 20, 20));
            //        g.FillRectangle(brushes[front[i, j]], new Rectangle(540 + i * 25, 280 + j * 25, 20, 20));
            //        g.FillRectangle(brushes[back[i, j]], new Rectangle(700 + i * 25, 280 + j * 25, 20, 20));

            //        //3d (3 strany)
            //        g.FillRectangle(brushes[front[i, j]], new Rectangle(50 + i * 80, 180 + j * 80, 70, 70));
            //        g.FillPolygon(brushes[top[i, j]], new Point[] { new Point(55 + i * 80 + (2 - j) * 45, 80 + j * 45),
            //                                                                          new Point(95 + i * 80 + (2 - j) * 45, 40 + j * 45),
            //                                                                          new Point(165 + i * 80 + (2 - j) * 45, 40 + j * 45),
            //                                                                          new Point(125 + i * 80 + (2 - j) * 45, 80 + j * 45) });
            //        g.FillPolygon(brushes[right[i, j]], new Point[] { new Point(290 + i * 45, 175 + j * 80 + i * -45),
            //                                                                          new Point(330 + i * 45, 135 + j * 80 + i * -45),
            //                                                                          new Point(330 + i * 45, 205 + j * 80 + i * -45),
            //                                                                          new Point(290 + i * 45, 245 + j * 80 + i * -45) });
            //    }
            //}
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Form1.ActiveForm.Refresh();

        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            TurnRight();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            TurnLeft();
        }

        private void buttonTop_Click(object sender, EventArgs e)
        {
            TurnUp();
        }

        private void buttonBottom_Click(object sender, EventArgs e)
        {
            TurnDown();
        }

        private void buttonFront_Click(object sender, EventArgs e)
        {
            TurnFront();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
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
            string tahy = "RLUDFB";
            string alg = textBoxAlgorithm.Text;
            for (int i = 0; i < alg.Length; i++)
            {
                if (tahy.Contains(alg[i]))
                {
                    if (i+1 < alg.Length)
                    {
                        if(alg[i+1] == '\'')
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
                        else if(alg[i+1] == '2')
                        {
                            alg = alg.Remove(i+1, 1).Insert(i+1, alg[i].ToString());
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
        }

        private void algorithm2_Click(object sender, EventArgs e)
        {
            textBoxAlgorithm.Text = "D2U2R2L2F2B2";
        }

        private void algorithm1_Click(object sender, EventArgs e)
        {
            textBoxAlgorithm.Text = "U'L'U'F'R2B'RFUB2UB'LU'FURF'";
        }

        double horizontal = 0;
        double vertical = 0.5;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    horizontal += 0.1;
                    break;
                case Keys.Left:
                    horizontal -= 0.1;
                    break;
                case Keys.Up:
                    vertical -= 0.1;
                    break;
                case Keys.Down:
                    vertical += 0.1;
                    break;
            }
            Render();

            ActiveForm.Refresh();
        }
        public void Render()
        {
            cubeVertices[0, 0, 0].X = Convert.ToInt32(cubeWidth * Math.Sin(horizontal + Math.PI * 1.5) + cubeWidth);
            cubeVertices[1, 0, 0].X = Convert.ToInt32(cubeWidth * Math.Sin(horizontal + Math.PI * 1) + cubeWidth);
            cubeVertices[0, 1, 0].X = Convert.ToInt32(cubeWidth * Math.Sin(horizontal + Math.PI * 1.5) + cubeWidth);
            cubeVertices[1, 1, 0].X = Convert.ToInt32(cubeWidth * Math.Sin(horizontal + Math.PI * 1) + cubeWidth);
            cubeVertices[0, 0, 1].X = Convert.ToInt32(cubeWidth * Math.Sin(horizontal + Math.PI * 0) + cubeWidth);
            cubeVertices[1, 0, 1].X = Convert.ToInt32(cubeWidth * Math.Sin(horizontal + Math.PI * 0.5) + cubeWidth);
            cubeVertices[0, 1, 1].X = Convert.ToInt32(cubeWidth * Math.Sin(horizontal + Math.PI * 0) + cubeWidth);
            cubeVertices[1, 1, 1].X = Convert.ToInt32(cubeWidth * Math.Sin(horizontal + Math.PI * 0.5) + cubeWidth);

            cubeVertices[0, 0, 0].Y = Convert.ToInt32(cubeWidth * Math.Sin(vertical) * Math.Sin(horizontal + Math.PI * 1) + cubeWidth * 1.75);
            cubeVertices[1, 0, 0].Y = Convert.ToInt32(cubeWidth * Math.Sin(vertical) * Math.Sin(horizontal + Math.PI * 0.5) + cubeWidth * 1.75);
            cubeVertices[0, 1, 0].Y = Convert.ToInt32(cubeWidth * Math.Sin(vertical) * Math.Sin(horizontal + Math.PI * 1) + cubeWidth * 0.5);
            cubeVertices[1, 1, 0].Y = Convert.ToInt32(cubeWidth * Math.Sin(vertical) * Math.Sin(horizontal + Math.PI * 0.5) + cubeWidth * 0.5);
            cubeVertices[0, 0, 1].Y = Convert.ToInt32(cubeWidth * Math.Sin(vertical) * Math.Sin(horizontal + Math.PI * 1.5) + cubeWidth * 1.75);
            cubeVertices[1, 0, 1].Y = Convert.ToInt32(cubeWidth * Math.Sin(vertical) * Math.Sin(horizontal + Math.PI * 2) + cubeWidth * 1.75);
            cubeVertices[0, 1, 1].Y = Convert.ToInt32(cubeWidth * Math.Sin(vertical) * Math.Sin(horizontal + Math.PI * 1.5) + cubeWidth * 0.5);
            cubeVertices[1, 1, 1].Y = Convert.ToInt32(cubeWidth * Math.Sin(vertical) * Math.Sin(horizontal + Math.PI * 2) + cubeWidth * 0.5);
        }
    }
}
