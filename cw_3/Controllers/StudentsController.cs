using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw_3.Models;
using cw_3.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace cw_3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {

        //4.4 - tylko w taki sposób udało mi się obejść problem
        //postman - GET : localhost:55015/api/students/s1111%27%20DROP%20TABLE%20Student--
        [HttpGet("{indexNumber}")]
        public IActionResult GetStudents(string indexNumber)
        {
            //string tmp;
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18158;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "SELECT S.IndexNumber, EN.Semester, STD.Name FROM STUDENT S " +
                                  "JOIN ENROLLMENT EN ON EN.IdEnrollment = S.IdEnrollment " +
                                  "JOIN STUDIES STD ON EN.IdStudy = STD.IdStudy " +
                                  "WHERE IndexNumber = '" + indexNumber + "'";

                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    string indexNumb = dr["IndexNumber"].ToString();
                    string semester = dr["Semester"].ToString();
                    string name = dr["Name"].ToString();
                    string anws = $"Numer Indeksu: {indexNumb}\tSemestr: {semester}\tNazwa kierunku: {name}";
                    return Ok(anws);
                }
            }
            return NotFound("Spróbuj innego numeru indeksu");
        }

        //4.3
        /*
        [HttpGet("{indexNumber}")]
        public IActionResult GetStudents(string indexNumber)
        {

            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18158;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "SELECT S.IndexNumber, EN.Semester, STD.Name FROM STUDENT S " +
                                  "JOIN ENROLLMENT EN ON EN.IdEnrollment = S.IdEnrollment " +
                                  "JOIN STUDIES STD ON EN.IdStudy = STD.IdStudy " +
                                  "WHERE IndexNumber = @index";

                com.Parameters.AddWithValue("index", indexNumber);
                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    string indexNumb = dr["IndexNumber"].ToString();
                    string semester = dr["Semester"].ToString();
                    string name = dr["Name"].ToString();
                    string anws = $"Numer Indeksu: {indexNumb}\tSemestr: {semester}\tNazwa kierunku: {name}";
                    return Ok(anws);
                }
            }
            return NotFound("Spróbuj innego numeru indeksu");
        }
        */

        //4.2
        /*
        [HttpGet]
        public IActionResult GetStudents()
        {
            var lista = new List<Student>();
            Random r = new Random();

            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18158;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "SELECT * FROM STUDENT";

                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.IdStudent = r.Next(1, 20000);
                    lista.Add(st);
                }
            }
            return Ok(lista);
        }
        */


        //previous work in cw_3
        /*
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }
        */


        //previous work in cw_3
        /*
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }
            else if (id == 2)
            {
                return Ok("Malewski");
            }

            return NotFound("Nie znaleziono studenta");
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult TestPut(int id)
        {
            if (id == 1)
            {
                return Ok("Aktualizacja dokończona");
            }

            return NotFound("Aktualizacja nie dokończona");
        }

        [HttpDelete("{id}")]
        public IActionResult TestDelete(int id)
        {
            if (id == 1)
            {
                return Ok("Usuwanie ukończone");
            }

            return NotFound("Usuwanie nie ukończone");
        }
        */
    }
}