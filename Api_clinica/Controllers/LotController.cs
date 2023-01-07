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
    public class LotController : ControllerBase
    {
        private readonly IConfiguration _condiguration;

        public LotController(IConfiguration configuration)
        {
            _condiguration = configuration;
        }


        // GET: api/<LotController>
        [HttpGet("{enterprise}")]
        public JsonResult Get(int enterprise)
        {
            string query = @"exec Get_API_Lot @id_enterprise = '" + enterprise + @"'";
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

        

        [HttpPost("{enterprise}")]
        public JsonResult Post(Lot inc, int enterprise)
        {
            string query = @"
                              EXEC Post_API_Lot 
                              @cod_lot = '" + inc.cod_lot + @"',
                              @date_exp = '" + inc.date_exp + @"',
                              @cod_enterprise = '" + enterprise + @"',
                              @user_register = '" + inc.user_register + @"'
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
