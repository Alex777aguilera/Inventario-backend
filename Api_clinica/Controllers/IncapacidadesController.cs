using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Api_clinica.Models;

namespace Api_clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncapacidadesController : ControllerBase
    {

        private readonly IConfiguration _condiguration;

        public IncapacidadesController(IConfiguration configuration)
        {
            _condiguration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"exec Get_API_Incapacidades";
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

            return new JsonResult(table);

        }

        [HttpPost]
        public JsonResult Post(Incapacidades inc )
        {
            string query = @"
                          insert into [dbo].[Patient_incapacity]
                          (cod_area, cod_employed, names, days, condition, diagnostic, user_register) 
                          values
                          (
                               '"+ inc.cod_area +@"',
                               '"+ inc.cod_employed +@"',
                               '"+ inc.names + @"',
                               '"+ inc.days +@"',
                               '"+ inc.condition +@"',
                               '"+ inc.diagnostic +@"',
                               '"+ inc.user_register +@"'
                           )";

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
