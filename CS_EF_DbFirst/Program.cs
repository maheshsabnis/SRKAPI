// See https://aka.ms/new-console-template for more information
using CS_EF_DbFirst.DbAccess;
using CS_EF_DbFirst.Models;
using System.Text.Json;

Console.WriteLine("Using EF COre Db First");

IDbAccess<Department,int> dbAccess = new DepartmentDbAccess();

var depts = await dbAccess.GetAsync();

Console.WriteLine($"All Records : {JsonSerializer.Serialize(depts)}");
Console.WriteLine( );
var dept = new Department() 
{
   DeptNo = 90, DeptName="Testing-Auto",Location="Pune-East",Capacity=100
};

 // await dbAccess.CreateAsync(dept);

  await dbAccess.UpdateAsync(dept.DeptNo, dept);

// await dbAccess.DeleteAsync(dept.DeptNo);

depts = await dbAccess.GetAsync();

Console.WriteLine($"All Records : {JsonSerializer.Serialize(depts)}");



Console.ReadLine();
