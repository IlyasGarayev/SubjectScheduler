using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubjectScheduler.CodeFirst.Entity.Model;

namespace SubjectScheduler.CodeFirst.Entity
{
    public class Groups
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int StudentCount { get; set; }
        public List<Shift> Shifts { get; set; }
    }
}
