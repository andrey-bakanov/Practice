// See https://aka.ms/new-console-template for more information
//using BenchmarkDotNet.Running;
//using ConsoleApp.Bloom;

//Console.WriteLine("Hello, World!");

//BloomTest.Test();

//var summary = BenchmarkRunner.Run(typeof(SimpleHash));


using ConsoleApp.Tasks;

MergeLists lists = new MergeLists();
lists.Execute();
