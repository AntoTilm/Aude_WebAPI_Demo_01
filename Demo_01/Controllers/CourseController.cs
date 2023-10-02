using Demo_01.DAL.Entities;
using Demo_01.DAL.Repositories;
using Demo_01.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private CourseRepository _courseRepository;

        public CourseController(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Course>))]
        // Doc Swagger pour savoir la réponse 200 elle renvoie quel type d'objet
        public IActionResult GetAll()
        {
            IEnumerable<Course> result = _courseRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{courseId:int}")]
        [ProducesResponseType(200, Type = typeof(Course))]
        [ProducesResponseType(404)]
        public IActionResult GetById(int courseId)
        {
            Course? course = _courseRepository.GetById(courseId);
            if(course is null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        [ProducesResponseType(201, Type =  typeof(Course))]
        public IActionResult Create(CourseDTO course)
        {
            Course courseToAdd = new Course
            {
                Name = course.Name,
                Description = course.Description,
            };
            courseToAdd = _courseRepository.Create(courseToAdd);
            return CreatedAtAction(nameof(GetById), new { courseId = courseToAdd.Id }, courseToAdd);
        }

        [HttpDelete("{courseId:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int courseId)
        {
            if (_courseRepository.Delete(courseId))
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{courseId:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Update(int courseId, CourseDTO course)
        {
            Course courseToUpdate = new Course
            {
                Name = course.Name,
                Description = course.Description
            };
            if (_courseRepository.Update(courseId, courseToUpdate))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
