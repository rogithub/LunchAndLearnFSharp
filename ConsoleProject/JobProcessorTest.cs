using System;
using System.Collections.Generic;
using Microsoft.FSharp.Core;
using myFsharpProject;

namespace ConsoleProject
{
	public class JobProcessorTest
	{
		/// Strings in C# are inmutable!!!
		/// If we re-write function to encrypt/decrypt in Portal
		/// in a F# func that takes as input string (xml) and
		/// returns string (encrypted xml) we could make it faster! 
		public static void Test()
		{
			var service = new Product.Services();

			// Create
			BusinessObjects.Component[] components = {
				new BusinessObjects.Component("Agua", 10.9),
				new BusinessObjects.Component("Cromo", 10.9),
				new BusinessObjects.Component("Manganeso", 10.9)
			};
			BusinessObjects.CreateNew info = new BusinessObjects.CreateNew(100, "Tumbirichato de amonio", components);
			BusinessObjects.SharedProduct product = service.Create(info);

			Console.WriteLine("{0}", product);

			// Merge
			var prodArray = service.GetMany(new int[] { 1, 2, 3, 4, 5, 6 });

			BusinessObjects.CreateFrom fromInfo = new BusinessObjects.CreateFrom(101, "Kit Product", components, prodArray);
			BusinessObjects.SharedProduct product2 = service.Create(fromInfo);

			Console.WriteLine("{0}", product2);

			//var predicate = FuncConvert.ToFSharpFunc((BusinessObjects.Component c) => c.Name == "Poison" && c.Percent > 10);
			//BusinessObjects.QueryInfo queryInfo = new BusinessObjects.QueryInfo(predicate, product2.Formula);
			//bool result = service.Query(queryInfo);

			//Console.WriteLine("product2 has Poison > 10% = {0}", result);
		}
	}
}
