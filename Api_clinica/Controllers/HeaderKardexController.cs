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
    public class HeaderKardexController : ControllerBase
    {
        private readonly IConfiguration _condiguration;

        public HeaderKardexController(IConfiguration configuration)
        {
            _condiguration = configuration;
        }

        [HttpPost]
        public JsonResult Post(Header_Kardex inc)
        {
            string query = @"
                              EXEC POST_API_Header_kardex 
                              @type_move = '" + inc.type_move + @"',
                              @n_trazability = '" + inc.n_trazability + @"',
                              @origin_product = '" + inc.origin_product + @"',
                              @reference = '" + inc.reference + @"',
                              @date_tranzaction = '" + inc.date_tranzaction + @"',
                              @user_register = '" + inc.user_register + @"',
                              @id_enterprise = '" + inc.id_enterprise + @"'
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


        [HttpGet("{enterprise}")]
        public JsonResult Get(int enterprise)
        {
            string query = @"exec Correlative_Kardex_Header @id_enterprise = '" + enterprise + @"' ";
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
