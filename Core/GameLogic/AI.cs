using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Core.GameLogic
{
    public static class AI
    {
        public static (int, int) GetAIMove(MapValues[,] map, MapValues value)
        {
            var board = (MapValues[,])map.Clone();
           // var bestScore = int.MinValue;
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map.Length; j++)
                {
                    if(map[i,j] == MapValues.Null)
                    {
                        map[i, j] = value;
                    }
                }
            }


            return (2, 2);

            
        }
    }
}
