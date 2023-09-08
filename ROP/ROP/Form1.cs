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

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 3; i++)
            {
                bottom[0, i] = 0; bottom[1, i] = 0; bottom[2, i] = 0;
                top[0, i] = 1; top[1, i] = 1; top[2, i] = 1;
                right[0, i] = 2; right[1, i] = 2; right[2, i] = 2;
                left[0, i] = 3;left[1, i] = 3; left[2, i] = 3;
                front[0, i] = 4; front[1, i] = 4; front[2, i] = 4;
                back[0, i] = 5; back[1, i] = 5; back[2, i] = 5;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Brush[] brushes = new Brush[6];
            brushes[0] = Brushes.White;
            brushes[1] = Brushes.Yellow;
            brushes[2] = Brushes.Red;
            brushes[3] = Brushes.Orange;
            brushes[4] = Brushes.Blue;
            brushes[5] = Brushes.Green;
            
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.Black, new Rectangle(45, 175, 240, 240));
            g.FillPolygon(Brushes.Black, new Point[] { new Point(45, 174),
                                                                                      new Point(183, 37),
                                                                                      new Point(423, 37),
                                                                                      new Point(287, 173) });
            g.FillPolygon(Brushes.Black, new Point[] { new Point(286, 175),
                                                                                      new Point(423, 38),
                                                                                      new Point(423, 277),
                                                                                      new Point(286, 414) });

            g.FillRectangle(Brushes.Black, new Rectangle(535, 195, 80, 240));
            g.FillRectangle(Brushes.Black, new Rectangle(455, 275, 320, 80));
            for (int i = 0;  i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //síť kostky
                    g.FillRectangle(brushes[bottom[i, j]], new Rectangle(540 + i * 25, 360 + j * 25, 20, 20));
                    g.FillRectangle(brushes[top[i, j]], new Rectangle(540 + i * 25, 200 + j * 25, 20, 20));
                    g.FillRectangle(brushes[right[i, j]], new Rectangle(620 + i * 25, 280 + j * 25, 20, 20));
                    g.FillRectangle(brushes[left[i, j]], new Rectangle(460 + i * 25, 280 + j * 25, 20, 20));
                    g.FillRectangle(brushes[front[i, j]], new Rectangle(540 + i * 25, 280 + j * 25, 20, 20));
                    g.FillRectangle(brushes[back[i, j]], new Rectangle(700 + i * 25, 280 + j * 25, 20, 20));

                    //3d (3 strany)
                    g.FillRectangle(brushes[front[i, j]], new Rectangle(50 + i * 80, 180 + j * 80, 70, 70));
                    g.FillPolygon(brushes[top[i, j]], new Point[] { new Point(55 + i * 80 + (2 - j) * 45, 80 + j * 45),
                                                                                      new Point(95 + i * 80 + (2 - j) * 45, 40 + j * 45),
                                                                                      new Point(165 + i * 80 + (2 - j) * 45, 40 + j * 45),
                                                                                      new Point(125 + i * 80 + (2 - j) * 45, 80 + j * 45) });
                    g.FillPolygon(brushes[right[i, j]], new Point[] { new Point(290 + i * 45, 175 + j * 80 + i * -45),
                                                                                      new Point(330 + i * 45, 135 + j * 80 + i * -45),
                                                                                      new Point(330 + i * 45, 205 + j * 80 + i * -45),
                                                                                      new Point(290 + i * 45, 245 + j * 80 + i * -45) });
                }
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Form1.ActiveForm.Refresh();

        }
    }
}
