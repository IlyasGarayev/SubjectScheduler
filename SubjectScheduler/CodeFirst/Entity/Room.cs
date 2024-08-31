using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectScheduler.CodeFirst.Entity
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Purpose { get; set; }
    }
}
