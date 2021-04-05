using Gradebook.Data;
using Gradebook.Models;
using Gradebook.Models.Student;
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
                            Name = e.Name // ternary
                        }).ToList();

                return query;
            }
        }

        public StudentDetail GetStudentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Students
                    .Single(e => e.StudentId == id && e.OwnerId == _userId);
                return
                    new StudentDetail
                    {
                        StudentId = entity.StudentId,
                        Name = entity.Name,
                        Nickname = entity.Nickname
                    };
            }
        }

        public bool UpdateStudent(StudentEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Students
                    .Single(e => e.StudentId == model.StudentId && e.OwnerId == _userId);

                entity.StudentId = model.StudentId;
                entity.Name = model.Name;
                entity.Nickname = model.Nickname;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteStudent(int studentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Students
                    .Single(e => e.StudentId == studentId && e.OwnerId == _userId);

                ctx.Students.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
