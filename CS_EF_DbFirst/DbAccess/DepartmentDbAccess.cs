using CS_EF_DbFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_EF_DbFirst.DbAccess
{
    internal class DepartmentDbAccess : IDbAccess<Department, int>
    {
        CompanyContext ctx;

        public DepartmentDbAccess()
        {
            ctx = new CompanyContext();
        }

        async Task<Department> IDbAccess<Department, int>.CreateAsync(Department entity)
        {
            var result = await ctx.Departments.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return result.Entity;
        }

        async Task IDbAccess<Department, int>.DeleteAsync(int id)
        {
             var record = await ctx.Departments.FindAsync(id);
             if(record == null)
                return;
             ctx.Departments.Remove(record);
             await ctx.SaveChangesAsync();
        }

        async Task<IEnumerable<Department>> IDbAccess<Department, int>.GetAsync()
        {
            return await ctx.Departments.ToListAsync();
        }

        async Task<Department> IDbAccess<Department, int>.GetAsync(int id)
        {
            return await ctx.Departments.FindAsync(id); 
        }

        async Task<Department> IDbAccess<Department, int>.UpdateAsync(int id, Department entity)
        {
            var record = await ctx.Departments.FindAsync(id);
            if (record == null)
                return null;
            record.DeptName = entity.DeptName;
            record.Capacity = entity.Capacity;
            record.Location = entity.Location;
            await ctx.SaveChangesAsync();
            return record;
        }
    }
}
