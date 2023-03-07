using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Com.Application.Entities
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        [Required(ErrorMessage = "DeptNo is required")]
        public int DeptNo { get; set; }
        [Required(ErrorMessage = "DeptName is required")]
        public string DeptName { get; set; } = null!;
        [Required(ErrorMessage = "Capacity is required")]
        [NumericNotNegative(ErrorMessage = "Capacity cannot be -ve")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
