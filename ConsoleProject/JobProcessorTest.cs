﻿using System;
using System.Collections.Generic;
using Microsoft.FSharp.Core;
using myFsharpProject;

namespace ConsoleProject
{
	public class JobProcessorTest
	{
		public static void Test()
		{
			var jobProcessor = new Services.JobProcessor();

			// Create
			Product.Component[] components = {
				new Product.Component("Agua", 10.9),
				new Product.Component("Cromo", 10.9),
				new Product.Component("Manganeso", 10.9)
			};
			Product.CreateNew info = new Product.CreateNew(100, "Tumbirichato de amonio", components);
			Product.SharedProduct product = jobProcessor.Create(info);

			Console.WriteLine("{0}", product);

			// Merge
			var prodArray = jobProcessor.GetMany(new int[] { 1, 2, 3, 4, 5, 6 });

			Product.CreateFrom fromInfo = new Product.CreateFrom(101, "Kit Product", components, prodArray);
			Product.SharedProduct product2 = jobProcessor.Create(fromInfo);

			Console.WriteLine("{0}", product2);

			//var predicate = FuncConvert.ToFSharpFunc((Product.Component c) => c.Name == "Poison" && c.Percent > 10);
			//Product.QueryInfo queryInfo = new Product.QueryInfo(predicate, product2.Formula);
			//bool result = jobProcessor.Query(queryInfo);

			//Console.WriteLine("product2 has Poison > 10% = {0}", result);
		}
	}
}