﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Api_clinica.Models;
using Microsoft.Extensions.Configuration;

namespace Api_clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenController : ControllerBase
    {
        private readonly IConfiguration _condiguration;

        public AlmacenController(IConfiguration configuration)
        {
            _condiguration = configuration;
        }


        // GET: api/<AlmacenController>
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            EXEC Get_API_Store  
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
            if (table.Rows.Count > 0)
            {
                return new JsonResult(table);
            }
            else
            {
                return new JsonResult("Not Data");
            }
        }

        

        // POST api/<AlmacenController>
        [HttpPost]
        public JsonResult Post(Almacen inc)
        {
            string query = @"
                             EXEC POST_API_Store 
                             @deatil_store = '" + inc.deatil_store + @"', 
                             @cod_enterprise = '" + inc.cod_enterprise + @"'
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

        // PUT api/<AlmacenController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        
    }
}
