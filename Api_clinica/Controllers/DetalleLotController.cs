using Api_clinica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace Api_clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleLotController : ControllerBase
    {
        private readonly IConfiguration _condiguration;

        public DetalleLotController(IConfiguration configuration)
        {
            _condiguration = configuration;
        }

        

        // GET api/<DetalleLotController>
        [HttpGet("{enterprise}")]
        public JsonResult Get(int enterprise)
        {
            string query = @"EXEC Get_API_Detail_lot @id_enterprise = '"+ enterprise +@"' ";
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

        // POST api/<DetalleLotController>
        [HttpPost]
        public JsonResult Post(DetalleLote inc)
        {
            string query = @"
                             EXEC POST_API_Detail_lot 
                             @cod_lot = '" + inc.cod_lot + @"',
                             @cod_prod = '" + inc.cod_prod + @"'
                            ";
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
            return new JsonResult("Added Successfully!!");

        }

    }
}
