using CS_Interfaces;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// Class Instance 
ClsMath m1 = new ClsMath();
Console.WriteLine($"Add = {m1.Add(3,4)}");
Console.WriteLine($"Sub = {m1.Subtract(3, 4)}");
Console.WriteLine($"Mul = {m1.Multiply(3, 4)}");
Console.WriteLine($"Div = {m1.Divide(8, 4)}");
Console.WriteLine($"Power = {m1.Power(3,4)}");
Console.WriteLine(  );
// INterface Reference containing the ClsMath instace
IMath m2 = new ClsMath();
Console.WriteLine($"Add = {m2.Add(3, 4)}");
Console.WriteLine($"Sub = {m2.Subtract(3, 4)}");
Console.WriteLine($"Mul = {m2.Multiply(3, 4)}");
Console.WriteLine($"Div = {m2.Divide(8, 4)}");

Console.WriteLine(  );
IMath m3 = new ClsNewMath();
 
Console.WriteLine($"Add = {m3.Add(3, 4)}");
Console.WriteLine($"Sub = {m3.Subtract(3, 4)}");
Console.WriteLine($"Mul = {m3.Multiply(3, 4)}");
Console.WriteLine($"Div = {m3.Divide(8, 4)}");


ClsNewMath m4 = new ClsNewMath();
// casting the m4 to IMath
Console.WriteLine($"Add = {((IMath)m4).Add(3, 4)}");
Console.WriteLine($"Sub = {((IMath)m4).Subtract(3, 4)}");
Console.WriteLine($"Mul = {((IMath)m4).Multiply(3, 4)}");
Console.WriteLine($"Div = {((IMath)m4).Divide(8, 4)}");

Console.WriteLine(  );
INewMath m5 = new ClsNewMath();
Console.WriteLine($"Add = {m5.Add(3, 4)}");
Console.WriteLine($"Sub = {m5.Subtract(3, 4)}");
Console.WriteLine($"Mul = {m5.Multiply(3, 4)}");
Console.WriteLine($"Div = {m5.Divide(8, 4)}");


Console.ReadLine();
