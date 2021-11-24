using AdminTurneador.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminTurneador.Controllers
{
    [Route("index")]
    public class IndexController : Controller
    {
        [HttpPost("login")]
        public  IActionResult Index([FromBody] UserDTO user)
        {
            try
            {
                MySqlConnectionStringBuilder Builder = new MySqlConnectionStringBuilder();
                Builder.Port = 3306;
                Builder.Server = "sql10.freemysqlhosting.net";
                Builder.Database = "sql10453129";
                Builder.UserID = "sql10453129";
                Builder.Password = "hiqpBFcRrn";
                Builder.AllowUserVariables = true;
                MySqlConnection con2 = new MySqlConnection(Builder.ToString());
                MySqlCommand command = new MySqlCommand();
                command.Connection = con2;
                con2.Open();
                command.CommandText = "SELECT * FROM Admin WHERE User = '" + user.User + "'";
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var pass = reader["Password"].ToString();
                    if(pass == user.Password)
                    {
                        this.Response.Cookies.Append("Id", reader["Id"].ToString());
                        con2.Close();
                        return StatusCode(200);
                    }
                }
                con2.Close();
                return StatusCode(500);
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
