// See https://aka.ms/new-console-template for more information
using CS_Interface_Generic_Constraints.Logic;
using CS_Interface_Generic_Constraints.Models;

Console.WriteLine("INterface with Costratints");

IDataAccess<Employee,int> empDs = new EmployeeDataAccess();

var emps = empDs.GetAll();
foreach (Employee emp in emps)
{
    Console.WriteLine($"EmpNo : {emp.EmpNo}, EmpName: {emp.EmpName}, DeptName: {emp.DeptName}");
}

var e = empDs.Get(101);
Console.WriteLine($"EmpNo : {e.EmpNo}, EmpName: {e.EmpName}, DeptName: {e.DeptName}");

Console.WriteLine(  );

empDs.AddRecord(new Employee() {EmpNo=103,EmpName="Ethan Hunt",DeptName="IMF" });

 emps = empDs.GetAll();
foreach (Employee emp in emps)
{
    Console.WriteLine($"EmpNo : {emp.EmpNo}, EmpName: {emp.EmpName}, DeptName: {emp.DeptName}");
}




Console.WriteLine();
IDataAccess<Person,string> perDs = new PersonDataAccess();



Console.ReadLine();
