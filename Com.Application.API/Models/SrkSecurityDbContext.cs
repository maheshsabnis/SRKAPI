using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Com.Application.API.Models
{
    /// <summary>
    /// THis class will Map to Database for 
    /// Creating AspNetCore Identity Tables 
    /// </summary>
    public class SrkSecurityDbContext : IdentityDbContext
    {
        /// <summary>
        /// REad the Connection String an will make sure that
        /// All The Mapping (Entity Class-To-Database Table) with be executed
        /// </summary>
        /// <param name="options"></param>
        public SrkSecurityDbContext(DbContextOptions<SrkSecurityDbContext> options):base(options)
        {
            
        }

        /// <summary>
        /// Execute Scripts to Generate Tables
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
