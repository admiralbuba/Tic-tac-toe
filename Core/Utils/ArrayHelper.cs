using System;

namespace Core
{
    static class ArrayHelper
    {
        public static void PutValuesInMap(MapValues[,] map, string buttonName, MapValues value)
        {
            map[Int32.Parse(buttonName[1].ToString()), Int32.Parse(buttonName[2].ToString())] = value;
        }
        public static string GetButtonNameFromIntTuple((int,int) value)
        {
            string result = String.Empty;
            if (value.Item1 == 0)
                result = "A" + value.Item1 + value.Item2;
            if (value.Item1 == 1)
                result = "B" + value.Item1 + value.Item2;
            if (value.Item1 == 2)
                result = "C" + value.Item1 + value.Item2;
            return result;
        } 
    }
}
