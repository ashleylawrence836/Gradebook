using Gradebook.Data;
using Gradebook.Models;
using Gradebook.Models.Grade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Services
{
    public class GradeService
    {
        private readonly Guid _userId;

        public GradeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGrade(GradeCreate model)
        {
            var entity =
                new Grade()
                {
                    OwnerId = _userId,
                    Score = model.Score,
                    AssignmentId = model.AssignmentId,
                    StudentId = model.StudentId,
                    CourseId = model.CourseId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Grades.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GradeListItem> GetGrades()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Grades
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new GradeListItem
                        {
                            GradeId = e.GradeId,
                            Score = Math.Round(e.Score),
                            AssignmentId = e.AssignmentId,
                            StudentId = e.StudentId,
                            CourseId = e.CourseId
                        });

                return query.ToArray();

            }
        }

        public GradeDetail GetGradeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Grades
                    .Single(e => e.GradeId == id && e.OwnerId == _userId);
                return
                    new GradeDetail
                    {
                        GradeId = entity.GradeId,
                        Score = entity.Score,
                        AssignmentId = entity.AssignmentId,
                        StudentId = entity.StudentId,
                        CourseId = entity.CourseId
                    };
            }
        }

        public bool UpdateGrade(GradeEdit grade)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Grades
                    .Single(e => e.GradeId == grade.GradeId && e.OwnerId == _userId);

                entity.Score = grade.Score;
                entity.AssignmentId = grade.AssignmentId;
                entity.StudentId = grade.StudentId;
                entity.CourseId = grade.CourseId;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGrade(int gradeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Grades
                    .Single(e => e.GradeId == gradeId && e.OwnerId == _userId);

                ctx.Grades.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
