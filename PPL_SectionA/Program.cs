using PPL_SectionA.BubbleSortParalell;
using PPL_SectionA.InventorySearchParallel;
using System.Diagnostics;
using System.Threading;
using System.Xml.Linq;

var prog = new ParallelBublleSort();
var array = prog.GenerateRandomArray(100000);
int[] numThreadsToTest = { 2, 3, 4, 6 };
var watch = Stopwatch.StartNew();
//foreach (var thread in numThreadsToTest)
//{
//    watch.Reset();
//    watch.Start();
//    prog.ParallelSorting(array.ToList(), thread);
//    watch.Stop();
//    Console.WriteLine($"The Execution time of the program is {watch.ElapsedMilliseconds}ms for {thread} number of threads (Bubble Sort)");
//}

var program = new ParallelSearch();
var list1 = program.GenerateBarcodes(100000);
//var threads = new List<Thread>();
//var res = new List<InventoryItem>();
//var buffer = new List<List<InventoryItem>>();
//var watch = Stopwatch.StartNew();
//watch.Reset();
//watch.Start();

//Thread thread = new Thread(() => program.FindBarcodes(30, 1, list, res));
//thread.Start();
//threads.Add(thread);
//Thread thread2 = new Thread(() => program.FindBarcodes(15, 7, list, res));
//thread2.Start();
//threads.Add(thread2);

//foreach (var thrd in threads)
//{
//    thrd.Join();
//}
//watch.Stop();
//Console.WriteLine("Result with threads");
//Console.WriteLine($"The Execution time of the program is {watch.ElapsedMilliseconds}ms");
//foreach(var item in res)
//{
//    Console.WriteLine($"{res.Count} {item}");
//}


//Console.WriteLine();
//Console.WriteLine("Result without threads");
//var res1 = new List<InventoryItem>();
//watch.Reset();
//watch.Start();
//program.FindBarcodes(30, 1, list, res1);
//program.FindBarcodes(15, 7, list, res1);
//watch.Stop();
//Console.WriteLine($"The Execution time of the program is {watch.ElapsedMilliseconds}ms");
//foreach (var item in res1)
//{
//    Console.WriteLine($"{res1.Count} {item}");
//}

//int[] arr = new int[] {1,2,3,4,5,6,7,8,9,10};
//int[] res = new int[10];
//Array.Copy(arr, 4, res, 0, 4);
//foreach(var i in res)
//{
//    Console.WriteLine(i);
//}


Dictionary<int, int> val = new Dictionary<int, int>() { { 1, 30 }, { 7, 15 }, { 10, 8 } };
watch = Stopwatch.StartNew();
foreach (var thread in numThreadsToTest)
{
    watch.Reset();
    watch.Start();
    program.ParallelSearching(list1, thread, val);
    watch.Stop();
    Console.WriteLine($"The Execution time of the program is {watch.ElapsedMilliseconds}ms for {thread} number of threads (Inventory searching)");
}

