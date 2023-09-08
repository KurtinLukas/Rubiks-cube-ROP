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
        public int[,] down = new int[3,3];
        public int[,] up = new int[3, 3];
        public int[,] right = new int[3, 3];
        public int[,] left = new int[3, 3];
        public int[,] front = new int[3, 3];
        public int[,] back = new int[3, 3];

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 3; i++)
            {
                down[0, i] = 0; down[1, i] = 0; down[2, i] = 0;
                up[0, i] = 1; up[1, i] = 1; up[2, i] = 1;
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
            g.FillRectangle(Brushes.Black, new Rectangle(95, 175, 320,80));
            g.FillRectangle(Brushes.Black, new Rectangle(175, 95, 80, 240));
            for (int i = 0;  i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    g.FillRectangle(brushes[down[i, j]], new Rectangle(180 + i * 20 + i*5, 260 + j * 20 + j*5, 20, 20));
                    g.FillRectangle(brushes[up[i, j]], new Rectangle(180 + i * 20 + i * 5, 100 + j * 20 + j * 5, 20, 20));
                    g.FillRectangle(brushes[right[i, j]], new Rectangle(260 + i * 20 + i * 5, 180 + j * 20 + j * 5, 20, 20));
                    g.FillRectangle(brushes[left[i, j]], new Rectangle(100 + i * 20 + i * 5, 180 + j * 20 + j * 5, 20, 20));
                    g.FillRectangle(brushes[front[i, j]], new Rectangle(180 + i * 20 + i * 5, 180 + j * 20 + j * 5, 20, 20));
                    g.FillRectangle(brushes[back[i, j]], new Rectangle(340 + i * 20 + i * 5, 180 + j * 20 + j * 5, 20, 20));
                }
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Form1.ActiveForm.Refresh();

        }
    }
}
