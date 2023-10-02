using Demo_01.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_01.DAL.Repositories
{
    public class CourseRepository
    {
        #region FAKE DB
        private static List<Course> _courses = new List<Course>
        {
            new Course
            {
                Id = 1,
                Name = ".Net : Web API",
                Description = "zebi ça fait des API"
            },
            new Course
            {
                Id = 2,
                Name = "Angular",
                Description = "C'est pour faire du front mais c'est un peu dur"
            }
        };
        private int NextId = 3;
        #endregion

        //CRUD
        //READ
        public IEnumerable<Course> GetAll()
        {
            return _courses.AsEnumerable();
        }

        public Course? GetById(int id)
        {
            return _courses.SingleOrDefault(c => c.Id == id);
        }

        //CREATE
        public Course Create(Course course)
        {
            Course courseToAdd = new Course
            {
                Id = NextId++,
                Name = course.Name,
                Description = course.Description,
            };

            _courses.Add(courseToAdd);
            return courseToAdd;
        }

        //UPDATE
        public bool Update(int id, Course course)
        {
            Course? courseToUpdate = _courses.SingleOrDefault(c => c.Id == id);
            if(courseToUpdate is null)
            {
                return false;
            }

            courseToUpdate.Name = course.Name;
            courseToUpdate.Description = course.Description;


            return true;

        }

        //DELETE
        public bool Delete(int id)
        {
            Course? courseToDelete = _courses.SingleOrDefault(c => c.Id == id);
            if( courseToDelete is null)
            {
                return false;
            }

            _courses.Remove(courseToDelete);
            return true;
        }

    }
}
