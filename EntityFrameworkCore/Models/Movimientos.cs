using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.Models
{
    public partial class Movimientos
    {
        public decimal Id { get; set; }
        public decimal IdPersona { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Estado { get; set; }

        public Personas IdPersonaNavigation { get; set; }
    }
}
