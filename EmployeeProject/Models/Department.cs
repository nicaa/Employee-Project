using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models
{
    [Table("Department")]
    public class Department
    {
        public int DepartmentID { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }


    }
}