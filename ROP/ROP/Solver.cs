using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROP
{
    public static class Solver
    {
        public static int[] sortedPosition = { 0, 1, 2, 5, 8, 7, 6, 3, 4 };

        public static void Solve(Cube[,] c)
        {

        }
        public static string FindPLL(Cube[,] c)
        {
            string output = "";
            string input;
            bool found = false;

            string offsetTurn = "";
            for(int i = 0; i < 4 && !found; i++)
            {
                input = "";
                for (int j = 0; j < 8; j++)
                {
                    int num = c[sortedPosition[(j+i*2)%8], 0].cubeIndex;
                    input += num;
                }
                //System.Windows.Forms.MessageBox.Show(input);
                switch (input)
                {
                    case "01258763":
                        output += "solved";
                        found = true;
                        break;
                    case "81052763": offsetTurn = "U"; output += "U'"; goto case "01652783";
                    case "61058723": offsetTurn = "U2"; output += "U2"; goto case "01652783";
                    case "61250783": offsetTurn = "U'"; output += "U"; goto case "01652783";
                    case "01652783":
                        output += Form1.PLL[0];
                        found = true;
                        break;
                    case "81256703": offsetTurn = "U'"; output += "U"; goto case "01856723";
                    case "21658703": offsetTurn = "U2"; output += "U2"; goto case "01856723";
                    case "21850763": offsetTurn = "U"; output += "U'"; goto case "01856723";
                    case "01856723":
                        output += Form1.PLL[1];
                        found = true;
                        break;
                    case "61852703":
                        output += Form1.PLL[2];
                        found = true;
                        break;
                    case "01236785": offsetTurn = "U'"; output += "U"; goto case "07852163";
                    case "67258213": offsetTurn = "U2"; output += "U2"; goto case "07852163";
                    case "21038765": offsetTurn = "U"; output += "U'"; goto case "07852163";
                    case "07852163":
                        output += Form1.PLL[3];
                        found = true;
                        break;
                }
                if (!found)
                    output += "U";
            }
            output += offsetTurn;
            //System.Windows.Forms.MessageBox.Show(output);
            if (output.StartsWith("UUU"))
            {
                output = new string(output.Remove(0, 3).Prepend('\'').Prepend('U').ToArray());
            }
            else if(output.StartsWith("U'U") || output.StartsWith("UU'"))
            {
                output = output.Remove(0, 3);
            }
            //System.Windows.Forms.MessageBox.Show(output);
            return output;
        }
    }
}
