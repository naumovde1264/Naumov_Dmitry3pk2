using System;
using System.Collections;
using System.Diagnostics;

namespace pz_2
{
    class Program
    {
        public class Graph
        {
            public int Size { get; set; }
            public bool[,] Adjacency { get; set; }
            public bool[] Vector { get; set; }

            public Graph(int size, bool[,] g)
            {
                Adjacency = new bool[size, size]; 
                Adjacency = g;
                Vector = new bool[size];
                for (int i = 0; i < size; i++)
                    Vector[i] = false; 
                Size = size;
            }
            public void Depth(int i)
            {
                Vector[i] = true;
                Console.Write(" {0}" + ' ', i);
                for (int k = 0; k < Size; k++)
                    if (Adjacency[i, k] && !(Vector[k]))
                    { 
                        Depth(k);
                    }
            }
            static void Main(string[] args)
            {
                bool[,] a = new bool[5, 5]
                {
                    {true, true, false, false,false},
                    {true, false, true, true,false},
                    {false, false, true, false,true},
                    {true,true, true, true,true},
                    {false,false,false,false,false}
                };

                Graph graph = new Graph(5, a);
                graph.Depth(3);
                bool vertices = true; 
                for (int i = 0; i < graph.Size; i++)
                {
                    if (!graph.Vector[i])
                    {
                        vertices = false;
                        break;
                    }
                }
                if (vertices)
                {
                    Console.WriteLine("\n связный граф");
                }
                else
                {
                    Console.WriteLine("\n несвязный граф");
                }
            }
        }
    }
}
