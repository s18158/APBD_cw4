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
                    st.IdStudent = r.Next(1,20000);
                    lista.Add(st);
                }
            }
            return Ok(lista);
        }



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