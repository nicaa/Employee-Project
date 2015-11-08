using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeProject.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        EmployeeContext context = new EmployeeContext();
       
        public IEnumerable<Department> All
        {
            get { return context.Departments; }

        }

        public Department Find(int id)
        {
            return context.Departments.Find(id);        
        }

        public void InsertOrUpdate(Department department)
        {
            if (department.DepartmentID == default(int))
            {
                // New entity
                context.Departments.Add(department);
            }
            else
            {
                // Existing entity
                context.Entry(department).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            context.Departments.Remove(Find(id));
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

    public interface IDepartmentRepository
    {
        IEnumerable<Department> All { get; }
        Department Find(int id);
        void InsertOrUpdate(Department department);
        void Delete(int id);
        void Save();
    }
}