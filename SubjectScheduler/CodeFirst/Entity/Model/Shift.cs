using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SubjectScheduler.CodeFirst.Entity.Model
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public DayOfWeek Day { get; set; } // Haftanın hangi günü (Pazartesi, Salı, vb.)
        public TimeSpan StartTime { get; set; } // Başlangıç saati
        public TimeSpan EndTime { get; set; } // Bitiş saati

        // Ders ve grup ile ilişkisi
        public int GroupId { get; set; }
        public Groups Group { get; set; }
    }

}
