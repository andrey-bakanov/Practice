// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using ConsoleApp.Algorithms.Searching;
using ConsoleApp.Algorithms.Sorting;
using ConsoleApp.Algorithms.WalkGraph;
using ConsoleApp.Bloom;
using ConsoleApp.Problems;

Console.WriteLine("Hello, World!");

//BloomTest.Test();

//var summary = BenchmarkRunner.Run(typeof(SimpleHash));


//SequenceOf1.Run();

//QuickSort.Run();

//CountLetters.Run();

//DFS.Run();


BinarySearch.Run();

//TrapWater.Run();

Console.Read();