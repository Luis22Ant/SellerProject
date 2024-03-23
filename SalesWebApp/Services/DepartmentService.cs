using SalesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebApp.Services
{
    public class DepartmentService
    {
        private readonly SalesWebAppContext _context;

        public DepartmentService(SalesWebAppContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(p => p.Name).ToList();
        }
    }
}
