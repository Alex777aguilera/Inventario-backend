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
    public class PermisosController : ControllerBase
    {
        private readonly IConfiguration _condiguration;

        public PermisosController(IConfiguration configuration)
        {
            _condiguration = configuration;
        }

        [HttpGet("{IdUsuario}/{CodSistema}")]
        public JsonResult Get(int IdUsuario, string CodSistema)
        {
            string query = @"exec ListarPermisosUsaurios_Web @IdUsuario = '" + IdUsuario + @"',
                                                             @CodSistema = '" + CodSistema + @"'       ";
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
        public JsonResult Post(SgMenu inc)
        {

            string query = @"
                                EXEC SG_Menus_Generar 
                                @NombreMenu = '" + inc.NombreMenu + @"',
                                @NombreLogico = '" + inc.NombreLogico + @"',   
                                @Nivel = '" + inc.Nivel + @"', 
                                @NombreMenuPadre = '" + inc.IdMenuPadre + @"', 
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
            return new JsonResult("Added Successfully!!");

        }


    }
}
