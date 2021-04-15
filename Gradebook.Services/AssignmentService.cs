using Gradebook.Data;
using Gradebook.Models.Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Services
{
    public class AssignmentService
    {
        private readonly Guid _userId;

        public AssignmentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAssignment(AssignmentCreate model)
        {
            var entity =
                new Assignment()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    DueDate = model.DueDate,
                    CourseId = model.CourseId,
                    StudentId = model.StudentId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Assignments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AssignmentListItem> GetAssignments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Assignments
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new AssignmentListItem
                        {
                            AssignmentId = e.AssignmentId,
                            Name = e.Name,
                            DueDate = e.DueDate,
                            Course = e.Course.Name
                        });

                return query.ToArray();
            }
        }

        public IEnumerable<Assignment> GetAssignmentList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Assignments.ToList();
            }
        }

        public AssignmentDetail GetAssignmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Assignments
                    .Single(e => e.AssignmentId == id && e.OwnerId == _userId);
                    return
                        new AssignmentDetail
                        {
                            AssignmentId = entity.AssignmentId,
                            Name = entity.Name,
                            DueDate = entity.DueDate,
                            Course = entity.Course.Name,
                            Student = entity.Student.FullName
                        };

            }
        }

        public bool UpdateAssignment(AssignmentEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Assignments
                    .Single(e => e.AssignmentId == model.AssignmentId && e.OwnerId == _userId);


                entity.Name = model.Name;
                entity.DueDate = model.DueDate;
                entity.CourseId = model.CourseId;
                //entity.StudentId = model.StudentId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAssignment(int assignmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Assignments
                    .Single(e => e.AssignmentId == assignmentId && e.OwnerId == _userId);

                ctx.Assignments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
