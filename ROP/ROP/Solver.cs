using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROP
{
    public static class Solver
    {
        public static int[] sortedPosition = { 0, 1, 2, 5, 4, 8, 7, 6, 3 };
        public static string[] PLL = {"R'FR'B2RF'R'B2R2",//Aa
            "R2B2RFR'B2RF'R",//Ab
            "R2UR2UDR2U'R2UR2U'D'R2UR2U2R2",//E
            "R'URU'R2F'U'FURFR'F'R2",//F
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
            "M2UM2UM'U2M2U2M'U2" //Z
        };

        public static void Solve(Cube[,] c)
        {

        }
        public static string FindPLL(Cube[,] c)
        {
            string output = "";
            string input;
            bool found = false;

            for(int i = 0; i < 4 && !found; i++)
            {
                input = "";
                for (int j = 0; j < 9; j++)
                {
                    if (j == 4) continue;
                    int num = (c[j, 0].cubeIndex % 9 + i * 2) % 9;
                    input += num > 4 ? num+1%9 : num;
                }
                System.Windows.Forms.MessageBox.Show(input);
                switch (input)
                {
                    case "01635872":
                        output += PLL[0];
                        found = true;
                        break;
                    case "01835276":
                        output += PLL[1];
                        found = true;
                        break;
                    case "21035876":
                        output += PLL[2];
                        found = true;
                        break;
                    case "07835612":
                        output = PLL[3];
                        found = true;
                        break;
                    case "01258763":
                        output = "solved";
                        found = true;
                        break;
                }
                if (!found)
                    output += "U'";
            }
            return output;
        }
    }
}
