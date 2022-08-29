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


//BinarySearch.Run();

//TrapWater.Run();

//SumOf2Nearest.Run();

//NearestGreatest.Run();

//FizzBuzz.Run();

//FindCerebrity.Run();

var target = new ConsoleApp.Algorithms.Lists.LinkedNode<int>() { Value = 3 };
ConsoleApp.Algorithms.Lists.LinkedList<int> list = new ConsoleApp.Algorithms.Lists.LinkedList<int>();
list.Add(new ConsoleApp.Algorithms.Lists.LinkedNode<int>() { Value = 1 });
list.Add(new ConsoleApp.Algorithms.Lists.LinkedNode<int>() { Value = 2 });
list.Add(target);
list.Add(new ConsoleApp.Algorithms.Lists.LinkedNode<int>() { Value = 4 }); 
list.Add(new ConsoleApp.Algorithms.Lists.LinkedNode<int>() { Value = 5 });

Console.WriteLine(list.Contains(target));
foreach (var l in list)
    Console.WriteLine(l.Value);


FindMaxLetter.Run();


GetMaxBranchSum.Run();


LongestIncreasingSubsequence.Run();

Console.Read();