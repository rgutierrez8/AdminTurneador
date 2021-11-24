using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminTurneador.Model
{
    public class Turn
    {
        public int Id { get; set; }
        public String SelectedDate { get; set; }
        public String Process { get; set; }
        public bool State { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
