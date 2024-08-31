using SubjectScheduler.CodeFirst.Context;
using SubjectScheduler.CodeFirst.Entity.Model;
using SubjectScheduler.CodeFirst.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SubjectScheduler.Scheduler
{
    public class Scheduler
    {
        private UniversityContext _context;

        public Scheduler(UniversityContext context)
        {
            _context = context;
        }

        public void GenerateSchedule()
        {
            var groups = _context.Groups.Include(g => g.Shifts).ToList();
            var teachers = _context.Teachers.Include(t => t.Availabilities).Include(t => t.Subjects).ToList();
            var rooms = _context.Rooms.ToList();
            var subjects = _context.Subjects.Include(s => s.Teachers).ToList();

            foreach (var group in groups)
            {
                foreach (var subject in subjects)
                {
                    // Gruplar için bir ders atamaya çalış
                    var availableTeacher = FindAvailableTeacher(teachers, subject, group.Shifts);

                    if (availableTeacher != null)
                    {
                        foreach (var shift in group.Shifts)
                        {
                            var availableRoom = FindAvailableRoom(rooms, group.StudentCount, shift);

                            if (availableRoom != null)
                            {
                                // Çakışmaları kontrol et
                                if (!IsConflict(availableTeacher, shift))
                                {
                                    // Ders ataması yap
                                    AssignClass(group, subject, availableTeacher, availableRoom, shift);
                                }
                            }
                        }
                    }
                }
            }

            _context.SaveChanges();
        }

        private Teacher FindAvailableTeacher(List<Teacher> teachers, Subject subject, List<Shift> shifts)
        {
            return teachers.FirstOrDefault(t => t.Subjects.Contains(subject) && t.Availabilities.Any(a => shifts.Any(s => a.Day == s.Day && a.StartTime <= s.StartTime && a.EndTime >= s.EndTime)));
        }

        private Room FindAvailableRoom(List<Room> rooms, int studentCount, Shift shift)
        {
            return rooms.FirstOrDefault(r => r.Capacity >= studentCount);
        }

        private bool IsConflict(Teacher teacher, Shift shift)
        {
            // Öğretmenin mevcut dersleriyle çakışma kontrolü
            return _context.Shifts.Any(s => s.GroupId != shift.GroupId && s.Day == shift.Day && s.StartTime == shift.StartTime && s.Group.Shifts.Any(gs => gs.GroupId == teacher.TeacherId));
        }

        private void AssignClass(Groups group, Subject subject, Teacher teacher, Room room, Shift shift)
        {
            // Ders atama işlemi
            Console.WriteLine($"Group {group.Name} will have {subject.Name} with {teacher.Name} in {room.Name} at {shift.StartTime} on {shift.Day}");

            // Veritabanına ekleyin
            shift.Group = group;
            _context.Shifts.Add(shift);
        }
    }

}
