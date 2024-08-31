using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectScheduler.CodeFirst.Entity.Model
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; } // Ders adı

        // Öğretmen ile ilişkisi
        public List<Teacher> Teachers { get; set; }
    }
}
