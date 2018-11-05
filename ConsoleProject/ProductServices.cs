using System;
using System.Collections.Generic;
using Microsoft.FSharp.Core;
using myFsharpProject;

namespace ConsoleProject
{
	public class ProductServices
	{
		/// Strings in C# are inmutable!!!
		/// If we re-write function to encrypt/decrypt in Portal
		/// in a F# func that takes as input string (xml) and
		/// returns string (encrypted xml) we could make it faster! 
		public static void Test()
		{
			var service = new Services();

			// Create
			Component[] components = {
				new Component("Agua", 10.9),
				new Component("Cromo", 10.9),
				new Component("Manganeso", 10.9)
			};
			CreateNew info = new CreateNew(100, "Tumbirichato de amonio", components);
			SharedProduct product = service.Create(info);

			Console.WriteLine("{0}", product);

			// Merge
			var prodArray = service.GetMany(new int[] { 1, 2, 3, 4, 5, 6 });

			CreateFrom fromInfo = new CreateFrom(101, "Kit Product", components, prodArray);
			SharedProduct product2 = service.Create(fromInfo);

			Console.WriteLine("{0}", product2);

			//var predicate = FuncConvert.ToFSharpFunc((Component c) => c.Name == "Poison" && c.Percent > 10);
			//QueryInfo queryInfo = new QueryInfo(predicate, product2.Formula);
			//bool result = service.Query(queryInfo);

			//Console.WriteLine("product2 has Poison > 10% = {0}", result);
		}
	}
}
