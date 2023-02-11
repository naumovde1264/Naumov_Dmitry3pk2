using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace pz_1
{
    internal class Timing 
    {
        TimeSpan duration;
        TimeSpan[] threads;
        public Timing()
        {
            duration = new TimeSpan(0);
            threads = new TimeSpan[Process.GetCurrentProcess().Threads.Count];
        }
        public void StartTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            for (int i = 0; i < threads.Length; i++)
                threads[i] = Process.GetCurrentProcess().Threads[i].UserProcessorTime;
        }
        public void StopTime()
        {
            TimeSpan tmp;
            for (int i = 0; i < threads.Length; i++)
            {
                tmp = Process.GetCurrentProcess().Threads[i].UserProcessorTime.Subtract(threads[i]);
                if (tmp > TimeSpan.Zero)
                    duration = tmp;
            }
        }
        public TimeSpan Result()
        {
            return duration;
        }
    }
    class Program
    {
        public static Random rnd = new Random(); 
        public static void FillIntArray(int[] a) 
        {
            for (int i = 0; i < a.Length; i++) a[i] = rnd.Next(0, 1000000); 
        }
        static int SearchBinaryList(List<int> a, int x) 
        {
            int middle, left = 0, right = a.Count - 1;
            do
            {
                middle = (left + right) / 2;
                if (x > a[middle])
                    left = middle + 1;
                else
                    right = middle - 1;
            }
            while (a[middle] != x && left <= right);
            if (a[middle] == x)
                return middle;
            else
                return -1;
        }
        static int SearchBinaryArray(int[] a, int x) 
        {
            int middle, left = 0, right = a.Length - 1;
            do
            {
                middle = (left + right) / 2;
                if (x > a[middle])
                    left = middle + 1;
                else
                    right = middle - 1;
            }
            while (a[middle] != x && left <= right);
            if (a[middle] == x)
                return middle;
            else
                return -1;
        }
        static void Main(string[] args)
        {

           

            //Задание №2
            

            Timing ops = new Timing();
            Stopwatch irs = new Stopwatch();
            int[] b = new int[500000];
            FillIntArray(b); 
            Console.Write("Простой поиск по массиву ");
            int x = Int32.Parse(Console.ReadLine());
            int res0 = -1; 
            int i2 = 0;
            irs.Start(); 
            ops.StartTime();
            while (i2 < b.Length && b[i2] != x) 
            {
                i2++;
                if (i2 < b.Length) res0 = i2;
            }
            irs.Stop(); 
            ops.StopTime();
            Console.WriteLine("Простой поиск по массиву, результат в тиках: {0}, {1} (Stopwatch, Timing)", irs.ElapsedTicks, ops.Result()); 

            Timing cloud = new Timing();
            int[] s = new int[7500];
            FillIntArray(s);
            Console.Write("Бинарный поиск по массиву, введите целое число: ");
            int e = Int32.Parse(Console.ReadLine()); 
            Stopwatch ioi = new Stopwatch();
            ioi.Start(); 
            cloud.StartTime();
            SearchBinaryArray(s, e);
            ioi.Stop(); 
            cloud.StopTime();
            Console.WriteLine("Бинарный поиск по массиву, результат найден за {0}, {1} (в тиках, Stopwatch, Timing)", ioi.ElapsedTicks, cloud.Result());
           
            // Задание №3
            

            Timing sit = new Timing();
            List<int> listint = new List<int>(); 
            for (int i = 0; i < 7500; i++) 
            {
                listint.Add(rnd.Next());
            }
            Console.Write("Простой поиск по LIST, введите целое число: ");
            int o = Int32.Parse(Console.ReadLine()); 
            int rt = -1; 
            int t = 0; 
            Stopwatch yiu = new Stopwatch();
            yiu.Start();
            sit.StartTime();
            while (t < listint.Count && listint[t] != o) 
            {
                t++;
                if (t < listint.Count) rt = t;
            }
            yiu.Stop();
            sit.StopTime();
            Console.WriteLine("Простой поиск по списку, результат найден за {0}, {1} (в тиках, Stopwatch, Timing)", yiu.ElapsedTicks, sit.Result()); 

            

            

            Timing help = new Timing();
            List<int> intlist = new List<int>(); 
            for (int i = 0; i < 7500; i++) 
            {
                intlist.Add(rnd.Next());
            }
            Console.WriteLine("Бинарный поиск по LIST, введите целое число: ");
            int pik = int.Parse(Console.ReadLine()); 
            Stopwatch why = new Stopwatch();
            why.Start();
            help.StartTime();
            SearchBinaryList(intlist, pik);
            why.Stop();
            help.StopTime();
            Console.WriteLine("Бинарный поиск по списку, результат найден за {0}, {1} (в тиках, Stopwatch, Timing)", why.ElapsedTicks, help.Result()); 

           

            //Задание №4
            

            Timing timing = new Timing();
            Hashtable hash = new Hashtable(); 
            for (int i = 0; i < 7500; i++) 
            {
                hash.Add(rnd.Next(), rnd.Next()); 
            }
            Console.Write("Хэш таблицы. ");
            int p = Int32.Parse(Console.ReadLine()); 
            int res000 = -1;
            int i4 = 0;
            Stopwatch jeckis = new Stopwatch();
            jeckis.Start(); 
            timing.StartTime();
            while (i4 < hash.Count && hash.Contains(i4)) 
            {
                i4++;
                if (i4 < listint.Count) res000 = i4;
            }
            jeckis.Stop(); 
            timing.StopTime();
            Console.WriteLine("Простой поиск по хэштаблице, результат найден за {0}, {1} (в тиках, Stopwatch, Timing)", jeckis.ElapsedTicks, timing.Result()); 

            
        }
    }
}

