using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PPL_SectionA.InventorySearchParallel
{
    public class ParallelSearch
    {
        private readonly object locker = new object();
        public InventoryItem[] GenerateBarcodes(int amount)
        {
            Random random = new Random();
            InventoryItem[] array = new InventoryItem[amount];
            for (int i = 0; i < amount; i++)
            {
                array[i] = new InventoryItem()
                {
                    Barcode = Guid.NewGuid().ToString("P"),
                    Type = random.Next(0,101)
                };
            }
            return array;
        }

        public void ParallelSearching(InventoryItem[] array, int numThreads, Dictionary<int, int> conditions) 
        { 
            
            var split = Math.Ceiling(Convert.ToDecimal(array.Length) / numThreads);
            if(array.Length % numThreads != 0)
            {
                split--;
            }
            

            List<InventoryItem[]> segments = new List<InventoryItem[]>();
            for(int i = 0; i < numThreads; i++)
            {
                int startIndex = i * Convert.ToInt32(split);
                
                InventoryItem[] ArrTemp = new InventoryItem[Convert.ToInt32(split)];
                Array.Copy(array, startIndex, ArrTemp, 0, Convert.ToInt32(split));
                segments.Add(ArrTemp);
            }
            
            var threads = new List<Thread>();
            //List<List<InventoryItem>> result = new List<List<InventoryItem>>();
            for (int i = 0; i < numThreads; i++)
            {
                var list = segments[i];
                var thread = new Thread(() => FindBarcodes(conditions, list));
                thread.Start();
                threads.Add(thread);
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }


        }

        public List<List<InventoryItem>> FindBarcodes(Dictionary<int,int> conditions, InventoryItem[] array) 
        {
            lock (locker)
            {
                var temp = new List<InventoryItem>();
                var result = new List<List<InventoryItem>>();
                for (int i = 0; i < conditions.Count; i++)
                {
                    foreach (var item in array)
                    {
                        if (temp.Count == conditions.ElementAt(i).Value)
                        {
                            result.Add(temp);
                            temp = new List<InventoryItem>();
                            break;
                        }
                        if (item.Type == conditions.ElementAt(i).Key && !temp.Contains(item))
                        {
                            temp.Add(item);
                        }

                    }
                }
                return result;
            }
        }
    }
}
