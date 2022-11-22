﻿using Microsoft.AspNetCore.Http;
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
