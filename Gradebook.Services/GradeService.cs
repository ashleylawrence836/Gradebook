using Gradebook.Data;
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
                    Score = model.Score
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
                            Score = Math.Round(e.Score)
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
                        Score = entity.Score
                    };
            }
        }

    }
}
