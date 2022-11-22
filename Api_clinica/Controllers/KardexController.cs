using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Api_clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KardexController : ControllerBase
    {
        private readonly IConfiguration _condiguration;

        public KardexController(IConfiguration configuration)
        {
            _condiguration = configuration;
        }

        // GET: api/<KardexController>
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                          exec Get_API_kardex";
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


        // POST api/<KardexController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<KardexController>/5
       // [HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<KardexController>/5
       // [HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
