using System;
using System.Collections.Generic;
using System.Linq;

namespace Mole_Test
{
    public class Program
    {
        List<int> moleCount = new List<int>();
        public void floodfill(int[,] paramArray, int a, int b)
        {
            if (a < 0 || a > 15 || b < 0 || b > 15 || paramArray[a, b] == 1)
            {
                return;
            }
            if (paramArray[a, b] == 2)
            {
                moleCount.Add(1);
            }
            paramArray[a, b] = 1;
            floodfill(paramArray, a + 1, b);
            floodfill(paramArray, a + 1, b + 1);
            floodfill(paramArray, a, b + 1);
            floodfill(paramArray, a - 1, b + 1);
            floodfill(paramArray, a - 1, b);
            floodfill(paramArray, a - 1, b - 1);
            floodfill(paramArray, a, b - 1);
            floodfill(paramArray, a + 1, b - 1);
        }
        public bool countFences(int[,] paramArray, int a, int b)
        {

            int count = 0;
            if (a + 1 > 15 || a - 1 < 0 || b + 1 > 15 || b - 1 < 0)
            {
                return true;
            }
            else
            {
                if (paramArray[a + 1, b] == 1)
                {
                    count = count + 1;
                }
                if (paramArray[a - 1, b] == 1)
                {
                    count = count + 1;
                }
                if (paramArray[a, b - 1] == 1)
                {
                    count = count + 1;
                }
                if (paramArray[a, b + 1] == 1)
                {
                    count = count + 1;

                }
                if (count > 2)
                {
                    //if(paramArray[a, b + 1]==0|| paramArray[a, b - 1] == 0 || paramArray[a+1, b] == 0 || paramArray[a-1, b ] == 0 )
                    //{
                    //    return true;
                    //}
                    //else { 
                    //return false;
                    //}
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public bool moleOnFence(int[,] paramArray, int a, int b)
        {
            if (a + 1 > 15 || a + 2 > 15 || a - 1 < 0 || a - 2 < 0 || b + 1 > 15 || b + 2 > 15 || b - 1 < 0 || b - 2 < 0)
            {
                return true;
            }
            else
            {
                if ((paramArray[a + 1, b] == 1 && paramArray[a - 1, b] == 1) || (paramArray[a, b + 1] == 1 && paramArray[a, b - 1] == 1))
                {
                    //if(paramArray[a+1,b]==0|| paramArray[a -1, b] == 0|| paramArray[a, b + 1] == 0 || paramArray[a, b - 1] == 0|| paramArray[a + 1, b] == 2 || paramArray[a - 1, b] == 2 || paramArray[a, b + 1] == 2 || paramArray[a, b - 1] == 2)
                    //{
                    //    return true;
                    //}
                    //else
                    //{
                    //    return false;

                    //}
                    return false;

                }
                else
                {
                    return true;
                }
            }
        }
        public static int Main(string[] args)
        {
            var mp = new Program();
            int[,] mainArray = new int[16, 16];
            int[,] tempArray = new int[16, 16];


            for (int i = 0; i < 16; i++)
            {
                var drawMap = Console.ReadLine();
                for (int j = 0; j < 16; j++)
                {
                    if (drawMap[j] == '|' || drawMap[j] == '+' || drawMap[j] == '-')
                    {
                        mainArray[i, j] = 1;
                        tempArray[i, j] = 1;

                    }
                    else if (drawMap[j] == ' ' || drawMap[j] == '.')
                    {
                        mainArray[i, j] = 0;
                        tempArray[i, j] = 0;

                    }
                    else
                    {
                        mainArray[i, j] = 2;
                        tempArray[i, j] = 2;

                    }
                }
            }

            //Check the mole holes is on fence or two fences are parallel or not

            //for (int x = 0; x < 16; x++)
            //{
            //    for (int y = 0; y < 16; y++)
            //    {
            //        if (tempArray[x, y] == 2)
            //        {
            //            if (mp.moleOnFence(tempArray, x, y) == false)
            //            {
            //                Console.WriteLine("Moles cant be on fence");
            //                return 0;
            //            }
            //        }

            //        if (tempArray[x, y] == 1)
            //        {
            //            if (mp.countFences(tempArray, x, y) == false)
            //            {
            //                Console.WriteLine("fences cant be parallel");
            //                mp.countFences(mainArray, x, y);
            //                return 0;
            //            }
            //        }

            //    }
            //}
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    if (mainArray[x, y] == 1)
                    {

                        if (y == 0)
                        {
                            if (mainArray[x, 1] != 1)
                            {
                                mp.floodfill(mainArray, x, 1);
                            }

                        }
                        else if (y < 15)
                        {
                            if (mainArray[x, y + 1] != 1 && mainArray[x, y - 1] != 1)
                            {
                                mp.floodfill(mainArray, x, y + 1);
                            }
                        }

                    }
                    else if (mainArray[x, y] == 2)
                    {
                        mainArray[x, y] = 0;
                    }

                }
            }
            Console.WriteLine(mp.moleCount.Count);
            return 0;

        }
    }
}
