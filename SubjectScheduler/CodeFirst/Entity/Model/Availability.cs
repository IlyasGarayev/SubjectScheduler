using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectScheduler.CodeFirst.Entity.Model
{
    public class Availability
    {
        public int AvailabilityId { get; set; }
        public DayOfWeek Day { get; set; } // Uygun olduğu gün
        public TimeSpan StartTime { get; set; } // Uygunluk başlangıcı
        public TimeSpan EndTime { get; set; } // Uygunluk bitişi

        // Öğretmen ile ilişkisi
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
