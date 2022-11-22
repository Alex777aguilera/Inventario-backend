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
    public class Tipo_ProductoController : ControllerBase
    {
        private readonly IConfiguration _condiguration;

        public Tipo_ProductoController(IConfiguration configuration)
        {
            _condiguration = configuration;
        }



        // GET: api/<Tipo_ProductoController>
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                          exec Get_API_Type_product";
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

       
        // POST api/<Tipo_ProductoController>
        [HttpPost]
        public JsonResult Post(Tipo_Producto inc)
        {
            string query = @"
                              exec POST_API_Type_product
                              @description_typeP = '" + inc.description_typeP + @"', 
                              @unid_med = '" + inc.unid_med + @"'
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

        // PUT api/<Tipo_ProductoController>/5
       // [HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        
    }
}
