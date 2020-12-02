using System;
using System.Windows.Forms;

namespace Tic_tac_toe
{
    static class ArrayHelper
    {
        public static void PutValuesInMap(MapValues[,] map, string buttonName, MapValues value)
        {
            map[Int32.Parse(buttonName[1].ToString()), Int32.Parse(buttonName[2].ToString())] = value;
        }
    }
}
