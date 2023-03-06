using CS_Interface_Generic;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

IOperation<int> clsInt = new ClsIntOperation();
Console.WriteLine($"Integer Add = {clsInt.Add(10,20)}");

IOperation<string> clsStr = new ClsStringOperation();
Console.WriteLine($"String Add = {clsStr.Add("James", "Bond")}");

Console.ReadLine();
