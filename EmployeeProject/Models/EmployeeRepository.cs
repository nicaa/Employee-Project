using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeContext context = new EmployeeContext();
        public IEnumerable<Employee> All
        {
            get { return context.employees; }
        }

        public Employee Find(int id)
        {
            return context.employees.Find(id);
        }

        public void InsertOrUpdate(Employee employee)
        {
            if (employee.EmployeeID == default(int))
            {
                // New entity
                context.employees.Add(employee);
            }
            else
            {
                // Existing entity
                context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            context.employees.Remove(Find(id));
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

    public interface IEmployeeRepository
    {
        IEnumerable<Employee> All { get; }
        Employee Find(int id);
        void InsertOrUpdate(Employee employee);
        void Delete(int id);
        void Save();
    }
        
     
}