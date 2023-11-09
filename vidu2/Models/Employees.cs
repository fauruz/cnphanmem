using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vidu2
{
    internal class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public int DepartmentId {  get; set; }
        public Employees()
        {
            Id = 0;
            Name = string.Empty;
            Gender = -1;
            DepartmentId = 0;
        }
    }
}
