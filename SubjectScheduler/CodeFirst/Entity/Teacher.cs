using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubjectScheduler.CodeFirst.Entity.Model;

namespace SubjectScheduler.CodeFirst.Entity
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Availability> Availabilities { get; set; }
    }
}
