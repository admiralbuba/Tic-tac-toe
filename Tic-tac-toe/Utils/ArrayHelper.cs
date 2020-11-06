using System;
using System.Windows.Forms;

namespace Tic_tac_toe
{
    static class ArrayHelper
    {
        public static void PutValuesInMap(MapValues[,] map, Button button, MapValues value)
        {
            map[Int32.Parse(button.Name[1].ToString()), Int32.Parse(button.Name[2].ToString())] = value;
        }
    }
}
