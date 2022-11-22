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
    public class LotController : ControllerBase
    {
        private readonly IConfiguration _condiguration;

        public LotController(IConfiguration configuration)
        {
            _condiguration = configuration;
        }


        // GET: api/<LotController>
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"exec Get_API_Lot";
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

        

        [HttpPost]
        public JsonResult Post(Lot inc)
        {
            string query = @"
                              EXEC Post_API_Lot 
                              @cod_lot = '" + inc.cod_lot + @"'
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
