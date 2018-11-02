using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleProject
{
	public class RaceConditionTest
	{

		//http://www.gotw.ca/publications/concurrency-ddj.htm
		public static void Test()
		{
			Stopwatch watch = new Stopwatch();
			watch.Start();
			List<int> list = new List<int>();
			int count = Environment.ProcessorCount;

			for(int i = 0; i < Environment.ProcessorCount; i++)
			{
				Thread.Sleep(1000);
				list.Add(i);
			};

			Console.WriteLine($"The total count should be {count}. The list count is {list.Count}. It took {watch.ElapsedMilliseconds} ms.");
		}


		public static void Test1()
		{
			Stopwatch watch = new Stopwatch();
			watch.Start();
			List<int> list = new List<int>();
			int count = 8;

			Parallel.For(0, count, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, (i) =>
			{
				Thread.Sleep(1000);
				list.Add(i);
			});

			Console.WriteLine($"The total count should be {count}. The list count is {list.Count}. It took {watch.ElapsedMilliseconds} ms.");
		}
	}
}
