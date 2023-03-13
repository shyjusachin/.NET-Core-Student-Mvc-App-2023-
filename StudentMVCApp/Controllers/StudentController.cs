using Microsoft.AspNetCore.Mvc;
using StudentMVCApp.Models;
using StudentMVCApp.Models.Student;

namespace StudentMVCApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentsDBContext _studentDBContext;
        public StudentController(StudentsDBContext studentsDBContext)
        {
            _studentDBContext = studentsDBContext;
        }
        public IActionResult Index()
        {
         
            return View();
        }

        //Save API
        [HttpPost]
        [ActionName("Save")]
        public IActionResult SaveStudent(Student student)
        {

            //Logic to Add students into database
            StudentTable studentTable = new StudentTable();
            studentTable.FirstName = student.FirstName;
            studentTable.LastName = student.LastName;
            studentTable.Address = student.Address;

            _studentDBContext.Add(studentTable);
            _studentDBContext.SaveChanges();

            return Json(student);
        }

        //Update Api
        [HttpPost]
        public IActionResult UpdateStudent(Student student)
        {
            //Logic to update
            StudentTable studentTable = new StudentTable();
            studentTable.Id= student.Id;
            studentTable.FirstName = student.FirstName;
            studentTable.LastName = student.LastName;
            studentTable.Address = student.Address;

            _studentDBContext.Update(studentTable);
            _studentDBContext.SaveChanges();
            return Json(student);
        }

        //Delete API
        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            //logic to remove data from database
            var student = _studentDBContext.StudentTables.FirstOrDefault(x=>x.Id==id);
            _studentDBContext.StudentTables.Remove(student);
            _studentDBContext.SaveChanges(true);
            return Json(new { id = id });
        }

        //Get all students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            //Get all students from database
            var students = _studentDBContext.StudentTables.ToList();
            return Json(students);
        }

        //Get all students
        [HttpGet]
        public IActionResult GetStudent(int id)
        {
            //Get all students from database
            var student = _studentDBContext.StudentTables.FirstOrDefault(_x=>_x.Id==id);
            return Json(student);
        }

    }
}
