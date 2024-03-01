using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROP
{
    public static class Solver
    {
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
            string input = "";
            bool found = false;
            for(int i = 0; i < 9; i++)
            {
                input += c[i, 0].cubeIndex%9;
            }

            for(int i = 0; i < 4 && !found; i++)
            {
                switch(input)
                {
                    case "016345872":
                        output = PLL[0];
                        break;
                    case "018345276":
                        output = PLL[1];
                        break;
                    case "210345876":
                        output = PLL[2];
                        break;
                    case "078345612":
                        output = PLL[3];
                        break;
                    case "012345678":
                        output = "solved";
                        break;
                }
            }
            return output;
        }
    }
}
