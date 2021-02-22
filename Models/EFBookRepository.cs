using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookDbContext _context;

        public EFBookRepository (BookDbContext context)
        {
            _context = context;
        }
        public IQueryable<Project> Projects => _context.Projects; //using lambda to make Projects variable more dynamic
    }
}
