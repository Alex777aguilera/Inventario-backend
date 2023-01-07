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
    public class DetailKardexController : ControllerBase
    {
        private readonly IConfiguration _condiguration;

        public DetailKardexController(IConfiguration configuration)
        {
            _condiguration = configuration;
        }

        [HttpPost("{enterprise}")]
        public JsonResult Post(Detail_Kardex inc, int enterprise)
        {
            string query = @"
                              EXEC POST_API_Detail_Kardex 
                              @header_id = '" + inc.header_id + @"',
                              @cod_store = '" + inc.cod_store + @"',
                              @id_detail_lot = '" + inc.id_detail_lot + @"',
                              @quantity = '" + inc.quantity + @"',
                              @cod_employed = '" + inc.cod_employed + @"',
                              @user_register = '" + inc.user_register + @"',
                              @id_enterprise = '" + enterprise + @"'
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
