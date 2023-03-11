// See https://aka.ms/new-console-template for more information
using CS_EF_SP.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.Json;

Console.WriteLine("USing EF 6 + SPs");

eShoppingCodiContext ctx = new eShoppingCodiContext();

var empsResult = ctx.Employees.FromSqlRaw<Employee>("sp_getAllEmployees");

foreach (var employee in empsResult)
{
    Console.WriteLine($"EmpNo: {employee.EmpNo}, EmpName: {employee.EmpName}");
}

SqlParameter pDeptNo = new SqlParameter("@DeptNo", 2222);
SqlParameter pDeptName = new SqlParameter("@DeptName", "Dept-2222");
SqlParameter pLocation = new SqlParameter("@Location", "Pune");
SqlParameter pCapacity = new SqlParameter("@Capacity", 22);

var deptResult = ctx.Departments.FromSqlRaw<Department>("sp_InsertDept @DeptNo @DeptName @Location @Capacity", pDeptNo,pDeptName,pLocation,pCapacity);




Console.ReadLine(); 



