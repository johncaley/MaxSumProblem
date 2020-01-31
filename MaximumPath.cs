///////////////////////////////////////
//                                   //
//  Assignment: Triangle.pdf(Ver 3)  //
//  Author: John Caley               //
//  Create Date: 1/3/2020            //
//                                   //
///////////////////////////////////////
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTargetExampleProgram
{
    class Program
    {
        //Display Contents of Triangle
        static void DisplayTriangle(List<List<int>> TriangleOfInts)
        {
            for (int i = 0; i < TriangleOfInts.Count; i++)
            {
                for (int j = 0; j < TriangleOfInts[i].Count; j++)
                {
                    Console.Write(TriangleOfInts[i][j] + " ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        static void Main(string[] args)
        {
            try
            {
                //Get contents of txt file
                string[] linesOfText = File.ReadAllLines(@"C:\Tmp\triangle.txt");

                //Sort array of strings into and two dimentional list of integers
                List<List<int>> TriangleOfInts = new List<List<int>>();
                for (int i = 0; i < linesOfText.Length; i++)
                {
                    string[] split = linesOfText[i].Split(' ');

                    List<int> tmpList = new List<int>();
                    for (int j = 0; j < split.Length-1; j++)
                    {
                        tmpList.Add(Convert.ToInt32(split[j]));
                    }
                    TriangleOfInts.Add(tmpList);
                }


                //DisplayTriangle(TriangleOfInts);


                //Get Largest Path
                for (int i = TriangleOfInts.Count-1; i > 0; i--)
                {
                    for (int j = 0; j < TriangleOfInts[i].Count-1; j++)
                    {
                        if (TriangleOfInts[i][j] > TriangleOfInts[i][j + 1])
                        {
                            TriangleOfInts[i - 1][j] += TriangleOfInts[i][j];
                        }
                        else
                        {
                            TriangleOfInts[i - 1][j] += TriangleOfInts[i][j + 1];
                        }
                    }
                    //DisplayTriangle(TriangleOfInts);
                }

                Console.WriteLine("Maximum Total: {0}", TriangleOfInts[0][0]);

            }
            catch(IOException)
            {
                Console.WriteLine("Error: text file not found. Ensure file path for 'linesOfText' is correct.");
            }
            Console.ReadKey();
        }
    }
}
