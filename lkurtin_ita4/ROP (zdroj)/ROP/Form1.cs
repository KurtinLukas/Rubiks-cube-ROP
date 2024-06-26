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
            GenerateCubes();
            RenderMatrix();
            pictureBox1.SendToBack();
            for(int i = 0; i < 21; i++)
            {
                comboBox1.Items[i] = PLL[i + 21] + "-" + PLL[i];
            }           
        }
        public void GenerateCubes()
        {
            {
                cubes[0, 0] = new Cube(new Vector3(-1.5, 0.5, 0.5), new Vector3(-1.5, 1.5, 0.5), 
                                       new Vector3(-0.5, 1.5, 0.5), new Vector3(-0.5, 0.5, 0.5),
                                       new Vector3(-1.5, 0.5, 1.5), new Vector3(-1.5, 1.5, 1.5), 
                                       new Vector3(-0.5, 1.5, 1.5), new Vector3(-0.5, 0.5, 1.5),
                                       Color.Black, Color.Orange, Color.Green, 
                                       Color.Black, Color.Black, Color.Yellow, 
                                       0);
                cubes[1, 0] = new Cube(new Vector3(-0.5, 0.5, 0.5), new Vector3(-0.5, 1.5, 0.5), new Vector3(0.5, 1.5, 0.5), new Vector3(0.5, 0.5, 0.5),
                                                     new Vector3(-0.5, 0.5, 1.5), new Vector3(-0.5, 1.5, 1.5), new Vector3(0.5, 1.5, 1.5), new Vector3(0.5, 0.5, 1.5),
                                                     Color.Black, Color.Black, Color.Green, Color.Black, Color.Black, Color.Yellow, 1);
                cubes[2, 0] = new Cube(new Vector3(0.5, 0.5, 0.5), new Vector3(0.5, 1.5, 0.5), new Vector3(1.5, 1.5, 0.5), new Vector3(1.5, 0.5, 0.5),
                                                     new Vector3(0.5, 0.5, 1.5), new Vector3(0.5, 1.5, 1.5), new Vector3(1.5, 1.5, 1.5), new Vector3(1.5, 0.5, 1.5),
                                                     Color.Black, Color.Black, Color.Green, Color.Red, Color.Black, Color.Yellow, 2);
                cubes[3, 0] = new Cube(new Vector3(-1.5, 0.5, -0.5), new Vector3(-1.5, 1.5, -0.5), new Vector3(-0.5, 1.5, -0.5), new Vector3(-0.5, 0.5, -0.5),
                                                     new Vector3(-1.5, 0.5, 0.5), new Vector3(-1.5, 1.5, 0.5), new Vector3(-0.5, 1.5, 0.5), new Vector3(-0.5, 0.5, 0.5),
                                                     Color.Black, Color.Orange, Color.Black, Color.Black, Color.Black, Color.Yellow, 3);
                cubes[4, 0] = new Cube(new Vector3(-0.5, 0.5, -0.5), new Vector3(-0.5, 1.5, -0.5), new Vector3(0.5, 1.5, -0.5), new Vector3(0.5, 0.5, -0.5),
                                                     new Vector3(-0.5, 0.5, 0.5), new Vector3(-0.5, 1.5, 0.5), new Vector3(0.5, 1.5, 0.5), new Vector3(0.5, 0.5, 0.5),
                                                     Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, Color.Yellow, 4);
                cubes[5, 0] = new Cube(new Vector3(0.5, 0.5, -0.5), new Vector3(0.5, 1.5, -0.5), new Vector3(1.5, 1.5, -0.5), new Vector3(1.5, 0.5, -0.5),
                                                     new Vector3(0.5, 0.5, 0.5), new Vector3(0.5, 1.5, 0.5), new Vector3(1.5, 1.5, 0.5), new Vector3(1.5, 0.5, 0.5),
                                                     Color.Black, Color.Black, Color.Black, Color.Red, Color.Black, Color.Yellow, 5);
                cubes[6, 0] = new Cube(new Vector3(-1.5, 0.5, -1.5), new Vector3(-1.5, 1.5, -1.5), new Vector3(-0.5, 1.5, -1.5), new Vector3(-0.5, 0.5, -1.5),
                                                     new Vector3(-1.5, 0.5, -0.5), new Vector3(-1.5, 1.5, -0.5), new Vector3(-0.5, 1.5, -0.5), new Vector3(-0.5, 0.5, -0.5),
                                                     Color.Blue, Color.Orange, Color.Black, Color.Black, Color.Black, Color.Yellow, 6);
                cubes[7, 0] = new Cube(new Vector3(-0.5, 0.5, -1.5), new Vector3(-0.5, 1.5, -1.5), new Vector3(0.5, 1.5, -1.5), new Vector3(0.5, 0.5, -1.5),
                                                     new Vector3(-0.5, 0.5, -0.5), new Vector3(-0.5, 1.5, -0.5), new Vector3(0.5, 1.5, -0.5), new Vector3(0.5, 0.5, -0.5),
                                                     Color.Blue, Color.Black, Color.Black, Color.Black, Color.Black, Color.Yellow, 7);
                cubes[8, 0] = new Cube(new Vector3(0.5, 0.5, -1.5), new Vector3(0.5, 1.5, -1.5), new Vector3(1.5, 1.5, -1.5), new Vector3(1.5, 0.5, -1.5),
                                                     new Vector3(0.5, 0.5, -0.5), new Vector3(0.5, 1.5, -0.5), new Vector3(1.5, 1.5, -0.5), new Vector3(1.5, 0.5, -0.5),
                                                     Color.Blue, Color.Black, Color.Black, Color.Red, Color.Black, Color.Yellow, 8);

                cubes[0, 1] = new Cube(new Vector3(-1.5, -0.5, 0.5), new Vector3(-1.5, 0.5, 0.5), new Vector3(-0.5, 0.5, 0.5), new Vector3(-0.5, -0.5, 0.5),
                                                     new Vector3(-1.5, -0.5, 1.5), new Vector3(-1.5, 0.5, 1.5), new Vector3(-0.5, 0.5, 1.5), new Vector3(-0.5, -0.5, 1.5),
                                                     Color.Black, Color.Orange, Color.Green, Color.Black, Color.Black, Color.Black, 9);
                cubes[1, 1] = new Cube(new Vector3(-0.5, -0.5, 0.5), new Vector3(-0.5, 0.5, 0.5), new Vector3(0.5, 0.5, 0.5), new Vector3(0.5, -0.5, 0.5),
                                                     new Vector3(-0.5, -0.5, 1.5), new Vector3(-0.5, 0.5, 1.5), new Vector3(0.5, 0.5, 1.5), new Vector3(0.5, -0.5, 1.5),
                                                     Color.Black, Color.Black, Color.Green, Color.Black, Color.Black, Color.Black, 10);
                cubes[2, 1] = new Cube(new Vector3(0.5, -0.5, 0.5), new Vector3(0.5, 0.5, 0.5), new Vector3(1.5, 0.5, 0.5), new Vector3(1.5, -0.5, 0.5),
                                                     new Vector3(0.5, -0.5, 1.5), new Vector3(0.5, 0.5, 1.5), new Vector3(1.5, 0.5, 1.5), new Vector3(1.5, -0.5, 1.5),
                                                     Color.Black, Color.Black, Color.Green, Color.Red, Color.Black, Color.Black, 11);
                cubes[3, 1] = new Cube(new Vector3(-1.5, -0.5, -0.5), new Vector3(-1.5, 0.5, -0.5), new Vector3(-0.5, 0.5, -0.5), new Vector3(-0.5, -0.5, -0.5),
                                                     new Vector3(-1.5, -0.5, 0.5), new Vector3(-1.5, 0.5, 0.5), new Vector3(-0.5, 0.5, 0.5), new Vector3(-0.5, -0.5, 0.5),
                                                     Color.Black, Color.Orange, Color.Black, Color.Black, Color.Black, Color.Black, 12);
                cubes[4, 1] = new Cube(new Vector3(-0.5, -0.5, -0.5), new Vector3(-0.5, 0.5, -0.5), new Vector3(0.5, 0.5, -0.5), new Vector3(0.5, -0.5, -0.5),
                                                     new Vector3(-0.5, -0.5, 0.5), new Vector3(-0.5, 0.5, 0.5), new Vector3(0.5, 0.5, 0.5), new Vector3(0.5, -0.5, 0.5),
                                                     Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, 13);
                cubes[5, 1] = new Cube(new Vector3(0.5, -0.5, -0.5), new Vector3(0.5, 0.5, -0.5), new Vector3(1.5, 0.5, -0.5), new Vector3(1.5, -0.5, -0.5),
                                                     new Vector3(0.5, -0.5, 0.5), new Vector3(0.5, 0.5, 0.5), new Vector3(1.5, 0.5, 0.5), new Vector3(1.5, -0.5, 0.5),
                                                     Color.Black, Color.Black, Color.Black, Color.Red, Color.Black, Color.Black, 14);
                cubes[6, 1] = new Cube(new Vector3(-1.5, -0.5, -1.5), new Vector3(-1.5, 0.5, -1.5), new Vector3(-0.5, 0.5, -1.5), new Vector3(-0.5, -0.5, -1.5),
                                                     new Vector3(-1.5, -0.5, -0.5), new Vector3(-1.5, 0.5, -0.5), new Vector3(-0.5, 0.5, -0.5), new Vector3(-0.5, -0.5, -0.5),
                                                     Color.Blue, Color.Orange, Color.Black, Color.Black, Color.Black, Color.Black, 15);
                cubes[7, 1] = new Cube(new Vector3(-0.5, -0.5, -1.5), new Vector3(-0.5, 0.5, -1.5), new Vector3(0.5, 0.5, -1.5), new Vector3(0.5, -0.5, -1.5),
                                                     new Vector3(-0.5, -0.5, -0.5), new Vector3(-0.5, 0.5, -0.5), new Vector3(0.5, 0.5, -0.5), new Vector3(0.5, -0.5, -0.5),
                                                     Color.Blue, Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, 16);
                cubes[8, 1] = new Cube(new Vector3(0.5, -0.5, -1.5), new Vector3(0.5, 0.5, -1.5), new Vector3(1.5, 0.5, -1.5), new Vector3(1.5, -0.5, -1.5),
                                                     new Vector3(0.5, -0.5, -0.5), new Vector3(0.5, 0.5, -0.5), new Vector3(1.5, 0.5, -0.5), new Vector3(1.5, -0.5, -0.5),
                                                     Color.Blue, Color.Black, Color.Black, Color.Red, Color.Black, Color.Black, 17);

                cubes[0, 2] = new Cube(new Vector3(-1.5, -1.5, 0.5), new Vector3(-1.5, -0.5, 0.5), new Vector3(-0.5, -0.5, 0.5), new Vector3(-0.5, -1.5, 0.5),
                                                     new Vector3(-1.5, -1.5, 1.5), new Vector3(-1.5, -0.5, 1.5), new Vector3(-0.5, -0.5, 1.5), new Vector3(-0.5, -1.5, 1.5),
                                                     Color.Black, Color.Orange, Color.Green, Color.Black, Color.White, Color.Black, 18);
                cubes[1, 2] = new Cube(new Vector3(-0.5, -1.5, 0.5), new Vector3(-0.5, -0.5, 0.5), new Vector3(0.5, -0.5, 0.5), new Vector3(0.5, -1.5, 0.5),
                                                     new Vector3(-0.5, -1.5, 1.5), new Vector3(-0.5, -0.5, 1.5), new Vector3(0.5, -0.5, 1.5), new Vector3(0.5, -1.5, 1.5),
                                                     Color.Black, Color.Black, Color.Green, Color.Black, Color.White, Color.Black, 19);
                cubes[2, 2] = new Cube(new Vector3(0.5, -1.5, 0.5), new Vector3(0.5, -0.5, 0.5), new Vector3(1.5, -0.5, 0.5), new Vector3(1.5, -1.5, 0.5),
                                                     new Vector3(0.5, -1.5, 1.5), new Vector3(0.5, -0.5, 1.5), new Vector3(1.5, -0.5, 1.5), new Vector3(1.5, -1.5, 1.5),
                                                     Color.Black, Color.Black, Color.Green, Color.Red, Color.White, Color.Black, 20);
                cubes[3, 2] = new Cube(new Vector3(-1.5, -1.5, -0.5), new Vector3(-1.5, -0.5, -0.5), new Vector3(-0.5, -0.5, -0.5), new Vector3(-0.5, -1.5, -0.5),
                                                     new Vector3(-1.5, -1.5, 0.5), new Vector3(-1.5, -0.5, 0.5), new Vector3(-0.5, -0.5, 0.5), new Vector3(-0.5, -1.5, 0.5),
                                                     Color.Black, Color.Orange, Color.Black, Color.Black, Color.White, Color.Black, 21);
                cubes[4, 2] = new Cube(new Vector3(-0.5, -1.5, -0.5), new Vector3(-0.5, -0.5, -0.5), new Vector3(0.5, -0.5, -0.5), new Vector3(0.5, -1.5, -0.5),
                                                     new Vector3(-0.5, -1.5, 0.5), new Vector3(-0.5, -0.5, 0.5), new Vector3(0.5, -0.5, 0.5), new Vector3(0.5, -1.5, 0.5),
                                                     Color.Black, Color.Black, Color.Black, Color.Black, Color.White, Color.Black, 22);
                cubes[5, 2] = new Cube(new Vector3(0.5, -1.5, -0.5), new Vector3(0.5, -0.5, -0.5), new Vector3(1.5, -0.5, -0.5), new Vector3(1.5, -1.5, -0.5),
                                                     new Vector3(0.5, -1.5, 0.5), new Vector3(0.5, -0.5, 0.5), new Vector3(1.5, -0.5, 0.5), new Vector3(1.5, -1.5, 0.5),
                                                     Color.Black, Color.Black, Color.Black, Color.Red, Color.White, Color.Black, 23);
                cubes[6, 2] = new Cube(new Vector3(-1.5, -1.5, -1.5), new Vector3(-1.5, -0.5, -1.5), new Vector3(-0.5, -0.5, -1.5), new Vector3(-0.5, -1.5, -1.5),
                                                     new Vector3(-1.5, -1.5, -0.5), new Vector3(-1.5, -0.5, -0.5), new Vector3(-0.5, -0.5, -0.5), new Vector3(-0.5, -1.5, -0.5),
                                                     Color.Blue, Color.Orange, Color.Black, Color.Black, Color.White, Color.Black, 24);
                cubes[7, 2] = new Cube(new Vector3(-0.5, -1.5, -1.5), new Vector3(-0.5, -0.5, -1.5), new Vector3(0.5, -0.5, -1.5), new Vector3(0.5, -1.5, -1.5),
                                                     new Vector3(-0.5, -1.5, -0.5), new Vector3(-0.5, -0.5, -0.5), new Vector3(0.5, -0.5, -0.5), new Vector3(0.5, -1.5, -0.5),
                                                     Color.Blue, Color.Black, Color.Black, Color.Black, Color.White, Color.Black, 25);
                cubes[8, 2] = new Cube(new Vector3(0.5, -1.5, -1.5), new Vector3(0.5, -0.5, -1.5), new Vector3(1.5, -0.5, -1.5), new Vector3(1.5, -1.5, -1.5),
                                                     new Vector3(0.5, -1.5, -0.5), new Vector3(0.5, -0.5, -0.5), new Vector3(1.5, -0.5, -0.5), new Vector3(1.5, -1.5, -0.5),
                                                     Color.Blue, Color.Black, Color.Black, Color.Red, Color.White, Color.Black, 26);
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cubes[i, j] = new Cube(cubes[i, j]);
                }
            }
            cubes[1, 1].rotateAxis = 0;
            cubes[5, 1].rotateAxis = 1;
            cubes[7, 1].rotateAxis = 2;
            cubes[3, 1].rotateAxis = 3;
        }
        //bílá = 0; žlutá = 1; červená = 2; oranžová = 3; modrá = 4; zelená = 5

        public double[,] projectionMatrix = new double[4, 4];
        public double[,] XRotationMatrix = new double[4, 4];
        public double[,] ZRotationMatrix = new double[4, 4];

        public List<char> animateTurn = new List<char>();
        //public double turnAnimX = 0;
        //public double turnAnimZ = 0;
        public double turnAnim = 0;
        public double rotX = 0;
        public double rotZ = Math.PI * 2;
        public double turnStep = 31;
        public double turnStepChangeRequest = 32;
        public double distanceFromCamera = 7;

        public string historieTahu = " ";
        private bool solving = false;

        Cube[,] cubes = new Cube[9, 3];
        
        public static string[] PLL = {"R'FR'B2RF'R'B2R2",//Aa  
            "R2B2RFR'B2RF'R",//Ab
            "RB'R'FRBR'F'RBR'FRB'R'F'",//E
            "R'U'F'RUR'U'R'FR2U'R'U'RUR'UR",//F
            "R2UR'UR'U'RU'R2DU'R'URD'",//Ga
            "R'U'RUD'R2UR'URU'RU'R2D",//Gb
            "R2U'RU'RUR'UR2D'URU'R'D",//Gc
            "RUR'U'DR2U'RU'R'UR'UR2D'",//Gd
            "M2UM2U2M2UM2",//H
            "L'U'LFL'U'LULF'L2UL",//Ja
            "RUR'F'RUR'U'R'FR2U'R'",//Jb
            "RUR'URUR'F'RUR'U'R'FR2U'R'U2RU'R'",//Na
            "R'URU'R'F'U'FRUR'FR'F'RU'R",//Nb
            "LU2L'U2LF'L'U'LULFL2",//Ra
            "R'U2RU2R'FRUR'U'R'F'R2",//Rb
            "RUR'U'R'FR2U'R'U'RUR'F'",//T
            "M2UMU2M'UM2",//Ua
            "M2U'MU2M'U'M2",//Ub
            "R'UR'U'RD'R'DR'UD'R2U'R2DR2",//V
            "FRU'R'U'RUR'F'RUR'U'R'FRF'",//Y
            "M2UM2UM'U2M2U2M'U2", //Z
            "Aa","Ab","E","F","Ga","Gb","Gc","Gd","H","Ja","Jb","Na","Nb","Ra","Rb","T","Ua","Ub","V","Y","Z"
        };

        public void Turn(string input)
        {
            if (input[0] == '\'' || input[0] == '2')
                return;

            if (historieTahu != "" && historieTahu.Last() == input[0] && input.Length == 1)
                historieTahu += "2";
            else historieTahu += input;
            label2.Text = "Historie: " + historieTahu.Substring(historieTahu.Length > 30 ? historieTahu.Length-31 : 0);

            Cube buffCorner = new Cube();
            Cube buffEdge = new Cube();

            if (input.Length == 1)
            {
                switch (input[0])
                {
                    case 'U':
                        buffCorner = new Cube(cubes[0, 0]);
                        cubes[0, 0] = new Cube(cubes[2, 0]);
                        cubes[2, 0] = new Cube(cubes[8, 0]);
                        cubes[8, 0] = new Cube(cubes[6, 0]);
                        cubes[6, 0] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[1, 0]);
                        cubes[1, 0] = new Cube(cubes[5, 0]);
                        cubes[5, 0] = new Cube(cubes[7, 0]);
                        cubes[7, 0] = new Cube(cubes[3, 0]);
                        cubes[3, 0] = new Cube(buffEdge);
                        cubes[4, 0] = new Cube(cubes[4, 0]);
                        break;
                    case 'D':
                        buffCorner = new Cube(cubes[0, 2]);
                        cubes[0, 2] = new Cube(cubes[6, 2]);
                        cubes[6, 2] = new Cube(cubes[8, 2]);
                        cubes[8, 2] = new Cube(cubes[2, 2]);
                        cubes[2, 2] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[1, 2]);
                        cubes[1, 2] = new Cube(cubes[3, 2]);
                        cubes[3, 2] = new Cube(cubes[7, 2]);
                        cubes[7, 2] = new Cube(cubes[5, 2]);
                        cubes[5, 2] = new Cube(buffEdge);
                        cubes[4, 2] = new Cube(cubes[4, 2]);
                        break;
                    case 'R':
                        buffCorner = new Cube(cubes[2, 0]);
                        cubes[2, 0] = new Cube(cubes[2, 2]);
                        cubes[2, 2] = new Cube(cubes[8, 2]);
                        cubes[8, 2] = new Cube(cubes[8, 0]);
                        cubes[8, 0] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[5, 0]);
                        cubes[5, 0] = new Cube(cubes[2, 1]);
                        cubes[2, 1] = new Cube(cubes[5, 2]);
                        cubes[5, 2] = new Cube(cubes[8, 1]);
                        cubes[8, 1] = new Cube(buffEdge);
                        cubes[5, 1] = new Cube(cubes[5, 1]);
                        break;
                    case 'L':
                        buffCorner = new Cube(cubes[0, 0]);
                        cubes[0, 0] = new Cube(cubes[6, 0]);
                        cubes[6, 0] = new Cube(cubes[6, 2]);
                        cubes[6, 2] = new Cube(cubes[0, 2]);
                        cubes[0, 2] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[3, 0]);
                        cubes[3, 0] = new Cube(cubes[6, 1]);
                        cubes[6, 1] = new Cube(cubes[3, 2]);
                        cubes[3, 2] = new Cube(cubes[0, 1]);
                        cubes[0, 1] = new Cube(buffEdge);
                        cubes[3, 1] = new Cube(cubes[3, 1]);
                        break;
                    case 'F':
                        buffCorner = new Cube(cubes[0, 0]);
                        cubes[0, 0] = new Cube(cubes[0, 2]);
                        cubes[0, 2] = new Cube(cubes[2, 2]);
                        cubes[2, 2] = new Cube(cubes[2, 0]);
                        cubes[2, 0] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[1, 0]);
                        cubes[1, 0] = new Cube(cubes[0, 1]);
                        cubes[0, 1] = new Cube(cubes[1, 2]);
                        cubes[1, 2] = new Cube(cubes[2, 1]);
                        cubes[2, 1] = new Cube(buffEdge);
                        cubes[1, 1] = new Cube(cubes[1, 1]);
                        break;
                    case 'B':
                        buffCorner = new Cube(cubes[6, 0]);
                        cubes[6, 0] = new Cube(cubes[8, 0]);
                        cubes[8, 0] = new Cube(cubes[8, 2]);
                        cubes[8, 2] = new Cube(cubes[6, 2]);
                        cubes[6, 2] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[7, 0]);
                        cubes[7, 0] = new Cube(cubes[8, 1]);
                        cubes[8, 1] = new Cube(cubes[7, 2]);
                        cubes[7, 2] = new Cube(cubes[6, 1]);
                        cubes[6, 1] = new Cube(buffEdge);
                        cubes[7, 1] = new Cube(cubes[7, 1]);
                        break;
                    case 'M':
                        buffCorner = new Cube(cubes[1, 0]);
                        cubes[1, 0] = new Cube(cubes[7, 0]);
                        cubes[7, 0] = new Cube(cubes[7, 2]);
                        cubes[7, 2] = new Cube(cubes[1, 2]);
                        cubes[1, 2] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[4, 0]);
                        cubes[4, 0] = new Cube(cubes[7, 1]);
                        cubes[7, 1] = new Cube(cubes[4, 2]);
                        cubes[4, 2] = new Cube(cubes[1, 1]);
                        cubes[1, 1] = new Cube(buffEdge);
                        cubes[4, 1] = new Cube(cubes[4, 1]);
                        break;
                    case 'E':
                        buffCorner = new Cube(cubes[0, 1]);
                        cubes[0, 1] = new Cube(cubes[6, 1]);
                        cubes[6, 1] = new Cube(cubes[8, 1]);
                        cubes[8, 1] = new Cube(cubes[2, 1]);
                        cubes[2, 1] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[1, 1]);
                        cubes[1, 1] = new Cube(cubes[3, 1]);
                        cubes[3, 1] = new Cube(cubes[7, 1]);
                        cubes[7, 1] = new Cube(cubes[5, 1]);
                        cubes[5, 1] = new Cube(buffEdge);
                        cubes[4, 1] = new Cube(cubes[4, 1]);
                        break;
                    case 'S':
                        buffCorner = new Cube(cubes[3, 0]);
                        cubes[3, 0] = new Cube(cubes[3, 2]);
                        cubes[3, 2] = new Cube(cubes[5, 2]);
                        cubes[5, 2] = new Cube(cubes[5, 0]);
                        cubes[5, 0] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[4, 0]);
                        cubes[4, 0] = new Cube(cubes[3, 1]);
                        cubes[3, 1] = new Cube(cubes[4, 2]);
                        cubes[4, 2] = new Cube(cubes[5, 1]);
                        cubes[5, 1] = new Cube(buffEdge);
                        cubes[4, 1] = new Cube(cubes[4, 1]);
                        break;
                    case 'x':
                        for (int i = 0; i < 3; i++)
                        {
                            buffCorner = new Cube(cubes[0, i]);
                            cubes[0, i] = new Cube(cubes[6, i]);
                            cubes[6, i] = new Cube(cubes[8, i]);
                            cubes[8, i] = new Cube(cubes[2, i]);
                            cubes[2, i] = new Cube(buffCorner);
                            buffEdge = new Cube(cubes[1, i]);
                            cubes[1, i] = new Cube(cubes[3, i]);
                            cubes[3, i] = new Cube(cubes[7, i]);
                            cubes[7, i] = new Cube(cubes[5, i]);
                            cubes[5, i] = new Cube(buffEdge);
                        }
                        break;
                    default:
                        throw new Exception("Invalid first symbol in Turn(" + input[0] + ");");
                }
            }
            else if(input.Last() == '\'') 
            {
                switch (input[0])
                {
                    case 'U':
                        buffCorner = new Cube(cubes[0, 0]);
                        cubes[0, 0] = new Cube(cubes[6, 0]);
                        cubes[6, 0] = new Cube(cubes[8, 0]);
                        cubes[8, 0] = new Cube(cubes[2, 0]);
                        cubes[2, 0] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[1, 0]);
                        cubes[1, 0] = new Cube(cubes[3, 0]);
                        cubes[3, 0] = new Cube(cubes[7, 0]);
                        cubes[7, 0] = new Cube(cubes[5, 0]);
                        cubes[5, 0] = new Cube(buffEdge);
                        cubes[4, 0] = new Cube(cubes[4, 0]);
                        break;
                    case 'D':
                        buffCorner = new Cube(cubes[0, 2]);
                        cubes[0, 2] = new Cube(cubes[2, 2]);
                        cubes[2, 2] = new Cube(cubes[8, 2]);
                        cubes[8, 2] = new Cube(cubes[6, 2]);
                        cubes[6, 2] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[1, 2]);
                        cubes[1, 2] = new Cube(cubes[5, 2]);
                        cubes[5, 2] = new Cube(cubes[7, 2]);
                        cubes[7, 2] = new Cube(cubes[3, 2]);
                        cubes[3, 2] = new Cube(buffEdge);
                        cubes[4, 2] = new Cube(cubes[4, 2]);
                        break;
                    case 'R':
                        buffCorner = new Cube(cubes[2, 0]);
                        cubes[2, 0] = new Cube(cubes[8, 0]);
                        cubes[8, 0] = new Cube(cubes[8, 2]);
                        cubes[8, 2] = new Cube(cubes[2, 2]);
                        cubes[2, 2] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[5, 0]);
                        cubes[5, 0] = new Cube(cubes[8, 1]);
                        cubes[8, 1] = new Cube(cubes[5, 2]);
                        cubes[5, 2] = new Cube(cubes[2, 1]);
                        cubes[2, 1] = new Cube(buffEdge);
                        cubes[5, 1] = new Cube(cubes[5, 1]);
                        break;
                    case 'L':
                        buffCorner = new Cube(cubes[0, 0]);
                        cubes[0, 0] = new Cube(cubes[0, 2]);
                        cubes[0, 2] = new Cube(cubes[6, 2]);
                        cubes[6, 2] = new Cube(cubes[6, 0]);
                        cubes[6, 0] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[3, 0]);
                        cubes[3, 0] = new Cube(cubes[0, 1]);
                        cubes[0, 1] = new Cube(cubes[3, 2]);
                        cubes[3, 2] = new Cube(cubes[6, 1]);
                        cubes[6, 1] = new Cube(buffEdge);
                        cubes[3, 1] = new Cube(cubes[3, 1]);
                        break;
                    case 'F':
                        buffCorner = new Cube(cubes[0, 0]);
                        cubes[0, 0] = new Cube(cubes[2, 0]);
                        cubes[2, 0] = new Cube(cubes[2, 2]);
                        cubes[2, 2] = new Cube(cubes[0, 2]);
                        cubes[0, 2] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[1, 0]);
                        cubes[1, 0] = new Cube(cubes[2, 1]);
                        cubes[2, 1] = new Cube(cubes[1, 2]);
                        cubes[1, 2] = new Cube(cubes[0, 1]);
                        cubes[0, 1] = new Cube(buffEdge);
                        cubes[1, 1] = new Cube(cubes[1, 1]);
                        break;
                    case 'B':
                        buffCorner = new Cube(cubes[6, 0]);
                        cubes[6, 0] = new Cube(cubes[6, 2]);
                        cubes[6, 2] = new Cube(cubes[8, 2]);
                        cubes[8, 2] = new Cube(cubes[8, 0]);
                        cubes[8, 0] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[7, 0]);
                        cubes[7, 0] = new Cube(cubes[6, 1]);
                        cubes[6, 1] = new Cube(cubes[7, 2]);
                        cubes[7, 2] = new Cube(cubes[8, 1]);
                        cubes[8, 1] = new Cube(buffEdge);
                        cubes[7, 1] = new Cube(cubes[7, 1]);
                        break;
                    case 'M':
                        buffCorner = new Cube(cubes[1, 0]);
                        cubes[1, 0] = new Cube(cubes[1, 2]);
                        cubes[1, 2] = new Cube(cubes[7, 2]);
                        cubes[7, 2] = new Cube(cubes[7, 0]);
                        cubes[7, 0] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[4, 0]);
                        cubes[4, 0] = new Cube(cubes[1, 1]);
                        cubes[1, 1] = new Cube(cubes[4, 2]);
                        cubes[4, 2] = new Cube(cubes[7, 1]);
                        cubes[7, 1] = new Cube(buffEdge);
                        cubes[4, 1] = new Cube(cubes[4, 1]);
                        break;
                    case 'E':
                        buffCorner = new Cube(cubes[0, 1]);
                        cubes[0, 1] = new Cube(cubes[2, 1]);
                        cubes[2, 1] = new Cube(cubes[8, 1]);
                        cubes[8, 1] = new Cube(cubes[6, 1]);
                        cubes[6, 1] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[1, 1]);
                        cubes[1, 1] = new Cube(cubes[5, 1]);
                        cubes[5, 1] = new Cube(cubes[7, 1]);
                        cubes[7, 1] = new Cube(cubes[3, 1]);
                        cubes[3, 1] = new Cube(buffEdge);
                        cubes[4, 1] = new Cube(cubes[4, 1]);
                        break;
                    case 'S':
                        buffCorner = new Cube(cubes[3, 0]);
                        cubes[3, 0] = new Cube(cubes[5, 0]);
                        cubes[5, 0] = new Cube(cubes[5, 2]);
                        cubes[5, 2] = new Cube(cubes[3, 2]);
                        cubes[3, 2] = new Cube(buffCorner);
                        buffEdge = new Cube(cubes[4, 0]);
                        cubes[4, 0] = new Cube(cubes[5, 1]);
                        cubes[5, 1] = new Cube(cubes[4, 2]);
                        cubes[4, 2] = new Cube(cubes[3, 1]);
                        cubes[3, 1] = new Cube(buffEdge);
                        cubes[4, 1] = new Cube(cubes[4, 1]);
                        break;
                    case 'x':
                        for (int i = 0; i < 3; i++)
                        {
                            buffCorner = new Cube(cubes[0, i]);
                            cubes[0, i] = new Cube(cubes[2, i]);
                            cubes[2, i] = new Cube(cubes[8, i]);
                            cubes[8, i] = new Cube(cubes[6, i]);
                            cubes[6, i] = new Cube(buffCorner);
                            buffEdge = new Cube(cubes[1, i]);
                            cubes[1, i] = new Cube(cubes[5, i]);
                            cubes[5, i] = new Cube(cubes[7, i]);
                            cubes[7, i] = new Cube(cubes[3, i]);
                            cubes[3, i] = new Cube(buffEdge);
                            cubes[4, i] = new Cube(cubes[4, i]);
                            cubes[4, i] = new Cube(cubes[4, i]);
                        }
                        break;
                    default:
                        throw new Exception("Invalid first symbol in Turn(" + input[0] + ");");
                }
            }
            else if (input.Last() == '2')
            {
                animateTurn.Prepend(input[0]);
            }            
        }

        private void buttonAlgorithm_Click(object sender, EventArgs e)
        {
            Algorithm(textBoxAlgorithm.Text);
        }

        public void Algorithm(string alg)
        {
            string tahy = "RLUDFBMESx";
            int xPlus = 0;
            for (int i = 0; i < alg.Length; i++)
            {
                if (tahy.Contains(alg[i]))
                {
                    if (alg[i] == 'x')
                    {
                        xPlus--;
                        if (i + 1 < alg.Length)
                        {
                            if (alg[i + 1] == '\'')
                            {
                                xPlus += 2;
                            }
                            if(alg[i+1] == '2')
                            {
                                xPlus += 3;
                            }
                        }
                    }
                    animateTurn.Add(alg[i]);
                    if (i + 1 < alg.Length)
                    {
                        if (alg[i + 1] == '\'')
                        {
                            
                            animateTurn.Add('\'');
                            i++;
                        }
                        else if (alg[i + 1] == '2')
                        {
                            animateTurn.Add(alg[i]);
                            i++;
                        }
                    }
                    
                }
            }
            //vrácení aktuálního otočení na kameru
            if(xPlus > 0)
            {
                for(int i = 0; i < xPlus; i++)
                {
                    animateTurn.Add('x');
                }
            }
            else
            {
                for(int i = 0; i > xPlus; i--)
                {
                    animateTurn.Add('x');
                    animateTurn.Add('\'');
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

        //Projection

        public void RenderMatrix()
        {
            float znear = 0.1f;
            float zfar = 1000;
            float fov = 90;
            float aspectRatio = pictureBox1.Height / pictureBox1.Width;
            if (pictureBox1.Height < pictureBox1.Width)
                aspectRatio = pictureBox1.Width / pictureBox1.Height;

            double fovRad = Math.Tan(fov * 0.5 / 180 * Math.PI);
            projectionMatrix[0, 0] = aspectRatio  / fovRad;
            projectionMatrix[1, 1] = fovRad;
            projectionMatrix[2, 2] = zfar / (zfar - znear);
            projectionMatrix[3, 2] = (-zfar * znear) / (zfar - znear);
            projectionMatrix[2, 3] = 1;


            // { aspectRatio / tan(fov/2)           0                     0             0
            // {                0             1/tan(fov/2)                0                  0
            // {                0                   0              zfar/(zfar-znear)        (-zfar * znear) / (zfar - znear)
            // {                0                   0                     1                      0
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
                else
                {
                    solve += historieTahu[i] + "\'";
                }
                historieTahu = historieTahu.Remove(i);
            }
            historieTahu = " ";
            Algorithm(solve);
            solving = true;
        }

        private void scrambleButton_Click(object sender, EventArgs e)
        {
            string moves = "RLUDFB2'";
            Random rng = new Random();
            string scramble = moves[rng.Next(0, 6)].ToString();
            string rawScramble = scramble;
            for (int i = 1; i < 20; i++)
            {
                string t = MoveRandom(rng);
                while (t[0] == rawScramble[rawScramble.Length - 1])
                {
                    t = MoveRandom(rng);
                }
                scramble += t;
                rawScramble += t[0];
            }
            Algorithm(scramble);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ZRotationMatrix[0, 0] = Math.Cos(rotX);
            ZRotationMatrix[0, 2] = -Math.Sin(rotX);
            ZRotationMatrix[1, 1] = 1;
            ZRotationMatrix[2, 0] = Math.Sin(rotX);
            ZRotationMatrix[2, 2] = Math.Cos(rotX);
            ZRotationMatrix[3, 3] = 1;

            XRotationMatrix[0, 0] = 1;
            XRotationMatrix[1, 1] = Math.Cos(rotZ * 0.5);
            XRotationMatrix[1, 2] = Math.Sin(rotZ * 0.5);
            XRotationMatrix[2, 1] = -Math.Sin(rotZ * 0.5);
            XRotationMatrix[2, 2] = Math.Cos(rotZ * 0.5);
            XRotationMatrix[3, 3] = 1;

            if (animateTurn.Count > 0)
            {
                if (solveButton.Enabled)
                    solveButton.Enabled = false;
                turnAnim += 1;
                AnimateTurn();
                if (animateTurn[0] == 'x')
                {
                    turnAnim = turnStep;
                }
            }

            if (turnAnim >= turnStep)
            {
                if (turnStepChangeRequest != turnStep)
                {
                    turnStep = turnStepChangeRequest;
                }
                

                string t = animateTurn[0].ToString();
                animateTurn.RemoveAt(0);
                if (animateTurn.Count > 0)
                {
                    if(animateTurn[0] == '\'')
                    {
                        t += '\'';
                        animateTurn.RemoveAt(0);
                    }
                }
                Turn(t);
                turnAnim = 0;

                if (solving && animateTurn.Count == 0)
                {
                    historieTahu = " ";
                    solving = false;
                    label2.Text = "Historie: ";
                }
                if (animateTurn.Count == 0)
                {
                    solveButton.Enabled = true;
                }
                
            }
            
            pictureBox1.Refresh();

        }

        public void AnimateTurn()
        {
            int prime = 1;
            if (animateTurn.Count > 1 && animateTurn[1] == '\'')
                prime = -1;
            switch (animateTurn[0])
            {
                case 'U':
                    for (int i = 0; i < 9; i++)
                    {
                        foreach (Square s in cubes[i, 0].squares)
                        {
                            foreach (Vector3 v in s.vectors)
                            {
                                v.animState.Y += prime;
                                v.X = Math.Sin(-v.animState.Y * Math.PI / 2 / turnStep + v.displacement.Y) * v.lengthFrom0.Y;
                                v.Z = Math.Cos(-v.animState.Y * Math.PI / 2 / turnStep + v.displacement.Y) * v.lengthFrom0.Y;
                            }
                        }
                    }
                    break;
                case 'D':
                    for (int i = 0; i < 9; i++)
                    {
                        foreach (Square s in cubes[i, 2].squares)
                        {
                            foreach (Vector3 v in s.vectors)
                            {
                                v.animState.Y+=prime;
                                v.X = Math.Sin(v.animState.Y * Math.PI / 2 / turnStep + v.displacement.Y) * v.lengthFrom0.Y;
                                v.Z = Math.Cos(v.animState.Y * Math.PI / 2 / turnStep + v.displacement.Y) * v.lengthFrom0.Y;
                            }
                        }
                    }
                    break;
                case 'R':
                    for (int i = 1; i < 4; i++)
                    {
                        for(int j = 0; j < 3; j++)
                        {
                            foreach (Square s in cubes[i*3-1, j].squares)
                            {
                                foreach (Vector3 v in s.vectors)
                                {
                                    switch (cubes[5, 1].rotateAxis)
                                    {
                                        case 0:
                                            v.animState.Z += prime;
                                            v.X = Math.Sin(v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                            v.Y = Math.Cos(v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                            break;
                                        case 1:
                                            v.animState.X += prime;
                                            v.Z = Math.Sin(-v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                            v.Y = Math.Cos(-v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                            break;
                                        case 2:
                                            v.animState.Z += prime;
                                            v.X = Math.Sin(-v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                            v.Y = Math.Cos(-v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                            break;
                                        case 3:
                                            v.animState.X += prime;
                                            v.Z = Math.Sin(v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                            v.Y = Math.Cos(v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                            break;
                                            
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 'L':
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            foreach (Square s in cubes[i * 3, j].squares)
                            {
                                foreach (Vector3 v in s.vectors)
                                {
                                    switch (cubes[3, 1].rotateAxis)
                                    {
                                        case 0:
                                            v.animState.Z += prime;
                                            v.X = Math.Sin(v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                            v.Y = Math.Cos(v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                            break;
                                        case 1:
                                            v.animState.X += prime;
                                            v.Z = Math.Sin(-v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                            v.Y = Math.Cos(-v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                            break;
                                        case 2:
                                            v.animState.Z += prime;
                                            v.X = Math.Sin(-v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                            v.Y = Math.Cos(-v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                            break;
                                        case 3:
                                            v.animState.X += prime;
                                            v.Z = Math.Sin(v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                            v.Y = Math.Cos(v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                            break;
                                            
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 'F':
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            foreach (Square s in cubes[i, j].squares)
                            {
                                foreach (Vector3 v in s.vectors)
                                {
                                    switch (cubes[1, 1].rotateAxis%4)
                                    {
                                        case 0:
                                            v.animState.Z += prime;
                                            v.X = Math.Sin(v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                            v.Y = Math.Cos(v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                            break;
                                        case 1:
                                            v.animState.X += prime;
                                            v.Z = Math.Sin(-v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                            v.Y = Math.Cos(-v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                            break;
                                        case 2:
                                            v.animState.Z += prime;
                                            v.X = Math.Sin(-v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                            v.Y = Math.Cos(-v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                            break;
                                        case 3:
                                            v.animState.X += prime;
                                            v.Z = Math.Sin(v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                            v.Y = Math.Cos(v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                            break;
                                    }
                                   
                                }
                            }
                        }
                    }
                    break;
                case 'B':
                    for (int i = 6; i < 9; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            foreach (Square s in cubes[i, j].squares)
                            {
                                foreach (Vector3 v in s.vectors)
                                {
                                    switch (cubes[7, 1].rotateAxis)
                                    {
                                        case 0:
                                            v.animState.Z += prime;
                                            v.X = Math.Sin(v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                            v.Y = Math.Cos(v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                            break;
                                        case 1:
                                            v.animState.X += prime;
                                            v.Z = Math.Sin(-v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                            v.Y = Math.Cos(-v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                            break;
                                        case 2:
                                            v.animState.Z += prime;
                                            v.X = Math.Sin(-v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                            v.Y = Math.Cos(-v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                            break;
                                        case 3:
                                            v.animState.X += prime;
                                            v.Z = Math.Sin(v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                            v.Y = Math.Cos(v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                            break;
                                            
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 'M':
                    for (int i = 1; i < 4; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            foreach (Square s in cubes[i * 3 - 2, j].squares)
                            {
                                foreach (Vector3 v in s.vectors)
                                {
                                    v.animState.X += prime;
                                    v.Z = Math.Sin(v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                    v.Y = Math.Cos(v.animState.X * Math.PI / 2 / turnStep + v.displacement.X) * v.lengthFrom0.X;
                                }
                            }
                        }
                    }
                    break;
                case 'E':
                    for (int i = 0; i < 9; i++)
                    {
                        foreach (Square s in cubes[i, 1].squares)
                        {
                            foreach (Vector3 v in s.vectors)
                            {
                                v.animState.Y += prime;
                                v.X = Math.Sin(v.animState.Y * Math.PI / 2 / turnStep + v.displacement.Y) * v.lengthFrom0.Y;
                                v.Z = Math.Cos(v.animState.Y * Math.PI / 2 / turnStep + v.displacement.Y) * v.lengthFrom0.Y;
                            }
                        }
                    }
                    break;
                case 'S':
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            foreach (Square s in cubes[i+3, j].squares)
                            {
                                foreach (Vector3 v in s.vectors)
                                {
                                    v.animState.Z += prime;
                                    v.X = Math.Sin(v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                    v.Y = Math.Cos(v.animState.Z * Math.PI / 2 / turnStep + v.displacement.Z) * v.lengthFrom0.Z;
                                }
                            }
                        }
                    }
                    break;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //add all squares to a list and sort by Z position, draw from far to near
            List<Square> squareSort = new List<Square>();
            foreach (Cube c in cubes)
            {
                foreach(Square squ in c.squares)//.Where(w => w.color != Color.Black)
                {
                    if (!squareSort.Contains(squ))
                        squareSort.Add(ComputeVectors(squ));
                }
            }
            squareSort = squareSort.OrderByDescending(q => q.Middle().Z).ToList();
            foreach (Square s in squareSort)
            {
                DrawSquare(g, s);
            }
        }

        public Square ComputeVectors(Square s)
        {
            Square d = s.Copy(); //Výsledný polygon
            Square t = new Square(); //offset polygon
            Square rotaceZ = new Square(); //první rotace polygon
            Square rotaceX = new Square(); //druhá rotace polygon
            for (int i = 0; i < 4; i++)
            {
                rotaceZ.vectors[i] = MultiplyMatrixVector(d.vectors[i], ZRotationMatrix);
                rotaceX.vectors[i] = MultiplyMatrixVector(rotaceZ.vectors[i], XRotationMatrix);
                t.vectors[i] = rotaceX.vectors[i];
                t.vectors[i].Z += distanceFromCamera;
                d.vectors[i] = MultiplyMatrixVector(t.vectors[i], projectionMatrix);
                d.vectors[i].X = (d.vectors[i].X + 1) * 0.5 * pictureBox1.Width;
                d.vectors[i].Y = (d.vectors[i].Y + 1) * 0.5 * pictureBox1.Height;
            }
            return d;
        }

        public void DrawSquare(Graphics g, Square s)
        {            
            Brush b = GetBrush(s.color);
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

        double turningRotX = 0;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveCube)
            {
                double value = (double)(oldMouse.X - MousePosition.X) / 100;
                double vertical = (double)(oldMouse.Y - MousePosition.Y) / 100;
                rotZ -= vertical;
                if (Math.Abs(rotZ) % (Math.PI * 4) > Math.PI && Math.Abs(rotZ) % (Math.PI * 4) < Math.PI * 3)
                {
                    rotX -= value;
                    turningRotX -= value;
                }
                else
                {
                    rotZ += vertical;
                }
                oldMouse = MousePosition;
                if (turningRotX % Math.PI > Math.PI / 4)
                {
                    turningRotX = -Math.PI / 4 + 0.1;
                    animateTurn.Add('x');
                }
                else if(turningRotX % Math.PI < -Math.PI / 4)
                {
                    turningRotX = Math.PI / 4 - 0.1;
                    animateTurn.Add('x');
                    animateTurn.Add('\'');
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            moveCube = false;
        }

        private void ButtonTurn(object sender, MouseEventArgs e)
        {
            char c = (sender as Button).Text[0];
            if (e.Button == MouseButtons.Left)
            {
                animateTurn.Add(c);
            }
            else if (e.Button == MouseButtons.Right)
            {
                animateTurn.Add(c);
                animateTurn.Add('\'');
                (sender as Button).Focus();
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string alg = comboBox1.SelectedItem.ToString().Substring(2);
            textBoxAlgorithm.Text = alg;
            Algorithm(alg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new HelperForm().Show();
        }

        private void ChangeSpeed(object sender, EventArgs e)
        {
            turnStepChangeRequest = 101 - (double)numericUpDown1.Value;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            animateTurn.Clear();
            GenerateCubes();
            RenderMatrix();
            historieTahu = " ";
            label2.Text = "Historie:";
            turnAnim = 0;
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            MessageBox.Show(historieTahu, "Historie");
        }

        private void ChangeDistance(object sender, EventArgs e)
        {
            distanceFromCamera = (double)numericUpDown2.Value;
        }

        private void Solve()
        {
            //nefunkční algoritmické skládání
            string solve = Solver.FindPLL(cubes);
            if (solve == "")
            {
                return;
            }
            else if(solve.EndsWith("solved"))
            {
                label1.Text = "solved";
            }
            solving = false;
            Algorithm(solve);
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            if (Width < Height)
            {
                pictureBox1.Size = new Size((int)(Width * 0.75), (int)(Width * 0.75));
            }
            else pictureBox1.Size = new Size((int)(Height * 0.75), (int)(Height * 0.75));
            RenderMatrix();
        }

        private void buttonClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(historieTahu.Substring(1));
            
        }
    }
}
