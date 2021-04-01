using Gradebook.Data;
using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Services
{
    public class StudentService
    {
        private readonly Guid _userId;

        public StudentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateStudent(StudentCreate student)
        {
            var entity =
                new Student()
                {
                    Name = student.Name,
                    Nickname = student.Nickname,
                    OwnerId = _userId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Students.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<StudentListItem> GetStudents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Students
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new StudentListItem
                        {
                            StudentId = e.StudentId,
                            Name = e.Name,
                        }).ToList();

                return query;
            }
        }
    }
}
