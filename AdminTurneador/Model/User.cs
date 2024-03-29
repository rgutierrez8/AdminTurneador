﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminTurneador.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public long Dni { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public List<Turn> Turns { get; set; }
    }
}
