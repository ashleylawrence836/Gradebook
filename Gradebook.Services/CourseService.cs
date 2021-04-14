using Gradebook.Data;
using Gradebook.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Services
{
    public class CourseService
    {
        private readonly Guid _userId;

        public CourseService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCourse(CourseCreate course)
        {
            var entity =
                new Course()
                {
                    OwnerId = _userId,
                    Name = course.Name,
                    StartDate = course.StartDate,
                    EndDate = course.EndDate
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Courses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CourseListItem> GetCourses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Courses
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new CourseListItem
                        {
                            CourseId = e.CourseId,
                            Name = e.Name,
                            StartDate = e.StartDate,
                            EndDate = e.EndDate
                        });

                return query.ToArray();
            }
        }

        public IEnumerable<Course> GetCourseList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Courses.ToList();
            }
        }

        public CourseDetail GetCourseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Courses
                    .Single(e => e.CourseId == id && e.OwnerId == _userId);
                return
                    new CourseDetail
                    {
                        CourseId = entity.CourseId,
                        Name = entity.Name,
                        StartDate = entity.StartDate,
                        EndDate = entity.EndDate
                    };
            }
        }

        public bool UpdateCourse(CourseEdit course)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Courses
                    .Single(e => e.CourseId == course.CourseId && e.OwnerId == _userId);

                entity.Name = course.Name;
                entity.StartDate = course.StartDate;
                entity.EndDate = course.EndDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCourse(int courseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Courses
                    .Single(e => e.CourseId == courseId && e.OwnerId == _userId);

                ctx.Courses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
