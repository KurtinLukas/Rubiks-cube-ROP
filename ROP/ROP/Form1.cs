﻿using System;
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
        public double rotX = 0;
        public double rotZ = 0;

        public string historieTahu = "";
        public bool redraw = false;

        Cube[,] cubes = new Cube[9, 3];


        private void Form1_Activated(object sender, EventArgs e)
        {

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
                        for (int i = 0; i < 9; i++)
                        {
                            cubes[2, i] = cubes[2, i + 2];
                        }
                        break;
                    case 'D':
                        for(int i = 0; i < 9; i++)
                        {
                            cubes[0, i] = cubes[0, i + 2];
                            cubes[0, i].position+=2;
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
                switch (input[0])
                {
                    case 'R': TurnRight(); TurnRight(); TurnRight(); break;
                    case 'L': TurnLeft(); TurnLeft(); TurnLeft(); break;
                    case 'U': TurnUp(); TurnUp(); TurnUp(); break;
                    case 'D': TurnDown(); TurnDown(); TurnDown(); break;
                    case 'F': TurnFront(); TurnFront(); TurnFront(); break;
                    case 'B': TurnBack(); TurnBack(); TurnBack(); break;
                }
            }
            else if(input[0] == '2')
            {

            }
        }

        //zastaralé funkce
        public void TurnRight()
        {


            //zastaralé
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
                    while(sw.ElapsedMilliseconds < 200)
                    {

                    }
                    pictureBox1.Refresh();
                    pictureBox2.Refresh();
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
            redraw = true;
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

            redraw = true;
            pictureBox1.Refresh();
            pictureBox2.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (redraw)
            {
                foreach (Cube c in cubes)
                {
                        foreach (Square s in c.squares.Where(s => s.color != Color.Black))
                        {
                            DrawSquare(g, s);
                        }
                }
                redraw = false;
            }
            
            Vector3 z = MultiplyMatrixVector(new Vector3(0,0,0), ZRotationMatrix);
            Vector3 x = MultiplyMatrixVector(z, XRotationMatrix);
            Vector3 v = MultiplyMatrixVector(x, projectionMatrix);
            z = MultiplyMatrixVector(new Vector3(0,0,0), ZRotationMatrix);
            x = MultiplyMatrixVector(z, XRotationMatrix);
            Vector3 zeroPoint = MultiplyMatrixVector(x, projectionMatrix);
            label2.Text = zeroPoint.X + "\n" + zeroPoint.Y + "\n" + zeroPoint.Z;
            g.DrawLine(new Pen(Brushes.Black, 3), (float)v.X, (float)v.Y, (float)zeroPoint.X, (float)zeroPoint.Y);
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
                t.vectors[i].Z += 8;
                d.vectors[i] = MultiplyMatrixVector(t.vectors[i], projectionMatrix);
                d.vectors[i].X = (d.vectors[i].X + 1) * 0.5 * pictureBox1.Width;
                d.vectors[i].Y = (d.vectors[i].Y + 1) * 0.5 * pictureBox1.Height;
            }
                Brush b = GetBrush(s.color);
                g.FillPolygon(b, new PointF[]{
                                                        new PointF((float)d.vectors[0].X, (float)d.vectors[0].Y),
                                                        new PointF((float)d.vectors[1].X, (float)d.vectors[1].Y),
                                                        new PointF((float)d.vectors[2].X, (float)d.vectors[2].Y),
                                                        new PointF((float)d.vectors[3].X, (float)d.vectors[3].Y)});
                //g.DrawPolygon(new Pen(b, 2), new PointF[]{
                //                                        new PointF((float)d.vectors[0].X, (float)d.vectors[0].Y),
                //                                        new PointF((float)d.vectors[1].X, (float)d.vectors[1].Y),
                //                                        new PointF((float)d.vectors[2].X, (float)d.vectors[2].Y),
                //                                        new PointF((float)d.vectors[3].X, (float)d.vectors[3].Y)});
            
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
                if(rotZ%(Math.PI*2+Math.PI) >Math.PI)
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

            if (redraw)
            {
                foreach (Cube c in cubes)
                {
                    foreach (Square s in c.squares.Where(x=>x.color != Color.Black))
                    {
                        
                    }
                }
                redraw = false;
            }
        }
    }

    public class Vector3 : ICloneable
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

        public object Clone()
        {
            return new Vector3(X, Y, Z);
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
    }

    public class Square : ICloneable
    {
        public Vector3[] vectors;
        public Color color = Color.Black;
        public Vector3 normal;

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
    }
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
