using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw_3.Models;

namespace cw_3.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
    }
}
