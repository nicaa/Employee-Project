using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models
{
    [Table("Employee")]
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Required]
        public string fName { get; set; }
        [Required]
        public string lName { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public int salary { get; set; }
        [Required]
        public int departmentID { get; set; }


    }
}