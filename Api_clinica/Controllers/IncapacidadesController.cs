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

        [HttpGet("{enterprise}")]
        public JsonResult Get(int enterprise)
        {
            string query = @"exec Get_API_Incapacidades @id_enterprise = '" + enterprise + @"' ";
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
        public JsonResult Post(Incapacidades inc )
        {

            string query = @"
                                EXEC POST_API_Patient_incapacity 
                                @cod_employed = '" + inc.cod_employed + @"',
                                @days = '" + inc.days + @"',   
                                @condition = '" + inc.condition + @"', 
                                @diagnostic = '" + inc.diagnostic + @"', 
                                @user_register = '" + inc.user_register + @"',
                                @status_p = '" + inc.status_p + @"',
                                @time_p = '" + inc.time_p + @"',
                                @days_p = '" + inc.days_p + @"',
                                @date_from = '" + inc.date_from + @"',
                                @date_to = '" + inc.date_to + @"',
                                @n_tranzability = '" + inc.n_tranzability + @"'
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

        [HttpPut("{enterprise}")]
        public JsonResult put(int enterprise)
        {
            string query = @"exec Correlative_incapacity @id_enterprise = '" + enterprise + @"' ";
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

    }
}
