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
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _condiguration;

        public LoginController(IConfiguration configuration)
        {
            _condiguration = configuration;
        }


        [HttpPost]
        public JsonResult Post(Login inc)
        {
            string query = @"
                              EXEC SG_Login_Web 
                              @Usuario = '" + inc.Usuario + @"',
                              @Contrasena = '" + inc.Contrasena + @"',
                              @CodSistema = '" + inc.CodSistema + @"'
                           ";

            DataTable table = new DataTable();

            string sqlDataSource = _condiguration.GetConnectionString("Seguridad_CadenaConexion");
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


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"exec Random_number ";
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
