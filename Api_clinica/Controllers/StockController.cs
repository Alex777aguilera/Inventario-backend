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
    public class StockController : ControllerBase
    {

        private readonly IConfiguration _condiguration;

        public StockController(IConfiguration configuration)
        {
            _condiguration = configuration;
        }


        // GET: api/<StockController>
        [HttpGet("{enterprise}")]
        public JsonResult Get(int enterprise)
        {
            string query = @"
                            EXEC Get_API_Stock @id_enterprise = '" + enterprise + @"'
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
        
        
        // SEMAFORIZACION 


        // PUT: api/<StockController>
        [HttpPut("{enterprise}")]
        public JsonResult Put(int enterprise)
        {
            string query = @"
                            EXEC SEMAFORIZACION @id_enterprise = '" + enterprise + @"'
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

        ///////// APIS SEMAFORIZACION MESES DE VENCIMIENTO

        // Delete: api/<StockController> METHOD DELETE, PARA DATOS MENORES A 3 MESES, DE LA FECHA ACTUAL
        [HttpDelete("{enterprise}")]
        public JsonResult Delete(int enterprise)
        {
            string query = @"
                            EXEC SEMAFORIZACION_3MESES_ROJO @id_enterprise = '" + enterprise + @"'
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

        // POST: api/<StockController> METHOD POST, PARA DATOS MAYORES A 3 MESES Y MENORES A 6 MESES DE LA FECHA ACTUAL
        [HttpPost("{enterprise}")]
        public JsonResult Post(int enterprise)
        {
            string query = @"
                            EXEC SEMAFORIZACION_3MESES_6MESES_AMARILLO @id_enterprise = '" + enterprise + @"'
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

        // PATCH: api/<StockController> METHOD PATCH, PARA DATOS MAYORES A 6 MESES, DE LA FECHA ACTUAL
        [HttpPatch("{enterprise}")]
        public JsonResult Patch(int enterprise)
        {
            string query = @"
                            EXEC SEMAFORIZACION_6MESES_VERDE @id_enterprise = '" + enterprise + @"'
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
    }
}
