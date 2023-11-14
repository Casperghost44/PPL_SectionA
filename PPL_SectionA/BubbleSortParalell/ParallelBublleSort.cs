using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPL_SectionA.BubbleSortParalell
{
    public class ParallelBublleSort
    {
        public int[] GenerateRandomArray(int length)
        {
            Random random = new Random();
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(1000000); // Random values between 0 and 999999
            }
            return array;
        }
        public void ParallelSorting(List<int> array, int NumOfThreads)
        {
            var max = array.Max();
            var min = array.Min();
            var mid = max / NumOfThreads;
            List<int>[] segments = new List<int>[NumOfThreads];
            var TempMin = min;
            for( int i = 0;  i < NumOfThreads - 1; i++ )
            {
                segments[i] = new List<int>();
                for(int j = 0; j < array.Count;  j++ )
                {
                    if (array[j] <= mid * (i + 1) && array[j] >= TempMin)
                    {
                        if (array[j] == TempMin && i != 0)
                        {
                            continue;
                        }
                        segments[i].Add(array[j]);
                    }
                    
                    
                }
                TempMin = mid * (i + 1);
            }

            segments[NumOfThreads - 1] = new List<int>();
            for (int j = 0; j < array.Count; j++)
            {
                if (array[j] <= max && array[j] > TempMin)
                {
                    segments[NumOfThreads - 1].Add(array[j]);
                }
            }

            var threads = new List<Thread>();
            for (int i = 0; i < NumOfThreads; i++)
            {
                var segment = segments[i];
                var thread = new Thread(() => BubbleSort(segment));
                thread.Start();
                threads.Add(thread);
            }


            foreach (var thread in threads)
            {
                thread.Join();
            }

            var result = new List<int>();
            foreach(var segment in segments)
            {
                foreach(var item in segment)
                {
                    result.Add(item);
                }
            }

        }

        public void BubbleSort(List<int> array)
        {
            int temp = 0;

            for (var j = 0; j < array.Count - 1; j++)
            {
                for (var i = 0; i < array.Count - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                    }
                }
            }
        }
    }
    
}
