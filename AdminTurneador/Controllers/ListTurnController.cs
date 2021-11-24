using AdminTurneador.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminTurneador.Controllers
{
    [Route("listTurn")]
    public class ListTurnController : Controller
    {
        public IActionResult Index()
        {
            List<TurnDTO> turns = new List<TurnDTO>();
            if(Request.Cookies.Count != 0)
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
                command.CommandText = "SELECT * FROM Turn WHERE State = 0";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    MySqlConnection con3 = new MySqlConnection(Builder.ToString());
                    var command2 = new MySqlCommand();
                    command2.Connection = con3;
                    con3.Open();
                    command2.CommandText = "SELECT * FROM User WHERE Id = " + Convert.ToInt32(reader["UserId"].ToString());
                    var reader2 = command2.ExecuteReader();
                    var user = new User();
                    if (reader2.Read())
                    {
                        user.Name = reader2["Name"].ToString();
                        user.LastName = reader2["LastName"].ToString();
                    }
                    var turn = new TurnDTO
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        SelectedDate = reader["SelectedDate"].ToString(),
                        Process = reader["Process"].ToString(),
                        State = Convert.ToInt32(reader["State"].ToString()),
                        UserId = Convert.ToInt32(reader["UserId"].ToString()),
                        User = new User
                        {
                            Id = user.Id,
                            Name = user.Name,
                            LastName = user.LastName
                        }
                    };
                    con3.Close();

                    turns.Add(turn);
                }
                con2.Close();
                
            }
            return Ok(turns);
        }

        [HttpPost("result")]
        public IActionResult Accept([FromBody] TurnDTO turn)
        {
            try
            {
                if(Convert.ToInt32(turn.State) == 1)
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

                    command.CommandText = "UPDATE Turn SET State = 1 WHERE Id = " + turn.Id;
                    command.ExecuteNonQuery();
                    con2.Close();
                }
                if (Convert.ToInt32(turn.State) == 2)
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

                    command.CommandText = "UPDATE Turn SET State = 2 WHERE Id = " + turn.Id;
                    command.ExecuteNonQuery();
                    con2.Close();
                }
                return Ok();
            }
            catch(Exception e)
            {
                return Ok();
            }
        }
    }
}
