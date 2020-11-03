using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Tic_tac_toe
{
    static class ArrayHelper
    {
        public static void PutValuesInMap(Values[,] map, Button button, Values value)
        {
            map[Int32.Parse(button.Name[1].ToString()), Int32.Parse(button.Name[2].ToString())] = value;
        }
    }
}
