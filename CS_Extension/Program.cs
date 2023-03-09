// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
MyClass m = new MyClass();

Console.WriteLine($"Add = {m.Add(10,20)}");
Console.WriteLine($"Mult = {m.Mult(20,30)}");

string mystr = "The James Bond is 007";

Console.WriteLine($"Reverse of {mystr} is = {mystr.ReverseString()}");


Console.ReadLine();



public sealed class MyClass
{
    public int Add(int x, int y)
    {
      return x + y;
    }

}

/// <summary>
/// Class with an Extension Method
/// Rule 1: The class MUST be Static
/// Rule 2: The Method which is to be used as Extension MUST be static
/// Rule 3: The First Parameter of the Extension Method MUST be
/// 'this' referred reference of the class / interface for which this method is
/// used as extension method. THis will make sure that the extension method will
/// be invokes using an instance of the 'this' refereed reference of the the class / interface
/// IN our case we will be using 'MyClass' as 'this' refereed as 
/// </summary>
public static class MyClassExtension  
{
    public static int Mult(this MyClass m, int x, int y)
    { return x * y; }


    public static string ReverseString(this string str)
    {
        string result = string.Empty;
        for (int i = str.Length - 1; i >=0; i--)
        {
            result += str[i];
        }
        return result;
    }
}