using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminTurneador.Model
{
    public class TurnDTO
    {
        public int Id { get; set; }
        public string SelectedDate { get; set; }
        public string Process { get; set; }
        public int State { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
