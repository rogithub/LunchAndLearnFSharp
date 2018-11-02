using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleProject
{
	public class RaceConditionTest
	{

		//http://www.gotw.ca/publications/concurrency-ddj.htm
		public static void Test()
		{
			List<int> list = new List<int>();
			int count = 1000;

			Parallel.For(0, count, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, (i) =>
			{
				list.Add(i);
			});

			Console.WriteLine($"The total count should be {count}. The list count is {list.Count}.");
		}


		public static void Test1()
		{
			List<int> list = new List<int>();
			int count = 8;

			Parallel.For(0, count, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, (i) =>
			{
				Thread.Sleep(1000);
				list.Add(i);
			});

			Console.WriteLine($"The total count should be {count}. The list count is {list.Count}.");
		}
	}
}
