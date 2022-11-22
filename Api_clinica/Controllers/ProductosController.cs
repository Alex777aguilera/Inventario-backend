using Api_clinica.Models;
using Microsoft.AspNetCore.Http;
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
    public class ProductosController : ControllerBase
    {
        private readonly IConfiguration _condiguration;

        public ProductosController(IConfiguration configuration)
        {
            _condiguration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"exec Get_API_Products";
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
            }else
            {
                return new JsonResult("Not Data");
            }

        }

        //api producto
        [HttpPatch]
        public JsonResult Get(Productos inc)
        {
            string query = @"
                              exec Get_API_ProductsID
                              @cod_prod = '"+inc.cod_prod+@"'
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
            return new JsonResult(table);
        }


        [HttpPost]
        public JsonResult Post(Productos inc)
        {
            string query = @"
                              EXEC Post_API_Products 
                              @cod_prod = '" + inc.cod_prod + @"',
                              @id_type_p = '" + inc.id_type_p + @"',
                              @name_product = '" + inc.name_product + @"', 
                              @full_name = '" + inc.full_name + @"', 
                              @unit_price = '" + inc.unit_price + @"', 
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
