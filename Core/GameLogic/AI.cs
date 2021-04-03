using System;
using System.Collections.Generic;
using System.Text;
using Core;
using System.Linq;

namespace Core.GameLogic
{
    public static class AI
    {
        private const int mapSize = 3;
        private static MapValues[,] map;
        public static (int, int) GetAIMove(MapValues[,] mapOrig)
        {
            map = (MapValues[,])mapOrig.Clone();

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if(map[i, j] == MapValues.Null)
                    {
                        map[i, j] = MapValues.O;
                        if (CheckForWin(MapValues.O))
                        {
                            return (i, j);
                        }
                        map[i, j] = MapValues.X;
                        if (CheckForWin(MapValues.X))
                        {
                            return (i, j);
                        }
                        map[i, j] = MapValues.Null;
                        var combination = CheckForVictoryCombination(MapValues.O);
                        if(combination.Count == mapSize)
                        {
                            foreach ((int, int) item in combination)
                            {
                                if (map[item.Item1, item.Item2] == MapValues.Null)
                                    return (item.Item1, item.Item2);
                            }
                        }
                    }
                }
            }
            return (0, 0);
        }
        private static bool CheckForWin(MapValues value)
        {
            if (map[0, 0] == value && map[0, 1] == value && map[0, 2] == value)
                return true;
            if (map[1, 0] == value && map[1, 1] == value && map[1, 2] == value)
                return true;
            if (map[2, 0] == value && map[2, 1] == value && map[2, 2] == value)
                return true;
            if (map[0, 0] == value && map[1, 1] == value && map[2, 2] == value)
                return true;
            if (map[2, 0] == value && map[1, 1] == value && map[0, 2] == value)
                return true;
            return false;
        }
        private static List<(int, int)> CheckForVictoryCombination(MapValues value)
        {
            if ((map[0, 0] == value || map[0, 0] == MapValues.Null) && (map[0, 2] == value || map[0, 2] == MapValues.Null) && (map[2, 2] == value || map[2, 2] == MapValues.Null))
                return new List<(int, int)>
                { 
                    (0, 0),
                    (0, 2),
                    (2, 2)
                };

            if ((map[0, 0] == value || map[0, 0] == MapValues.Null) && (map[0, 2] == value || map[0, 2] == MapValues.Null) && (map[2, 0] == value || map[2, 0] == MapValues.Null))
                return new List<(int, int)>
                {
                    (0, 0),
                    (0, 2),
                    (2, 0)
                };

            if ((map[0, 0] == value || map[0, 0] == MapValues.Null) && (map[2, 0] == value || map[2, 0] == MapValues.Null) && (map[2, 2] == value || map[2, 2] == MapValues.Null))
                return new List<(int, int)>
                {
                    (0, 0),
                    (2, 0),
                    (2, 2)
                };


            if ((map[0, 2] == value || map[0, 2] == MapValues.Null) && (map[2, 0] == value || map[2, 0] == MapValues.Null) && (map[2, 2] == value || map[2, 2] == MapValues.Null))
                return new List<(int, int)>
                {
                    (0, 2),
                    (2, 0),
                    (2, 2)
                };

            if ((map[0, 0] == value || map[0, 0] == MapValues.Null) && (map[1, 1] == value || map[1, 1] == MapValues.Null) && (map[0, 2] == value || map[0, 2] == MapValues.Null))
                return new List<(int, int)>
                {
                    (0, 0),
                    (1, 1),
                    (0, 2)
                };

            if ((map[0, 0] == value || map[0, 0] == MapValues.Null) && (map[1, 1] == value || map[1, 1] == MapValues.Null) && (map[2, 0] == value || map[2, 0] == MapValues.Null))
                return new List<(int, int)>
                {
                    (0, 0),
                    (1, 1),
                    (2, 0)
                };

            if ((map[2, 2] == value || map[2, 2] == MapValues.Null) && (map[1, 1] == value || map[1, 1] == MapValues.Null) && (map[2, 0] == value || map[2, 0] == MapValues.Null))
                return new List<(int, int)>
                {
                    (2, 2),
                    (1, 1),
                    (2, 0)
                };

            if ((map[2, 2] == value || map[2, 2] == MapValues.Null) && (map[1, 1] == value || map[1, 1] == MapValues.Null) && (map[0, 2] == value || map[0, 2] == MapValues.Null))
                return new List<(int, int)>
                {
                    (2, 2),
                    (1, 1),
                    (0, 2)
                };


            return new List<(int, int)>{(0, 0)};
        }
    }
}
