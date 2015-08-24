using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace School_Management_System.Controllers
{
    public class StudentsController : ApiController
    {
        studentDBEntities objapi;

        public StudentsController()
        {
            objapi = new studentDBEntities();
        }

        [HttpGet]
        public IEnumerable<spConStudents_Result> Get(string StudentName, string StudentEmail)
        {
            StudentName = (StudentName == null) ? "" : StudentName;
            StudentEmail = (StudentEmail == null) ? "" : StudentEmail;
            return objapi.spConStudents(StudentName, StudentEmail).AsEnumerable();
        }

        [HttpGet]
        public IEnumerable<string> insertStudent(string StudentName, string StudentEmail, string Phone, string Address)
        {
            return objapi.spInsStudents(StudentName, StudentEmail, Phone, Address).AsEnumerable();
        }

        [HttpGet]
        public IEnumerable<string> updateStudent(int stdID, string StudentName, string StudentEmail, string Phone, string Address)
        {
            return objapi.spUPDStudents(stdID, StudentName, StudentEmail, Phone, Address).AsEnumerable();
        }

        [HttpGet]
        public string deleteStudent(int stdID)
        {
            objapi.spDelStudents(stdID);
            return "deleted";
        }
    }
}
