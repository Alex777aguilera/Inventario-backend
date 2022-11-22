using Api_clinica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tipo_MovimientoController : ControllerBase
    {
        private readonly IConfiguration _condiguration;

        public Tipo_MovimientoController(IConfiguration configuration)
        {
            _condiguration = configuration;
        }

        // GET: api/<Tipo_MovimientoController>
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                          exec Get_API_Type_move";
            DataTable table = new DataTable();
            string sqlDataSource = _condiguration.GetConnectionString("connect");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            if (table.Rows.Count > 0)
            {
                return new JsonResult(table);
            }
            else
            {
                return new JsonResult("Not Data");
            }
        }

        // GET api/<Tipo_ProductoController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(id);
        }

        // POST api/<Tipo_MovimientoController>
        //[HttpPost]
        //  public void Post([FromBody] string value)
        // {
        // }

        // PUT api/<Tipo_MovimientoController>/5
        //  [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }


    }
}
