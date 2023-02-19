// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using ConsoleApp.Algorithms.Searching;
using ConsoleApp.Algorithms.Sorting;
using ConsoleApp.Algorithms.WalkGraph;
using ConsoleApp.Bloom;
using ConsoleApp.Problems;
using ConsoleApp.Problems.Easy;
using ConsoleApp.Problems.Medium;
using ConsoleApp.TestTasks;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Hello, World!");

//BloomTest.Test();

//var summary = BenchmarkRunner.Run(typeof(SimpleHash));


//SequenceOf1.Run();

//QuickSort.Run();

//CountLetters.Run();

//DFS.Run();


BinarySearch.Run();

//TrapWater.Run();

//SumOf2Nearest.Run();

//NearestGreatest.Run();

//FizzBuzz.Run();

//FindCerebrity.Run();

//var target = new ConsoleApp.Algorithms.Lists.LinkedNode<int>() { Value = 3 };
//ConsoleApp.Algorithms.Lists.LinkedList<int> list = new ConsoleApp.Algorithms.Lists.LinkedList<int>();
//list.Add(new ConsoleApp.Algorithms.Lists.LinkedNode<int>() { Value = 1 });
//list.Add(new ConsoleApp.Algorithms.Lists.LinkedNode<int>() { Value = 2 });
//list.Add(target);
//list.Add(new ConsoleApp.Algorithms.Lists.LinkedNode<int>() { Value = 4 }); 
//list.Add(new ConsoleApp.Algorithms.Lists.LinkedNode<int>() { Value = 5 });

//Console.WriteLine(list.Contains(target));
//foreach (var l in list)
//    Console.WriteLine(l.Value);


//FindMaxLetter.Run();


//GetMaxBranchSum.Run();


//LongestIncreasingSubsequence.Run();


//PallindromeString.Run();
//PallindromeNumber.Run();


//ReverseArray.Run();

//SumOfLeafs.Run();


//MaxArraySequence.Run();

//PallindromeLongestSubstring.Run();

//MaxSubArraySumOfSizeN.Run();


//FindFirstNotRepeatingCharacter.Run();

//FindAllDuplicatesInArray.Run();


//Fibonachi.Run();


//ArrayToBinaryTree.Run();


Test1.Run();

//Anagram.Run();

NumberOfGoodWaysToSplitString.Run();





//MergeLists lists = new MergeLists();
//MergeListsN lists = new MergeListsN();
//lists.Execute();

//SearchInSortedMatrix sorter = new SearchInSortedMatrix();
//sorter.Execute();

//MatrixIslands matrixIslands = new MatrixIslands();
//matrixIslands.Execute();

ArrayIntersection sect1 = new ArrayIntersection();
sect1.Execute();

ArrayRotation rotation1 = new ArrayRotation();
rotation1.Execute();


SquareOfSortedArray sq = new SquareOfSortedArray();
sq.Execute();

Console.Read();